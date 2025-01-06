using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using DAL;

namespace BUS
{
    public class SHAService
    {
        ChatAppDBContext context = new ChatAppDBContext();

        public string HashPassword(string passwordInput, string secretKey, string salt)
        {
            string combined = passwordInput + secretKey + salt;

            using (SHA1 sha1 = SHA1.Create()) 
            {
                byte[] bytes = Encoding.UTF8.GetBytes(combined);
                byte[] hash = sha1.ComputeHash(bytes);

                return Convert.ToBase64String(hash);
            }
        }
    }
}
