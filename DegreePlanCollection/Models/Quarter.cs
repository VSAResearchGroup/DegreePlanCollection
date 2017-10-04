namespace DegreePlanCollection.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Quarter")]
    public partial class Quarter
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Quarter()
        {
            StudentEnrollments = new HashSet<StudentEnrollment>();
        }

        public int QuarterID { get; set; }

        [Column("Quarter")]
        [StringLength(10)]
        public string Quarter1 { get; set; }

        public int? Status { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StudentEnrollment> StudentEnrollments { get; set; }
    }
}
