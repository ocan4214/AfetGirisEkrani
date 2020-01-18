namespace AfetProje.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("semt")]
    public partial class semt
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long SEMT_ID { get; set; }

        public long? IL_ID { get; set; }

        public long? ILCE_ID { get; set; }

        [StringLength(50)]
        public string SEMT_ADI_BUYUK { get; set; }

        [StringLength(50)]
        public string SEMT_ADI { get; set; }

        [StringLength(50)]
        public string SEMT_ADI_KUCUK { get; set; }

        [StringLength(7)]
        public string POSTA_KODU { get; set; }
    }
}
