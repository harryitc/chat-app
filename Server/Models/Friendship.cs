namespace Server.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Friendship
    {
        public int FriendshipID { get; set; }

        public int RequesterID { get; set; }

        public int AddressID { get; set; }

        [StringLength(50)]
        public string Status { get; set; }

        public DateTime? CreatedAt { get; set; }

        public virtual User User { get; set; }

        public virtual User User1 { get; set; }
    }
}
