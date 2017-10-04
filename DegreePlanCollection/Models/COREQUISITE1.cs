namespace DegreePlanCollection.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("COREQUISITES")]
    public partial class COREQUISITE1
    {
        public int id { get; set; }

        public int courses_id { get; set; }

        public int group_id { get; set; }

        public int courses_corequisite_id { get; set; }

        public virtual COURS COURS { get; set; }

        public virtual COURS COURS1 { get; set; }
    }
}
