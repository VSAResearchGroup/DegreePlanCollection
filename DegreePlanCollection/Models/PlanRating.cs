namespace DegreePlanCollection.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PlanRating")]
    public partial class PlanRating
    {
        public int PlanID { get; set; }

        public int OptionGroupID { get; set; }

        public int? Stars { get; set; }

        public int ID { get; set; }
    }
}
