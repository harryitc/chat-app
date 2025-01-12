namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class GroupMember
    {
        [Key]
        public int MemberID { get; set; }

        public int GroupID { get; set; }

        public int UserID { get; set; }

        [StringLength(50)]
        public string Role { get; set; }

        public DateTime? JoinedAt { get; set; }

        public DateTime? LastSeen { get; set; }

        public virtual Group Group { get; set; }

        public virtual User User { get; set; }
    }
}
