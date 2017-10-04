namespace DegreePlanCollection.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("WeekDay")]
    public partial class WeekDay
    {
        [Key]
        public int DayID { get; set; }

        [Column("WeekDay")]
        [StringLength(10)]
        public string WeekDay1 { get; set; }

        public int? Status { get; set; }
    }
}
