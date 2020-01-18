namespace AfetProje.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("il")]
    public partial class il
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long IL_ID { get; set; }

        [StringLength(255)]
        public string PLAKA { get; set; }

        [StringLength(255)]
        public string IL_ADI_BUYUK { get; set; }

        [StringLength(255)]
        public string IL_ADI { get; set; }

        [StringLength(255)]
        public string IL_ADI_KUCUK { get; set; }
    }
}
