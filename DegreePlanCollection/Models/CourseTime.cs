namespace DegreePlanCollection.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CourseTime")]
    public partial class CourseTime
    {
        public int ID { get; set; }

        public int? CourseID { get; set; }

        [StringLength(10)]
        public string CourseNumber { get; set; }

        public int? StartTimeID { get; set; }

        public int? EndTimeID { get; set; }

        public int? DayID { get; set; }

        public int? QuarterID { get; set; }

        public int? Year { get; set; }

        public int? Status { get; set; }

        public int? SectionID { get; set; }

        public virtual Course Course { get; set; }
    }
}
