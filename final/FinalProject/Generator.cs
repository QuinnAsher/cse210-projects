using System.Security.Cryptography;
using System.Text;

namespace FinalProject;

public static class Generator
{
    public static long GenerateAccountNumber()
    {
        var random = new Random();
        var accountNumber = random.NextInt64(1000000000, 9999999999);
        return accountNumber;
    }


    public static int GenerateOtp()
    {
        var random = new Random();
        var otp = random.Next(100000, 999999);
        return otp;
    }

    public static string GenerateCustomerId()
    {
        var uniqueId = Guid.NewGuid().ToString("N");
        return uniqueId;
    }

    public static string GenerateTransactionId()
    {
        var uniqueId = Guid.NewGuid().ToString("N");
        return uniqueId;
    }

    public static string HashPassword(string password)
    {
        // convert the password to a byte array
        var passwordBytes = Encoding.UTF8.GetBytes(password);

        // create a SHA256 instance
        using var sha256 = SHA256.Create();

        // compute the hash of the password
        var hashBytes = sha256.ComputeHash(passwordBytes);

        // convert the hash bytes to a hexadecimal string
        var hashedPassword = BitConverter.ToString(hashBytes).Replace(", ", "");
        return "";
    }
}