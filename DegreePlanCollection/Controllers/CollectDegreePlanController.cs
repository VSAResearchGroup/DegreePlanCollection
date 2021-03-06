﻿using System;
using System.Collections.Generic;

using System.Linq;
using System.Net;
using System.Web.DynamicData;
using System.Web.Mvc;

using DegreePlanCollection.Models;
using Microsoft.Ajax.Utilities;

namespace DegreePlanCollection.Controllers
{
    public class CollectDegreePlanController : Controller
    {
        private VSA db = new VSA();


       
        // GET: CollectDegreePlan
        public ActionResult Index()
        {
            var models = db.AdmissionRequiredCourses.Select(f => new { f.MajorID, f.SchoolID }).Distinct();
            var final = from p in models
                        join pm in db.Majors on (int)p.MajorID equals pm.ID
                        join s in db.Schools on (int)p.SchoolID equals s.ID
                        orderby pm.Name
                        select new SchoolMajorViewModel { Major = pm.Name, MajorId = (int)p.MajorID, School = s.Name, SchoolId = (int)p.SchoolID };
            return View(final.ToList());
        }

        // GET: CollectDegreePlan/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prerequisite prerequisite = db.Prerequisites.Find(id);
            if (prerequisite == null)
            {
                return HttpNotFound();
            }
            return View(prerequisite);
        }

      


        public ActionResult Create()
        {
            CollectDegreeViewModel newDegree = new CollectDegreeViewModel();
            var schools = from f in db.Schools select f.Name;       
            newDegree.Schools = new SelectList(schools);
            return View(newDegree);

        }

        /// <summary>
        /// Add the current core course to the CurrentDegreeCourses
        /// </summary>
        /// <param name="m">Collect Degree Info model</param>
        /// <returns>The CollectCoure Course page</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddCourseToList(CollectDegreeViewModel m)
        {

            if (m.CurrentDegreeCourses == null)
            {
                m.CurrentDegreeCourses = m.CurrentCourse;

            }
            else
            {
                if(!m.CurrentDegreeCourses.Contains(m.CurrentCourse))
                    m.CurrentDegreeCourses += "|" + m.CurrentCourse;

            }


            m.CurrentCourse = "";
            return View("CollectCoreCourses", m);
        }

       /// <summary>
       /// Takes a list of required courses and creates list of courses that need info collected
       /// 
       /// </summary>
       /// <param name="m"></param>
       /// <returns>CollectCourseInfo view if there are courses to collect info from
       ///          Index if there are no courses to collect info from
       /// </returns>
        [ValidateAntiForgeryToken]
        public ActionResult CollectCourseInfo(CollectDegreeViewModel m)
        {
            // courses are seperated by | character
            string[] courses = m.CurrentDegreeCourses.Split('|');

            // upper case needs trimming
            var dbCourses = db.Courses.Select(c => c.CourseNumber);

            // This will be more accurate when there is autocomplete
            // users will less likely enter MATH105 when MATH 105 is correct
            string coursesRequireInfo = "";
            string firstCourse = "";
            foreach (string s in courses)
            {
                if (!dbCourses.Any(g => g.Trim().Equals(s)))
                {
                    // course doesn't exits in db 

                    firstCourse = s;
                    if (coursesRequireInfo.Equals(""))
                    {
                        coursesRequireInfo = s;
                    }
                    else
                    {
                        coursesRequireInfo += "|" + s;
                    }
                }
                else {
                    // course  exits in db 
                    //    no prereqs                  no time scheduling
                    if (!CourseHasPrereqs(s) || !CourseHasCourseSchedule(s))
                    {
                        // skip over classes that have no entries in prereq since they have no prereqs
                        if (!CourseHasPrereqs(s) && CourseHasCourseSchedule(s) && db.Courses
                                .Where(c => c.CourseNumber.Trim().ToLower().Equals(s.Trim().ToLower()))
                                .Select(c => c.PreRequisites).FirstOrDefault().IsNullOrWhiteSpace())
                        {
                            continue;
                        }
                        firstCourse = s;
                        if (coursesRequireInfo.Equals(""))
                        {
                            coursesRequireInfo = s;
                        }
                        else
                        {
                            coursesRequireInfo += "|" + s;
                        }
                    }
                }
            }

            m.CurrentCollectDegreeInfoCourses = coursesRequireInfo;

            getNextModel(firstCourse, ref m);

            if (coursesRequireInfo.IsNullOrWhiteSpace())
            {
                WriteToAdmissonReq(m.CurrentDegreeCourses,m.CurrentDegree, m.School);
                return RedirectToAction("Index");
            }
            return View(m);
        }

