using System;
using System.Windows.Forms;

namespace VideoMotionDetect
{
	public static class WinFormsExtensions
	{
		static WinFormsExtensions()
		{

		}

		public static void InvokeIfRequired<T>(this T c, Action<T> action)
			where T : Control
		{
			if (c.InvokeRequired)
			{
				c.Invoke(new Action(() => action(c)));
			}
			else
			{
				action(c);
			}
		}
	}
}
