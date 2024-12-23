using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comunicator.DTO
{
    public class GroupNotificationDTO
    {
        public int NotificationID { get; set; }

        public int GroupID { get; set; }

        public int UserID { get; set; }

        public string Content { get; set; }

        public bool? IsRead { get; set; }

        public DateTime? Timestamp { get; set; }
    }
}
