namespace DegreePlanCollection.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class COLLEGE_RANKINGS
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int colleges_id { get; set; }

        public int rank { get; set; }

        public virtual COLLEGE COLLEGE { get; set; }
    }
}
