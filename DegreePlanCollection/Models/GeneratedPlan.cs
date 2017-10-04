namespace DegreePlanCollection.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("GeneratedPlan")]
    public partial class GeneratedPlan
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public GeneratedPlan()
        {
            StudyPlans = new HashSet<StudyPlan>();
            StudyPlans1 = new HashSet<StudyPlan>();
        }

        public int ID { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        public double? Score { get; set; }

        public int? ParameterSetID { get; set; }

        public DateTime? DateAdded { get; set; }

        public DateTime? LastDateModified { get; set; }

        public int? Status { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StudyPlan> StudyPlans { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StudyPlan> StudyPlans1 { get; set; }
    }
}
