// using System.Security.Cryptography;
// using System.Text;
//
// namespace FinalProject;
//
// public static class PasswordManager
// {
//     public static string HashPassword(string password)
//     {
//         // convert the password to a byte array
//         var passwordBytes = Encoding.UTF8.GetBytes(password);
//
//         // create a SHA256 instance
//         using var sha256 = SHA256.Create();
//
//         // compute the hash of the password
//         var hashBytes = sha256.ComputeHash(passwordBytes);
//
//         // convert the hash bytes to a hexadecimal string
//         var hashedPassword = BitConverter.ToString(hashBytes).Replace("-", "");
//         return hashedPassword;
//     }
//
//     
//     public static bool ComparePassword(string dataBasePassword, string inputPassword)
//     {
//         return dataBasePassword == inputPassword;
//     }
// }