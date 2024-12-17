using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Demo_ImageViewer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            // Tạo một PictureBox để hiển thị hình ảnh
            PictureBox pictureBox = new PictureBox
            {
                Width = 400,
                Height = 300,
                SizeMode = PictureBoxSizeMode.StretchImage, // Co giãn hình ảnh theo kích thước PictureBox
            };

            this.Controls.Add(pictureBox);

            // URL hình ảnh cần tải
            string imageUrl = "https://plus.unsplash.com/premium_photo-1726743697632-5790d2ebf36b?q=80&w=2070&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D";

            // Gọi hàm tải hình ảnh và hiển thị lên PictureBox
            //LoadImageFromUrl(pictureBox, imageUrl);
            LoadImageFromUrlAsync(pictureBox, imageUrl);

        }
        private void LoadImageFromUrl(PictureBox pictureBox, string url)
        {
            try
            {
                using (WebClient webClient = new WebClient())
                {
                    byte[] imageData = webClient.DownloadData(url); // Tải dữ liệu hình ảnh từ URL
                    using (System.IO.MemoryStream stream = new System.IO.MemoryStream(imageData))
                    {
                        Image image = Image.FromStream(stream); // Tạo đối tượng hình ảnh từ stream
                        pictureBox.Image = image; // Gán hình ảnh vào PictureBox
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải hình ảnh: {ex.Message}");
            }
        }

        private async void LoadImageFromUrlAsync(PictureBox pictureBox, string url)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    byte[] imageData = await client.GetByteArrayAsync(url); // Tải hình ảnh
                    using (System.IO.MemoryStream stream = new System.IO.MemoryStream(imageData))
                    {
                        Image image = Image.FromStream(stream);
                        pictureBox.Image = image;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải hình ảnh: {ex.Message}");
            }
        }
    }
}
