using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace EPhoneApi.Util;

public static class PasswordUtil
{
    public static string GenerateSalt()
    {
        var bytes = new byte[128 / 8];
        var rng = RandomNumberGenerator.Create();
        rng.GetBytes(bytes);
        return Convert.ToBase64String(bytes);
    }

    public static string ComputerPasswordHash(string password, string salt)
    {
        var hashBytes = KeyDerivation.Pbkdf2(
            password,
            Convert.FromBase64String(salt),
            KeyDerivationPrf.HMACSHA512,
            100000,
            256 / 8);
        return Convert.ToBase64String(hashBytes);
    }

    public static bool VerifyPassword(string password, string salt, string passwordHash)
    {
        var enteredPasswordHash = ComputerPasswordHash(password, salt);
        return string.Equals(enteredPasswordHash, passwordHash);
    }
}