        public ActionResult EditPlan(int MajorId, int SchoolId)
        {
            var requiredClasses = db.AdmissionRequiredCourses.Where(t => t.MajorID == MajorId && t.SchoolID == SchoolId).Select(t => new { t.CourseID });
            var final = from p in requiredClasses
                        join pm in db.Courses on p.CourseID equals pm.CourseID
                        select new CourseViewModel { Course = pm.CourseNumber, CourseId = (int)p.CourseID };
            return View(final.OrderBy(t => t).ToList());
        }

        /// <summary>
        /// Returns time id of TimeSpan string representation time
        /// </summary>
        /// <param name="time">String representation of a TimeSpan</param>
        /// <returns>time id</returns>
        /// <remarks>assuming time conforms to the TimeSlot format</remarks>
        public int GetTimeId(string time)
        {
            // assuming time conforms to the TimeSlot format

            var times = db.TimeSlots.Where(m => m.Time.ToString().Equals(time)).Select(m => m.TimeID);
            return times.First();
        }
        /// <summary>
        /// returns TimeSpan representation of TimeSpan associated with timeId
        /// </summary>
        /// <param name="timeId">Time id</param>
        /// <returns>returns TimeSpan representation of TimeSpan associated with timeId</returns>
        public TimeSpan GetTimeStringRep(int timeId)
        {
           

            var times = db.TimeSlots.Where(m => m.TimeID.Equals(timeId)).Select(m => m.Time);
            return (TimeSpan) times.First();
        }

        /// <summary>
        /// Takes the list of course schedulings and course number to populate CourseTime table
        /// </summary>
        /// <param name="m">list of day and start and end times</param>
        /// <param name="courseNumber">Course Title</param>
        public void writeToCourseTime(List<CourseTimeViewModel> m, string courseNumber)
        {

            foreach (var v in m)
            {
                int courseId = getCourseId(courseNumber);

                int q = GetQuarterStringToInt(v.Quarter);
                bool[] days = { v.Monday, v.Tuesday, v.Wednesday, v.Thursday, v.Friday };
                int startTime = GetTimeId(v.StartTime.ToString());
                int endTime = GetTimeId(v.EndTime.ToString());

                for (int i = 0; i < days.Length; i++)
                {
                    if (days[i])
                    {
                        db.CourseTimes.Add(new CourseTime
                        {
                            CourseID = courseId,
                            CourseNumber = courseNumber,
                            StartTimeID = startTime,
                            EndTimeID = endTime,
                            DayID = i + 1,
                            QuarterID = q,
                            Year = 1,
                            Status = -1,
                            SectionID = 20
                        });
                    }
                }
            }
            db.SaveChanges();
        }

        /// <summary>
        /// Takes quarter string and returnns the id associated with it
        /// </summary>
        /// <param name="s">the quarter in string format</param>
        /// <returns>the quarter's id</returns>
        public int GetQuarterStringToInt(string s)
        {
            switch (s.ToLower())
            {
                case "fall":
                    return 1;
                case "winter":
                    return 2;
                case "spring":
                    return 3;
                case "summer":
                    return 4;
                default:
                    return -1;
            }
        }

