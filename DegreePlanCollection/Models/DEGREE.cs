namespace DegreePlanCollection.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DEGREES")]
    public partial class DEGREE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DEGREE()
        {
            DEGREE_ADMISSION_CATEGORIES = new HashSet<DEGREE_ADMISSION_CATEGORIES>();
            DEGREE_ADMISSION_COURSES = new HashSet<DEGREE_ADMISSION_COURSES>();
            DEGREE_CATEGORIES = new HashSet<DEGREE_CATEGORIES>();
            DEGREE_GRADUATION_CATEGORIES = new HashSet<DEGREE_GRADUATION_CATEGORIES>();
            DEGREE_GRADUATION_COURSES = new HashSet<DEGREE_GRADUATION_COURSES>();
            PLANS = new HashSet<PLAN>();
        }

        public int id { get; set; }

        public int colleges_id { get; set; }

        [Required]
        [StringLength(255)]
        public string degree_name { get; set; }

        public int departments_id { get; set; }

        [Required]
        [StringLength(255)]
        public string degree_type { get; set; }

        public bool use_catalog { get; set; }

        public virtual COLLEGE COLLEGE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DEGREE_ADMISSION_CATEGORIES> DEGREE_ADMISSION_CATEGORIES { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DEGREE_ADMISSION_COURSES> DEGREE_ADMISSION_COURSES { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DEGREE_CATEGORIES> DEGREE_CATEGORIES { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DEGREE_GRADUATION_CATEGORIES> DEGREE_GRADUATION_CATEGORIES { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DEGREE_GRADUATION_COURSES> DEGREE_GRADUATION_COURSES { get; set; }

        public virtual DEGREE_NOTES DEGREE_NOTES { get; set; }

        public virtual DEGREE_RANKINGS DEGREE_RANKINGS { get; set; }

        public virtual DEPARTMENT1 DEPARTMENT { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PLAN> PLANS { get; set; }
    }
}
