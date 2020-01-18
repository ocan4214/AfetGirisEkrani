namespace AfetProje.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class mahalle_koy
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long MAH_ID { get; set; }

        public long? IL_ID { get; set; }

        public long? ILCE_ID { get; set; }

        public long? SEMT_ID { get; set; }

        [StringLength(50)]
        public string MAHALLE_ADI_BUYUK { get; set; }

        [StringLength(50)]
        public string MAHALLE_ADI { get; set; }

        [StringLength(50)]
        public string MAHALLE_ADI_KUCUK { get; set; }
    }
}
