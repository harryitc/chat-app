﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using Comunicator;
using Comunicator.Models;

namespace Client
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
            this.KeyPreview = true;
            this.KeyDown += frm_GroupCreator_KeyDown;
        }

        private void performCreate()
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
                    Role = UserRole.ADMIN,
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
                MessageBox.Show("Group created Failed! " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.No;
            }
            finally
            {
                // Đóng form sau khi tạo nhóm
                this.Close();
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            this.performCreate();
        }

        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int HT_CAPTION = 0x2;
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern int GreateGroup(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool ReleaseCapture();

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (e.Clicks == 1 && e.Y <= this.Height && e.Y >= 0)
                {
                    ReleaseCapture();
                    GreateGroup(this.Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
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

        private void frm_GroupCreator_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.performCreate();
            }
        }
    }
}
