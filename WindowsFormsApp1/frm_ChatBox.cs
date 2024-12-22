using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Windows.Forms;
using WindowsFormsApp1.Models;

using Newtonsoft.Json.Linq;

using WindowsFormsApp1.utils;
using Newtonsoft.Json;

using Comunicator;

namespace WindowsFormsApp1
{
    public partial class frm_ChatBox : Form
    {
        private int selectedGroupId;
        ChatAppDBContext db = new ChatAppDBContext();

        User user = new User();

        private string serverIp = "127.0.0.1";
        private int serverPort = 8888;

        private TcpClient client;
        private NetworkStream stream;

        public frm_ChatBox(User user)
        {
            InitializeComponent();
            this.user = user;
            ConnectToServer(this.serverIp, this.serverPort);
            this.KeyPreview = true; 
            this.KeyDown += frm_ChatBox_KeyDown;
        }

        private void ConnectToServer(string serverIp, int serverPort)
        {
            try
            {
                client = new TcpClient(serverIp, serverPort);
                stream = client.GetStream();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tạo ip + port client " + ex.Message);
                return;
            }
            // Listen for incoming messages
            Thread thread = new Thread(ReceiveMessages);
            thread.IsBackground = true;
            thread.Start();
        }

        private void ReceiveMessages()
        {
            byte[] buffer = new byte[4096];
            while (true)
            {

                string receivedData = "";
                try
                {
                    int bytesRead = stream.Read(buffer, 0, buffer.Length);

                    receivedData = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                    //MessageBox.Show(message);
                }
                catch
                {
                    MessageBox.Show("Disconnected from server.");
                    break;
                }


                JObject json = JObject.Parse(receivedData);
                string type = json["Type"].ToString();

                switch (type)
                {
                    case EventType.SEND_MESSAGE:
                        HandleMessage(json["Data"].ToObject<GroupMessage>());
                        break;
                    case "addFriend":
                        //HandleAddFriend(json["Data"].ToObject<FriendRequestData>());
                        break;
                    case "groupAction":
                        //HandleGroupAction(json["Data"].ToObject<GroupActionData>());
                        break;
                    default:
                        MessageBox.Show($"Unknown type: {type}");
                        break;
                }
            }
        }

        private void HandleMessage(GroupMessage groupMessage)
        {
            var userRequest = this.db.GroupMessages.FirstOrDefault(x =>
            x.MessageID == groupMessage.MessageID &&
            x.GroupID == groupMessage.GroupID &&
            this.selectedGroupId == groupMessage.GroupID
            );

            if (userRequest != null)
            {
                Invoke(new Action(() =>
                {
                    if (groupMessage.MessageType == "text")
                    {
                        AppendMessageToRichTextBox(userRequest.User.Username, groupMessage.Content, groupMessage.Timestamp);
                    }
                    else if (groupMessage.MessageType == "image")
                    {
                        DisplayImageInRichTextBox(userRequest.User.Username, groupMessage.Content, groupMessage.Timestamp);
                    }
                }));
            }
            else
            {
                //MessageBox.Show("UserRequest bi null roi: " + message);
            }
        }

