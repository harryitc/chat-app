using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Migrations;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Comunicator;
using Comunicator.Models;
using Newtonsoft.Json;

namespace Client
{
    public partial class frm_ImageView : Form
    {
        private User user;
        public frm_ImageView(User userInput)
        {
            InitializeComponent();
            this.user = userInput;
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



                        using (ChatAppDBContext context = new ChatAppDBContext())
                        {
                            // Bao bọc đối tượng trong một RequestWrapper
                            //try
                            //{
                                //context.Users.AddOrUpdate(new User
                                //{
                                //    ProfilePicture = base64Image
                                //});
                                context.Users.Attach(user);
                                user.ProfilePicture = base64Image;
                                //context.Users.AddOrUpdate(user);
                                context.SaveChanges();
                                loadPicture();  
                                MessageBox.Show("Đã cập nhật ảnh đại diện thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            //}
                            //catch (Exception ex)
                            //{
                            //    MessageBox.Show("Lỗi: " + ex.Message);
                            //    //PrintJson(ex);
                            //}
                        }
                    }
                }
            });
            dialogThread.SetApartmentState(ApartmentState.STA);
            dialogThread.Start();
        }

        private void frm_ImageView_Load(object sender, EventArgs e)
        {
            loadPicture();
        }

        private void loadPicture()
        {
            string userIMG = user.ProfilePicture;
            if (!string.IsNullOrEmpty(userIMG))
            {
                pic_IMG.Image = ConvertBase64ToImage(userIMG);
            }
            else
            {
                pic_IMG.Image = null;
            }
        }

        private Image ConvertBase64ToImage(string base64Image)
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
