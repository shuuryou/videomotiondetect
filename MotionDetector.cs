using OpenCvSharp;
using System;
using System.Globalization;
using System.IO;

/*
 * Motion detection ported from my own project <https://github.com/shuuryou/camsrv/>,
 * in which it is shoplifted from <https://github.com/jooray/motion-detection>,
 * who shoplifted it from <https://blog.cedric.ws/opencv-simple-motion-detection>.
 *
 * Thanks to Cédric Verstraeten for the general motion detection algorithm,
 * a mutation of which lives on in this code.
 * 
 * This C# port made was in early 2023. It is just a quick and dirty conversion
 * of the C++ code, so not a piece of poetry. But I did expand it so each frame
 * is cropped to the region of interest, which speeds things up quite a bit if
 * the ROI is small enough. It can also skip empty video frames correctly.
 * 
 * OpenCVSharp has poor memory management, so the processing loop has to hassle
 * the garbage collector (GC.Collect) to keep memory usage down. Sadly this
 * kills performance.
 */
namespace VideoMotionDetect
{
	internal static class MotionDetector
	{
		private static Mat s_MotionMask = null;
		private static Rect s_BoundingRect = Rect.Empty;

		public static Mat MotionMask
		{
			get { return s_MotionMask; }
			set { s_MotionMask = value; }
		}

		public static Rect BoundingRect
		{
			get { return s_BoundingRect; }
			set { s_BoundingRect = value; }
		}

		public delegate void LogMessageEventHandler(string msg);
		public static event LogMessageEventHandler LogMessage;

