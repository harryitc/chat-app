namespace Comunicator.models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class GroupMessage
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public GroupMessage()
        {
            Attachments = new HashSet<Attachment>();
            ReadReceipts = new HashSet<ReadReceipt>();
        }

        [Key]
        public int MessageID { get; set; }

        public int GroupID { get; set; }

        public int SenderID { get; set; }

        public string Content { get; set; }

        [StringLength(50)]
        public string MessageType { get; set; }

        public DateTime? Timestamp { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Attachment> Attachments { get; set; }

        public virtual Group Group { get; set; }

        public virtual User User { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ReadReceipt> ReadReceipts { get; set; }
    }
}
