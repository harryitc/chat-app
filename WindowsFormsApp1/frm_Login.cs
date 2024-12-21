﻿using System;
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
using WindowsFormsApp1.Models;

namespace WindowsFormsApp1
{
    public partial class frm_Login : Form
    {
        ChatAppDBContext db = new ChatAppDBContext();
        public frm_Login()
        {
            InitializeComponent();
        }

        private void frm_Login_Load(object sender, EventArgs e)
        {

        }


        private void lblSignin_Click(object sender, EventArgs e)
        {
            new Thread(() => Application.Run(new frm_Signin())).Start();
            this.Close();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void txtLoginPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void txtLoginUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_Email_TextChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void btnStart_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtIP_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtLoginUsername.Text) || string.IsNullOrEmpty(txtLoginPassword.Text))
                {
                    MessageBox.Show("Please fill out the form!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                //Check if there's a user in the database.
                var user = db.Users.FirstOrDefault(u => u.Username == txtLoginUsername.Text &&
                                                       u.Password == txtLoginPassword.Text);
                if (user != null)
                {
                    MessageBox.Show($"Welcome, {user.Username}!", "Login Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    //Redirect the user to the chat box form.
                    new Thread(() => Application.Run(new frm_ChatBox(user))).Start();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Username or password is incorrect!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex) { MessageBox.Show($"{ex.Message}"); }
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
            btnClose.Image = global::WindowsFormsApp1.Properties.Resources.Close_Hover;
        }

        private void btnClose_MouseLeave(object sender, EventArgs e)
        {
            btnClose.Image = global::WindowsFormsApp1.Properties.Resources.Close;
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

        private void btnClose_Click(object sender, EventArgs e)
        {

        }

        private void btnClose_MouseClick(object sender, MouseEventArgs e)
        {
            this.Close();
        }
    }
}
