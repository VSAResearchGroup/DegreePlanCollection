namespace DegreePlanCollection.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("COURSES")]
    public partial class COURS
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public COURS()
        {
            COLLEGE_ADMISSION_COURSES = new HashSet<COLLEGE_ADMISSION_COURSES>();
            COREQUISITES = new HashSet<COREQUISITE1>();
            COREQUISITES1 = new HashSet<COREQUISITE1>();
            DEGREE_ADMISSION_COURSES = new HashSet<DEGREE_ADMISSION_COURSES>();
            DEGREE_GRADUATION_COURSES = new HashSet<DEGREE_GRADUATION_COURSES>();
            PLAN_SELECTEDCOURSES = new HashSet<PLAN_SELECTEDCOURSES>();
            PREREQUISITES = new HashSet<PREREQUISITE1>();
            PREREQUISITES1 = new HashSet<PREREQUISITE1>();
            STUDENT_PLACEMENTCOURSES = new HashSet<STUDENT_PLACEMENTCOURSES>();
            STUDENT_PLACEMENTCOURSES1 = new HashSet<STUDENT_PLACEMENTCOURSES>();
            STUDENTS_COMPLETEDCOURSES = new HashSet<STUDENTS_COMPLETEDCOURSES>();
            CODEKEYS = new HashSet<CODEKEY>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }

        [Required]
        [StringLength(13)]
        public string course_number { get; set; }

        [Required]
        [StringLength(255)]
        public string title { get; set; }

        public decimal? min_credit { get; set; }

        public decimal max_credit { get; set; }

        [StringLength(1800)]
        public string course_description { get; set; }

        public int departments_id { get; set; }

        public bool use_catalog { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<COLLEGE_ADMISSION_COURSES> COLLEGE_ADMISSION_COURSES { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<COREQUISITE1> COREQUISITES { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<COREQUISITE1> COREQUISITES1 { get; set; }

        public virtual COURSE_RANKINGS COURSE_RANKINGS { get; set; }

        public virtual DEPARTMENT1 DEPARTMENT { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DEGREE_ADMISSION_COURSES> DEGREE_ADMISSION_COURSES { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DEGREE_GRADUATION_COURSES> DEGREE_GRADUATION_COURSES { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PLAN_SELECTEDCOURSES> PLAN_SELECTEDCOURSES { get; set; }

        public virtual PREREQUISITE_PERMISSIONS PREREQUISITE_PERMISSIONS { get; set; }

        public virtual PREREQUISITE_PLACEMENTS PREREQUISITE_PLACEMENTS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PREREQUISITE1> PREREQUISITES { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PREREQUISITE1> PREREQUISITES1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<STUDENT_PLACEMENTCOURSES> STUDENT_PLACEMENTCOURSES { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<STUDENT_PLACEMENTCOURSES> STUDENT_PLACEMENTCOURSES1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<STUDENTS_COMPLETEDCOURSES> STUDENTS_COMPLETEDCOURSES { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CODEKEY> CODEKEYS { get; set; }
    }
}