        /// <summary>
        /// Writes course info to database. Enumerates through list till all courses are written to db 
        /// </summary>
        /// <param name="m">Model for degree info collection</param>
        /// <returns>CollectCourseInfo if the model is invalid or there are still courses that need to be collected
        /// Index if there are no courses to collect info from
        /// </returns>
        [ValidateAntiForgeryToken]
        public ActionResult WriteCourseToDb(CollectDegreeViewModel m)
        {
            if (ModelState.IsValid)
            {
                List<string> courses = m.CurrentCollectDegreeInfoCourses.Split('|').ToList();

                if (!(CheckIfCourseInDb(m.currentCollectInfoCourse) &&
                    CourseHasCourseSchedule(m.currentCollectInfoCourse) && CourseHasPrereqs(m.currentCollectInfoCourse)))
                {
                


                // write course to Courses Table
                    if (!CheckIfCourseInDb(m.currentCollectInfoCourse))
                    {
                        WriteToCourseTable(m.currentCollectInfoCourse, m.Title, m.MinCredit, m.MaxCredit, m.Description,
                            m.Prerequisite);
                    }

                    // the coures will be guaranteed to be in the db at this point


                    // if there are no time scheduling, write to the Course Time table
                    if (!CourseHasCourseSchedule(m.currentCollectInfoCourse))
                    {
                        writeToCourseTime(m.CourseTimeInfo.ToList(), m.currentCollectInfoCourse);
                    }


                    // courses is a list of courses that still need info collect from user
                    List<DefferedPrerequisiteModel> f = m.DefferedPrerequisites.ToList();
                    // skip over courses without prereqs or courses that all ready have prereq entries
                    if (!m.Prerequisite.IsNullOrWhiteSpace() || CourseHasPrereqs(m.currentCollectInfoCourse))
                    {

                        WritePrereqs(m.Prerequisite, m.currentCollectInfoCourse, ref courses, ref f);

                        m.DefferedPrerequisites = f;
                    }
                }
                string[] coursesArr = courses.ToArray();
                
                // take elements 1 to courseArr.Length -1
                string nextCollectDegreeInfoCourses = string.Join("|", coursesArr.Reverse().Take(coursesArr.Length - 1).Reverse());
                m.CurrentCollectDegreeInfoCourses = nextCollectDegreeInfoCourses;

                // if the nextCollectDegreeInfo Course is empty, the degree collection is over
                if (nextCollectDegreeInfoCourses.IsNullOrWhiteSpace())
                {
                  

                    // write Degree courses to the admission required table
                    WriteToAdmissonReq(m.CurrentDegreeCourses, m.CurrentDegree, m.School, m.DefferedPrerequisites.ToList());


                    return RedirectToAction("Index");
                }
                
                // the first is the current the second is the next
                string nextCourse = coursesArr[1];


                // there are still courses to collect
                // reset course info for new course



                getNextModel(nextCourse,ref m);
                


                return View("CollectCourseInfo", m);
            }


            // model validation failed
            return View("CollectCourseInfo", m);
        }

        
        /// <summary>
        /// Creates model initilizing it with info associated with nextCourse
        /// </summary>
        /// <param name="nextCourse">The course that information will be collected from next</param>
        /// <param name="m">The degree collection model</param>
        private void getNextModel(string nextCourse,ref CollectDegreeViewModel m)
        {
            Course nCourse = getCourse(nextCourse);

            m.CourseTimeInfo = new List<CourseTimeViewModel>
            {
                new CourseTimeViewModel {Quarter = "Fall"},
                new CourseTimeViewModel {Quarter = "Winter"},
                new CourseTimeViewModel {Quarter = "Spring"},
                new CourseTimeViewModel {Quarter = "Summer"}
            };

            m.Title = "";
            m.Description = "";
            m.MinCredit = 0;
            m.MaxCredit = 1;
            m.Prerequisite = "";

            if (nCourse != null)
            {
                if (CourseHasCourseSchedule(nCourse.CourseNumber))
                {
                    m.CourseTimeInfo = null;
                }


                m.Title = nCourse.Title;
                m.Description = nCourse.Description;
                m.MinCredit = nCourse.MinCredit == null ? 0 : (int)nCourse.MinCredit;
                m.MaxCredit = nCourse.MaxCredit == null ? 0 : (int)nCourse.MaxCredit;
                m.Prerequisite = nCourse.PreRequisites;
            }
        }

