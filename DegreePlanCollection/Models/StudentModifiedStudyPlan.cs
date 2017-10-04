namespace DegreePlanCollection.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("StudentModifiedStudyPlan")]
    public partial class StudentModifiedStudyPlan
    {
        public int ID { get; set; }

        public int? PlanID { get; set; }

        public int? QuarterID { get; set; }

        public int? YearID { get; set; }

        public int? CourseID { get; set; }

        public DateTime? DateAdded { get; set; }

        public DateTime? LastDateModified { get; set; }
    }
}
