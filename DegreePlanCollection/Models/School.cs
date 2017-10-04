namespace DegreePlanCollection.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("School")]
    public partial class School
    {
        public int ID { get; set; }

        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(10)]
        public string Acronymn { get; set; }

        [StringLength(150)]
        public string Address { get; set; }

        public DateTime? CreationDate { get; set; }

        public DateTime? LastDateModified { get; set; }

        public int? Status { get; set; }
    }
}
