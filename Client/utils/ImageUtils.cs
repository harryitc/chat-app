using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;
using System.Runtime.CompilerServices;

namespace Client.utils
{
    public class ImageUtils
    {

        public static Image DEFAULT_IMAGE = global::Client.Properties.Resources.default_avatar_profile_icon_social_media_user_image_gray_avatar_icon_blank_profile_silhouette_vector_illustration_561158_3467;

        //private static void LoadImageFromUrl(PictureBox pictureBox, string url)
        //{
        //    try
        //    {
        //        using (WebClient webClient = new WebClient())
        //        {
        //            byte[] imageData = webClient.DownloadData(url); // Tải dữ liệu hình ảnh từ URL
        //            using (System.IO.MemoryStream stream = new System.IO.MemoryStream(imageData))
        //            {
        //                Image image = Image.FromStream(stream); // Tạo đối tượng hình ảnh từ stream
        //                pictureBox.Image = image; // Gán hình ảnh vào PictureBox
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show($"Lỗi khi tải hình ảnh: {ex.Message}");
        //    }
        //}

        public static void LoadImage(PictureBox pictureBox, string image)
        {
            if (string.IsNullOrEmpty(image))
            {
                pictureBox.Image = DEFAULT_IMAGE;
                return;
            }

            if (IsUrl(image))
            {
                // Xử lý nếu là URL
                LoadImageFromUrlAsync(pictureBox, image);
            }
            else if (IsBase64String(image))
            {
                // Xử lý nếu là Base64
                pictureBox.Image = ConvertBase64ToImage(image);
            }
            else
            {
                MessageBox.Show("Dữ liệu không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static async void LoadImageFromUrlAsync(PictureBox pictureBox, string url)
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
                //MessageBox.Show($"Lỗi khi tải hình ảnh: {ex.Message}");
                //Image image = Image.FromStream();
                //pictureBox.Image = ;
            }
        }


        // Kiểm tra chuỗi có phải URL hay không
        private static bool IsUrl(string str)
        {
            return Uri.TryCreate(str, UriKind.Absolute, out Uri uriResult) &&
                   (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
        }

        // Kiểm tra chuỗi có phải Base64 hay không
        private static bool IsBase64String(string base64)
        {
            // Bỏ qua các ký tự trống hoặc xuống dòng trong Base64
            base64 = base64.Trim();
            return (base64.Length % 4 == 0) && Regex.IsMatch(base64, @"^[a-zA-Z0-9\+/]*={0,2}$", RegexOptions.None);
        }

        public static Image ConvertBase64ToImage(string base64Image)
        {
            try
            {
                // Chuyển đổi Base64 thành byte[]
                byte[] imageBytes = Convert.FromBase64String(base64Image);

                // Tạo một đối tượng Image từ byte[]
                using (var ms = new MemoryStream(imageBytes))
                {
                    return Image.FromStream(ms);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error converting Base64 to Image: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

    }
}
