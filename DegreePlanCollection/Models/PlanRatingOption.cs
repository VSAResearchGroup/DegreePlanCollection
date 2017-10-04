namespace DegreePlanCollection.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PlanRatingOption")]
    public partial class PlanRatingOption
    {
        public int ID { get; set; }

        public int OptionGroupID { get; set; }

        public int DescriptionID { get; set; }
    }
}
