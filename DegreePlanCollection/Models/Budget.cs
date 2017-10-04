namespace DegreePlanCollection.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Budget")]
    public partial class Budget
    {
        public int ID { get; set; }

        [Column("Budget")]
        [StringLength(30)]
        public string Budget1 { get; set; }

        public int? MaxCredit { get; set; }

        public int? ResidentStatusID { get; set; }

        public DateTime? CreationDate { get; set; }

        public DateTime? LastDateModified { get; set; }

        public int? Status { get; set; }
    }
}
