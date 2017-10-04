namespace DegreePlanCollection.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("RequisitesType")]
    public partial class RequisitesType
    {
        public int ID { get; set; }

        [StringLength(50)]
        public string RequisiteType { get; set; }

        public int? Status { get; set; }
    }
}
