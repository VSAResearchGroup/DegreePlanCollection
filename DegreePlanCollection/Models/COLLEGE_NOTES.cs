namespace DegreePlanCollection.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class COLLEGE_NOTES
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int colleges_id { get; set; }

        [StringLength(1800)]
        public string courses_note { get; set; }

        [StringLength(1800)]
        public string departments_note { get; set; }

        [StringLength(1800)]
        public string codekeys_note { get; set; }

        public virtual COLLEGE COLLEGE { get; set; }
    }
}
