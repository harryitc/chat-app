using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.models;
using WindowsFormsApp1.utils;
using static System.Collections.Specialized.BitVector32;

namespace WindowsFormsApp1
{
    public partial class frm_ChatBox : Form
    {
        ChatAppDBContext db = new ChatAppDBContext();
        private string Username;
        public frm_ChatBox(string Username)
        {
            InitializeComponent();
            this.Username = Username;
        }

        private void frm_ChatBox_Load(object sender, EventArgs e)
        {
            //Show the current user logged in.
            var user = db.Users.FirstOrDefault(u => u.Username == this.Username);

            if (user != null)
            {
                String imageURL = user.ProfilePicture;
                lblWelcome.Text = $"Welcome {Username}";
                ImageUtils.LoadImageFromUrlAsync(pic_User, imageURL);
                /*if (imageURL == null || imageURL == "")
                {
                    string defaultImageURL = "https://www.google.com/url?sa=i&url=https%3A%2F%2Ficonduck.com%2Ficons%2F160691%2Favatar-default-symbolic&psig=AOvVaw3zQnn0x2TaO84oqw14Ndsh&ust=1734682587593000&source=images&cd=vfe&opi=89978449&ved=0CBEQjRxqFwoTCLityK6ys4oDFQAAAAAdAAAAABAE";
                    ImageUtils.LoadImageFromUrlAsync(pic_User, defaultImageURL);
                }
                else
                {

                }*/
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you wanna logout?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                MessageBox.Show("Logout successfully!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                new Thread(() => Application.Run(new frm_Login())).Start();
                this.Close();
            }
            else if (result == DialogResult.No)
            {
                MessageBox.Show("Logout canceled successfully!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void pic_User_Click(object sender, EventArgs e)
        {

        }
    }
}
