using System;
using System.Diagnostics;

namespace GeeksControl.Agent.SystemControl;

public static class SystemController
{
    public static void Lock()
    {
#if WINDOWS
        Process.Start("rundll32.exe", "user32.dll,LockWorkStation");
#else
        Console.WriteLine("LOCK skipped on Mac");
#endif
    }
}