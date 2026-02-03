using System;
#if WINDOWS
using System.Security.Principal;
#endif

namespace GeeksControl.Shared.Security;

public static class SecurityGuard
{
    public static void EnsureSystem()
    {
#if WINDOWS
        if (!WindowsIdentity.GetCurrent().IsSystem)
        {
            Environment.FailFast("Agent tampering detected");
        }
#else
        // На Mac просто пропускаем проверку
        Console.WriteLine("SecurityGuard skipped (non-Windows platform)");
#endif
    }
}