        /// <summary>
        /// When information collection is done, all courses are written to the AdmissionRequiredCourses table
        /// </summary>
        /// <param name="currentDegreeCourses">string with all the degree required courses seperated with | </param>
        /// <param name="currentDegree">string of current Degree</param>
        /// <param name="school">string of school</param>
        /// <param name="deffered">list of courses that did not exist when assigned as another courses prereq  </param>
        private void WriteToAdmissonReq(string currentDegreeCourses, string currentDegree, string school, List<DefferedPrerequisiteModel> deffered =null)
        {
            string[] requiredCourses = currentDegreeCourses.Split('|');

            // write new degree to Major table
            if (!CheckIfDegreeInDb(currentDegree))
            {

                WriteToMajorsTable(currentDegree);

            }

            int majorId = getMajorId(currentDegree);
            int schoolId = getSchoolId(school);
            foreach (string s in requiredCourses)
            {
                int courseId = getCourseId(s);
                db.AdmissionRequiredCourses.Add(new AdmissionRequiredCours
                {
                    MajorID = majorId,
                    CourseID = courseId,
                    SchoolID = schoolId

                });

            }

            if (deffered != null)
            {
                // write deffered prerreqs to Prerequisite table
                foreach (var v in deffered)
                {
                    int courseId = v.courseId;

                    // the prereq is now in the db so it is save to get the courseid
                    int prereqId = getCourseId(v.prereqName);
                    db.Prerequisites.Add(new Prerequisite
                    {

                        CourseID = courseId,
                        PrerequisiteID = prereqId,
                        GroupID = v.groupId

                    });
                }

            }
            db.SaveChanges();

        }

        /// <summary>
        /// Returns the Course with CourseNumber courseNumber
        /// </summary>
        /// <param name="courseNumber">CourseNumber of course</param>
        /// <returns>Course with CourseNumber courseNumber</returns>
        private Course getCourse(string courseNumber)
        {
            var c = db.Courses.Where(m => m.CourseNumber.Equals(courseNumber));
         
            return    c.FirstOrDefault();

        }

        /// <summary>
        /// Write major to majors table
        /// </summary>
        /// <param name="major">major</param>
        private void WriteToMajorsTable(string major)
        {

            db.Majors.Add(new Major
            {
                Name = major,
                Description = "",
                DepartmentID = getDepartmentDegree(major),
                Status = 1


            });
            db.SaveChanges();
        }

        /// <summary>
        /// Gets the department associated with major
        /// </summary>
        /// <param name="major">the major to find the department of</param>
        /// <returns>id of department degree</returns>
        /// <remarks>
        /// If the major does not have a department the department is set
        /// </remarks>
        private int getDepartmentDegree(string major)
        {

            if (!db.Departments.Where(m => m.Name.Trim().ToLower().Contains(major.Trim().ToLower())).Select(m => m.ID).Any())
          
            {
                db.Departments.Add(new Department
                {
                    Name = major
                });
                db.SaveChanges();
            }
            var t= db.Departments.Where(m => m.Name.Trim().ToLower().Contains(major.Trim().ToLower())).Select(m => m.ID);
           
            return  t.First();
        }

        /// <summary>
        /// Write a new course to the database
        /// </summary>
        /// <param name="courseNumber"></param>
        /// <param name="title"></param>
        /// <param name="minCredit"></param>
        /// <param name="maxCredit"></param>
        /// <param name="description"></param>
        /// <param name="prerequisite"></param>
        /// <param name="sectionID"></param>
        private void WriteToCourseTable(string courseNumber, string title, int minCredit, int maxCredit, string description, string prerequisite, int sectionID = 20)
        {
            db.Courses.Add(new Course
            {
                CourseNumber = courseNumber,
                Title = title,
                MinCredit = minCredit,
                MaxCredit = maxCredit,
                Description = description,
                PreRequisites = prerequisite,
                SectionID = sectionID
            });

            db.SaveChanges();
        }

