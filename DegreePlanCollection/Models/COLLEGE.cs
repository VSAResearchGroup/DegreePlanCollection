namespace DegreePlanCollection.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("COLLEGES")]
    public partial class COLLEGE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public COLLEGE()
        {
            COLLEGE_ADMISSION_CODEKEYS = new HashSet<COLLEGE_ADMISSION_CODEKEYS>();
            COLLEGE_ADMISSION_COURSES = new HashSet<COLLEGE_ADMISSION_COURSES>();
            COLLEGE_ADMISSION_DEPARTMENTS = new HashSet<COLLEGE_ADMISSION_DEPARTMENTS>();
            COLLEGE_DEPARTMENTS = new HashSet<COLLEGE_DEPARTMENTS>();
            DEGREES = new HashSet<DEGREE>();
        }

        public int id { get; set; }

        [Required]
        [StringLength(255)]
        public string college_name { get; set; }

        [Required]
        [StringLength(255)]
        public string college_city { get; set; }

        [StringLength(255)]
        public string college_website { get; set; }

        public bool use_catalog { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<COLLEGE_ADMISSION_CODEKEYS> COLLEGE_ADMISSION_CODEKEYS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<COLLEGE_ADMISSION_COURSES> COLLEGE_ADMISSION_COURSES { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<COLLEGE_ADMISSION_DEPARTMENTS> COLLEGE_ADMISSION_DEPARTMENTS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<COLLEGE_DEPARTMENTS> COLLEGE_DEPARTMENTS { get; set; }

        public virtual COLLEGE_NOTES COLLEGE_NOTES { get; set; }

        public virtual COLLEGE_RANKINGS COLLEGE_RANKINGS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DEGREE> DEGREES { get; set; }
    }
}
