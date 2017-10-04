namespace DegreePlanCollection.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PLAN_SELECTEDCOURSES
    {
        public int id { get; set; }

        public int plans_id { get; set; }

        public int courses_id { get; set; }

        public int degree_categories_id { get; set; }

        public int? completedcourses_id { get; set; }

        public decimal? credit { get; set; }

        public virtual COURS COURS { get; set; }

        public virtual DEGREE_CATEGORIES DEGREE_CATEGORIES { get; set; }

        public virtual PLAN PLAN { get; set; }
    }
}
