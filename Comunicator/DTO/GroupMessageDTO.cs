using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comunicator.DTO
{
    public class GroupMessageDTO
    {
        public int MessageID { get; set; }

        public int GroupID { get; set; }

        public int SenderID { get; set; }

        public string Content { get; set; }

        public string MessageType { get; set; }

        public DateTime? Timestamp { get; set; }
    }
}
