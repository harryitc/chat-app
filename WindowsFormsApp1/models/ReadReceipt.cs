namespace WindowsFormsApp1.models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ReadReceipt
    {
        [Key]
        public int ReceiptID { get; set; }

        public int MessageID { get; set; }

        public int UserID { get; set; }

        public DateTime? ReadAt { get; set; }

        public virtual GroupMessage GroupMessage { get; set; }

        public virtual User User { get; set; }
    }
}
