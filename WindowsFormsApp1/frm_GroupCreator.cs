using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using WindowsFormsApp1.models;

namespace WindowsFormsApp1
{
    public partial class frm_GroupCreator : Form
    {
        ChatAppDBContext db = new ChatAppDBContext();
        public int UserId { get; set; } // ID của người dùng hiện tại
        //public Action<Group> OnGroupCreated; // Callback để cập nhật frm_ChatBox

        public frm_GroupCreator(int userID)
        {
            InitializeComponent();
            UserId = userID;
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            try
            {
                string groupName = txtGroupName.Text.Trim();
                string groupDescription = txtNote.Text.Trim();

                if (string.IsNullOrEmpty(groupName))
                {
                    MessageBox.Show("Group name is required!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Thêm nhóm vào bảng Groups
                var newGroup = new Group
                {
                    GroupName = groupName,
                    GroupDescription = groupDescription,
                    CreatedBy = UserId,
                    CreatedAt = DateTime.Now
                };

                db.Groups.Add(newGroup);
                db.SaveChanges();

                var newGroupMember = new GroupMember
                {
                    GroupID = newGroup.GroupID,
                    UserID = UserId,
                    Role = "Admin",
                    JoinedAt = DateTime.Now,
                    LastSeen = DateTime.Now,
                };

                db.GroupMembers.Add(newGroupMember);
                db.SaveChanges();

                //// Gọi callback để cập nhật dgvGroups trong frm_ChatBox
                //OnGroupCreated?.Invoke(newGroup);

                MessageBox.Show("Group created successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Group created Failed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.No;
            }
            finally
            {
                // Đóng form sau khi tạo nhóm
                this.Close();
            }

        }
    }
}
