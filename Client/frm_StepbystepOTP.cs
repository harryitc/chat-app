using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OtpNet;
using System.Security.Cryptography;

namespace Client
{
    public partial class frm_StepbystepOTP : Form
    {
        private byte[] secretKey;
        public frm_StepbystepOTP()
        {
            InitializeComponent();
            InitializeForm();
        }
        
        private void InitializeForm()
        {
            // Secret key cho ví dụ (Base32)
            string base32Secret = "E2TAMAHIPK3OHQKHXPMLQTRYTXHKHA2F";
            secretKey = Base32Encoding.ToBytes(base32Secret);

            // Tạo giao diện TextBox cho 20 byte
            for (int i = 0; i < 20; i++)
            {
                TextBox textBox = new TextBox
                {
                    Name = $"txtByte{i}",
                    Location = new Point(20 + (i % 5) * 80, 20 + (i / 5) * 40),
                    Size = new Size(70, 30),
                    ReadOnly = true,
                    TextAlign = HorizontalAlignment.Center
                };
                Controls.Add(textBox);
            }

            // Nút tính toán OTP
            Button btnCalculate = new Button
            {
                Text = "Calculate OTP",
                Location = new Point(20, 200),
                Size = new Size(150, 40)
            };
            btnCalculate.Click += BtnCalculate_Click;
            Controls.Add(btnCalculate);

            // TextBox hiển thị mã OTP
            TextBox txtOTP = new TextBox
            {
                Name = "txtOTP",
                Location = new Point(200, 200),
                Size = new Size(150, 40),
                ReadOnly = true,
                Font = new Font("Arial", 12, FontStyle.Bold),
                TextAlign = HorizontalAlignment.Center
            };
            Controls.Add(txtOTP);
        }

        private byte[] ComputeHmacSha1(byte[] secretKey, long counter)
        {
            // Chuyển counter (long) thành mảng byte (8 byte)
            byte[] counterBytes = BitConverter.GetBytes(counter);
            if (BitConverter.IsLittleEndian)
            {
                Array.Reverse(counterBytes); // Đảm bảo big-endian
            }

            // Tạo HMACSHA1 và tính toán hash
            using (var hmac = new HMACSHA1(secretKey))
            {
                return hmac.ComputeHash(counterBytes);
            }
        }

        private void BtnCalculate_Click(object sender, EventArgs e)
        {
            // Lấy thời gian hiện tại theo bước TOTP (30 giây)
            long unixTime = DateTimeOffset.UtcNow.ToUnixTimeSeconds() / 30;

            // Tạo hash (HMAC-SHA1) sử dụng thư viện OTP.NET
            byte[] hash = ComputeHmacSha1(secretKey, unixTime);

            // Hiển thị từng byte trong TextBox
            for (int i = 0; i < 20; i++)
            {
                var txtBox = Controls.Find($"txtByte{i}", true).FirstOrDefault() as TextBox;
                if (txtBox != null)
                {
                    txtBox.Text = hash[i].ToString("X2");
                    txtBox.Font = new Font("Arial", 10, FontStyle.Regular);
                    txtBox.BackColor = SystemColors.Window;
                }
            }

            // Lấy offset (byte cuối cùng của hash)
            int offset = hash[hash.Length - 1] & 0x0F;

            // Làm nổi bật 4 byte được offset
            for (int i = offset; i < offset + 4; i++)
            {
                var txtBox = Controls.Find($"txtByte{i}", true).FirstOrDefault() as TextBox;
                if (txtBox != null)
                {
                    txtBox.Font = new Font("Arial", 10, FontStyle.Bold);
                    txtBox.BackColor = Color.Yellow;
                }
            }

            // Tính OTP từ 4 byte offset
            int otp = CalculateOTP(hash, offset);

            // Hiển thị OTP
            var txtOTP = Controls["txtOTP"] as TextBox;
            if (txtOTP != null)
            {
                txtOTP.Text = otp.ToString("D6");
            }
        }

        private int CalculateOTP(byte[] hash, int offset)
        {
            // Lấy 4 byte từ offset
            int binaryCode = (hash[offset] & 0x7F) << 24
                           | (hash[offset + 1] & 0xFF) << 16
                           | (hash[offset + 2] & 0xFF) << 8
                           | (hash[offset + 3] & 0xFF);

            // Mod với 10^6 để lấy mã OTP
            return binaryCode % 1_000_000;
        }

    }
}
