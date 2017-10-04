namespace DegreePlanCollection.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PREREQUISITE_PLACEMENTS
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int courses_id { get; set; }

        [Required]
        [StringLength(255)]
        public string placement { get; set; }

        public virtual COURS COURS { get; set; }
    }
}
