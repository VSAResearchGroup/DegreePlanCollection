namespace DegreePlanCollection.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class STUDENT_PLACEMENTCOURSES
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int students_accounts_id { get; set; }

        public int math_courses_id { get; set; }

        public int english_courses_id { get; set; }

        public virtual COURS COURS { get; set; }

        public virtual COURS COURS1 { get; set; }

        public virtual STUDENT1 STUDENT { get; set; }
    }
}
