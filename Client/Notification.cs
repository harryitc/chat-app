using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Comunicator.models;

namespace Client
{
    public partial class Notification : Form
    {
        public Notification()
        {
            InitializeComponent();
            this.pnUserControl.AutoScroll = true;
            ChatAppDBContext db = new ChatAppDBContext();
            List<Friendship> friends = db.Friendships.Where(p=>p.Status == "pending").ToList();
            for (int i = 0; i < friends.Count; i++)
            {
                NotificationUserControl notificationUserControl = new NotificationUserControl
                {
                    Dock = DockStyle.Top,
                };
                notificationUserControl.lbID.Text = friends[i].FriendshipID.ToString();

                notificationUserControl.lbUser.Text = friends[i].User.Username;
                notificationUserControl.lbStatus.Text = friends[i].Status;

                MessageBox.Show(friends[i].FriendshipID.ToString());

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

        // Xử lý khi nhấn nút "Accepted"
        private void HandleAccepted(NotificationUserControl control, int friendshipId)
        {
            try
            {
                ChatAppDBContext db = new ChatAppDBContext();
                var friendship = db.Friendships.FirstOrDefault(f => f.FriendshipID == friendshipId);

                if (friendship != null)
                {
                    friendship.Status = "accepted";
                    db.SaveChanges();
                    control.lbStatus.Text = "accepted"; // Cập nhật trạng thái trên giao diện
                    control.btnAccepted.Enabled = false; // Vô hiệu hóa nút "Accepted"
                    control.btnDenied.Enabled = false;  // Vô hiệu hóa nút "Denied"
                }
                else
                {
                    MessageBox.Show("Khong the accepted");
                }
            }
            catch (Exception ex) {
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

                if (friendship != null)
                {
                    db.Friendships.Remove(friendship);
                    db.SaveChanges();
                }

                pnUserControl.Controls.Remove(control); // Loại bỏ UserControl khỏi Panel
                control.Dispose(); // Giải phóng tài nguyên
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
