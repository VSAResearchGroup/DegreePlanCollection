namespace DegreePlanCollection.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Student")]
    public partial class Student
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Student()
        {
            StudentEnrollments = new HashSet<StudentEnrollment>();
        }

        public long StudentID { get; set; }

        public long? MajorID { get; set; }

        public long? DepartmentID { get; set; }

        public int? JobTypeID { get; set; }

        public int? Status { get; set; }

        public virtual JobType JobType { get; set; }

        public virtual Major Major { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StudentEnrollment> StudentEnrollments { get; set; }
    }
}
