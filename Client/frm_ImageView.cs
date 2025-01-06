using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Migrations;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Client.utils;

using DAL;
using DAL.Config;


namespace Client
{
    public partial class frm_ImageView : Form
    {

        private string imageBase64 = string.Empty;
        private string loadType = string.Empty;

        public event EventHandler<string> DataSent;

        public frm_ImageView(string imageBase64, string typeLoad)
        {
            InitializeComponent();
            this.imageBase64 = imageBase64;
            this.loadType = typeLoad;
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            Thread dialogThread = new Thread(() =>
            {
                Thread.CurrentThread.SetApartmentState(ApartmentState.STA);
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        string imagePath = openFileDialog.FileName;
                        byte[] imageBytes = File.ReadAllBytes(imagePath);
                        string base64Image = Convert.ToBase64String(imageBytes);
                        this.imageBase64 = base64Image;
                        ImageUtils.LoadImage(this.pic_IMG, this.imageBase64);
                    }
                }
            });
            dialogThread.SetApartmentState(ApartmentState.STA);
            dialogThread.Start();
        }

        private void frm_ImageView_Load(object sender, EventArgs e)
        {
            ImageUtils.LoadImage(this.pic_IMG, this.imageBase64);
            if (this.loadType != "avatar")
            {
                btnSubmit.Enabled = false;
                btnCreate.Enabled = false;
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            this.DataSent?.Invoke(this, this.imageBase64);
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

        private void btnClose_MouseHover(object sender, EventArgs e)
        {
            btn_Close.Image = global::Client.Properties.Resources.Close_Hover;
        }

        private void btnClose_MouseLeave(object sender, EventArgs e)
        {
            btn_Close.Image = global::Client.Properties.Resources.Close;
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
