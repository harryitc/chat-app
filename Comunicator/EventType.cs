using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comunicator
{
    public static class EventType
    {
        public const string SEND_MESSAGE = "SEND_MESSAGE";
        public const string CREATE_GROUP = "CREATE_GROUP";
        public const string JOIN_GROUP = "JOIN_GROUP";
        public const string FRIENDSHIPS = "FRIENDSHIPS";
        public const string STATUS_ACCOUNT = "STATUS_ACCOUNT";
        // Bổ sung thêm (nếu cần thiết)...
    }
}
