namespace WindowsFormsApp1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class GroupNotification
    {
        [Key]
        public int NotificationID { get; set; }

        public int GroupID { get; set; }

        public int UserID { get; set; }

        [Required]
        public string Content { get; set; }

        public bool? IsRead { get; set; }

        public DateTime? Timestamp { get; set; }

        public virtual Group Group { get; set; }

        public virtual User User { get; set; }
    }
}
