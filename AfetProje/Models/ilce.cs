namespace AfetProje.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ilce")]
    public partial class ilce
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long ILCE_ID { get; set; }

        public long? IL_ID { get; set; }

        [StringLength(50)]
        public string ILCE_ADI_BUYUK { get; set; }

        [StringLength(50)]
        public string ILCE_ADI { get; set; }

        [StringLength(50)]
        public string ILCE_ADI_KUCUK { get; set; }
    }
}
