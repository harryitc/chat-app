﻿using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Comunicator.Models;

using Newtonsoft.Json.Linq;

using Client.utils;
using Newtonsoft.Json;

using Comunicator;
using System.Data.Entity;
using System.Runtime.Remoting.Messaging;

namespace Client
{
    public partial class frm_ChatBox : Form
    {
        private int selectedGroupId;

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

            this.TriggerStatusLogin(StatusLogin.ONLINE);
        }

        private void TriggerStatusLogin(string status)
        {
            using (ChatAppDBContext context = new ChatAppDBContext())
            {
                // Bao bọc đối tượng trong một RequestWrapper
                try
                {
                    var userFound = context.Users.FirstOrDefault(user => user.UserID == this.user.UserID);
                    if (userFound == null) return;

                    context.Users.Attach(userFound);
                    userFound.Status = status;
                    context.SaveChanges();

                    this.user = userFound;

                    var request = new
                    {
                        Type = EventType.STATUS_LOGIN,
                        Data = new User
                        {
                            UserID = userFound.UserID,
                            Username = userFound.Username,
                            Status = userFound.Status,
                            CreatedAt = userFound.CreatedAt,
                            Password = userFound.Password,
                            Email = userFound.Email,
                            ProfilePicture = userFound.ProfilePicture
                        }
                    };

                    // Chuyển đối tượng thành JSON
                    string jsonData = JsonConvert.SerializeObject(request);
                    byte[] buffer = Encoding.UTF8.GetBytes(jsonData);

                    //HandleEventLogin(request.Data, true);

                    // Gửi dữ liệu
                    stream.Write(buffer, 0, buffer.Length);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                    //PrintJson(ex);
                }
            }
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
                MessageBox.Show("Lỗi khởi tạo ứng dựng REALTIME. Đừng lo, vẫn hoạt động bình thường!" + ex.Message);
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
                    //MessageBox.Show("Disconnected from server.");
                    break;
                }


                JObject json = JObject.Parse(receivedData);
                string type = json["Type"].ToString();

