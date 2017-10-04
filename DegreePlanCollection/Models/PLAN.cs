namespace DegreePlanCollection.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PLANS")]
    public partial class PLAN
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PLAN()
        {
            PLAN_SELECTEDCOURSES = new HashSet<PLAN_SELECTEDCOURSES>();
            STUDENTS = new HashSet<STUDENT1>();
            DEGREES = new HashSet<DEGREE>();
        }

        public int id { get; set; }

        public int students_accounts_id { get; set; }

        [Required]
        [StringLength(255)]
        public string plan_name { get; set; }

        public DateTime time_created { get; set; }

        public DateTime? time_updated { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PLAN_SELECTEDCOURSES> PLAN_SELECTEDCOURSES { get; set; }

        public virtual STUDENT1 STUDENT { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<STUDENT1> STUDENTS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DEGREE> DEGREES { get; set; }
    }
}