		public static int video_motion_detection(string file, int threshold,
			int maxDeviation, int sensitivity, int continuation, bool verbose)
		{
			string videoFileForLog = Path.GetFileNameWithoutExtension(file);
			DateTime lastGC = DateTime.MinValue;

			VideoCapture capture = new VideoCapture(file);

			if (!capture.IsOpened())
			{
				Log(Properties.Resources.MotionDetectorFileCouldNotRead, videoFileForLog);
				return -1;
			}

			Log("{0}: Starting motion detection.", videoFileForLog);

			Mat read_frame = null;
			Mat prev_frame, current_frame, next_frame;

			// Keep reading until we get a non-empty frame. In an ideal world,
			// this loop only ever performs one iteration. In reality, it can
			// be 2 or 3 depending on how the camera stream was grabbed. Also
			// see the comment above "while (read_frame.Empty())" ...
			for (; ; )
			{
				if (!capture.Grab())
				{
					Log(Properties.Resources.MotionDetectorNoFramesInVideo, videoFileForLog);

					if (read_frame != null)
						read_frame.Release();

					capture.Release();

					return -1;
				}

				read_frame = capture.RetrieveMat();

				if (read_frame.Empty())
				{
					read_frame.Release();
					continue;
				}

				if (s_BoundingRect != Rect.Empty)
				{
					next_frame = new Mat(read_frame, s_BoundingRect);
					read_frame.Release();
				}
				else
					next_frame = read_frame;

				break;
			}

			Cv2.CvtColor(next_frame, next_frame, ColorConversionCodes.RGB2GRAY);

			if (s_MotionMask != null)
				Cv2.BitwiseAnd(next_frame, next_frame, next_frame, s_MotionMask);

			prev_frame = current_frame = next_frame;

			Mat erode_kernel = Cv2.GetStructuringElement(MorphShapes.Rect, new Size(2, 2));

			int degreeOfActivity = 0;
			int lastMotionPos = 0;
			int sequenceCounter = 0;

			while (capture.Grab())
			{
				prev_frame = current_frame;
				current_frame = next_frame;

				read_frame = capture.RetrieveMat();

				// I have encountered videos from IP cameras that have empty
				// frames. Possibly due to UDP packets getting dropped. In
				// CvtColor below, the error then is:
				// "OpenCvSharp.OpenCVException: !_src.empty()"

				while (read_frame.Empty())
				{
					Log(Properties.Resources.MotionDetectorEmptyFrame, videoFileForLog);

					read_frame.Release();

					if (!capture.Grab())
					{
						Log(Properties.Resources.MotionDetectorNoFramesInVideo, videoFileForLog);
						goto done;
					}
				}

				if (s_BoundingRect != Rect.Empty)
				{
					next_frame = new Mat(read_frame, s_BoundingRect);
					read_frame.Release();
				}
				else
					next_frame = read_frame;

				Cv2.CvtColor(next_frame, next_frame, ColorConversionCodes.RGB2GRAY);

				if (s_MotionMask != null)
				{
					Mat tmp = new Mat();
					next_frame.CopyTo(tmp, s_MotionMask);
					next_frame.Release();
					next_frame = tmp;
				}

				int changedPixels;

				/* --------------------------------------------------------------
				 * Calculate the difference between the images and then do a
				 * bitwise AND, which will reveal motion between frames.
				 * 
				 * What is being done is a variant of "three-frame differencing"
				 * and is described in "A System for Video Surveillance and
				 * Monitoring" (Collins et. al; CMU-RI-TR-00-12). This avoids
				 * ghosting when stationary objects start to move.
				 * 
				 * Then apply a binary threshold to remove noise. Areas with a
				 * low difference between frames are removed by this operation.
				 * 
				 * Next apply erode to reduce areas with less differences and
				 * boost areas with more differences. It is like lowering the
				 * "sharpness"  of an image. The intent is removing even more
				 * noise.
				 * 
				 * If you do not understand threshold and erode, pleace a few
				 * "motion.SaveImage" calls in that area and set breakpoints.
				 * It will become clear. :-)
				 * 
				 * Finally, calculate the standard deviation. Standard
				 * deviation will be a high value when there is a lot of
				 * motion between frames that are not in a small area. Unless
				 * the camera is pointing at a busy public area, it is probably
				 * not real motion, but heavy rain or snow, branches moving
				 * in the wind, sun glare, sudden movement of an automatic
				 * PTZ camera, etc.
				 * --------------------------------------------------------------
				 */

				using (Mat d1 = new Mat())
				using (Mat d2 = new Mat())
				{
					Cv2.Absdiff(prev_frame, next_frame, d1);
					Cv2.Absdiff(next_frame, current_frame, d2);

					using (Mat motion = new Mat())
					{
						Cv2.BitwiseAnd(d1, d2, motion);
						Cv2.Threshold(motion, motion, threshold, 255, ThresholdTypes.Binary);
						Cv2.Erode(motion, motion, erode_kernel);

						using (Mat mean = new Mat())
						using (Mat stddev = new Mat())
						{
							Cv2.MeanStdDev(motion, mean, stddev);

							if (stddev.At<double>(0) > maxDeviation)
							{
								changedPixels = 0;
								goto done;
							}

							changedPixels = motion.CountNonZero();
						}
					}

					if (verbose)
						Log(Properties.Resources.MotionDetectorChangedPixels, videoFileForLog, changedPixels);
				}

				/* --------------------------------------------------------------
				 * If there are not enough changed pixels, do nothing, but if
				 * already counting sequential frames of motion, stop counting.
				 * 
				 * Otherwise increase sequence counter. If it becomes larger
				 * than the set continuation, increase the overall degree of
				 * activity value (score) for this video file.
				 * 
				 * This sequence counting system is less taxing on the CPU than
				 * other, more sophisticated methods. It works because in real
				 * life, motion that the average person cares about will occur
				 * in more than one frame.
				 * --------------------------------------------------------------
				 */

				if (changedPixels < sensitivity)
				{
					if (sequenceCounter != 0)
					{
						if (verbose)
							Log(Properties.Resources.MotionDetectorAbortingSequence, videoFileForLog);

						sequenceCounter = 0;
					}

					goto done;
				}
				sequenceCounter++;

				if (verbose)
					Log(Properties.Resources.MotionDetectorSequenceIncreasing,
						videoFileForLog, sequenceCounter, continuation);

				if (sequenceCounter >= continuation)
				{
					int pos = capture.PosMsec / 1000;

					if (pos > lastMotionPos)
					{
						degreeOfActivity++;
						lastMotionPos = pos;

						if (verbose)
							Log(Properties.Resources.MotionDetectorMotionDetected, videoFileForLog, pos);
					}
				}

			done:

				if (DateTime.Now.Subtract(lastGC).TotalSeconds > 2)
				{
					GC.Collect();

					Log(Properties.Resources.MotionDetectorStatusLog, videoFileForLog,
						capture.PosFrames, capture.FrameCount);

					lastGC = DateTime.Now;
				}
			}

			prev_frame.Release();
			current_frame.Release();
			next_frame.Release();
			capture.Release();

			GC.Collect();

			Log(Properties.Resources.MotionDetectorFinished, videoFileForLog, degreeOfActivity);

			return degreeOfActivity;
		}

		private static void Log(string format, params object[] args)
		{
			LogMessage?.Invoke(string.Format(CultureInfo.InvariantCulture, format, args));
		}
	}
}