                switch (type)
                {
                    case EventType.SEND_MESSAGE:
                        HandleEventMessage(json["Data"].ToObject<GroupMessage>());
                        break;
                    case EventType.JOIN_GROUP:
                        HandleEventJoinGroup(json["Data"].ToObject<GroupMember>());
                        break;
                    case EventType.STATUS_LOGIN:
                        HandleEventStatusAccount(json["Data"].ToObject<User>());
                        break;
                    case EventType.FRIENDSHIPS:
                        HandleEventAddFriend(json["Data"].ToObject<Friendship>());
                        break;
                    case EventType.NOTI_FRIENDSHIPS:
                        HandleEventNotiFriend(json["Data"].ToObject<Friendship>());
                        break;
                    default:
                        MessageBox.Show($"Unknown type: {type}");
                        break;
                }
            }
        }

        private void HandleEventNotiFriend(Friendship friendship, bool isSendForMe = false)
        {

            if (!isSendForMe && !CanUserAccepted(friendship.AddressID))
            {
                return;
            }

            using (ChatAppDBContext context = new ChatAppDBContext())
            {
                var userFound = context.Users.FirstOrDefault(user => user.UserID == friendship.AddressID);
                if (userFound != null)
                {
                    bool isOffline = userFound.Status == StatusLogin.OFFLINE;
                    if (isOffline) return;
                }
                else
                {
                    return;
                }
            }
            this.updateNotifi(friendship.Status);
        }

        private void HandleEventStatusAccount(User friend, bool isSendForMe = false)
        {

            using (ChatAppDBContext context = new ChatAppDBContext())
            {
                var userFound = context.Users.FirstOrDefault(p => p.UserID == user.UserID);
                if (userFound == null)
                {
                    return;
                }

                foreach (DataGridViewRow row in this.dgvFriends.Rows)
                {
                    if (row.Cells["UserID"].Value.ToString() == friend.UserID.ToString())
                    {
                        row.Cells["Status"].Value = friend.Status;
                        break;
                    }
                }
            }
        }

        private void HandleEventJoinGroup(GroupMember groupMember, bool isSendForMe = false)
        {

            using (ChatAppDBContext context = new ChatAppDBContext())
            {
                var groupMemberWithoutUserID = context.GroupMembers.ToList();
                if (!isSendForMe)
                {

                    var userFoundInGroup = context.GroupMembers.FirstOrDefault(
                            p => p.GroupID == groupMember.GroupID &&
                            p.UserID == this.user.UserID
                            );
                    if (userFoundInGroup == null)
                    {
                        return;
                    }

                    foreach (DataGridViewRow row in this.dgvGroups.Rows)
                    {
                        if (row.Cells[0].Value.ToString() == groupMember.GroupID.ToString())
                        {
                            int sl = groupMemberWithoutUserID.Where(item => item.GroupID == groupMember.GroupID).Count();
                            row.Cells["sl"].Value = sl.ToString();
                            break;
                        }
                    }
                }
                else
                {
                    var groupFound = context.Groups.FirstOrDefault(group => group.GroupID == groupMember.GroupID);
                    if (groupFound == null) return;
                    int sl = groupMemberWithoutUserID.Where(item => item.GroupID == groupMember.GroupID).Count();
                    this.dgvGroups.Rows.Add(groupMember.GroupID, groupFound.GroupName, groupMember.Role, sl);
                }
            }
        }

        private void HandleEventMessage(GroupMessage groupMessage, bool isSendForMe = false)
        {

            using (ChatAppDBContext context = new ChatAppDBContext())
            {

                var userRequest = context.GroupMessages.FirstOrDefault(x =>
                x.MessageID == groupMessage.MessageID &&
                x.GroupID == groupMessage.GroupID &&
                this.selectedGroupId == groupMessage.GroupID
                );

                if (userRequest != null)
                {
                    Invoke(new Action(() =>
                    {
                        if (userRequest.MessageType == "text")
                        {
                            AppendMessageToRichTextBox(userRequest.User.Username, userRequest.Content, userRequest.Timestamp);
                        }
                        else if (userRequest.MessageType == "image")
                        {
                            DisplayImageInRichTextBox(userRequest.User.Username, userRequest.Content, userRequest.Timestamp);
                        }
                    }));
                }
                else
                {
                    //MessageBox.Show("UserRequest bi null roi: " + message);
                }
            }

        }

        private void HandleEventAddFriend(Friendship friendRequest, bool isSendForMe = false)
        {

            using (ChatAppDBContext context = new ChatAppDBContext())
            {

                if (friendRequest.Status == StatusFriend.DENIED)
                {
                    return;
                }

                //var friendships = context.Friendships.Where(p => p.AddressID == friendRequest.AddressID && p.Status == StatusFriend.ACCEPTED);

                if (!isSendForMe)
                {
                    if (this.user.UserID != friendRequest.RequesterID) return;
                    var userFound = context.Users.FirstOrDefault(f => f.UserID == friendRequest.AddressID);
                    if (userFound == null) return;
                    this.dgvFriends.Rows.Add(userFound.UserID, userFound.Username, userFound.Status);
                }
                else
                {
                    var userFound = context.Users.FirstOrDefault(f => f.UserID == friendRequest.RequesterID);
                    if (userFound == null) return;
                    this.dgvFriends.Rows.Add(userFound.UserID, userFound.Username, userFound.Status);
                }

                this.updateNotifi(friendRequest.Status);

            }
        }

        private bool CanUserAccepted(int userID)
        {
            return this.user.UserID == userID;
        }


        private void frm_ChatBox_Load(object sender, EventArgs e)
        {

            String imageURL = user.ProfilePicture ?? "";
            ImageUtils.LoadImageFromUrlAsync(pic_User, imageURL);

            using (ChatAppDBContext context = new ChatAppDBContext())
            {
                var listFriendsAccepted = context.Friendships.Where(friend => friend.Status == StatusFriend.ACCEPTED).ToList();
                var listFriends = listFriendsAccepted.Where(item => item.RequesterID == this.user.UserID || item.AddressID == this.user.UserID);
                //var usersOnline = context.Users.Where(user =>
                //    user.Status != StatusLogin.OFFLINE
                //);
                var users = context.Users.ToList();
                // Users
                lblWelcome.Text = $"{user.Username}";
                dgvFriends.Columns.Add("UserID", "User ID");
                dgvFriends.Columns["UserID"].Visible = false; // Ẩn cột UserID
                dgvFriends.Columns.Add("Username", "Username");
                dgvFriends.Columns.Add("Status", "Status");

                foreach (var friend in listFriends)
                {
                    var friendFound = users.FirstOrDefault(x => (x.UserID == friend.AddressID || x.UserID == friend.RequesterID) && x.UserID != this.user.UserID);
                    if (friendFound != null)
                    {
                        dgvFriends.Rows.Add(friendFound.UserID, friendFound.Username, friendFound.Status);
                    }
                }

                dgvGroups.Columns.Add("GroupID", "Group ID");
                dgvGroups.Columns["GroupID"].Visible = false; // Ẩn cột GroupID
                dgvGroups.Columns.Add("GroupName", "Group Name");
                dgvGroups.Columns.Add("role", "Role");
                dgvGroups.Columns.Add("sl", "Quantity");


                //Groups
                var groupMembers = context.GroupMembers.Where(g => g.UserID == user.UserID).ToList();
                var groupMemberWithoutUserID = context.GroupMembers.ToList();
                foreach (var groupMember in groupMembers)
                {
                    int sl = groupMemberWithoutUserID.Where(item => item.GroupID == groupMember.GroupID).Count();
                    dgvGroups.Rows.Add(groupMember.GroupID, groupMember.Group.GroupName, groupMember.Role, sl);
                }

                // notifi
                int countNotifi = context.Friendships.Where(p =>
                p.Status == StatusFriend.PENDING &&
                 this.user.UserID == p.AddressID
                ).Count();

                this.lbNoti.Text = countNotifi.ToString();

            }

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (ChatAppDBContext context = new ChatAppDBContext())
            {
                string receiverUsername = txtReceiver.Text.Trim();

                var receiver = context.Users.FirstOrDefault(u => u.Username == receiverUsername);
                if (receiver == null)
                {
                    MessageBox.Show("Người dùng không tồn tại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (receiver.UserID == this.user.UserID)
                {
                    MessageBox.Show("Không thể thêm bạn bè Chính bản thân", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                var existingFriendship = context.Friendships
                    .FirstOrDefault(f =>
                        (f.RequesterID == this.user.UserID && f.AddressID == receiver.UserID) ||
                        (f.RequesterID == receiver.UserID && f.AddressID == this.user.UserID));

                if (existingFriendship != null)
                {
                    MessageBox.Show("Bạn đã gửi hoặc nhận lời mời kết bạn từ người dùng này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                Friendship newFriendship = new Friendship
                {
                    AddressID = receiver.UserID,
                    RequesterID = this.user.UserID,
                    Status = StatusFriend.PENDING,
                    CreatedAt = DateTime.Now
                };

                var response = context.Friendships.Add(newFriendship);
                context.SaveChanges();

                MessageBox.Show("Đã gửi kết bạn thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Bao bọc đối tượng trong một RequestWrapper
                try
                {
                    var request = new
                    {
                        Type = EventType.NOTI_FRIENDSHIPS,
                        Data = new Friendship
                        {
                            FriendshipID = response.FriendshipID,
                            AddressID = response.AddressID,
                            RequesterID = response.RequesterID,
                            Status = response.Status,
                            CreatedAt = response.CreatedAt,
                        }
                    };

                    // Chuyển đối tượng thành JSON
                    string jsonData = JsonConvert.SerializeObject(request);
                    byte[] buffer = Encoding.UTF8.GetBytes(jsonData);

                    //HandleEventNotiFriend(request.Data, true);

                    // Gửi dữ liệu
                    stream.Write(buffer, 0, buffer.Length);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                    //PrintJson(ex);
                }

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

            using (ChatAppDBContext context = new ChatAppDBContext())
            {
                var groupMembers = context.GroupMembers.Where(g => g.UserID == user.UserID).ToList();
                var groupMemberWithoutUserID = context.GroupMembers.ToList();
                foreach (var groupMember in groupMembers)
                {
                    int sl = groupMemberWithoutUserID.Where(item => item.GroupID == groupMember.GroupID).Count();
                    dgvGroups.Rows.Add(groupMember.GroupID, groupMember.Group.GroupName, groupMember.Role, sl);
                }
            }
        }

        private void LoadGroupMessages(int groupId)
        {
            using (ChatAppDBContext context = new ChatAppDBContext())
            {
                var messages = context.GroupMessages
                .Where(msg => msg.GroupID == groupId)
                .OrderBy(msg => msg.Timestamp)
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


            using (ChatAppDBContext context = new ChatAppDBContext())
            {
                // Bao bọc đối tượng trong một RequestWrapper
                try
                {
                    var response = context.GroupMessages.Add(new GroupMessage
                    {
                        GroupID = selectedGroupId,
                        SenderID = this.user.UserID,
                        Content = messageContent,
                        MessageType = "text",
                        Timestamp = DateTime.Now,
                    });

                    context.SaveChanges();

                    var request = new
                    {
                        Type = EventType.SEND_MESSAGE,
                        Data = new GroupMessage
                        {
                            MessageID = response.MessageID,
                            GroupID = response.GroupID
                        }
                    };

                    // Chuyển đối tượng thành JSON
                    string jsonData = JsonConvert.SerializeObject(request);
                    byte[] buffer = Encoding.UTF8.GetBytes(jsonData);

                    HandleEventMessage(request.Data, true);

                    // Gửi dữ liệu
                    stream.Write(buffer, 0, buffer.Length);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                    //PrintJson(ex);
                }
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            this.performSendMessage();
        }

        public static T DeepClone<T>(T obj)
        {
            var json = JsonConvert.SerializeObject(obj, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            return JsonConvert.DeserializeObject<T>(json);
        }

        private void dgvGroups_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowSelected = e.RowIndex;
            selectedGroupId = selectedGroupId = Convert.ToInt32(dgvGroups.Rows[rowSelected].Cells["GroupID"].Value);
            LoadGroupMessages(selectedGroupId);

            using (ChatAppDBContext context = new ChatAppDBContext())
            {
                var groupSelected = context.Groups.FirstOrDefault(group => group.GroupID == selectedGroupId);
                if (groupSelected != null)
                {
                    lbGroupName.Text = groupSelected.GroupName ?? "";
                    ImageUtils.LoadImageFromUrlAsync(picGroup, groupSelected.GroupImage ?? "");
                }
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

                this.TriggerStatusLogin(StatusLogin.OFFLINE);

                new Thread(() => Application.Run(new frm_Login())).Start();
                if (client != null && client.Connected)
                {
                    client.Close();
                }
                if (stream != null)
                {
                    stream.Close();
                }
                this.Close();
            }
            else if (result == DialogResult.No)
            {
                //MessageBox.Show("Logout canceled successfully!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnClose_MouseHover(object sender, EventArgs e)
        {
            btnClose.Image = global::Client.Properties.Resources.Close_Hover;
        }

        private void btnClose_MouseLeave(object sender, EventArgs e)
        {
            btnClose.Image = global::Client.Properties.Resources.Close;
        }

        private void btnClose_MouseClick(object sender, MouseEventArgs e)
        {
            TriggerStatusLogin(StatusLogin.OFFLINE);
            this.Close();
        }

        private void btnNoti_Click(object sender, EventArgs e)
        {
            Notification noti = new Notification(this.user);
            noti.DataSent += OnDataNotiReceived;
            noti.Show();
        }

        private void OnDataNotiReceived(object sender, Friendship friend)
        {
            var request = new
            {
                Type = EventType.FRIENDSHIPS,
                Data = new Friendship
                {
                    Status = friend.Status,
                    AddressID = friend.AddressID,
                    CreatedAt = friend.CreatedAt,
                    FriendshipID = friend.FriendshipID,
                    RequesterID = friend.RequesterID,
                }
            };

            this.HandleEventAddFriend(request.Data, true);
            // Bao bọc đối tượng trong một RequestWrapper
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

        private void btnJoinGroup_Click(object sender, EventArgs e)
        {
            JoinGroups joinGroups = new JoinGroups(this.user);

            // Đăng ký sự kiện DataSent từ form con
            joinGroups.DataSent += OnDataReceived;

            joinGroups.ShowDialog();
            //if (DialogResult.OK == joinGroups.DialogResult)
            //{

            //}
        }

        // Xử lý dữ liệu nhận được từ form con
        private void OnDataReceived(object sender, GroupMember groupMember)
        {
            // Bao bọc đối tượng trong một RequestWrapper
            var request = new
            {
                Type = EventType.JOIN_GROUP,
                Data = new GroupMember
                {
                    GroupID = groupMember.GroupID,
                    UserID = groupMember.UserID,
                    MemberID = groupMember.MemberID,
                    Role = groupMember.Role,
                    LastSeen = groupMember.LastSeen,
                    JoinedAt = groupMember.JoinedAt
                }
            };

            try
            {
                HandleEventJoinGroup(request.Data, true);

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



                        using (ChatAppDBContext context = new ChatAppDBContext())
                        {
                            // Bao bọc đối tượng trong một RequestWrapper
                            try
                            {
                                var response = context.GroupMessages.Add(new GroupMessage
                                {
                                    GroupID = selectedGroupId,
                                    SenderID = this.user.UserID,
                                    Content = base64Image,
                                    MessageType = "image",
                                    Timestamp = DateTime.Now
                                });

                                context.SaveChanges();

                                var request = new
                                {
                                    Type = EventType.SEND_MESSAGE,
                                    Data = new GroupMessage
                                    {
                                        MessageID = response.MessageID,
                                        GroupID = response.GroupID
                                    }
                                };

                                // Chuyển đối tượng thành JSON
                                string jsonData = JsonConvert.SerializeObject(request);
                                byte[] buffer = Encoding.UTF8.GetBytes(jsonData);

                                HandleEventMessage(request.Data, true);

                                // Gửi dữ liệu
                                stream.Write(buffer, 0, buffer.Length);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Lỗi: " + ex.Message);
                                //PrintJson(ex);
                            }
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

        private void dgvGroups_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        private async void btnSearchText_Click_1(object sender, EventArgs e)
        {
            string keyword = txtSearchGroup.Text.Trim();

            using (ChatAppDBContext context = new ChatAppDBContext())
            {
                try
                {
                    var groups = await context.GroupMembers
                        .Where(gm => gm.UserID == this.user.UserID) // Chỉ lấy các nhóm mà người dùng hiện tại tham gia
                        .Select(gm => gm.Group) // Lấy thông tin nhóm
                        .Where(g => string.IsNullOrEmpty(keyword) || g.GroupName.Contains(keyword)) // Lọc theo từ khóa
                        .ToListAsync();

                    if (groups.Count == 0)
                    {
                        dgvGroups.Rows.Clear();
                        MessageBox.Show("Không tìm thấy nhóm nào phù hợp.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    dgvGroups.Rows.Clear();
                    foreach (var group in groups)
                    {
                        // Lấy vai trò của người dùng trong nhóm
                        var userRole = context.GroupMembers
                            .Where(gm => gm.GroupID == group.GroupID && gm.UserID == this.user.UserID)
                            .Select(gm => gm.Role)
                            .FirstOrDefault() ?? "Thành viên";

                        int memberCount = context.GroupMembers.Count(gm => gm.GroupID == group.GroupID);

                        dgvGroups.Rows.Add(group.GroupID, group.GroupName, userRole, memberCount);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi tìm kiếm nhóm: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void HighlightMessages(string keyword)
        {
            // Lưu lại vị trí con trỏ hiện tại
            int originalSelectionStart = rtbDialog.SelectionStart;
            int originalSelectionLength = rtbDialog.SelectionLength;

            // Đặt lại tất cả văn bản về màu mặc định
            rtbDialog.SelectAll();
            rtbDialog.SelectionBackColor = rtbDialog.BackColor;

            RemoveAllHighlights();

            // Tìm và highlight các đoạn chứa từ khóa
            int startIndex = 0;
            while ((startIndex = rtbDialog.Text.IndexOf(keyword, startIndex, StringComparison.OrdinalIgnoreCase)) != -1)
            {
                rtbDialog.Select(startIndex, keyword.Length);
                rtbDialog.SelectionBackColor = Color.Yellow;
                startIndex += keyword.Length;
            }

            // Khôi phục vị trí con trỏ
            rtbDialog.Select(originalSelectionStart, originalSelectionLength);
            rtbDialog.SelectionBackColor = rtbDialog.BackColor;
        }

        private void RemoveAllHighlights()
        {
            //Bỏ các highlight cũ
            rtbDialog.SelectAll();
            rtbDialog.SelectionBackColor = rtbDialog.BackColor;

            // Bỏ chọn văn bản
            rtbDialog.Select(0, 0);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string keyword = txtSearchText.Text.Trim();

            if (string.IsNullOrEmpty(keyword))
            {
                //Bỏ highlight nếu từ khóa rỗng
                RemoveAllHighlights();
                return;
            }

            HighlightMessages(keyword);
        }

        private void txtSearchGroup_TextChanged(object sender, EventArgs e)
        {

        }

        private void updateNotifi(string status)
        {
            int count = int.Parse(this.lbNoti.Text);

            switch (status)
            {
                case StatusFriend.ACCEPTED:
                    count -= 1;
                    break;
                case StatusFriend.PENDING:
                    count += 1;
                    break;
            }

            if (count < 0) count = 0;

            this.lbNoti.Text = count.ToString();
        }
    }
}
