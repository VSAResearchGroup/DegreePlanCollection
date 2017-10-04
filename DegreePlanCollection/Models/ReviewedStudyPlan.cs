namespace DegreePlanCollection.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ReviewedStudyPlan")]
    public partial class ReviewedStudyPlan
    {
        public int ID { get; set; }

        public long? StudentID { get; set; }

        public int? PlanID { get; set; }

        [StringLength(50)]
        public string PlanName { get; set; }

        public long? AdvisorID { get; set; }

        public DateTime? CreationDate { get; set; }

        public DateTime? ReviewDate { get; set; }

        public DateTime? LastDateModified { get; set; }

        public int? Status { get; set; }

        public virtual StudyPlan StudyPlan { get; set; }
    }
}
