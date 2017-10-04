namespace DegreePlanCollection.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Parameter
    {
        public int ID { get; set; }

        public int? MajorID { get; set; }

        public int? SchoolID { get; set; }

        public int? JobTypeID { get; set; }

        public int? BudgetID { get; set; }

        public int? StartQuarterID { get; set; }

        [MaxLength(1)]
        public byte[] TimePreferenceID { get; set; }

        [MaxLength(1)]
        public byte[] QuarterPreferenceID { get; set; }

        [StringLength(50)]
        public string Placements { get; set; }

        [StringLength(50)]
        public string Completed { get; set; }

        public DateTime? CreationDate { get; set; }

        public DateTime? LastDateModified { get; set; }

        public int? Status { get; set; }
    }
}
