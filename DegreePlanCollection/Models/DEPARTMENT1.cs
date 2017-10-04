namespace DegreePlanCollection.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DEPARTMENTS")]
    public partial class DEPARTMENT1
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DEPARTMENT1()
        {
            COLLEGE_ADMISSION_DEPARTMENTS = new HashSet<COLLEGE_ADMISSION_DEPARTMENTS>();
            COLLEGE_DEPARTMENTS = new HashSet<COLLEGE_DEPARTMENTS>();
            COURSES = new HashSet<COURS>();
            DEGREES = new HashSet<DEGREE>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }

        [Required]
        [StringLength(255)]
        public string department_name { get; set; }

        [StringLength(255)]
        public string see_also { get; set; }

        [StringLength(1800)]
        public string dept_intro { get; set; }

        [StringLength(10)]
        public string abv_title { get; set; }

        [StringLength(10)]
        public string abv_title2 { get; set; }

        public bool use_catalog { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<COLLEGE_ADMISSION_DEPARTMENTS> COLLEGE_ADMISSION_DEPARTMENTS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<COLLEGE_DEPARTMENTS> COLLEGE_DEPARTMENTS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<COURS> COURSES { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DEGREE> DEGREES { get; set; }

        public virtual DEPARTMENT_RANKINGS DEPARTMENT_RANKINGS { get; set; }
    }
}
