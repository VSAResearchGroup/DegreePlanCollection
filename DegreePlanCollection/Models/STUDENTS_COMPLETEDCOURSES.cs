namespace DegreePlanCollection.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class STUDENTS_COMPLETEDCOURSES
    {
        public int id { get; set; }

        public int students_accounts_id { get; set; }

        public int courses_id { get; set; }

        public decimal credit { get; set; }

        public virtual COURS COURS { get; set; }

        public virtual STUDENT1 STUDENT { get; set; }
    }
}
