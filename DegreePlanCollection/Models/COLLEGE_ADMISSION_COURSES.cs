namespace DegreePlanCollection.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class COLLEGE_ADMISSION_COURSES
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int colleges_id { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int courses_id { get; set; }

        [Required]
        [StringLength(50)]
        public string foreign_course_number { get; set; }

        public virtual COLLEGE COLLEGE { get; set; }

        public virtual COURS COURS { get; set; }
    }
}
