using System.Security.Cryptography;
using System.Text;

namespace GeeksControl.Shared.Auth;

public static class PasswordHasher
{
    public static string Hash(string value)
    {
        using var sha = SHA256.Create();
        return Convert.ToHexString(sha.ComputeHash(Encoding.UTF8.GetBytes(value)));
    }
}