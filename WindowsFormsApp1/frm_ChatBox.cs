using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Models;
using WindowsFormsApp1.utils;

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


        }

        private void ConnectToServer(string serverIp, int serverPort)
        {

            //try
            //{
            //    // Kết nối đến server
            //    using (TcpClient client = new TcpClient())
            //    {
            //        Console.WriteLine("Attempting to connect to the server...");

            //        // Thử kết nối với thời gian chờ 5 giây
            //        IAsyncResult result = client.BeginConnect(serverIp, serverPort, null, null);
            //        bool success = result.AsyncWaitHandle.WaitOne(TimeSpan.FromSeconds(5));

            //        if (!success)
            //        {
            //            throw new TimeoutException("Connection to the server timed out.");
            //        }

            //        // Đảm bảo kết nối thành công
            //        client.EndConnect(result);
            //        Console.WriteLine("Connected to the server!");

            //        // Gửi dữ liệu JSON
            //        using (NetworkStream stream = client.GetStream())
            //        {
            //            byte[] buffer = Encoding.UTF8.GetBytes(jsonMessage);
            //            stream.Write(buffer, 0, buffer.Length);
            //            Console.WriteLine("Sent to server: " + jsonMessage);
            //        }
            //    }
            //}
            //catch (SocketException ex)
            //{
            //    Console.WriteLine($"Socket error: {ex.Message}");
            //    Console.WriteLine("Check if the server is running and reachable.");
            //}
            //catch (TimeoutException ex)
            //{
            //    Console.WriteLine($"Timeout error: {ex.Message}");
            //    Console.WriteLine("The server might be too slow or not responding.");
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine($"Unexpected error: {ex.Message}");
            //}
            //finally
            //{
            //    Console.WriteLine("Client connection process completed.");
            //}

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
            byte[] buffer = new byte[1024];
            while (true)
            {
                try
                {
                    int bytesRead = stream.Read(buffer, 0, buffer.Length);

                    string message = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                    //MessageBox.Show(this, message);
                    GroupMessage chatMessage = JsonSerializer.Deserialize<GroupMessage>(message);

                    var userRequest = this.db.GroupMessages.FirstOrDefault(x =>
                    x.MessageID == chatMessage.MessageID
                    );

                    Invoke(new Action(() => AppendMessageToRichTextBox(userRequest.User.Username, chatMessage.Content, chatMessage.Timestamp)));
                }
                catch
                {
                    MessageBox.Show("Disconnected from server.");
                    break;
                }
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

                lbNoti.Text = (info + 1).ToString();
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
                AppendMessageToRichTextBox(message.User.Username, message.Content, message.Timestamp);
            }
        }

        private void AppendMessageToRichTextBox(string senderName, string content, DateTime? timestamp)
        {

            string formattedMessage = $"[{timestamp:yyyy-MM-dd HH:mm:ss}] {senderName}: {content}\n";

            // Định dạng tùy chỉnh cho tin nhắn của người gửi
            rtbDialog.SelectionStart = rtbDialog.TextLength;
            rtbDialog.SelectionLength = 0;

            if (senderName == this.user.Username) // Tin nhắn của bản thân
            {
                rtbDialog.SelectionColor = Color.Blue;
                rtbDialog.SelectionFont = new Font(rtbDialog.Font, FontStyle.Bold);
            }
            else
            {
                rtbDialog.SelectionColor = Color.Black;
                rtbDialog.SelectionFont = rtbDialog.Font;
            }

            rtbDialog.AppendText(formattedMessage);
            rtbDialog.SelectionColor = rtbDialog.ForeColor; // Reset màu

            txtMessage.Clear();

        }

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

            var newMessage = new GroupMessage
            {
                GroupID = selectedGroupId,
                SenderID = this.user.UserID,
                Content = messageContent,
                MessageType = "text",
                Timestamp = DateTime.Now,
            };

            try
            {
                // Serialize đối tượng thành JSON
                string jsonMessage = JsonSerializer.Serialize<GroupMessage>(newMessage);
                byte[] buffer = Encoding.UTF8.GetBytes(jsonMessage);

                stream.Write(buffer, 0, buffer.Length);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //PrintJson(ex);
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
                lbGroupName.Text = groupSelected.GroupName ?? "";
                ImageUtils.LoadImageFromUrlAsync(picGroup, groupSelected.GroupImage ?? "");
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

        private static void PrintJson(object obj)
        {
            MessageBox.Show(JsonSerializer.Serialize(obj, new JsonSerializerOptions { WriteIndented = true }));
        }
    }
}
