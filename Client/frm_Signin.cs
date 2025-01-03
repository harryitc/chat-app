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

using DAL;


namespace Client
{
    public partial class frm_Signin : Form
    {
        ChatAppDBContext db = new ChatAppDBContext();

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
                var newUser = new User
                {
                    Username = txt_SigninUsername.Text,
                    Email = txt_Email.Text,
                    Password = txt_SigninPassword.Text,
                    ProfilePicture = "",
                    CreatedAt = DateTime.Now,
                };

                var response = db.Users.Add(newUser);
                db.SaveChanges();

                this.userID = response.UserID;

                frm_ImageView frm_ImageView = new frm_ImageView(response.ProfilePicture);
                frm_ImageView.DataSent += OnDataPictureUserReceived;
                frm_ImageView.ShowDialog();

                MessageBox.Show("Sign up successful! You can now login.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
