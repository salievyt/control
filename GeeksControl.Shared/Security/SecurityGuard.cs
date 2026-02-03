using System.Security.Principal;

namespace GeeksControl.Shared.Security;

public static class SecurityGuard
{
    public static void EnsureSystem()
    {
#pragma warning disable CA1416 // Validate platform compatibility
#pragma warning disable CA1416 // Validate platform compatibility
        if (!WindowsIdentity.GetCurrent().IsSystem)
        {
            Environment.FailFast("Agent tampering detected");
        }
#pragma warning restore CA1416 // Validate platform compatibility
#pragma warning restore CA1416 // Validate platform compatibility
    }
}