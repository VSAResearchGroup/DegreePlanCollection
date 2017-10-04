namespace DegreePlanCollection.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Requisite
    {
        public long ID { get; set; }

        public int? CourseID { get; set; }

        public int? RequisiteID { get; set; }

        public int? Relationship { get; set; }

        public int? DepartmentID { get; set; }

        public int? Status { get; set; }

        public int? UserID { get; set; }

        public DateTime? LastDateModified { get; set; }

        [StringLength(10)]
        public string CourseName { get; set; }

        [StringLength(10)]
        public string RequisiteName { get; set; }
    }
}
