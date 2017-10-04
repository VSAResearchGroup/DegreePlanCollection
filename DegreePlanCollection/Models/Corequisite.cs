namespace DegreePlanCollection.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Corequisite")]
    public partial class Corequisite
    {
        public int ID { get; set; }

        public int CourseID { get; set; }

        public int GroupID { get; set; }

        public int CorequisiteID { get; set; }
    }
}
