namespace DegreePlanCollection.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("StudyPlan")]
    public partial class StudyPlan
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public StudyPlan()
        {
            ReviewedStudyPlans = new HashSet<ReviewedStudyPlan>();
        }

        public int ID { get; set; }

        public int? PlanID { get; set; }

        public int? QuarterID { get; set; }

        public int? YearID { get; set; }

        public int? CourseID { get; set; }

        public DateTime? DateAdded { get; set; }

        public DateTime? LastDateModified { get; set; }

        public virtual GeneratedPlan GeneratedPlan { get; set; }

        public virtual GeneratedPlan GeneratedPlan1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ReviewedStudyPlan> ReviewedStudyPlans { get; set; }
    }
}
