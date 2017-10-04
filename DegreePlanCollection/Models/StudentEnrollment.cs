namespace DegreePlanCollection.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("StudentEnrollment")]
    public partial class StudentEnrollment
    {
        public long ID { get; set; }

        public long StudentID { get; set; }

        [StringLength(10)]
        public string CourseNumber { get; set; }

        public int? QuarterID { get; set; }

        public int? Elective { get; set; }

        public int? Core { get; set; }

        public int? CreditNo { get; set; }

        public int? Status { get; set; }

        public int? Year { get; set; }

        public DateTime? EnrollmentDate { get; set; }

        public DateTime? LastDateModified { get; set; }

        public virtual Quarter Quarter { get; set; }

        public virtual Student Student { get; set; }
    }
}
