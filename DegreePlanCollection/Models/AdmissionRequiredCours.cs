namespace DegreePlanCollection.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AdmissionRequiredCourses")]
    public partial class AdmissionRequiredCours
    {
        public int ID { get; set; }

        public int? MajorID { get; set; }

        public int? SchoolID { get; set; }

        public int? CourseID { get; set; }

        public int? DepartmentID { get; set; }
    }
}
