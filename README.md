# Standalone Motion Detection for Surveillance Camera Recordings

This is a small program written in C# that uses OpenCvSharp to detect motion in video files. It has been tested with H.264 and H.265 encoded videos and offers an acceptable level of performance. It should also support other video formats (basically, it is only limited to the formats OpenCvSharp supports). The motion detection algorithm is a slightly improved version of the one used in my [camsrvd](https://github.com/shuuryou/camsrv) project.

If you have one or more surveillance cameras that continuously record video files onto an SD card or onto a network server, this program can help you find just those video files that contain motion in the areas you are interested in. For example, if someone put junk mail into your mailbox, you can highlight your mailbox as a “region of interest” and the program will check all of the video files you point it at for motion around your mailbox.

Many surveillance cameras offer some form of primitive motion detection in their chipset, but it is often not very good and either creates lots of false alerts or too little alerts. Other solutions require you to set up a server dedicated to recording video and detecting motion, which may be too much for small residential or light commercial environments. They may also require you to buy a particular camera brand or a camera that specifically supports Onvif or similar protocols.

My program allows you to use whatever surveillance cameras you want as long as they can save video files in a supported format and to a location you can access the files from. In addition, you can choose only to run the motion detection process when you really need it, which can help you lower power consumption and save energy. 

I am sure there are similar and better programs than mine, but as with my other projects, this was created with a specific personal use case in mind and only afterwards made into something I decided to release publicly.

## How to Use

The graphical user interface makes it very simple to perform motion detection. You need to have one or more videos that show the same scene. Then you can start the Video Motion Detection tool. It will open this window:

