namespace DegreePlanCollection.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class DEGREE_CATEGORIES
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DEGREE_CATEGORIES()
        {
            DEGREE_ADMISSION_CATEGORIES = new HashSet<DEGREE_ADMISSION_CATEGORIES>();
            DEGREE_ADMISSION_COURSES = new HashSet<DEGREE_ADMISSION_COURSES>();
            DEGREE_GRADUATION_CATEGORIES = new HashSet<DEGREE_GRADUATION_CATEGORIES>();
            DEGREE_GRADUATION_COURSES = new HashSet<DEGREE_GRADUATION_COURSES>();
            PLAN_SELECTEDCOURSES = new HashSet<PLAN_SELECTEDCOURSES>();
        }

        public int id { get; set; }

        public int degrees_id { get; set; }

        [Required]
        [StringLength(50)]
        public string category { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DEGREE_ADMISSION_CATEGORIES> DEGREE_ADMISSION_CATEGORIES { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DEGREE_ADMISSION_COURSES> DEGREE_ADMISSION_COURSES { get; set; }

        public virtual DEGREE DEGREE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DEGREE_GRADUATION_CATEGORIES> DEGREE_GRADUATION_CATEGORIES { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DEGREE_GRADUATION_COURSES> DEGREE_GRADUATION_COURSES { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PLAN_SELECTEDCOURSES> PLAN_SELECTEDCOURSES { get; set; }
    }
}
