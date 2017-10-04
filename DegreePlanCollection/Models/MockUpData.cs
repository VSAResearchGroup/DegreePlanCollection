namespace DegreePlanCollection.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MockUpData")]
    public partial class MockUpData
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long StudentID { get; set; }

        [StringLength(250)]
        public string Major { get; set; }

        public int? JobTypeID { get; set; }

        public int? NoOfCourses { get; set; }

        public int? Elective { get; set; }

        public int? Core { get; set; }

        public int? ElectiveCredit { get; set; }

        public int? CoreCredit { get; set; }

        public int? CreditNo { get; set; }
    }
}