![Main window](https://user-images.githubusercontent.com/36278767/220477893-22445495-2454-461c-80f0-2571311d9aa1.png)

### Set Region of Interest
First, please click **Create from video file** to set the region of interest. It will open a file browser dialog and you can select a video file. The first frame of video will be displayed in a new window like below:

![Set region of interest window](https://user-images.githubusercontent.com/36278767/220477929-c0911f18-d63b-430a-82fe-ed8fd8c81a8c.png)

You can use the mouse to highlight the region of the video that you want the motion detection algorithm to focus on. It works similar to Microsoft Paint.

Use the **New** button to clear any highlights you made.

Use the **Open** button to load a highlighted area you made previously.

Use the **Save** button to save the currently highlighted area to file on disk.

The **Mark** button turns on highlight mode. Click and hold the left mouse button to highlight an area of the video. Let go of the left mouse button to stop highlighting.

The **Clear** button will remove highlighted areas. Click and hold the left the mouse button to remove highlighted areas of the video. Let go of the left mouse button to stop removing.

The **Size** selection box allows you to set the size of the highlighter.

The **Display** selection box lets you select between stretching the video frame to the size of the window or showing it in its actual size.

The **Finished** button will apply the highlighted area to the motion detection algorithm.

### Configure Motion Detection Parameters

The default parameters are normally sufficient for most situations where a surveillance camera is mounted at a typical location (e.g. corner of a room, outside above a door or parking space).

#### Threshold
**Threshold** controls how sensitive motion detection is to differences between individual frames in a video file. This is used to remove noise. Higher values will decrease the level of sensitivity (changes between frames need to be more significant) and lower values increase the level of sensitivity.

Check the examples below.

##### Threshold = 1
![Threshold set to 1](https://user-images.githubusercontent.com/36278767/220478236-39ef0508-3e51-4208-945a-94cf5c94a2bb.png)

##### Threshold = 50
![Threshold set to 50](https://user-images.githubusercontent.com/36278767/220478241-7aed8a35-43fe-40ea-b107-eb474790cbf5.png)

##### Threshold = 128
![Threshold set to 128](https://user-images.githubusercontent.com/36278767/220478242-388672b2-7ed9-44df-b399-1b139841593a.png)

#### Deviation
**Deviation** sets how concentrated to a single area any differences between individual frames have to be. Lower values mean that motion has to be in a very constrained area, while higher values allow
for more spaced out motion throughout the entire video frame, which usually leads to false positives (e.g. during rain or snowfall, or when sunlight hits the camera lens).

Consider the following frame of video. An automatic PTZ camera was currently moving to another position. As you can see a lot of changes are distributed throughout the entire frame of video. Without checking the deviation, this would be a false positive motion detection.

##### PTZ Camera Swinging Around
![PTZ camera swinging around](https://user-images.githubusercontent.com/36278767/220478449-e9a63da8-6bbf-4a53-92b0-55dd6138cf21.gif)

##### Differences During Camera Movement
![ptz](https://user-images.githubusercontent.com/36278767/220478453-2f949df2-6d9b-45f8-ae94-754b0fd6381e.png)

The differences are all over the frame, so the deviation is high and this would not be considered a frame for further motion analysis.

#### Sensitivity
**Sensitivity** tells the algorithm how many pixels in total need to change between video frames after all filters have been applied. Higher values mean that more needs to change between frames, which usually results in less motion being detected. Lower values will cause more motion to be detected.

#### Continuation
**Continuation** defines how many times the configured sensitivity has to be exceeded in direct succession before motion is confirmed and the degree of activity (how many times confirmed motion was detected in total) is increased. Increase the value to filter out short events like insects or birds flying past the camera. 

#### Parallel Processing
**Parallel processing** sets how many video files are processed in parallel. Please note that depending on the video resolution and the number of frames per second (lower resolution and lower FPS use less resources), motion detection will consume a large amount of CPU and RAM. I strongly advise you change this setting carefully and only after confirming with Task Manager that your system is not running low on resources.

### Start Motion Detection
Simply click **Start motion detection** to begin the process. You will first be asked where to save a text file that contains the results of motion detection and the rest is then automatic. You will probably hear your CPU fan at its highest level fairly soon. :sweat_smile:

It is usually okay to leave **Verbose status output** disabled. If you enable it, it will slow down the process and cause a lot of log entries about the internal state of the motion detection algorithm to be added to the status output.

While motion detection is running, the results text file will be updated continuously. The text file is in TSV (tab-separated values) format.
* The first column is either `OK` (processed successfully) or `NG` (failed to process).
* The second column contains the full path to the video file.
* The third column contains the degree of activity (how many times confirmed motion was detected in total) if the video file was processed successfully, or debugging information if the video file failed to be processed.

Please note that the debugging information in case of an error will span multiple lines. When processing the results text file automatically, test the beginning of each line for `OK` or `NG` before proceeding further.

## Basic Explanation of the Motion Detection Algorithm

The motion detection algorithm is fairly simple. It is contained in the `MotionDetector.cs` file and is commented. The basic flow is like this:

1. Three images are extracted from the video file (previous, current, next)

1. If a region of interest is set, the images are cropped to its bounding box to speed up processing and the region of interest is applied as a mask to prevent motion detection in unwanted areas.

1. The frames are turned to grayscale.\
![Sample frame from a video converted to grayscale](https://user-images.githubusercontent.com/36278767/220479339-a8db0d07-c090-4baa-b311-d46687cb40f0.png)

1. The difference between the frames `previous` and `next` is computed and stored in `d1`.

1. The difference between the frames `next` and `current` is computed and stored in `d2`.

1. “d1” and “d2” are added together (binary AND) and stored `motion`.\
![Content of motion matrix](https://user-images.githubusercontent.com/36278767/220479496-7e58f231-59e2-42a7-a6f7-43653e1eab02.png)

1. Threshold is applied to `motion` to filter out noise and mark actual changes clearly.\
![Application of threshold](https://user-images.githubusercontent.com/36278767/220479551-873936e4-50ef-440a-8cc3-7340b622ae9a.png)

1. To remove more noise, Erode is applied to `motion` to reduce areas with less differences and increase areas with more differences.\
![Application of erode](https://user-images.githubusercontent.com/36278767/220479575-bccca850-0b13-4457-9408-02a5d3cd3f22.png)

1. Standard deviation is calculated for `motion` to see if changes are constrained to a small area or spread throughout the entire frame of video. If too high, does not continue.

1. The number of changed pixels is determined for `motion`.

1. If the number of changed pixels is above the configured Sensitivity consecutively for the number of times specified by Continuation, the degree of activity is increased by 1.

## License

GNU Affero General Public License v3.0. Please see LICENSE file for details.

I am also required to make the following attribution statement: "<a target="_blank" href="https://icons8.com/icon/70MtpQBvFfyb/motion-detector">Motion Detector</a> icon by <a target="_blank" href="https://icons8.com">Icons8</a>"

Sample images in this readme file were taken from random publicly accessible IP cameras listed at http://www.insecam.org/en/bycountry/JP/
