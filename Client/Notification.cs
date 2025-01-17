﻿using System;
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
    public partial class Notification : Form
    {

        // Khai báo sự kiện
        public event EventHandler<Friendship> DataSent;

        public Notification(User user)
        {
            InitializeComponent();
            this.pnUserControl.AutoScroll = true;
            using (ChatAppDBContext context = new ChatAppDBContext())
            {
                List<Friendship> friends = context.Friendships.Where(p =>
                p.Status == StatusFriend.PENDING &&
                user.UserID == p.AddressID
                ).ToList();
                foreach (var friend in friends)
                {
                    NotificationUserControl notificationUserControl = new NotificationUserControl
                    {
                        Dock = DockStyle.Top,
                    };

                    var userRequestFound = context.Users.FirstOrDefault(p => p.UserID == friend.RequesterID);

                    notificationUserControl.lbID.Text = friend.FriendshipID.ToString();
                    notificationUserControl.lbUser.Text = userRequestFound.Username;
                    notificationUserControl.lbStatus.Text = friend.Status;
                    notificationUserControl.btnAccepted.Enabled = true;
                    notificationUserControl.btnDenied.Enabled = true;
                    //notificationUserControl.lbStatusRequest.Text = "Cần phản hồi";

                    // Đăng ký sự kiện
                    notificationUserControl.btnAccepted.Click += (s, e) =>
                    {
                        HandleAccepted(notificationUserControl, int.Parse(notificationUserControl.lbID.Text));
                    };

                    notificationUserControl.btnDenied.Click += (s, e) =>
                    {
                        HandleDenied(notificationUserControl, int.Parse(notificationUserControl.lbID.Text));
                    };

                    this.pnUserControl.Controls.Add(notificationUserControl);
                }

            }
        }

        // Xử lý khi nhấn nút "Accepted"
        private void HandleAccepted(NotificationUserControl control, int friendshipId)
        {
            try
            {
                ChatAppDBContext db = new ChatAppDBContext();
                var friendship = db.Friendships.FirstOrDefault(f => f.FriendshipID == friendshipId);

                if (friendship != null)
                {
                    db.Friendships.Attach(friendship);
                    friendship.Status = StatusFriend.ACCEPTED;
                    db.SaveChanges();
                    control.lbStatus.Text = StatusFriend.ACCEPTED; // Cập nhật trạng thái trên giao diện
                    pnUserControl.Controls.Remove(control); // Loại bỏ UserControl khỏi Panel
                    control.Dispose(); // Giải phóng tài nguyên
                    this.DataSent?.Invoke(this, friendship);
                }
                else
                {
                    MessageBox.Show("Khong the accepted");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // Xử lý khi nhấn nút "Denied"
        private void HandleDenied(NotificationUserControl control, int friendshipId)
        {
            try
            {
                ChatAppDBContext db = new ChatAppDBContext();
                var friendship = db.Friendships.FirstOrDefault(f => f.FriendshipID == friendshipId);

                if (friendship == null)
                {
                    MessageBox.Show("[Notification] ban be nay khong ton tai");
                    return;
                }

                db.Friendships.Attach(friendship);
                friendship.Status = StatusFriend.DENIED;
                db.Friendships.Remove(friendship);
                db.SaveChanges();

                pnUserControl.Controls.Remove(control); // Loại bỏ UserControl khỏi Panel
                control.Dispose(); // Giải phóng tài nguyên
                this.DataSent?.Invoke(this, friendship);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
        private void btnClose_MouseClick(object sender, MouseEventArgs e)
        {
            this.Close();
        }
    }
}
