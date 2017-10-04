namespace DegreePlanCollection.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("StudentPlan")]
    public partial class StudentPlan
    {
        public int ID { get; set; }

        public int? PlanID { get; set; }

        [StringLength(50)]
        public string PlanName { get; set; }

        public long? StudentID { get; set; }

        public DateTime? CreationDate { get; set; }

        public DateTime? LastDateModified { get; set; }
    }
}