        /// <summary>
        /// Write prereqs to prereq table
        /// </summary>
        /// <param name="prereqGroup">Group of courses seperated by or and and</param>
        /// <param name="currentCollectInfoCourse">The course that is associated with the prereqs</param>
        /// <param name="courses">The courses that need information collected</param>
        /// <param name="defferedList">List of courses that do not exits in database but are another course's prereq</param>
        private void WritePrereqs(string prereqGroup, string currentCollectInfoCourse, ref List<string> courses,  ref List<DefferedPrerequisiteModel> defferedList)
        {
            string[] prereqGroups = prereqGroup.ToLower().Replace("or", "|").Split('|');

            string[][] prereq = new string[prereqGroups.Length][];
            for (int i = 0; i < prereqGroups.Length; i++)
            {

                // courses are lower case
                string[] classesInGroup = prereqGroups[i].ToLower().Replace("and", "+").Split('+');
                prereq[i] = classesInGroup;


                foreach (string s in classesInGroup)
                {
                    // courses were compared using ToLower- restore ToUpper format

                    string currentString = s.ToUpper();

                    if (CheckIfCourseInDb(currentString))
                    {
                        int prereqCourseId = getCourseId(currentString);
                        int courseId = getCourseId(currentCollectInfoCourse);
                        db.Prerequisites.Add(new Prerequisite
                        {
                            PrerequisiteID = prereqCourseId,
                            CourseID = courseId,
                            GroupID = i + 1

                        });
                        db.SaveChanges();

                        // check if prereq has scheduled times
                        if (!CourseHasCourseSchedule(currentString))
                        {
                            if(!courses.Contains(currentString.Trim()))
                                courses.Add(currentString.Trim());
                        }
                    }
                    else
                    {
                        // add course to list to write when prereq is written
                        defferedList.Add(new DefferedPrerequisiteModel
                        {
                            courseId = getCourseId(currentCollectInfoCourse),
                            groupId = i +1,
                            prereqName = currentString
                        });

                        // check not necesary
                        if (!courses.Contains(currentString.Trim()))
                            courses.Add(currentString.Trim());
                    }
                    

                }

            }
        }

        /// <summary>
        /// Returns true if the course associated with courseNumber has entries in the CourseTime table
        /// </summary>
        /// <param name="courseNumber">course</param>
        /// <returns>true if courseNumber has time scheduling</returns>
        private bool CourseHasCourseSchedule(string courseNumber)
        {
            List<string> courses = (from c in db.CourseTimes select c.CourseNumber).ToList();


            return courses.Any(x => x.Trim().ToLower().Equals(courseNumber.Trim().ToLower()));
        }

        /// <summary>
        /// Returns true if the course associated with courseNumber has entries in the Prerequisites table
        /// </summary>
        /// <param name="courseNumber">course</param>
        /// <returns>true if courseNumber has prerequisites</returns>
        private bool CourseHasPrereqs(string courseNumber)
        {
            int courseID = getCourseId(courseNumber);
            List<int> courses = (from c in db.Prerequisites select c.CourseID).ToList();


            return courses.Any(x => x == courseID);
        }

        /// <summary>
        /// Returns true if the course associated with courseNumber has entries in the Course table
        /// </summary>
        /// <param name="courseName">course</param>
        /// <returns>true if courseName is in Course</returns>
        private bool CheckIfCourseInDb(string courseName)
        {
            List<string> courses = (from c in db.Courses select c.CourseNumber).ToList();


            return courses.Any(x => x.Trim().ToLower().Equals(courseName.Trim().ToLower()));
        }

        /// <summary>
        /// Returns true if degree is in the Majors table
        /// </summary>
        /// <param name="degreeName">degree</param>
        /// <returns>true if degreeNane exists in Majors table</returns>
        private bool CheckIfDegreeInDb(string degreeName)
        {
            List<string> degrees = (from c in db.Majors select c.Name).ToList();


            return degrees.Any(x => x.Trim().ToLower().Equals(degreeName.Trim().ToLower()));
        }

