using System;
using System.Collections.Generic;

using System.Linq;
using System.Net;
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
                join pm in db.Majors on (int)  p.MajorID equals pm.ID
                join s in db.Schools on  (int) p.SchoolID equals s.ID
                select new SchoolMajorViewModel {Major = pm.Name, MajorId=  (int)p.MajorID, School = s.Name, SchoolId = (int) p.SchoolID};
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

       



        // POST: CollectDegreePlan/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult HandleForm(string response)
        {
            
            ViewBag.CurrentDegree = response;
            return View("Index");
        }




        public ActionResult Create()
        {
            CollectDegreeViewModel newDegree = new CollectDegreeViewModel();
            newDegree.CurrentDegreeCourses = "";
            newDegree.deferredPrereqs = "";
           




            var schools = from f in db.Schools select f.Name;

            newDegree.Schools = new SelectList(schools);
            
            return View(newDegree);

        }

        [HttpPost]
        public ActionResult AddCourseToList(CollectDegreeViewModel m)
        {

            if (m.CurrentDegreeCourses == null)
            {
                m.CurrentDegreeCourses = m.CurrentCourse.Replace("amp;", "");

            }
            else
            {
                m.CurrentDegreeCourses += "|" + m.CurrentCourse.Replace("amp;", "");

            }
            m.CurrentCourse = "";
            return View( "CollectCoreCourses",m);
        }



       

        public ActionResult CollectCourseInfo(CollectDegreeViewModel m)
        {
       

            string[] courses = m.CurrentDegreeCourses.Split('|');
            var dbCourses = db.Courses.Select(c => c.CourseNumber);

            // This will be more accurate when there is autocomplete
            // users will less likely enter MATH105 when MATH 105 is correct
            string coursesRequireInfo = "";
            foreach (string s in courses)
            {
                string currString = s.Replace("amp;", "");
                if (!dbCourses.Any(g => g.Trim().Equals(currString)) || !CourseHasPrereqs(currString) || !CourseHasCourseSchedule(currString))
                {
                    if (coursesRequireInfo.Equals(""))
                    {
                        coursesRequireInfo = currString;
                    }
                    else
                    {
                        coursesRequireInfo += "|" + currString;
                    }
                } 
            }



            if (coursesRequireInfo.IsNullOrWhiteSpace())
            {
                // write new degree to Major table
                if (!CheckIfCourseInDb(m.CurrentDegree))
                {
                    db.Majors.Add(new Major
                    {
                        Name = m.CurrentDegree

                    });

                    db.SaveChanges();
                }
                string[] requiredCourses = m.CurrentDegreeCourses.Split('|');

                int majorId = getMajorId(m.CurrentDegree);
                int schoolId = getSchoolId(m.School);
                foreach (string s in requiredCourses)
                {

                    string currString = s.Replace("amp;", "");


                    int courseId = getCourseId(currString);
                    db.AdmissionRequiredCourses.Add(new AdmissionRequiredCours
                    {
                        MajorID = majorId,
                        CourseID = courseId,
                        SchoolID = schoolId

                    });
                }

                if (!m.deferredPrereqs.IsNullOrWhiteSpace())
                {
                    string[] deferredRows = m.deferredPrereqs.Split('|');

                    foreach (var s in deferredRows)
                    {
                        string[] rowInfo = s.Split(',');
                        int courseId = getCourseId(rowInfo[0]);
                        int prereqId = getCourseId(rowInfo[1]);
                        int groupNum = int.Parse(rowInfo[2]);
                        db.Prerequisites.Add(new Prerequisite
                        {
                            PrerequisiteID = prereqId,
                            CourseID = courseId,
                            GroupID = groupNum

                        });
                    }
                }


                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                m.CurrentCollectDegreeInfoCourses = coursesRequireInfo;
                return View(m);

            }
        }

        public ActionResult EditPlan(int MajorId, int SchoolId)
        {
            var requiredClasses = db.AdmissionRequiredCourses.Where(t => t.MajorID == MajorId && t.SchoolID == SchoolId).Select(t => new { t.CourseID});
            var final = from p in requiredClasses
                join pm in db.Courses on p.CourseID equals pm.CourseID
                select new CourseCourseIDViewModel {Course = pm.CourseNumber, CourseId = (int) p.CourseID};
            return View(final.OrderBy(t=>t).ToList());
        }

        public int GetTimeId(string time)
        {
          // assuming time conforms to the TimeSlot format

            var times = db.TimeSlots.Where(m => m.Time.ToString().Equals(time)).Select(m => m.TimeID);
            return times.First();
        }

        public void writeToCourseTime(List<CourseTimeViewModel> m, string courseNumber)
        {
           
            foreach (var v in m)
            {
                int courseId = getCourseId(courseNumber);

               int q = GetQuarterStringToInt(v.Quarter);
                bool[] days = {v.Monday, v.Tuesday, v.Wednesday, v.Thursday, v.Friday};
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
                            DayID = i+1,
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



        public ActionResult WriteCourseToDb(CollectDegreeViewModel m)
        {
            if (ModelState.IsValid)
            {
                if (!CheckIfCourseInDb(m.currentCollectInfoCourse.Replace("amp;", "")))
                {
                    db.Courses.Add(new Course
                    {
                        CourseNumber = m.currentCollectInfoCourse.Replace("amp;", ""),
                        Title = m.Title,
                        MinCredit = m.MinCredit,
                        MaxCredit = m.MaxCredit,
                        Description = m.Description,
                        PreRequisites = m.Prerequisite,
                        SectionID = 20


                    });

                    db.SaveChanges();
                }

                if (!CourseHasCourseSchedule(m.currentCollectInfoCourse))
                {
                    writeToCourseTime(m.CourseTimeInfo.ToList(), m.currentCollectInfoCourse);
                }
                // the coures will be guarnteed to be in the db at this point

                List<string> courses = m.CurrentCollectDegreeInfoCourses.Split('|').ToList();

                if (!m.Prerequisite.IsNullOrWhiteSpace())
                {
                    string[] prereqGroups = m.Prerequisite.ToLower().Replace("or", "|").Split('|');

                        string[][] prereq = new string[prereqGroups.Length][];
                        for (int i = 0; i < prereqGroups.Length; i++)
                        {
                            string[] classesInGroup = prereqGroups[i].ToLower().Replace("and", "+").Split('+');
                            prereq[i] = classesInGroup;


                            foreach (string s in classesInGroup)
                            {
                                string currentString = s.ToUpper();
                                if (!CheckIfCourseInDb(currentString) && !CourseHasPrereqs(currentString))
                                {
                                    if (!courses.Contains(currentString.Trim()))
                                    {
                                        courses.Add(currentString.Trim());
                                        m.deferredPrereqs +=
                                            "|" + m.currentCollectInfoCourse + "," + currentString.Trim() + "," + i + 1;
                                    }
                                }
                                else
                                {
                                    int prereqCourseId = getCourseId(currentString);
                                    int courseId = getCourseId(m.currentCollectInfoCourse);
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
                        }
                        }



                    }
            
                


                string[] courseArr = courses.ToArray();
                string nextCollectDegreeInfoCourses =
                    String.Join("|", courseArr.Reverse().Take(courseArr.Length - 1).Reverse());
                m.CurrentCollectDegreeInfoCourses = nextCollectDegreeInfoCourses;


                if (nextCollectDegreeInfoCourses.IsNullOrWhiteSpace())
                {
                    // write new degree to Major table
                    if (!CheckIfDegreeInDb(m.CurrentDegree))
                    {
                        db.Majors.Add(new Major
                        {
                            Name = m.CurrentDegree

                        });

                        db.SaveChanges();
                    }
                    string[] requiredCourses = m.CurrentDegreeCourses.Split('|');

                    int majorId = getMajorId(m.CurrentDegree);
                    int schoolId = getSchoolId(m.School);
                    foreach (string s in requiredCourses)
                    {
                        string currString = s.Replace("amp;", "");
                        int courseId = getCourseId(s);
                        db.AdmissionRequiredCourses.Add(new AdmissionRequiredCours
                        {
                            MajorID = majorId,
                            CourseID = courseId,
                            SchoolID = schoolId

                        });
                        db.SaveChanges();

                    }

                    if (!m.deferredPrereqs.IsNullOrWhiteSpace())
                    {
                        string[] deferredRows = m.deferredPrereqs.Split('|');

                        foreach (var s in deferredRows)
                        {
                            string[] rowInfo = s.Split(',');
                            int courseId = getCourseId(rowInfo[0]);
                            int prereqId = getCourseId(rowInfo[1]);
                            int groupNum = int.Parse(rowInfo[2]);
                            db.Prerequisites.Add(new Prerequisite
                            {
                                PrerequisiteID = prereqId,
                                CourseID = courseId,
                                GroupID = groupNum

                            });
                            db.SaveChanges();

                        }
                    }


                    return RedirectToAction("Index");
                }
                db.SaveChanges();

                return View("CollectCourseInfo", m);
            }
            return View("CollectCourseInfo", m);
        }

        private bool CourseHasCourseSchedule(string courseNumber)
        {
            List<string> courses = (from c in db.CourseTimes select c.CourseNumber).ToList();


            return courses.Any(x => x.Trim().ToLower().Equals(courseNumber.Trim().ToLower()));
        }

        private bool CourseHasPrereqs(string courseNumber)
        {
            int courseID = getCourseId(courseNumber);
            List<int> courses = (from c in db.Prerequisites select c.CourseID).ToList();


            return courses.Any(x => x == courseID);
        }



        private bool CheckIfCourseInDb(string courseName)
        {
            List<string> courses = (from c in db.Courses select c.CourseNumber).ToList();


            return courses.Any(x => x.Trim().ToLower().Equals(courseName.Trim().ToLower()));
        }

        
        private bool CheckIfDegreeInDb(string degreeName)
        {
            List<string> degrees = (from c in db.Majors select c.Name).ToList();


            return degrees.Any(x => x.Trim().ToLower().Equals(degreeName.Trim().ToLower()));
        }

        private int getCourseId(string courseNumber)
        {
            var courses = (from c in db.Courses select new { c.CourseID, c.CourseNumber}).ToList();


            return courses.Find(x => x.CourseNumber.Trim().ToLower().Equals( courseNumber.Trim().ToLower())).CourseID;
        }

        private int getMajorId(string major)
        {
            var majors = (from c in db.Majors select new {  c.ID, c.Name }).ToList();


            return (int) majors.Find(x => x.Name.Trim().ToLower().Equals(major.Trim().ToLower())).ID;
        }

        private int getSchoolId(string school)
        {
            var courses = (from c in db.Schools select new { c.ID, c.Name }).ToList();


            return courses.Find(x => x.Name.Trim().ToLower().Equals(school.Trim().ToLower())).ID;
        }


        public ActionResult DisplayCoursePreReq(int CourseId)
        {
            var prereqs = db.Prerequisites.Where(t => t.CourseID == CourseId);
                

            var final = (from p in prereqs
                        join pm in db.Courses on p.CourseID equals pm.CourseID
                        join pm2 in db.Courses on p.PrerequisiteID equals pm2.CourseID
                select  new PrereqViewModel { Course = pm.CourseNumber, PrerequisiteCourse = pm2.CourseNumber,GroupId = p.GroupID, CourseId = p.CourseID, PrereqId = p.PrerequisiteID}).Distinct() ;
            return View(final.ToList());
        }

        public ActionResult DisplayCourseTime(int CourseId)
        {
            var ct = db.CourseTimes.Where(t => t.CourseID == CourseId);

            var final = (from p in ct
                join dy in db.WeekDays on p.DayID equals dy.DayID
                join q in db.Quarters on p.QuarterID equals q.QuarterID
                join s in db.Sections on p.SectionID equals s.ID
                join st in db.TimeSlots on p.StartTimeID equals st.TimeID
                join st2 in db.TimeSlots on p.EndTimeID equals st2.TimeID
                select new DisplayCourseTimeViewModel { EndTime = (TimeSpan) st2.Time, StartTime = (TimeSpan) st.Time,CourseNumber = p.CourseNumber, Day = dy.WeekDay1,Quarter = q.Quarter1, Section = s.Section1});

           
                    
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


        public ActionResult HandleDegreeCollegeForm(CollectDegreeViewModel m)
        {
            // write to db
            return View("CollectCoreCourses", m);

        }
    }
}
