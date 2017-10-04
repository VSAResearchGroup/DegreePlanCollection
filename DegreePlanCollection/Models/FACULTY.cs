namespace DegreePlanCollection.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("FACULTY")]
    public partial class FACULTY
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int accounts_id { get; set; }

        public bool editor { get; set; }

        public bool administrator { get; set; }

        public virtual ACCOUNT ACCOUNT { get; set; }
    }
}
