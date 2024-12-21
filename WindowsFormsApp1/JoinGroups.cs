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
    public partial class JoinGroups : Form
    {
        private User requestID;
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

        private Group findGroup (string groupName)
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
                GroupMember newmember = new GroupMember();

                newmember.GroupID = find.GroupID;
                newmember.UserID = requestID.UserID;
                newmember.Role = "member";

                dBContext.GroupMembers.Add(newmember);
                dBContext.SaveChanges();
                MessageBox.Show("Join this group successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
