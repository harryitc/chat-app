using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Comunicator.DTO
{
    public class GroupMemberDTO
    {
        public int MemberID { get; set; }
        public int GroupID { get; set; }
        public int UserID { get; set; }
        public string Role { get; set; }
        public DateTime? JoinedAt { get; set; }
        public DateTime? LastSeen { get; set; }
    }
}
