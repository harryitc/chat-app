using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL;
using BUS;
using OtpNet;


namespace Client
{
    public partial class frm_Login : Form
    {
        ChatAppDBContext db = new ChatAppDBContext();
        private readonly AuthService auth = new AuthService();
        public frm_Login()
        {
            InitializeComponent();
            this.KeyPreview = true;
        }


        private void lblSignin_Click(object sender, EventArgs e)
        {
            new Thread(() => Application.Run(new frm_Signin())).Start();
            this.Close();
        }



        private void performLogin()
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtLoginUsername.Text)
                    || string.IsNullOrWhiteSpace(txtLoginPassword.Text))
                {
                    MessageBox.Show("Please fill out the form!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                //Check if there's a user in the database.
                var user = db.Users.FirstOrDefault(u => u.Username == txtLoginUsername.Text );
                
                if (!auth.CheckAuth(user, txtOtp.Text, txtLoginPassword.Text))
                {
                    //Redirect the user to the chat box form.
                    MessageBox.Show("Username, password or OTP Token is incorrect!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    
                }
                else
                {
                    //MessageBox.Show($"Welcome, {user.Username}!", "Login Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    new Thread(() => Application.Run(new frm_ChatBox(user))).Start();
                    this.Close();
                }    
            }
            catch (Exception ex) { MessageBox.Show($"{ex.Message}"); }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            this.performLogin();
        }

        private void lblLogin_MouseHover(object sender, EventArgs e)
        {
            lblLogin.ForeColor = Color.RoyalBlue;
        }

        private void lblLogin_MouseLeave(object sender, EventArgs e)
        {
            lblLogin.ForeColor = Color.WhiteSmoke;
        }

        private void btnClose_MouseHover(object sender, EventArgs e)
        {
            btnClose.Image = global::Client.Properties.Resources.Close_Hover;
        }

        private void btnClose_MouseLeave(object sender, EventArgs e)
        {
            btnClose.Image = global::Client.Properties.Resources.Close;
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

        private void btnClose_MouseClick(object sender, MouseEventArgs e)
        {
            this.Close();
        }

        private void frm_Login_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.performLogin();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {

        }
    }
}
