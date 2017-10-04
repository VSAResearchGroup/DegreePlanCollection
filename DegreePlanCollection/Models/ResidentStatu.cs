namespace DegreePlanCollection.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ResidentStatu
    {
        public int ID { get; set; }

        [StringLength(30)]
        public string Residency { get; set; }

        public DateTime? CreationDate { get; set; }

        public DateTime? LastDateModified { get; set; }

        public int? Status { get; set; }
    }
}
