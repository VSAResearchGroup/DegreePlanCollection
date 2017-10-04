namespace DegreePlanCollection.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PREREQUISITE_PERMISSIONS
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int courses_id { get; set; }

        public virtual COURS COURS { get; set; }
    }
}
