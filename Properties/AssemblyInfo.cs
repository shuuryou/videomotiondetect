using System;
using System.Reflection;
using System.Resources;
using System.Runtime.InteropServices;

[assembly: AssemblyTitle("Video Motion Detection")]
[assembly: AssemblyDescription("Video Motion Detection")]
[assembly: AssemblyCompany("https://github.com/shuuryou/videomotiondetect")]
[assembly: AssemblyProduct("Video Motion Detection")]
[assembly: AssemblyCopyright("Copyright © 2023")]
[assembly: ComVisible(false)]
[assembly: Guid("df538be2-7335-4385-b860-3b4b318f2130")]
[assembly: AssemblyVersion("1.0.0.0")]
[assembly: NeutralResourcesLanguageAttribute("en-US")]
[assembly: CLSCompliant(true)]

#if DEBUG
[assembly: AssemblyConfiguration("DEBUG")]
#else
[assembly: AssemblyConfiguration("RELEASE")]
#endif