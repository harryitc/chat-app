using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using DAL;
using DAL.Config;

namespace Client
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
            this.KeyPreview = true;
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

        private void performJoin()
        {
            try
            {
                ChatAppDBContext dBContext = new ChatAppDBContext();
                var find = findGroup(txtGroupID.Text);
                var findMember = dBContext.GroupMembers.FirstOrDefault(p => p.UserID == requestID.UserID);
                if (findMember != null)
                {
                    MessageBox.Show("You are already in this group!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning); 
                    return;
                }
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

        private void btnJoin_Click(object sender, EventArgs e)
        {
            this.performJoin();
        }

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

        private void btnClose_MouseHover(object sender, EventArgs e)
        {
            btnClose.Image = global::Client.Properties.Resources.Close_Hover;
        }

        private void btnClose_MouseLeave(object sender, EventArgs e)
        {
            btnClose.Image = global::Client.Properties.Resources.Close;
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void JoinGroups_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.performJoin();
            }
        }
    }
}
