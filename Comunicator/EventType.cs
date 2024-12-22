﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comunicator
{
    public static class EventType
    {
        public const string SEND_MESSAGE = "SEND_MESSAGE"; // Truyền tin nhắn (text, image, ...)
        public const string CREATE_GROUP = "CREATE_GROUP"; // Tạo group
        public const string JOIN_GROUP = "JOIN_GROUP"; // Tham gia group
        public const string FRIENDSHIPS = "FRIENDSHIPS"; // Lời mời kết bạn
        public const string STATUS_ACCOUNT = "STATUS_ACCOUNT"; // Login/ Logout
        // Bổ sung thêm (nếu cần thiết)...
    }
}
