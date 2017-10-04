namespace DegreePlanCollection.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("StudentStudyPlan")]
    public partial class StudentStudyPlan
    {
        public int ID { get; set; }

        public long? StudentID { get; set; }

        public int? PlanID { get; set; }

        public DateTime? CreationDate { get; set; }

        public DateTime? LastDateModified { get; set; }

        public int? Status { get; set; }
    }
}
