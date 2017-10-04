namespace DegreePlanCollection.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class DEGREE_NOTES
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int degrees_id { get; set; }

        [StringLength(1800)]
        public string admission_courses_note { get; set; }

        [StringLength(1800)]
        public string admission_categories_note { get; set; }

        [StringLength(1800)]
        public string graduation_courses_note { get; set; }

        [StringLength(1800)]
        public string graduation_categories_note { get; set; }

        [StringLength(1800)]
        public string general_note { get; set; }

        public virtual DEGREE DEGREE { get; set; }
    }
}
