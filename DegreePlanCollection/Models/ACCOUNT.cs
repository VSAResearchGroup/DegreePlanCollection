namespace DegreePlanCollection.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ACCOUNTS")]
    public partial class ACCOUNT
    {
        public int id { get; set; }

        public bool active { get; set; }

        [Required]
        [StringLength(60)]
        public string email { get; set; }

        [Required]
        [StringLength(40)]
        public string first_name { get; set; }

        [Required]
        [StringLength(40)]
        public string last_name { get; set; }

        [Required]
        [StringLength(255)]
        public string password { get; set; }

        [Required]
        [StringLength(255)]
        public string salt { get; set; }

        public virtual FACULTY FACULTY { get; set; }

        public virtual STUDENT1 STUDENT { get; set; }
    }
}
