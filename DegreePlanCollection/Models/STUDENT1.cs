namespace DegreePlanCollection.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("STUDENTS")]
    public partial class STUDENT1
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public STUDENT1()
        {
            PLANS = new HashSet<PLAN>();
            STUDENTS_COMPLETEDCOURSES = new HashSet<STUDENTS_COMPLETEDCOURSES>();
            PLANS1 = new HashSet<PLAN>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int accounts_id { get; set; }

        public int student_id { get; set; }

        public virtual ACCOUNT ACCOUNT { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PLAN> PLANS { get; set; }

        public virtual STUDENT_PLACEMENTCOURSES STUDENT_PLACEMENTCOURSES { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<STUDENTS_COMPLETEDCOURSES> STUDENTS_COMPLETEDCOURSES { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PLAN> PLANS1 { get; set; }
    }
}
