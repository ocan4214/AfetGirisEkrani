namespace AfetProje.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public enum ApprovalStatus
    {
        Pending=0,Approved=1,Rejected=2,Online=3
    }

    [Table("Afet")]
    public partial class Afet
    {
        

        public string ID { get; set; }

        public string GlideNo { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime FirstSeen { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime LastSeen { get; set; }

        public int? DaysLast { get; set; }

        public DisasterType DisasterType { get; set; }

        public string Province { get; set; }

        public string Borough { get; set; }

        public string Village { get; set; }

        public string Neighborhood { get; set; }

        public string BeldeMevki { get; set; }

        public string ReasonofDisaster { get; set; }

        public string Latitude { get; set; }

        public string Longitude { get; set; }

        public string ReasonDetails { get; set; }

        public string EffectedAreas { get; set; }

        public string Source { get; set; }

        public ApprovalStatus Status { get; set; }

       
        public virtual ICollection<File> Files { get; set; }
    }
}
