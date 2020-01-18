namespace AfetProje.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("File")]
    public partial class File
    {
        public int FileId { get; set; }

        [StringLength(255)]
        public string FileName { get; set; }

        [StringLength(100)]
        public string ContentType { get; set; }

        public byte[] Content { get; set; }

        public FileType FileType { get; set; }

        public int PersonId { get; set; }

        [StringLength(128)]
        public string Afet_ID { get; set; }

        public virtual Afet Afet { get; set; }
    }
}
