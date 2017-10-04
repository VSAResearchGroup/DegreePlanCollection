namespace DegreePlanCollection.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("_TimeSlot")]
    public partial class C_TimeSlot
    {
        [Key]
        public int TimeID { get; set; }

        public TimeSpan? Time { get; set; }

        public int? Status { get; set; }
    }
}
