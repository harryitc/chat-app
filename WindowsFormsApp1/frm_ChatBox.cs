using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.models;
using WindowsFormsApp1.utils;
using static System.Windows.Forms.LinkLabel;

namespace WindowsFormsApp1
{
    public partial class frm_ChatBox : Form
    {
        private int id;
        private int selectedGroupId;
        private bool isDragging = false;
        private Point startPoint = new Point(0, 0);
        private string selectedBase64Image;
        ChatAppDBContext db = new ChatAppDBContext();

        User user = new User();

        public frm_ChatBox(int userID)
        {
            InitializeComponent();
            this.id = userID;
        }

        private void frm_ChatBox_Load(object sender, EventArgs e)
        {
            List<User> users = db.Users.ToList();


            this.user = users.FirstOrDefault(s => s.UserID == id);

            String imageURL = user.ProfilePicture;
            ImageUtils.LoadImageFromUrlAsync(pic_User, imageURL);
            /*if (imageURL == null || imageURL == "")
            {
                string defaultImageURL = "https://www.google.com/url?sa=i&url=https%3A%2F%2Ficonduck.com%2Ficons%2F160691%2Favatar-default-symbolic&psig=AOvVaw3zQnn0x2TaO84oqw14Ndsh&ust=1734682587593000&source=images&cd=vfe&opi=89978449&ved=0CBEQjRxqFwoTCLityK6ys4oDFQAAAAAdAAAAABAE";
                ImageUtils.LoadImageFromUrlAsync(pic_User, defaultImageURL);
            }
            else
            {

            }*/
            var listFriends = db.Friendships.Where(friend => friend.RequesterID == id && friend.Status == "accepted").ToList();

            lblWelcome.Text = $"{user.Username}";
            for (int i = 0; i < listFriends.Count; i++)
            {
                dgvFriends.Rows.Add(listFriends[i].User.Username, listFriends[i].User.Status);
            }

            dgvGroups.Columns.Add("GroupID", "Group ID");
            dgvGroups.Columns["GroupID"].Visible = false; // Ẩn cột GroupID
            dgvGroups.Columns.Add("GroupName", "Group Name");

            //Groups
            var groups = db.Groups.Where(g => g.CreatedBy == user.UserID).ToList();
            for (int i = 0; i < groups.Count; i++)
            {
                dgvGroups.Rows.Add(groups[i].GroupID, groups[i].GroupName);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string request = txtReceiver.Text;
            List<User> users = db.Users.ToList();
            //var user = users.FirstOrDefault(u => u.UserID == id)
            bool flat = false;
            for (int i = 0; i < users.Count; i++)
            {
                if (users[i].Username == request)
                {
                    Friendship addfr = new Friendship();
                    addfr.AddressID = this.id;
                    addfr.RequesterID = users[i].UserID;
                    addfr.Status = "pending";
                    addfr.CreatedAt = DateTime.Now;
                    MessageBox.Show("Đã gửi kết bạn thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    db.Friendships.Add(addfr);
                    db.SaveChanges();
                    flat = true;
                }
            }
            if (flat == false)
                MessageBox.Show("Người dùng không tồn tại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);


        }

        private void btnCreateGroup_Click(object sender, EventArgs e)
        {
            frm_GroupCreator groupCreator = new frm_GroupCreator(this.id);
            groupCreator.ShowDialog();
            if (DialogResult.OK == groupCreator.DialogResult)
            {
                loadListGroup();
            }
        }

        private void loadListGroup()
        {
            this.dgvGroups.Rows.Clear();
            //Groups
            var groups = db.Groups.Where(g => g.CreatedBy == this.user.UserID).ToList();
            for (int i = 0; i < groups.Count; i++)
            {
                dgvGroups.Rows.Add(groups[i].GroupID, groups[i].GroupName);
            }
        }

        private void LoadGroupMessages(int groupId)
        {
            var messages = db.GroupMessages
                .Where(msg => msg.GroupID == groupId)
                .OrderBy(msg => msg.Timestamp)
                .Select(msg => new
                {
                    SenderName = msg.User.Username, // Liên kết với bảng User
                    msg.Content,
                    msg.Timestamp,
                    msg.MessageType
                })
                .ToList();

            rtbDialog.Clear();
            foreach (var message in messages)
            {
                if (message.MessageType == "text")
                {
                    AppendMessageToRichTextBox(message.SenderName, message.Content, message.Timestamp);
                }
                else if (message.MessageType == "image")
                {
                    DisplayImageInRichTextBox(message.SenderName, message.Content, message.Timestamp);
                }
            }
        }

        //private void AppendMessageToRichTextBox(string senderName, string content, DateTime? timestamp)
        //{
        //    string formattedMessage = $"[{timestamp:yyyy-MM-dd HH:mm:ss}] {senderName}: {content}\n";

        //    // Định dạng tùy chỉnh cho tin nhắn của người gửi
        //    rtbDialog.SelectionStart = rtbDialog.TextLength;
        //    rtbDialog.SelectionLength = 0;

        //    if (senderName == "Me") // Tin nhắn của bản thân
        //    {
        //        rtbDialog.SelectionColor = Color.Blue;
        //        rtbDialog.SelectionFont = new Font(rtbDialog.Font, FontStyle.Bold);
        //        rtbDialog.SelectionAlignment = HorizontalAlignment.Right;
        //    }
        //    else
        //    {
        //        rtbDialog.SelectionColor = Color.Black;
        //        rtbDialog.SelectionFont = rtbDialog.Font;
        //    }

        //    rtbDialog.AppendText(formattedMessage);
        //    rtbDialog.SelectionColor = rtbDialog.ForeColor; // Reset màu
        //}

        private void AppendMessageToRichTextBox(string senderName, string content, DateTime? timestamp)
        {
            rtbDialog.BeginInvoke(new MethodInvoker(() =>
            {
                Font currentFont = rtbDialog.SelectionFont;

                //Username
                rtbDialog.SelectionStart = rtbDialog.TextLength;
                rtbDialog.SelectionLength = 0;
                rtbDialog.SelectionColor = Color.Red;
                rtbDialog.SelectionFont = new Font(currentFont.FontFamily, currentFont.Size, FontStyle.Bold);
                rtbDialog.AppendText(senderName);
                rtbDialog.SelectionColor = rtbDialog.ForeColor;

                rtbDialog.AppendText(": ");

                //Message
                rtbDialog.SelectionStart = rtbDialog.TextLength;
                rtbDialog.SelectionLength = 0;
                rtbDialog.SelectionColor = Color.Green;
                rtbDialog.SelectionFont = new Font(currentFont.FontFamily, currentFont.Size, FontStyle.Regular);
                rtbDialog.AppendText(content);
                rtbDialog.SelectionColor = rtbDialog.ForeColor;

                rtbDialog.AppendText(" ");

                rtbDialog.SelectionStart = rtbDialog.GetFirstCharIndexOfCurrentLine();
                rtbDialog.SelectionLength = 0;

                if (senderName == this.user.Username)
                {
                    rtbDialog.SelectionAlignment = HorizontalAlignment.Right;
                }
                else rtbDialog.SelectionAlignment = HorizontalAlignment.Left;

                rtbDialog.AppendText(Environment.NewLine);
            }));
        }


        //private void DisplayImageInRichTextBox(string senderName, string base64Image, DateTime? timestamp)
        //{
        //    byte[] imageBytes = Convert.FromBase64String(base64Image);
        //    using (var ms = new MemoryStream(imageBytes))
        //    {
        //        string formattedMessage = $"[{timestamp:yyyy-MM-dd HH:mm:ss}] {senderName}\n";
        //        if (senderName == "Me") // Tin nhắn của bản thân
        //        {
        //            rtbDialog.SelectionColor = Color.Blue;
        //            rtbDialog.SelectionFont = new Font(rtbDialog.Font, FontStyle.Bold);
        //            rtbDialog.SelectionAlignment = HorizontalAlignment.Right;
        //        }
        //        else
        //        {
        //            rtbDialog.SelectionColor = Color.Black;
        //            rtbDialog.SelectionFont = rtbDialog.Font;
        //        }

        //        rtbDialog.AppendText(formattedMessage);
        //        rtbDialog.SelectionColor = rtbDialog.ForeColor;

        //        Clipboard.SetImage(Image.FromStream(ms)); // Sao chép ảnh vào Clipboard
        //        rtbDialog.Paste();                        // Dán ảnh vào RichTextBox
        //    }
        //}


        //private void DisplayImageInRichTextBox(string senderName, string base64Image, DateTime? timestamp)
        //{
        //    if (string.IsNullOrEmpty(base64Image) || base64Image.Length % 4 != 0 || !base64Image.All(c => "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/=".Contains(c)))
        //    {
        //        // Handle invalid Base-64 string
        //        MessageBox.Show("Invalid image data.");
        //        return;
        //    }

        //    byte[] imageBytes = Convert.FromBase64String(base64Image);
        //    using (var ms = new MemoryStream(imageBytes))
        //    {
        //        string formattedMessage = $"[{timestamp:yyyy-MM-dd HH:mm:ss}] {senderName}\n";
        //        if (senderName == "Me")
        //        {
        //            rtbDialog.SelectionColor = Color.Blue;
        //            rtbDialog.SelectionFont = new Font(rtbDialog.Font, FontStyle.Bold);
        //            rtbDialog.SelectionAlignment = HorizontalAlignment.Right;
        //        }
        //        else
        //        {
        //            rtbDialog.SelectionColor = Color.Black;
        //            rtbDialog.SelectionFont = rtbDialog.Font;
        //        }

        //        rtbDialog.AppendText(formattedMessage);
        //        rtbDialog.SelectionColor = rtbDialog.ForeColor;

        //        Clipboard.SetImage(Image.FromStream(ms));
        //        rtbDialog.Paste();
        //    }
        //}


        //private string ConvertToRtfImage(string base64Image)
        //{
        //    // Chuyển Base64 thành byte[] 
        //    byte[] imageBytes = Convert.FromBase64String(base64Image);

        //    // Đưa byte[] vào định dạng RTF
        //    string rtfImage = @"{\rtf1\ansi{\pict\jpegblip " + BitConverter.ToString(imageBytes).Replace("-", "") + "}}";

        //    return rtfImage;
        //}
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


        private void DisplayImageInRichTextBox(string senderName, string base64Image, DateTime? timestamp)
        {

            rtbDialog.BeginInvoke(new MethodInvoker(() =>
                {
                    Font currentFont = rtbDialog.SelectionFont;

                    // Username
                    rtbDialog.SelectionStart = rtbDialog.TextLength;
                    rtbDialog.SelectionLength = 0;
                    rtbDialog.SelectionColor = Color.Red;
                    rtbDialog.SelectionFont = new Font(currentFont.FontFamily, currentFont.Size, FontStyle.Bold);
                    rtbDialog.AppendText(senderName);
                    rtbDialog.SelectionColor = rtbDialog.ForeColor;
                    rtbDialog.AppendText(": ");

                    // Image
                    if (!string.IsNullOrEmpty(base64Image)) // Kiểm tra xem có ảnh không
                    {
                        byte[] imageBytes = Convert.FromBase64String(base64Image);
                        using (var ms = new MemoryStream(imageBytes))
                        {
                            Image image = ConvertBase64ToImage(base64Image);  // Chuyển Base64 thành ảnh
                            if (image != null)
                            {
                                 Thread thread = new Thread(() =>
                                {
                                    Clipboard.Clear();
                                    Clipboard.SetImage(image);
                                });
                                thread.SetApartmentState(ApartmentState.STA);
                                thread.Start();
                                thread.Join();
                                rtbDialog.Paste();
                            }
                            else
                            {
                                MessageBox.Show("Image is null. Cannot display in RichTextBox.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }

                        }
                    }



                    // Căn lề cho văn bản và ảnh
                    rtbDialog.SelectionStart = rtbDialog.GetFirstCharIndexOfCurrentLine();
                    rtbDialog.SelectionLength = 0;

                    if (senderName == this.user.Username)
                    {
                        rtbDialog.SelectionAlignment = HorizontalAlignment.Right; // Căn phải
                    }
                    else
                    {
                        rtbDialog.SelectionAlignment = HorizontalAlignment.Left; // Căn trái
                    }

                    rtbDialog.AppendText(Environment.NewLine);

                })
        );
        }


        //private void DisplayImageInRichTextBox(string senderName, string base64Image, DateTime? timestamp)
        //{
        //    if (rtbDialog.InvokeRequired)
        //    {
        //        rtbDialog.Invoke(new Action(() => DisplayImageInRichTextBox(senderName, base64Image, timestamp)));
        //        return;
        //    }

        //    if (string.IsNullOrEmpty(base64Image) || base64Image.Length % 4 != 0 || !base64Image.All(c => "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/=".Contains(c)))
        //    {
        //        // Handle invalid Base-64 string
        //        MessageBox.Show("Invalid image data.");
        //        return;
        //    }

        //    byte[] imageBytes = Convert.FromBase64String(base64Image);
        //    using (var ms = new MemoryStream(imageBytes))
        //    {
        //        string formattedMessage = $"[{timestamp:yyyy-MM-dd HH:mm:ss}] {senderName}\n";
        //        if (senderName == "Me")
        //        {
        //            rtbDialog.SelectionColor = Color.Blue;
        //            rtbDialog.SelectionFont = new Font(rtbDialog.Font, FontStyle.Bold);
        //            rtbDialog.SelectionAlignment = HorizontalAlignment.Right;
        //        }
        //        else
        //        {
        //            rtbDialog.SelectionColor = Color.Black;
        //            rtbDialog.SelectionFont = rtbDialog.Font;
        //        }

        //        rtbDialog.AppendText(formattedMessage);
        //        rtbDialog.SelectionColor = rtbDialog.ForeColor;

        //        Clipboard.SetImage(Image.FromStream(ms));
        //        rtbDialog.Paste();
        //    }
        //}




        private void btnSend_Click(object sender, EventArgs e)
        {
            string messageContent = txtMessage.Text.Trim();
            if (string.IsNullOrEmpty(messageContent))
            {
                MessageBox.Show("Message cannot be empty.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (selectedGroupId <= 0)
            {
                MessageBox.Show("Please select a group.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var newMessage = new GroupMessage
                {
                    GroupID = selectedGroupId,
                    SenderID = id,
                    Content = messageContent,
                    MessageType = "text",
                    Timestamp = DateTime.Now
                };

                db.GroupMessages.Add(newMessage);
                db.SaveChanges();

                //if (!string.IsNullOrEmpty(selectedBase64Image))
                //{
                //    var newAttachment = new Attachment
                //    {
                //        MessageID = newMessage.MessageID, // Liên kết với ID tin nhắn
                //        FilePath = selectedBase64Image,   // Lưu Base64 của ảnh
                //        FileType = "image/png"           // Định dạng file
                //    };

                //    db.Attachments.Add(newAttachment);
                //    db.SaveChanges();
                //}

                AppendMessageToRichTextBox(this.user.Username, messageContent, DateTime.Now);

                //if (!string.IsNullOrEmpty(selectedBase64Image))
                //{
                //    DisplayImageInRichTextBox(selectedBase64Image);
                //}

                txtMessage.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvGroups_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowSelected = e.RowIndex;
            selectedGroupId = selectedGroupId = Convert.ToInt32(dgvGroups.Rows[rowSelected].Cells["GroupID"].Value);
            LoadGroupMessages(selectedGroupId);
            var groupSelected = db.Groups.FirstOrDefault(group => group.GroupID == selectedGroupId);
            if (groupSelected != null)
            {
                lbGroupName.Text = groupSelected.GroupName;
                ImageUtils.LoadImageFromUrlAsync(picGroup, groupSelected.GroupImage);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void pic_User_Click(object sender, EventArgs e)
        {

        }

        private void btn_LogOut_Click(object sender, EventArgs e)
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

        private void btnClose_MouseHover(object sender, EventArgs e)
        {
            btnClose.Image = global::WindowsFormsApp1.Properties.Resources.Close_Hover;
        }

        private void btnClose_MouseLeave(object sender, EventArgs e)
        {
            btnClose.Image = global::WindowsFormsApp1.Properties.Resources.Close;
        }

        private void btnClose_MouseClick(object sender, MouseEventArgs e)
        {
            this.Close();
        }

        private void btnNoti_Click(object sender, EventArgs e)
        {

        }

        private void btnPicture_Click(object sender, EventArgs e)
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

                        var newMessage = new GroupMessage
                        {
                            GroupID = selectedGroupId,
                            SenderID = id,
                            Content = base64Image,
                            MessageType = "image",
                            Timestamp = DateTime.Now
                        };

                        db.GroupMessages.Add(newMessage);
                        db.SaveChanges();


                        // Chuyển việc sao chép ảnh vào Clipboard sang UI thread
                        this.Invoke(new Action(() =>
                        {
                            // Chèn hình ảnh vào RichTextBox
                            DisplayImageInRichTextBox(this.user.Username, selectedBase64Image, DateTime.Now);
                        }));
                        // Display image in txtMessage
                    }
                }
            });
            dialogThread.SetApartmentState(ApartmentState.STA);
            dialogThread.Start();
        }

        //Kéo thả form
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

        private void btnLove_Click(object sender, EventArgs e)
        {

        }
    }
}