        private void frm_ChatBox_Load(object sender, EventArgs e)
        {

            String imageURL = user.ProfilePicture ?? "";
            ImageUtils.LoadImageFromUrlAsync(pic_User, imageURL);
            /*if (imageURL == null || imageURL == "")
            {
                string defaultImageURL = "https://www.google.com/url?sa=i&url=https%3A%2F%2Ficonduck.com%2Ficons%2F160691%2Favatar-default-symbolic&psig=AOvVaw3zQnn0x2TaO84oqw14Ndsh&ust=1734682587593000&source=images&cd=vfe&opi=89978449&ved=0CBEQjRxqFwoTCLityK6ys4oDFQAAAAAdAAAAABAE";
                ImageUtils.LoadImageFromUrlAsync(pic_User, defaultImageURL);
            }
            else
            {

            }*/
            var listFriends = db.Friendships.Where(friend => friend.RequesterID == this.user.UserID && friend.Status == "accepted").ToList();

            lblWelcome.Text = $"{user.Username}";
            for (int i = 0; i < listFriends.Count; i++)
            {
                dgvFriends.Rows.Add(listFriends[i].User.Username, listFriends[i].User.Status);
            }

            dgvGroups.Columns.Add("GroupID", "Group ID");
            dgvGroups.Columns["GroupID"].Visible = false; // Ẩn cột GroupID
            dgvGroups.Columns.Add("GroupName", "Group Name");
            dgvGroups.Columns.Add("role", "Role");
            dgvGroups.Columns.Add("sl", "Quantity");


            //Groups
            var groupMembers = db.GroupMembers.Where(g => g.UserID == user.UserID).ToList();
            var groupMemberWithoutUserID = db.GroupMembers.ToList();
            foreach (var groupMember in groupMembers)
            {
                int sl = groupMemberWithoutUserID.Where(item => item.GroupID == groupMember.GroupID).Count();
                dgvGroups.Rows.Add(groupMember.GroupID, groupMember.Group.GroupName, groupMember.Role, sl);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string request = txtReceiver.Text;
            List<User> users = db.Users.ToList();
            var requestIDFound = users.FirstOrDefault(u => this.user.Username == u.Username);
            if (requestIDFound != null)
            {
                Friendship addfr = new Friendship();
                addfr.AddressID = requestIDFound.UserID;
                addfr.RequesterID = this.user.UserID;
                addfr.Status = "accepted";
                addfr.CreatedAt = DateTime.Now;
                MessageBox.Show("Đã gửi kết bạn thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                db.Friendships.Add(addfr);
                db.SaveChanges();

                //lbNoti.Text = (info + 1).ToString();
            }
            else
            {
                MessageBox.Show("Người dùng không tồn tại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void btnCreateGroup_Click(object sender, EventArgs e)
        {
            frm_GroupCreator groupCreator = new frm_GroupCreator(this.user.UserID);
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
            var groupMembers = db.GroupMembers.Where(g => g.UserID == user.UserID).ToList();
            var groupMemberWithoutUserID = db.GroupMembers.ToList();
            foreach (var groupMember in groupMembers)
            {
                int sl = groupMemberWithoutUserID.Where(item => item.GroupID == groupMember.GroupID).Count();
                dgvGroups.Rows.Add(groupMember.GroupID, groupMember.Group.GroupName, groupMember.Role, sl);
            }
        }

        private void LoadGroupMessages(int groupId)
        {
            var messages = db.GroupMessages
                .Where(msg => msg.GroupID == groupId)
                .OrderBy(msg => msg.Timestamp)
                //.Select(msg => new
                //{
                //    SenderName = msg.User.Username, // Liên kết với bảng User
                //    msg.Content,
                //    msg.Timestamp
                //})
                .ToList();

            rtbDialog.Clear();
            foreach (var message in messages)
            {
                if (message.MessageType == "text")
                {
                    AppendMessageToRichTextBox(message.User.Username, message.Content, message.Timestamp);
                }
                else if (message.MessageType == "image")
                {
                    DisplayImageInRichTextBox(message.User.Username, message.Content, message.Timestamp);
                }
            }
        }
        private void AppendMessageToRichTextBox(string senderName, string content, DateTime? timestamp)
        {
            rtbDialog.BeginInvoke(new MethodInvoker(() =>
            {
                Font currentFont = rtbDialog.SelectionFont;

                rtbDialog.AppendText($"[{timestamp:yyyy-MM-dd HH:mm:ss}]");

                //Username
                rtbDialog.SelectionStart = rtbDialog.TextLength;
                rtbDialog.SelectionLength = 0;
                rtbDialog.SelectionColor = Color.Red;
                rtbDialog.SelectionFont = new Font(currentFont.FontFamily, currentFont.Size, FontStyle.Bold);
                rtbDialog.AppendText(senderName);
                rtbDialog.SelectionColor = rtbDialog.ForeColor;

                if (senderName == this.user.Username) // Tin nhắn của bản thân
                {
                    rtbDialog.SelectionColor = Color.DarkBlue;
                }

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

                if (senderName == this.user.Username) // Tin nhắn của bản thân
                {
                    rtbDialog.SelectionAlignment = HorizontalAlignment.Right;
                }
                else rtbDialog.SelectionAlignment = HorizontalAlignment.Left;

                rtbDialog.AppendText(Environment.NewLine);
            }));
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
                                   //this.Invoke(new Action(() =>
                                   // {
                                   Clipboard.Clear();
                                   Clipboard.SetImage(image);
                                   //}));
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

        private void performSendMessage()
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


            // Bao bọc đối tượng trong một RequestWrapper
            var request = new
            {
                Type = EventType.SEND_MESSAGE,
                Data = new GroupMessage
                {
                    GroupID = selectedGroupId,
                    SenderID = this.user.UserID,
                    Content = messageContent,
                    MessageType = "text",
                    Timestamp = DateTime.Now,
                }
            };

            try
            {
                // Chuyển đối tượng thành JSON
                string jsonData = JsonConvert.SerializeObject(request);
                byte[] buffer = Encoding.UTF8.GetBytes(jsonData);

                // Gửi dữ liệu
                stream.Write(buffer, 0, buffer.Length);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //PrintJson(ex);
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            this.performSendMessage();
        }

        private void dgvGroups_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowSelected = e.RowIndex;
            selectedGroupId = selectedGroupId = Convert.ToInt32(dgvGroups.Rows[rowSelected].Cells["GroupID"].Value);
            LoadGroupMessages(selectedGroupId);
            var groupSelected = db.Groups.FirstOrDefault(group => group.GroupID == selectedGroupId);
            if (groupSelected != null)
            {
                lbGroupName.Text = groupSelected.GroupName ?? "";
                ImageUtils.LoadImageFromUrlAsync(picGroup, groupSelected.GroupImage ?? "");
            }

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
                client.Close();
                stream.Close();
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
            Notification noti = new Notification();
            noti.Show();
        }

        private void btnJoinGroup_Click(object sender, EventArgs e)
        {
            JoinGroups joinGroups = new JoinGroups(this.user);
            joinGroups.ShowDialog();
            if (DialogResult.OK == joinGroups.DialogResult)
            {
                loadListGroup();
            }
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


                        // Bao bọc đối tượng trong một RequestWrapper
                        var request = new
                        {
                            Type = EventType.SEND_MESSAGE,
                            Data = new GroupMessage
                            {
                                GroupID = selectedGroupId,
                                SenderID = this.user.UserID,
                                Content = base64Image,
                                MessageType = "image",
                                Timestamp = DateTime.Now
                            }
                        };

                        try
                        {
                            // Chuyển đối tượng thành JSON
                            string jsonData = JsonConvert.SerializeObject(request);
                            byte[] buffer = Encoding.UTF8.GetBytes(jsonData);

                            // Gửi dữ liệu
                            stream.Write(buffer, 0, buffer.Length);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                            //PrintJson(ex);
                        }
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

        private void btnLove_Click(object sender, EventArgs e)
        {

        }

        private void frm_ChatBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) 
            {
                this.performSendMessage();
            }
        }
    }
}
