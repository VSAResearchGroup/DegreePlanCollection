namespace DegreePlanCollection.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CODEKEYS")]
    public partial class CODEKEY
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CODEKEY()
        {
            COLLEGE_ADMISSION_CODEKEYS = new HashSet<COLLEGE_ADMISSION_CODEKEYS>();
            COURSES = new HashSet<COURS>();
        }

        public int id { get; set; }

        [Column("codekey")]
        [Required]
        [StringLength(4)]
        public string codekey1 { get; set; }

        [Required]
        [StringLength(50)]
        public string description { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<COLLEGE_ADMISSION_CODEKEYS> COLLEGE_ADMISSION_CODEKEYS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<COURS> COURSES { get; set; }
    }
}
