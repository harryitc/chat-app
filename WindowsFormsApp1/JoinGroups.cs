using Comunicator;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Models;

namespace WindowsFormsApp1
{
    public partial class JoinGroups : Form
    {
        private User requestID;

        // Khai báo sự kiện
        public event EventHandler<GroupMember> DataSent;

        public JoinGroups(User u)
        {
            InitializeComponent();
            this.requestID = u;
        }

        private void JoinGroups_Load(object sender, EventArgs e)
        {
            txtGroupNames.Enabled = false;
            btnJoin.Enabled = false;
        }

        private Group findGroup(string groupName)
        {
            ChatAppDBContext dBContext = new ChatAppDBContext();
            var group = dBContext.Groups.ToList();
            if (txtGroupID.Text != null)
            {
                foreach (var item in group)
                {
                    if (item.GroupID == int.Parse(txtGroupID.Text))
                    {
                        return item;
                    }
                }
            }
            return null;
        }

        private void txtGroupID_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if ((txtGroupID.Text.Trim().Length <= 0))
                {
                    txtGroupNames.Text = "";
                    btnJoin.Enabled = false;
                    return;
                }
                ChatAppDBContext dBContext = new ChatAppDBContext();
                var group = dBContext.Groups.ToList();
                var find = findGroup(txtGroupID.Text);
                if (find != null)
                {
                    txtGroupNames.Text = find.GroupName;
                    btnJoin.Enabled = true;
                }
                else
                {
                    txtGroupNames.Text = "";
                    btnJoin.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnJoin_Click(object sender, EventArgs e)
        {
            try
            {
                ChatAppDBContext dBContext = new ChatAppDBContext();
                var find = findGroup(txtGroupID.Text);
                GroupMember member = new GroupMember
                {
                    GroupID = find.GroupID,
                    UserID = requestID.UserID,
                    Role = UserRole.MEMBER,
                    JoinedAt = DateTime.Now,
                };

                var newMember = dBContext.GroupMembers.Add(member);
                dBContext.SaveChanges();

                MessageBox.Show("Join this group successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Kích hoạt sự kiện và truyền dữ liệu
                DataSent?.Invoke(this, newMember);

                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
