using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;
using DAL;

using Google.Apis.Auth.OAuth2;
using Google.Apis.Gmail.v1;
using GmailV1 = Google.Apis.Gmail.v1.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using MimeKit;
using System.IO;

namespace Client
{
    public partial class frm_Signin : Form
    {
        ChatAppDBContext db = new ChatAppDBContext();
        private readonly OtpService otp = new OtpService();
        private readonly SHAService sha = new SHAService();

        private int userID;

        public frm_Signin()
        {
            InitializeComponent();
            this.KeyPreview = true;
        }

        private void frm_Signin_Load(object sender, EventArgs e)
        {

        }

        private void lblSignin_Click(object sender, EventArgs e)
        {
            new Thread(() => Application.Run(new frm_Login())).Start();
            this.Close();
        }

        private void lblSignin_MouseHover(object sender, EventArgs e)
        {
            lblSignin.ForeColor = Color.RoyalBlue;
        }

        private void lblSignin_MouseLeave(object sender, EventArgs e)
        {
            lblSignin.ForeColor = Color.WhiteSmoke;
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                string emailPattern = @"^[a-zA-Z][a-zA-Z0-9._%+-]*@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
                return Regex.IsMatch(email, emailPattern);
            }
            catch
            {
                return false;
            }
        }

        private void performSignin()
        {
            try
            {
                //Form can't be empty.
                if (txt_Email.Text == "" || txt_SigninUsername.Text == "" || txt_SigninPassword.Text == "")
                {
                    MessageBox.Show("Please fill out the form!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                //Check if the email format is correct or not.
                if (!IsValidEmail(txt_Email.Text))
                {
                    MessageBox.Show("Please enter the correct email format!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                //Check if there's a user in the database.
                var existingUser = db.Users.FirstOrDefault(u => u.Username == txt_SigninUsername.Text ||
                                                                 u.Email == txt_Email.Text);
                if (existingUser != null)
                {
                    MessageBox.Show("Username or Email already exists!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                //Create a new user in the database.
                string secretKey = otp.GenerateSecretKey();
                var newUser = new User
                {
                    Username = txt_SigninUsername.Text,
                    Email = txt_Email.Text,
                    SecretKey = secretKey,
                    Password = sha.HashPassword(txt_SigninPassword.Text, secretKey, "AESoftware"),
                    ProfilePicture = "",
                    CreatedAt = DateTime.Now,
                };

                var response = db.Users.Add(newUser);
                db.SaveChanges();

                this.userID = response.UserID;

                frm_ImageView frm_ImageView = new frm_ImageView(response.ProfilePicture, "avatar");
                frm_ImageView.DataSent += OnDataPictureUserReceived;
                frm_ImageView.ShowDialog();

                MessageBox.Show("Sign up successful!\nHere is your OTP QRCode, using Authenticator to scan it.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                var QRCodeImage = otp.GenerateQRCode(response);
                frm_ImageView QRScan = new frm_ImageView(QRCodeImage, "qrCode");
                QRScan.DataSent += OnDataPictureUserReceived;
                QRScan.ShowDialog();

                sendEmail(response.Email, response.Username, txt_SigninPassword.Text);

                txt_Email.Clear();
                txt_SigninUsername.Clear();
                txt_SigninPassword.Clear();

                //Redirect the user to the login form.
                new Thread(() => Application.Run(new frm_Login())).Start();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}");
            }
        }

        private void sendEmail(string recipientEmail, string username, string password)
        {
            try
            {
                string[] Scopes = { GmailService.Scope.GmailSend };
                string ApplicationName = "Gmail API Test";

                // Đọc file JSON từ thông tin xác thực đã tải xuống
                UserCredential credential;

                using (var stream = new FileStream("credentials.json", FileMode.Open, FileAccess.Read))
                {
                    string credPath = "token.json";
                    credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                        GoogleClientSecrets.Load(stream).Secrets,
                        Scopes,
                        "user",
                        CancellationToken.None,
                        new FileDataStore(credPath, true)).Result;
                    Console.WriteLine("Credential file saved to: " + credPath);
                }

                // Tạo dịch vụ Gmail API
                var service = new GmailService(new BaseClientService.Initializer()
                {
                    HttpClientInitializer = credential,
                    ApplicationName = ApplicationName,
                });

                // Tạo nội dung email với username và password
                var email = new MimeMessage();
                email.From.Add(new MailboxAddress("ADTC - No Reply", "no-reply@gmail.com"));
                email.To.Add(new MailboxAddress("ChatApp - Register Successfully", recipientEmail));  // Recipient email passed as parameter
                email.Subject = "ChatApp - Register Successfully";

                // Cấu trúc body email với HTML (username và password)
                string emailBody = File.ReadAllText("./Email.template.html");

                // Chèn dữ liệu động vào template
                emailBody = emailBody.Replace("{username}", username).Replace("{password}", password);

                // Cài đặt body email dưới dạng HTML
                email.Body = new TextPart("html")
                {
                    Text = emailBody
                };

                // Chuyển đổi email sang định dạng Base64
                var message = new Google.Apis.Gmail.v1.Data.Message
                {
                    Raw = Base64UrlEncode(email.ToString())
                };

                // Gửi email
                service.Users.Messages.Send(message, "me").Execute();
                Console.WriteLine("Email sent successfully!");
                MessageBox.Show("Email sent successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        // Hàm để mã hóa Base64 URL
        public static string Base64UrlEncode(string input)
        {
            var bytes = Encoding.UTF8.GetBytes(input);
            return Convert.ToBase64String(bytes)
                .Replace("+", "-") // Thay đổi "+" thành "-"
                .Replace("/", "_") // Thay đổi "/" thành "_"
                .Replace("=", ""); // Loại bỏ dấu "="
        }
        private void OnDataPictureUserReceived(object sender, string imageBase64)
        {
            {
                var user = db.Users.FirstOrDefault(p => p.UserID == this.userID);
                db.Users.Attach(user);
                user.ProfilePicture = imageBase64;
                db.SaveChanges();
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            this.performSignin();
        }

        private void btnClose_MouseHover(object sender, EventArgs e)
        {
            btnClose.Image = global::Client.Properties.Resources.Close_Hover;
        }

        private void btnClose_MouseLeave(object sender, EventArgs e)
        {
            btnClose.Image = global::Client.Properties.Resources.Close;
        }

        private void btnClose_MouseClick(object sender, MouseEventArgs e)
        {
            this.Close();
        }

        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int HT_CAPTION = 0x2;
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool ReleaseCapture();

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (e.Clicks == 1 && e.Y <= this.Height && e.Y >= 0)
                {
                    ReleaseCapture();
                    SendMessage(this.Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
                }
            }
        }

        private void frm_Signin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.performSignin();
            }
        }
    }
}
