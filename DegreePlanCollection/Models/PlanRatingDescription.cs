namespace DegreePlanCollection.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PlanRatingDescription")]
    public partial class PlanRatingDescription
    {
        public int ID { get; set; }

        [StringLength(50)]
        public string Description { get; set; }
    }
}
