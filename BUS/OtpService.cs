using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using OtpNet;
using QRCoder;

namespace BUS
{
    public class OtpService
    {
        ChatAppDBContext context = new ChatAppDBContext();

        public string GenerateSecretKey()
        {
            var secretKey = KeyGeneration.GenerateRandomKey(20);
            var base32SecretKey = Base32Encoding.ToString(secretKey);

            return base32SecretKey;
        }

        public string GenerateQRCode(User userInput)
        {
            string appName = "ChatAppAESoftware";
            string qrCodeData = $"otpauth://totp/{appName}:{userInput.Username}?secret={userInput.SecretKey}&issuser={appName}";

            using (var qrGenerator = new QRCodeGenerator())
            {
                var qrCode = qrGenerator.CreateQrCode(qrCodeData, QRCodeGenerator.ECCLevel.Q);
                var qrCodeImage = new QRCode(qrCode).GetGraphic(20);

                using (var memoryStream = new System.IO.MemoryStream())
                {
                    qrCodeImage.Save(memoryStream, System.Drawing.Imaging.ImageFormat.Png);
                    byte[] imageBytes = memoryStream.ToArray();
                    string base64Image = Convert.ToBase64String(imageBytes);

                    return base64Image;
                }
            }
        }
    }
}
