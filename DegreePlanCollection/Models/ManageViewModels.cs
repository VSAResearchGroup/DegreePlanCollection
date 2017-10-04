using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using System.Web.Razor;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;

namespace DegreePlanCollection.Models
{
    public class IndexViewModel
    {
        public bool HasPassword { get; set; }
        public IList<UserLoginInfo> Logins { get; set; }
        public string PhoneNumber { get; set; }
        public bool TwoFactor { get; set; }
        public bool BrowserRemembered { get; set; }
    }

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

    public class CourseCourseIDViewModel
    {
        public string Course { get; set; }
        public int CourseId { get; set; }
    }

   
  

    public class ManageLoginsViewModel
    {
        public IList<UserLoginInfo> CurrentLogins { get; set; }
        public IList<AuthenticationDescription> OtherLogins { get; set; }
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
        public string Description { get; set; }

        [Display(Name = "Minimum Credits")]
        public int MinCredit { get; set; }


        [Required]
        [Range(1, 20)]
        [Display(Name = "Maximum Credits")]
        public int MaxCredit { get; set; }

        [Display(Name = "Prerequisite Group")]
        public string Prerequisite { get; set; }

        public IList<CourseTimeViewModel> CourseTimeInfo { get; set; }


        public string deferredPrereqs { get; set; }

        public CollectDegreeViewModel()
        {
            CurrentDegree = "";
            CurrentCourse = "";
            School = "";
            CurrentDegreeCourses = "";

        CurrentCollectDegreeInfoCourses = "";

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
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }     
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

    public class FactorViewModel
    {
        public string Purpose { get; set; }
    }

    public class SetPasswordViewModel
    {
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "New password")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm new password")]
        [System.ComponentModel.DataAnnotations.Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }

    public class ChangePasswordViewModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Current password")]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "New password")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm new password")]
        [System.ComponentModel.DataAnnotations.Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }

    public class AddPhoneNumberViewModel
    {
        [Required]
        [Phone]
        [Display(Name = "Phone Number")]
        public string Number { get; set; }
    }

    public class VerifyPhoneNumberViewModel
    {
        [Required]
        [Display(Name = "Code")]
        public string Code { get; set; }

        [Required]
        [Phone]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }
    }

    public class ConfigureTwoFactorViewModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
    }
}