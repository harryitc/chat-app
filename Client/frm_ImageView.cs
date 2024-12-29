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
using Comunicator;
using Comunicator.Models;
using Newtonsoft.Json;

namespace Client
{
    public partial class frm_ImageView : Form
    {

        private string imageBase64 = string.Empty;

        public event EventHandler<string> DataSent;

        public frm_ImageView(string imageBase64)
        {
            InitializeComponent();
            this.imageBase64 = imageBase64;
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
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            this.DataSent?.Invoke(this, this.imageBase64);
            this.Close();
        }
    }
}
