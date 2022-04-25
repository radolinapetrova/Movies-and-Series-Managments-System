using System.Security.Cryptography;
using System.Text;

namespace Entities
{
    public static class PasswordHasher
    {

        public static String Hash(string password)
        {
            using (var hasher = SHA256.Create())
            {
                byte[] hashedBytes = hasher.ComputeHash(Encoding.UTF8.GetBytes(password));

               return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
            }
        }

    }
}
