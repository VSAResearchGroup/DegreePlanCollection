namespace DegreePlanCollection.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class COLLEGE_ADMISSION_DEPARTMENTS
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int colleges_id { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int departments_id { get; set; }

        public decimal credit { get; set; }

        public virtual COLLEGE COLLEGE { get; set; }

        public virtual DEPARTMENT1 DEPARTMENT { get; set; }
    }
}
