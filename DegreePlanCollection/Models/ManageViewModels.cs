using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Web.Mvc;
using System.Web.Razor;
using Microsoft.Ajax.Utilities;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;

namespace DegreePlanCollection.Models
{
   
    public class SchoolMajorViewModel
    {
        public string Major { get; set; }
        public string School { get; set;  }
        public int MajorId { get; set; }
        public int SchoolId { get; set; }
    }

    public class PrereqViewModel
    {
        public string Course { get; set; }
        public string PrerequisiteCourse { get; set; }
        public int GroupId { get; set; }
        public int CourseId { get; set; }
        public int PrereqId { get; set; }
    }

    public class CourseViewModel
    {
        public string Course { get; set; }
        public int CourseId { get; set; }
        public string Title { get; set; }
        public string Desc { get; set; }
        public string Prereq { get; set; }
        public int MinCredit { get; set; }
        public int MaxCredit { get; set; }
    }

   
  


    public class CollectDegreeViewModel
    {
        public string CurrentDegree { get; set; }
        public string CurrentCourse { get; set; }
        public string School { get; set; }
        public IEnumerable<SelectListItem> Schools { get; set; }
        public  string CurrentDegreeCourses { get; set; }
        public string currentCollectInfoCourse { get; set; }
        public string CurrentCollectDegreeInfoCourses { get; set; }

        [Required]
        public string Title { get; set; }

        [MaxLength(1000)]
        public string Description { get; set; }


        [PositiveNumber(ErrorMessage = "Minimum Credits can't be negative")]
        [Display(Name = "Minimum Credits")]
        public int MinCredit { get; set; }


        [Required]
        [Range(1, 20)]
        [Display(Name = "Maximum Credits")]
        public int MaxCredit { get; set; }

        [PrereqValidation(ErrorMessage = "Prerequisite Group Invalid")]
        [Display(Name = "Prerequisite Group")]
        [MaxLength(250)]
        public string Prerequisite { get; set; }

        public IList<CourseTimeViewModel> CourseTimeInfo { get; set; }

        public IList<DefferedPrerequisiteModel> DefferedPrerequisites { get; set; }

        public CollectDegreeViewModel()
        {
            CurrentDegree = "";
            CurrentCourse = "";
            School = "";
            CurrentDegreeCourses = "";

            Title = "";
            Description = "";
            MinCredit = 0;
            MaxCredit = 1;
            Prerequisite = "";
            CourseTimeInfo = new List<CourseTimeViewModel>();
            DefferedPrerequisites = new List<DefferedPrerequisiteModel>();
            CurrentDegreeCourses = "";
           
        }
}

    public class DefferedPrerequisiteModel
    {
        // this will have a courseId
       public int courseId { get; set; }

        // this feild does is not in the db yet
        public string prereqName { get; set; }

        public int groupId { get; set; }

    }
    public class PositiveNumber : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            
            if (value == null)
            {
                return true;
            }
            int val;
            if (int.TryParse(value.ToString(), out val))
            {

               

                if (val >= 0)
                    return true;
            }
            return false;

        }
    }


    public class PrereqValidation : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            string prereqString = (string)value;

            if (prereqString.IsNullOrWhiteSpace())
            {
                return true;
            }


            string[] groups = prereqString.Split(' ');

            if (groups.Length == 0)
            {
                return false;
            }                 

            string[] prereqGroups = prereqString.ToLower().Replace("or", "|").Split('|');

            if (prereqGroups.Any(m => m.IsNullOrWhiteSpace()))
            {
                return false;
            }

            foreach (string v in prereqGroups)
            {
                string[] groupCourses = v.Replace("and", "+").Split('+');

                if (groupCourses.Any(n => n.IsNullOrWhiteSpace()))
                {
                    return false;
                }

            }
            return true;
        }
    }


    public class CourseTimeViewModel
    {
        public string Quarter { get; set; }
        public bool Monday { get; set; }
        public bool Tuesday { get; set; }
        public bool Wednesday { get; set; }
        public bool Thursday { get; set; }
        public bool Friday { get; set; }
        [TimeInputValidation(ErrorMessage = "hh:mm:ss in military time")]
        public TimeSpan StartTime { get; set; }

        [TimeInputValidation(ErrorMessage = "hh:mm:ss in military time")]
        public TimeSpan EndTime { get; set; }     
    }



    public class TimeInputValidation : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value == null)
            {
                return false;
            }

            string s = value.ToString();
            string[] vals = s.Split(':');
            return true;
        }
    }


    public class DisplayCourseTimeViewModel
    {
        public string Quarter { get; set; }
        public bool Monday { get; set; }
        public bool Tuesday { get; set; }
        public bool Wednesday { get; set; }
        public bool Thursday { get; set; }
        public bool Friday { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public string CourseNumber { get; set; }
        public string Day { get; set; }
        public string Section { get; set; }
    }

    public class CollectCourseInfoViewModel
        {
            public string CourseNumber { get; set; }
        public string Title { get; set; }
        public int MinCredit { get; set; }
        public int MaxCredit { get; set; }
        public string Description { get; set; }
        public string Prerequisite { get; set; }
    
    }

    public class ScheduleViewModel
    {
        public string Course { get; set; }
        public int CourseId { get; set; }
    }
}