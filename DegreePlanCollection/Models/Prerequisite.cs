namespace DegreePlanCollection.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Prerequisite")]
    public partial class Prerequisite
    {
        public int ID { get; set; }

        public int CourseID { get; set; }

        public int GroupID { get; set; }

        public int PrerequisiteID { get; set; }

        public virtual Course Course { get; set; }

        public virtual Course Course1 { get; set; }
    }
}