        /// <summary>
        /// Get the CourseId associated with courseNumber
        /// </summary>
        /// <param name="courseNumber"></param>
        /// <returns></returns>
        private int getCourseId(string courseNumber)
        {
            var courses = (from c in db.Courses select new { c.CourseID, c.CourseNumber }).ToList();


            return courses.Find(x => x.CourseNumber.Trim().ToLower().Equals(courseNumber.Trim().ToLower())).CourseID;
        }

        /// <summary>
        /// Returns MajorId associated with string major
        /// </summary>
        /// <param name="major"></param>
        /// <returns></returns>
        private int getMajorId(string major)
        {
            var majors = (from c in db.Majors select new { c.ID, c.Name }).ToList();


            return (int)majors.Find(x => x.Name.Trim().ToLower().Equals(major.Trim().ToLower())).ID;
        }

        /// <summary>
        /// Returns SchoolId associated with string school
        /// </summary>
        /// <param name="major"></param>
        /// <returns></returns>
        private int getSchoolId(string school)
        {
            var courses = (from c in db.Schools select new { c.ID, c.Name }).ToList();


            return courses.Find(x => x.Name.Trim().ToLower().Equals(school.Trim().ToLower())).ID;
        }

        /// <summary>
        /// Returns DisplayCoursePreReq view and passes in courseId's prereqs
        /// </summary>
        /// <param name="CourseId"></param>
        /// <returns></returns>
        public ActionResult DisplayCoursePreReq(int CourseId)
        {
            var prereqs = db.Prerequisites.Where(t => t.CourseID == CourseId);


            var final = (from p in prereqs
                         join pm in db.Courses on p.CourseID equals pm.CourseID
                         join pm2 in db.Courses on p.PrerequisiteID equals pm2.CourseID
                         select new PrereqViewModel { Course = pm.CourseNumber, PrerequisiteCourse = pm2.CourseNumber, GroupId = p.GroupID, CourseId = p.CourseID, PrereqId = p.PrerequisiteID }).Distinct();
            return View(final.ToList());
        }

        /// <summary>
        /// Returns view with all course scheduling
        /// </summary>
        /// <param name="CourseId"></param>
        /// <returns></returns>
        public ActionResult DisplayCourseTime(int CourseId)
        {
            var ct = db.CourseTimes.Where(t => t.CourseID == CourseId);

            var final = (from p in ct
                         join dy in db.WeekDays on p.DayID equals dy.DayID
                         join q in db.Quarters on p.QuarterID equals q.QuarterID
                         join s in db.Sections on p.SectionID equals s.ID
                         join st in db.TimeSlots on p.StartTimeID equals st.TimeID
                         join st2 in db.TimeSlots on p.EndTimeID equals st2.TimeID
                        
                         select new DisplayCourseTimeViewModel { EndTime = (TimeSpan)st2.Time, StartTime = (TimeSpan)st.Time, CourseNumber = p.CourseNumber, Day = dy.WeekDay1, Quarter = q.Quarter1, Section = s.Section1 });

            List<string> quarterOrder = new List<string> {"Summer", "Spring", "Winter", "Fall" };
            final.OrderBy(x => quarterOrder.IndexOf(x.Quarter));

            return View(final.ToList());
        }


        // GET: CollectDegreePlan/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prerequisite prerequisite = db.Prerequisites.Find(id);
            if (prerequisite == null)
            {
                return HttpNotFound();
            }
            return View(prerequisite);
        }

        // POST: CollectDegreePlan/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(string response)
        {
            ViewBag.CurrentDegree = response;
            return View();
        }

        // GET: CollectDegreePlan/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prerequisite prerequisite = db.Prerequisites.Find(id);
            if (prerequisite == null)
            {
                return HttpNotFound();
            }
            return View(prerequisite);
        }

        // POST: CollectDegreePlan/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Prerequisite prerequisite = db.Prerequisites.Find(id);
            db.Prerequisites.Remove(prerequisite);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        /// <summary>
        /// Redirects the index page to the collectcorecourses page
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        [ValidateAntiForgeryToken]
        public ActionResult HandleDegreeCollegeForm(CollectDegreeViewModel m)
        {
          
            // write to db
            return View("CollectCoreCourses", m);

        }
    }
}
