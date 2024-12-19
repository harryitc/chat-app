using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.models;

namespace WindowsFormsApp1
{
    public partial class frm_ChatBox : Form
    {
        private int id;
        private int selectedGroupId;
        public frm_ChatBox(int userID)
        {
            InitializeComponent();
            this.id = userID;
        }

        private void frm_ChatBox_Load(object sender, EventArgs e)
        {
            ChatAppDBContext db = new ChatAppDBContext();
            List<User> users = db.Users.ToList();

            var user = users.FirstOrDefault(s=>s.UserID == id);
            var listFriends = db.Friendships.Where(friend => friend.RequesterID == id && friend.Status == "accepted").ToList();
            
            lblWelcome.Text = $"Welcome: {user.Username}";
            for (int i = 0; i < listFriends.Count; i++)
            {
                dgvFriends.Rows.Add(listFriends[i].User.Username, listFriends[i].User.Status);
            }

            //Groups
            List<GroupMember> members = new List<GroupMember>();
            var group = db.GroupMembers.Where(g => g.UserID == id).ToList();
            for (int i = 0; i < group.Count; i++)
            {
                dgvGroups.Rows.Add(group[i].Group.GroupName);
            }

            //tải tin nhắn vào rtbDialog
            using (ChatAppDBContext dbChat = new ChatAppDBContext())
            {
                var groups = dbChat.GroupMembers
                    .Where(g => g.UserID == id)
                    .Select(g => g.Group)
                    .ToList();

                dgvGroups.Columns.Clear();
                dgvGroups.Columns.Add("GroupID", "Group ID");
                dgvGroups.Columns["GroupID"].Visible = false; // Ẩn cột GroupID
                dgvGroups.Columns.Add("GroupName", "Group Name");

                foreach (var i in groups)
                {
                    dgvGroups.Rows.Add(i.GroupID, i.GroupName);
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ChatAppDBContext db = new ChatAppDBContext();
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
            frm_GroupCreator groupCreator = new frm_GroupCreator();
            groupCreator.ShowDialog();
        }

        private void LoadGroupMessages(int groupId)
        {
            using (ChatAppDBContext db = new ChatAppDBContext())
            {
                var messages = db.GroupMessages
                    .Where(msg => msg.GroupID == groupId)
                    .OrderBy(msg => msg.Timestamp)
                    .Select(msg => new
                    {
                        SenderName = msg.User.Username, // Liên kết với bảng User
                        msg.Content,
                        msg.Timestamp
                    })
                    .ToList();

                rtbDialog.Clear();
                foreach (var message in messages)
                {
                    AppendMessageToRichTextBox(message.SenderName, message.Content, message.Timestamp);
                }
            }
        }

        private void AppendMessageToRichTextBox(string senderName, string content, DateTime? timestamp)
        {
            string formattedMessage = $"[{timestamp:yyyy-MM-dd HH:mm:ss}] {senderName}: {content}\n";

            // Định dạng tùy chỉnh cho tin nhắn của người gửi
            rtbDialog.SelectionStart = rtbDialog.TextLength;
            rtbDialog.SelectionLength = 0;

            if (senderName == "Me") // Tin nhắn của bản thân
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

            try
            {
                using (ChatAppDBContext db = new ChatAppDBContext())
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
                }

                AppendMessageToRichTextBox("Me", messageContent, DateTime.Now);
                txtMessage.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvGroups_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvGroups.SelectedRows.Count > 0)
            {
                // Lấy GroupID từ cột đầu tiên
                selectedGroupId = Convert.ToInt32(dgvGroups.SelectedRows[0].Cells["GroupID"].Value);

                // Gọi hàm để tải tin nhắn
                LoadGroupMessages(selectedGroupId);
            }
        }

        private void dgvGroups_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvGroups.SelectedRows.Count > 0)
            {
                // Lấy GroupID từ cột đầu tiên
                selectedGroupId = Convert.ToInt32(dgvGroups.SelectedRows[0].Cells["GroupID"].Value);

                // Gọi hàm để tải tin nhắn
                LoadGroupMessages(selectedGroupId);
            }
        }
    }
}
