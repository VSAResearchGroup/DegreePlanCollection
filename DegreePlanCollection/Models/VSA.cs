namespace DegreePlanCollection.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class VSA : DbContext
    {
        public VSA()
            : base("name=VSA")
        {
        }

        public virtual DbSet<C_TimeSlot> C_TimeSlot { get; set; }
        public virtual DbSet<AcademicYear> AcademicYears { get; set; }
        public virtual DbSet<ACCOUNT> ACCOUNTS { get; set; }
        public virtual DbSet<CODEKEY> CODEKEYS { get; set; }
        public virtual DbSet<COLLEGE_ADMISSION_CODEKEYS> COLLEGE_ADMISSION_CODEKEYS { get; set; }
        public virtual DbSet<COLLEGE_ADMISSION_COURSES> COLLEGE_ADMISSION_COURSES { get; set; }
        public virtual DbSet<COLLEGE_ADMISSION_DEPARTMENTS> COLLEGE_ADMISSION_DEPARTMENTS { get; set; }
        public virtual DbSet<COLLEGE_DEPARTMENTS> COLLEGE_DEPARTMENTS { get; set; }
        public virtual DbSet<COLLEGE_NOTES> COLLEGE_NOTES { get; set; }
        public virtual DbSet<COLLEGE_RANKINGS> COLLEGE_RANKINGS { get; set; }
        public virtual DbSet<COLLEGE> COLLEGES { get; set; }
        public virtual DbSet<Corequisite> Corequisites { get; set; }
        public virtual DbSet<COREQUISITE1> COREQUISITES1 { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<COURSE_RANKINGS> COURSE_RANKINGS { get; set; }
        public virtual DbSet<COURS> COURSES1 { get; set; }
        public virtual DbSet<CourseTime> CourseTimes { get; set; }
        public virtual DbSet<DEGREE_ADMISSION_CATEGORIES> DEGREE_ADMISSION_CATEGORIES { get; set; }
        public virtual DbSet<DEGREE_ADMISSION_COURSES> DEGREE_ADMISSION_COURSES { get; set; }
        public virtual DbSet<DEGREE_CATEGORIES> DEGREE_CATEGORIES { get; set; }
        public virtual DbSet<DEGREE_GRADUATION_CATEGORIES> DEGREE_GRADUATION_CATEGORIES { get; set; }
        public virtual DbSet<DEGREE_GRADUATION_COURSES> DEGREE_GRADUATION_COURSES { get; set; }
        public virtual DbSet<DEGREE_NOTES> DEGREE_NOTES { get; set; }
        public virtual DbSet<DEGREE_RANKINGS> DEGREE_RANKINGS { get; set; }
        public virtual DbSet<DEGREE> DEGREES { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<DEPARTMENT_RANKINGS> DEPARTMENT_RANKINGS { get; set; }
        public virtual DbSet<DEPARTMENT1> DEPARTMENTS1 { get; set; }
        public virtual DbSet<FACULTY> FACULTies { get; set; }
        public virtual DbSet<GeneratedPlan> GeneratedPlans { get; set; }
        public virtual DbSet<JobType> JobTypes { get; set; }
        public virtual DbSet<Major> Majors { get; set; }
        public virtual DbSet<Parameter> Parameters { get; set; }
        public virtual DbSet<ParameterSet> ParameterSets { get; set; }
        public virtual DbSet<PLAN_SELECTEDCOURSES> PLAN_SELECTEDCOURSES { get; set; }
        public virtual DbSet<PlanRating> PlanRatings { get; set; }
        public virtual DbSet<PlanRatingDescription> PlanRatingDescriptions { get; set; }
        public virtual DbSet<PlanRatingOption> PlanRatingOptions { get; set; }
        public virtual DbSet<PLAN> PLANS { get; set; }
        public virtual DbSet<Prerequisite> Prerequisites { get; set; }
        public virtual DbSet<PREREQUISITE_PERMISSIONS> PREREQUISITE_PERMISSIONS { get; set; }
        public virtual DbSet<PREREQUISITE_PLACEMENTS> PREREQUISITE_PLACEMENTS { get; set; }
        public virtual DbSet<PREREQUISITE1> PREREQUISITES1 { get; set; }
        public virtual DbSet<Quarter> Quarters { get; set; }
        public virtual DbSet<ReviewedStudyPlan> ReviewedStudyPlans { get; set; }
        public virtual DbSet<Section> Sections { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<STUDENT_PLACEMENTCOURSES> STUDENT_PLACEMENTCOURSES { get; set; }
        public virtual DbSet<StudentEnrollment> StudentEnrollments { get; set; }
        public virtual DbSet<StudentModifiedStudyPlan> StudentModifiedStudyPlans { get; set; }
        public virtual DbSet<STUDENT1> STUDENTS1 { get; set; }
        public virtual DbSet<STUDENTS_COMPLETEDCOURSES> STUDENTS_COMPLETEDCOURSES { get; set; }
        public virtual DbSet<StudentStudyPlan> StudentStudyPlans { get; set; }
        public virtual DbSet<StudyPlan> StudyPlans { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<WeekDay> WeekDays { get; set; }
        public virtual DbSet<AdmissionRequiredCours> AdmissionRequiredCourses { get; set; }
        public virtual DbSet<Budget> Budgets { get; set; }
        public virtual DbSet<MockUpData> MockUpDatas { get; set; }
        public virtual DbSet<PrerequisiteTransfer> PrerequisiteTransfers { get; set; }
        public virtual DbSet<Requisite> Requisites { get; set; }
        public virtual DbSet<RequisitesType> RequisitesTypes { get; set; }
        public virtual DbSet<ResidentStatu> ResidentStatus { get; set; }
        public virtual DbSet<School> Schools { get; set; }
        public virtual DbSet<StudentPlan> StudentPlans { get; set; }
        public virtual DbSet<TimePreference> TimePreferences { get; set; }
        public virtual DbSet<TimeSlot> TimeSlots { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<C_TimeSlot>()
                .Property(e => e.Time)
                .HasPrecision(0);

            modelBuilder.Entity<ACCOUNT>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<ACCOUNT>()
                .Property(e => e.first_name)
                .IsUnicode(false);

            modelBuilder.Entity<ACCOUNT>()
                .Property(e => e.last_name)
                .IsUnicode(false);

            modelBuilder.Entity<ACCOUNT>()
                .Property(e => e.password)
                .IsUnicode(false);

            modelBuilder.Entity<ACCOUNT>()
                .Property(e => e.salt)
                .IsUnicode(false);

            modelBuilder.Entity<ACCOUNT>()
                .HasOptional(e => e.FACULTY)
                .WithRequired(e => e.ACCOUNT)
                .WillCascadeOnDelete();

            modelBuilder.Entity<ACCOUNT>()
                .HasOptional(e => e.STUDENT)
                .WithRequired(e => e.ACCOUNT)
                .WillCascadeOnDelete();

            modelBuilder.Entity<CODEKEY>()
                .Property(e => e.codekey1)
                .IsUnicode(false);

            modelBuilder.Entity<CODEKEY>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<CODEKEY>()
                .HasMany(e => e.COLLEGE_ADMISSION_CODEKEYS)
                .WithRequired(e => e.CODEKEY)
                .HasForeignKey(e => e.codekeys_id);

            modelBuilder.Entity<CODEKEY>()
                .HasMany(e => e.COURSES)
                .WithMany(e => e.CODEKEYS)
                .Map(m => m.ToTable("COURSES_CODEKEYS").MapLeftKey("codekeys_id").MapRightKey("courses_id"));

            modelBuilder.Entity<COLLEGE_ADMISSION_CODEKEYS>()
                .Property(e => e.credit)
                .HasPrecision(4, 2);

            modelBuilder.Entity<COLLEGE_ADMISSION_COURSES>()
                .Property(e => e.foreign_course_number)
                .IsUnicode(false);

            modelBuilder.Entity<COLLEGE_ADMISSION_DEPARTMENTS>()
                .Property(e => e.credit)
                .HasPrecision(4, 2);

            modelBuilder.Entity<COLLEGE_NOTES>()
                .Property(e => e.courses_note)
                .IsUnicode(false);

            modelBuilder.Entity<COLLEGE_NOTES>()
                .Property(e => e.departments_note)
                .IsUnicode(false);

            modelBuilder.Entity<COLLEGE_NOTES>()
                .Property(e => e.codekeys_note)
                .IsUnicode(false);

            modelBuilder.Entity<COLLEGE>()
                .Property(e => e.college_name)
                .IsUnicode(false);

            modelBuilder.Entity<COLLEGE>()
                .Property(e => e.college_city)
                .IsUnicode(false);

            modelBuilder.Entity<COLLEGE>()
                .Property(e => e.college_website)
                .IsUnicode(false);

            modelBuilder.Entity<COLLEGE>()
                .HasMany(e => e.COLLEGE_ADMISSION_CODEKEYS)
                .WithRequired(e => e.COLLEGE)
                .HasForeignKey(e => e.colleges_id);

            modelBuilder.Entity<COLLEGE>()
                .HasMany(e => e.COLLEGE_ADMISSION_COURSES)
                .WithRequired(e => e.COLLEGE)
                .HasForeignKey(e => e.colleges_id);

            modelBuilder.Entity<COLLEGE>()
                .HasMany(e => e.COLLEGE_ADMISSION_DEPARTMENTS)
                .WithRequired(e => e.COLLEGE)
                .HasForeignKey(e => e.colleges_id);

            modelBuilder.Entity<COLLEGE>()
                .HasMany(e => e.COLLEGE_DEPARTMENTS)
                .WithRequired(e => e.COLLEGE)
                .HasForeignKey(e => e.colleges_id);

            modelBuilder.Entity<COLLEGE>()
                .HasOptional(e => e.COLLEGE_NOTES)
                .WithRequired(e => e.COLLEGE)
                .WillCascadeOnDelete();

            modelBuilder.Entity<COLLEGE>()
                .HasOptional(e => e.COLLEGE_RANKINGS)
                .WithRequired(e => e.COLLEGE)
                .WillCascadeOnDelete();

            modelBuilder.Entity<COLLEGE>()
                .HasMany(e => e.DEGREES)
                .WithRequired(e => e.COLLEGE)
                .HasForeignKey(e => e.colleges_id);

            modelBuilder.Entity<Course>()
                .Property(e => e.CourseNumber)
                .IsFixedLength();

            modelBuilder.Entity<Course>()
                .Property(e => e.AbbreviatedTitle)
                .IsUnicode(false);

            modelBuilder.Entity<Course>()
                .Property(e => e.Title)
                .IsUnicode(false);

            modelBuilder.Entity<Course>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Course>()
                .Property(e => e.PreRequisites)
                .IsUnicode(false);

            modelBuilder.Entity<Course>()
                .Property(e => e.CoRequisites)
                .IsUnicode(false);

            modelBuilder.Entity<Course>()
                .HasMany(e => e.Prerequisites1)
                .WithRequired(e => e.Course)
                .HasForeignKey(e => e.CourseID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Course>()
                .HasMany(e => e.Prerequisites2)
                .WithRequired(e => e.Course1)
                .HasForeignKey(e => e.PrerequisiteID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<COURS>()
                .Property(e => e.course_number)
                .IsUnicode(false);

            modelBuilder.Entity<COURS>()
                .Property(e => e.title)
                .IsUnicode(false);

            modelBuilder.Entity<COURS>()
                .Property(e => e.min_credit)
                .HasPrecision(4, 2);

            modelBuilder.Entity<COURS>()
                .Property(e => e.max_credit)
                .HasPrecision(4, 2);

            modelBuilder.Entity<COURS>()
                .Property(e => e.course_description)
                .IsUnicode(false);

            modelBuilder.Entity<COURS>()
                .HasMany(e => e.COLLEGE_ADMISSION_COURSES)
                .WithRequired(e => e.COURS)
                .HasForeignKey(e => e.courses_id);

            modelBuilder.Entity<COURS>()
                .HasMany(e => e.COREQUISITES)
                .WithRequired(e => e.COURS)
                .HasForeignKey(e => e.courses_corequisite_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<COURS>()
                .HasMany(e => e.COREQUISITES1)
                .WithRequired(e => e.COURS1)
                .HasForeignKey(e => e.courses_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<COURS>()
                .HasOptional(e => e.COURSE_RANKINGS)
                .WithRequired(e => e.COURS)
                .WillCascadeOnDelete();

            modelBuilder.Entity<COURS>()
                .HasMany(e => e.DEGREE_ADMISSION_COURSES)
                .WithRequired(e => e.COURS)
                .HasForeignKey(e => e.courses_id);

            modelBuilder.Entity<COURS>()
                .HasMany(e => e.DEGREE_GRADUATION_COURSES)
                .WithRequired(e => e.COURS)
                .HasForeignKey(e => e.courses_id);

            modelBuilder.Entity<COURS>()
                .HasMany(e => e.PLAN_SELECTEDCOURSES)
                .WithRequired(e => e.COURS)
                .HasForeignKey(e => e.courses_id);

            modelBuilder.Entity<COURS>()
                .HasOptional(e => e.PREREQUISITE_PERMISSIONS)
                .WithRequired(e => e.COURS)
                .WillCascadeOnDelete();

            modelBuilder.Entity<COURS>()
                .HasOptional(e => e.PREREQUISITE_PLACEMENTS)
                .WithRequired(e => e.COURS)
                .WillCascadeOnDelete();

            modelBuilder.Entity<COURS>()
                .HasMany(e => e.PREREQUISITES)
                .WithRequired(e => e.COURS)
                .HasForeignKey(e => e.courses_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<COURS>()
                .HasMany(e => e.PREREQUISITES1)
                .WithRequired(e => e.COURS1)
                .HasForeignKey(e => e.courses_prerequisite_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<COURS>()
                .HasMany(e => e.STUDENT_PLACEMENTCOURSES)
                .WithRequired(e => e.COURS)
                .HasForeignKey(e => e.english_courses_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<COURS>()
                .HasMany(e => e.STUDENT_PLACEMENTCOURSES1)
                .WithRequired(e => e.COURS1)
                .HasForeignKey(e => e.math_courses_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<COURS>()
                .HasMany(e => e.STUDENTS_COMPLETEDCOURSES)
                .WithRequired(e => e.COURS)
                .HasForeignKey(e => e.courses_id);

            modelBuilder.Entity<CourseTime>()
                .Property(e => e.CourseNumber)
                .IsFixedLength();

            modelBuilder.Entity<DEGREE_ADMISSION_CATEGORIES>()
                .Property(e => e.credit)
                .HasPrecision(4, 2);

            modelBuilder.Entity<DEGREE_ADMISSION_COURSES>()
                .Property(e => e.foreign_course_number)
                .IsUnicode(false);

            modelBuilder.Entity<DEGREE_CATEGORIES>()
                .Property(e => e.category)
                .IsUnicode(false);

            modelBuilder.Entity<DEGREE_CATEGORIES>()
                .HasMany(e => e.DEGREE_ADMISSION_CATEGORIES)
                .WithRequired(e => e.DEGREE_CATEGORIES)
                .HasForeignKey(e => e.degree_categories_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DEGREE_CATEGORIES>()
                .HasMany(e => e.DEGREE_ADMISSION_COURSES)
                .WithRequired(e => e.DEGREE_CATEGORIES)
                .HasForeignKey(e => e.degree_categories_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DEGREE_CATEGORIES>()
                .HasMany(e => e.DEGREE_GRADUATION_CATEGORIES)
                .WithRequired(e => e.DEGREE_CATEGORIES)
                .HasForeignKey(e => e.degree_categories_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DEGREE_CATEGORIES>()
                .HasMany(e => e.DEGREE_GRADUATION_COURSES)
                .WithRequired(e => e.DEGREE_CATEGORIES)
                .HasForeignKey(e => e.degree_categories_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DEGREE_CATEGORIES>()
                .HasMany(e => e.PLAN_SELECTEDCOURSES)
                .WithRequired(e => e.DEGREE_CATEGORIES)
                .HasForeignKey(e => e.degree_categories_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DEGREE_GRADUATION_CATEGORIES>()
                .Property(e => e.credit)
                .HasPrecision(4, 2);

            modelBuilder.Entity<DEGREE_GRADUATION_COURSES>()
                .Property(e => e.foreign_course_number)
                .IsUnicode(false);

            modelBuilder.Entity<DEGREE_NOTES>()
                .Property(e => e.admission_courses_note)
                .IsUnicode(false);

            modelBuilder.Entity<DEGREE_NOTES>()
                .Property(e => e.admission_categories_note)
                .IsUnicode(false);

            modelBuilder.Entity<DEGREE_NOTES>()
                .Property(e => e.graduation_courses_note)
                .IsUnicode(false);

            modelBuilder.Entity<DEGREE_NOTES>()
                .Property(e => e.graduation_categories_note)
                .IsUnicode(false);

            modelBuilder.Entity<DEGREE_NOTES>()
                .Property(e => e.general_note)
                .IsUnicode(false);

            modelBuilder.Entity<DEGREE>()
                .Property(e => e.degree_name)
                .IsUnicode(false);

            modelBuilder.Entity<DEGREE>()
                .Property(e => e.degree_type)
                .IsUnicode(false);

            modelBuilder.Entity<DEGREE>()
                .HasMany(e => e.DEGREE_ADMISSION_CATEGORIES)
                .WithRequired(e => e.DEGREE)
                .HasForeignKey(e => e.degrees_id);

            modelBuilder.Entity<DEGREE>()
                .HasMany(e => e.DEGREE_ADMISSION_COURSES)
                .WithRequired(e => e.DEGREE)
                .HasForeignKey(e => e.degrees_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DEGREE>()
                .HasMany(e => e.DEGREE_CATEGORIES)
                .WithRequired(e => e.DEGREE)
                .HasForeignKey(e => e.degrees_id);

            modelBuilder.Entity<DEGREE>()
                .HasMany(e => e.DEGREE_GRADUATION_CATEGORIES)
                .WithRequired(e => e.DEGREE)
                .HasForeignKey(e => e.degrees_id);

            modelBuilder.Entity<DEGREE>()
                .HasMany(e => e.DEGREE_GRADUATION_COURSES)
                .WithRequired(e => e.DEGREE)
                .HasForeignKey(e => e.degrees_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DEGREE>()
                .HasOptional(e => e.DEGREE_NOTES)
                .WithRequired(e => e.DEGREE)
                .WillCascadeOnDelete();

            modelBuilder.Entity<DEGREE>()
                .HasOptional(e => e.DEGREE_RANKINGS)
                .WithRequired(e => e.DEGREE)
                .WillCascadeOnDelete();

            modelBuilder.Entity<DEGREE>()
                .HasMany(e => e.PLANS)
                .WithMany(e => e.DEGREES)
                .Map(m => m.ToTable("PLAN_SELECTEDDEGREES").MapLeftKey("degrees_id").MapRightKey("plans_id"));

            modelBuilder.Entity<Department>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Department>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Department>()
                .Property(e => e.Code)
                .IsUnicode(false);

            modelBuilder.Entity<Department>()
                .HasMany(e => e.Courses)
                .WithOptional(e => e.Department)
                .WillCascadeOnDelete();

            modelBuilder.Entity<DEPARTMENT1>()
                .Property(e => e.department_name)
                .IsUnicode(false);

            modelBuilder.Entity<DEPARTMENT1>()
                .Property(e => e.see_also)
                .IsUnicode(false);

            modelBuilder.Entity<DEPARTMENT1>()
                .Property(e => e.dept_intro)
                .IsUnicode(false);

            modelBuilder.Entity<DEPARTMENT1>()
                .Property(e => e.abv_title)
                .IsUnicode(false);

            modelBuilder.Entity<DEPARTMENT1>()
                .Property(e => e.abv_title2)
                .IsUnicode(false);

            modelBuilder.Entity<DEPARTMENT1>()
                .HasMany(e => e.COLLEGE_ADMISSION_DEPARTMENTS)
                .WithRequired(e => e.DEPARTMENT)
                .HasForeignKey(e => e.departments_id);

            modelBuilder.Entity<DEPARTMENT1>()
                .HasMany(e => e.COLLEGE_DEPARTMENTS)
                .WithRequired(e => e.DEPARTMENT)
                .HasForeignKey(e => e.departments_id);

            modelBuilder.Entity<DEPARTMENT1>()
                .HasMany(e => e.COURSES)
                .WithRequired(e => e.DEPARTMENT)
                .HasForeignKey(e => e.departments_id);

            modelBuilder.Entity<DEPARTMENT1>()
                .HasMany(e => e.DEGREES)
                .WithRequired(e => e.DEPARTMENT)
                .HasForeignKey(e => e.departments_id);

            modelBuilder.Entity<DEPARTMENT1>()
                .HasOptional(e => e.DEPARTMENT_RANKINGS)
                .WithRequired(e => e.DEPARTMENT)
                .WillCascadeOnDelete();

            modelBuilder.Entity<GeneratedPlan>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<GeneratedPlan>()
                .HasMany(e => e.StudyPlans)
                .WithOptional(e => e.GeneratedPlan)
                .HasForeignKey(e => e.PlanID);

            modelBuilder.Entity<GeneratedPlan>()
                .HasMany(e => e.StudyPlans1)
                .WithOptional(e => e.GeneratedPlan1)
                .HasForeignKey(e => e.PlanID);

            modelBuilder.Entity<JobType>()
                .Property(e => e.JobType1)
                .IsUnicode(false);

            modelBuilder.Entity<Major>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Major>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Major>()
                .Property(e => e.DegreeType)
                .IsUnicode(false);

            modelBuilder.Entity<Parameter>()
                .Property(e => e.TimePreferenceID)
                .IsFixedLength();

            modelBuilder.Entity<Parameter>()
                .Property(e => e.QuarterPreferenceID)
                .IsFixedLength();

            modelBuilder.Entity<Parameter>()
                .Property(e => e.Placements)
                .IsUnicode(false);

            modelBuilder.Entity<Parameter>()
                .Property(e => e.Completed)
                .IsUnicode(false);

            modelBuilder.Entity<ParameterSet>()
                .Property(e => e.CompletedCourses)
                .IsUnicode(false);

            modelBuilder.Entity<ParameterSet>()
                .Property(e => e.PlacementCourses)
                .IsUnicode(false);

            modelBuilder.Entity<PLAN_SELECTEDCOURSES>()
                .Property(e => e.credit)
                .HasPrecision(4, 2);

            modelBuilder.Entity<PLAN>()
                .Property(e => e.plan_name)
                .IsUnicode(false);

            modelBuilder.Entity<PLAN>()
                .HasMany(e => e.PLAN_SELECTEDCOURSES)
                .WithRequired(e => e.PLAN)
                .HasForeignKey(e => e.plans_id);

            modelBuilder.Entity<PLAN>()
                .HasMany(e => e.STUDENTS)
                .WithMany(e => e.PLANS1)
                .Map(m => m.ToTable("PLAN_ACTIVEPLANS").MapLeftKey("plans_id").MapRightKey("students_accounts_id"));

            modelBuilder.Entity<PREREQUISITE_PLACEMENTS>()
                .Property(e => e.placement)
                .IsUnicode(false);

            modelBuilder.Entity<Quarter>()
                .Property(e => e.Quarter1)
                .IsFixedLength();

            modelBuilder.Entity<ReviewedStudyPlan>()
                .Property(e => e.PlanName)
                .IsUnicode(false);

            modelBuilder.Entity<Section>()
                .Property(e => e.Section1)
                .IsFixedLength();

            modelBuilder.Entity<Student>()
                .HasMany(e => e.StudentEnrollments)
                .WithRequired(e => e.Student)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<StudentEnrollment>()
                .Property(e => e.CourseNumber)
                .IsFixedLength();

            modelBuilder.Entity<STUDENT1>()
                .HasMany(e => e.PLANS)
                .WithRequired(e => e.STUDENT)
                .HasForeignKey(e => e.students_accounts_id);

            modelBuilder.Entity<STUDENT1>()
                .HasOptional(e => e.STUDENT_PLACEMENTCOURSES)
                .WithRequired(e => e.STUDENT)
                .WillCascadeOnDelete();

            modelBuilder.Entity<STUDENT1>()
                .HasMany(e => e.STUDENTS_COMPLETEDCOURSES)
                .WithRequired(e => e.STUDENT)
                .HasForeignKey(e => e.students_accounts_id);

            modelBuilder.Entity<STUDENTS_COMPLETEDCOURSES>()
                .Property(e => e.credit)
                .HasPrecision(4, 2);

            modelBuilder.Entity<StudyPlan>()
                .HasMany(e => e.ReviewedStudyPlans)
                .WithOptional(e => e.StudyPlan)
                .HasForeignKey(e => e.PlanID);

            modelBuilder.Entity<WeekDay>()
                .Property(e => e.WeekDay1)
                .IsFixedLength();

            modelBuilder.Entity<Budget>()
                .Property(e => e.Budget1)
                .IsUnicode(false);

            modelBuilder.Entity<MockUpData>()
                .Property(e => e.Major)
                .IsUnicode(false);

            modelBuilder.Entity<PrerequisiteTransfer>()
                .Property(e => e.CourseNumber)
                .IsUnicode(false);

            modelBuilder.Entity<PrerequisiteTransfer>()
                .Property(e => e.PrerequisiteNumber)
                .IsUnicode(false);

            modelBuilder.Entity<Requisite>()
                .Property(e => e.CourseName)
                .IsFixedLength();

            modelBuilder.Entity<Requisite>()
                .Property(e => e.RequisiteName)
                .IsFixedLength();

            modelBuilder.Entity<ResidentStatu>()
                .Property(e => e.Residency)
                .IsUnicode(false);

            modelBuilder.Entity<School>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<School>()
                .Property(e => e.Acronymn)
                .IsUnicode(false);

            modelBuilder.Entity<School>()
                .Property(e => e.Address)
                .IsUnicode(false);

            modelBuilder.Entity<StudentPlan>()
                .Property(e => e.PlanName)
                .IsUnicode(false);

            modelBuilder.Entity<TimePreference>()
                .Property(e => e.TimePeriod)
                .IsUnicode(false);

            modelBuilder.Entity<TimeSlot>()
                .Property(e => e.Time)
                .HasPrecision(0);
        }
    }
}
