using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comunicator.DTO
{
    public class FriendshipDTO
    {
        public int FriendshipID { get; set; }

        public int RequesterID { get; set; }

        public int AddressID { get; set; }

        public string Status { get; set; }

        public DateTime? CreatedAt { get; set; }
    }
}
