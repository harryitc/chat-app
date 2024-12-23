namespace Comunicator.models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Attachment
    {
        public int AttachmentID { get; set; }

        public int MessageID { get; set; }

        [Required]
        [StringLength(500)]
        public string FilePath { get; set; }

        [StringLength(50)]
        public string FileType { get; set; }

        public virtual GroupMessage GroupMessage { get; set; }
    }
}
