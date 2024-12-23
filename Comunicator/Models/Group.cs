namespace Comunicator.models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Group
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Group()
        {
            GroupMembers = new HashSet<GroupMember>();
            GroupMessages = new HashSet<GroupMessage>();
            GroupNotifications = new HashSet<GroupNotification>();
        }

        public int GroupID { get; set; }

        [Required]
        [StringLength(200)]
        public string GroupName { get; set; }

        public string GroupDescription { get; set; }

        public int CreatedBy { get; set; }

        public DateTime? CreatedAt { get; set; }

        [StringLength(500)]
        public string GroupImage { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GroupMember> GroupMembers { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GroupMessage> GroupMessages { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GroupNotification> GroupNotifications { get; set; }

        public virtual User User { get; set; }
    }
}
