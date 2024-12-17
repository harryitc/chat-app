using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace WindowsFormsApp1.utils
{
    public class ImageUtils
    {

        private static void LoadImageFromUrl(PictureBox pictureBox, string url)
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

        public static async void LoadImageFromUrlAsync(PictureBox pictureBox, string url)
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
