namespace DegreePlanCollection.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ParameterSet")]
    public partial class ParameterSet
    {
        public int ID { get; set; }

        public int? MajorID { get; set; }

        public int? SchoolID { get; set; }

        public int? JobTypeID { get; set; }

        public int? BudgetID { get; set; }

        public int? TimePreferenceID { get; set; }

        public int? QuarterPreferenceID { get; set; }

        [StringLength(250)]
        public string CompletedCourses { get; set; }

        [StringLength(250)]
        public string PlacementCourses { get; set; }

        public DateTime? DateAdded { get; set; }

        public DateTime? LastDateModified { get; set; }

        public int? Status { get; set; }
    }
}
