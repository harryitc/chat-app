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
using WindowsFormsApp1.Models;

namespace WindowsFormsApp1
{
    public partial class frm_Signin : Form
    {
        ChatAppDBContext db = new ChatAppDBContext();
        public frm_Signin()
        {
            InitializeComponent();
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

        private void btnLogin_Click(object sender, EventArgs e)
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
                    CreatedAt = DateTime.Now,
                };

                db.Users.Add(newUser);
                db.SaveChanges();

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
    }
}
