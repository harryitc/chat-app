using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using DAL;
using OtpNet;
using BUS;

namespace BUS
{
    public class AuthService
    {
        private readonly SHAService sha = new SHAService();
        public bool CheckAuth(User user, string otpToken, string password)
        {
            if (user == null)
            {
                return false;
            }

            string newhashpass = sha.HashPassword(password, user.SecretKey, "AESoftware");

            if (newhashpass != user.Password)
            {
                return false;
            }

            var totp = new Totp(Base32Encoding.ToBytes(user.SecretKey));
            bool isValidToken = totp.VerifyTotp(otpToken, out _);

            return isValidToken;
        }
    }
}
