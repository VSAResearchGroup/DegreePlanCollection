namespace DegreePlanCollection.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Course")]
    public partial class Course
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Course()
        {
            CourseTimes = new HashSet<CourseTime>();
            Prerequisites1 = new HashSet<Prerequisite>();
            Prerequisites2 = new HashSet<Prerequisite>();
        }

        public int CourseID { get; set; }

        [StringLength(10)]
        public string CourseNumber { get; set; }

        [StringLength(50)]
        public string AbbreviatedTitle { get; set; }

        [StringLength(100)]
        public string Title { get; set; }

        public int? MinCredit { get; set; }

        public int? MaxCredit { get; set; }

        [StringLength(1000)]
        public string Description { get; set; }

        public int? DepartmentID { get; set; }

        [StringLength(250)]
        public string PreRequisites { get; set; }

        [StringLength(250)]
        public string CoRequisites { get; set; }

        public int? UseCatalog { get; set; }

        public int? SectionID { get; set; }

        public virtual Department Department { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CourseTime> CourseTimes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Prerequisite> Prerequisites1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Prerequisite> Prerequisites2 { get; set; }
    }
}
