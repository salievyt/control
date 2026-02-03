using System.Diagnostics;

namespace GeeksControl.Agent.SystemControl{

public static class SystemController
{
    public static void Lock()
    {
        Process.Start("rundll32.exe", "user32.dll,LockWorkStation");
    }
}
}