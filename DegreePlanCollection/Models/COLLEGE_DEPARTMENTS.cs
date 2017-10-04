namespace DegreePlanCollection.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class COLLEGE_DEPARTMENTS
    {
        public int id { get; set; }

        public int colleges_id { get; set; }

        public int departments_id { get; set; }

        public virtual COLLEGE COLLEGE { get; set; }

        public virtual DEPARTMENT1 DEPARTMENT { get; set; }
    }
}
