using System.Security.Principal;

namespace GeeksControl.Shared.Security;

public static class SecurityGuard
{
    public static void EnsureSystem()
    {
        if (!WindowsIdentity.GetCurrent().IsSystem)
        {
            Environment.FailFast("Agent tampering detected");
        }
    }
}