using System.Security.Cryptography;
using System.Text;

namespace FinalProject;

public class PasswordManager
{
    private string _password;


    public PasswordManager(string password)
    {
        _password = password;
    }


    public string HashPassword()
    {
        // convert the password to a byte array
        var passwordBytes = Encoding.UTF8.GetBytes(_password);

        // create a SHA256 instance
        using var sha256 = SHA256.Create();

        // compute the hash of the password
        var hashBytes = sha256.ComputeHash(passwordBytes);

        // convert the hash bytes to a hexadecimal string
        var hashedPassword = BitConverter.ToString(hashBytes).Replace("-", "");
        return hashedPassword;
    }



    public string HashInputPassword(string inputPassword)
    {
        var inPasswordBytes = Encoding.UTF8.GetBytes(inputPassword);

        using var sha256 = SHA256.Create();

        var hashBytes = sha256.ComputeHash(inPasswordBytes);

        var hashedInputPassword = BitConverter.ToString(hashBytes).Replace("-", "");
        return hashedInputPassword;
    }
    
    public bool CompareHashedPassword(string inputPassword)
    {
        var hashedPassword = HashPassword();
        var hashedInputPassword = HashInputPassword(inputPassword);
        return hashedPassword == hashedInputPassword;
    }
}