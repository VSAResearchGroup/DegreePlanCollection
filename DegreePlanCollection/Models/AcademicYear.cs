namespace DegreePlanCollection.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AcademicYear")]
    public partial class AcademicYear
    {
        public int ID { get; set; }

        public int? Year { get; set; }

        public int? Status { get; set; }
    }
}
