using System.Security.Cryptography;
using System.Text;

namespace ParadiseApi
{
    public class HashPassword
    {
        public static string ComputeHash(string password, string salt)
        {
            byte[] bytesToHash = Encoding.UTF8.GetBytes(password);
            byte[] saltBytes = Encoding.UTF8.GetBytes(salt);

            var byteResult = new Rfc2898DeriveBytes(bytesToHash, saltBytes, 10000);

            return Convert.ToBase64String(byteResult.GetBytes(24));
        }
        public static bool Verifications(string hash,string password,string salt)
        {
            var newPass = ComputeHash(password, salt);

            return newPass == hash;
        }
    }
}
