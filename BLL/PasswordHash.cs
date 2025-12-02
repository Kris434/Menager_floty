using System.Security.Cryptography;
using System.Text;
using Konscious.Security.Cryptography;

namespace BLL;

public static class PasswordHash
{
    private const int SaltSize = 16;
    private const int HashSize = 32;
    private const int DegreeOfParallelism = 8;
    private const int Iterations = 4;
    private const int MemorySize = 1024;

    public static string Hash(string password)
    {
        byte[] salt = new byte[SaltSize];

        using (var random = RandomNumberGenerator.Create())
        {
            random.GetBytes(salt);
        }
        
        byte[] hash = HashPassword(password, salt);
        
        var combined = new byte[hash.Length + salt.Length];
        
        Array.Copy(salt, 0, combined, 0, salt.Length);
        Array.Copy(hash, 0, combined, salt.Length, hash.Length);

        // Convert to base64 for storage
        return Convert.ToBase64String(combined);
    }

    private static byte[] HashPassword(string password, byte[] salt)
    {
        var argon2 = new Argon2id(Encoding.UTF8.GetBytes(password))
        {
            Salt = salt,
            DegreeOfParallelism = DegreeOfParallelism,
            Iterations = Iterations,
            MemorySize = MemorySize,
        };
        
        return argon2.GetBytes(HashSize);
    }
    
    public static bool VerifyPassword(string password, string hashedPassword)
    {
        byte[] combinedBytes = Convert.FromBase64String(hashedPassword);
        
        byte[] salt = new byte[SaltSize];
        byte[] hash = new byte[HashSize];
        Array.Copy(combinedBytes, 0, salt, 0, SaltSize);
        Array.Copy(combinedBytes, SaltSize, hash, 0, HashSize);

        byte[] newHash = HashPassword(password, salt);

        return CryptographicOperations.FixedTimeEquals(hash, newHash);
    }
}