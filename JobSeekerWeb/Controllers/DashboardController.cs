using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JobSeekerWeb.Models;
using JobSeekerWeb.CustomUtils;
using System.Data.SqlClient;

namespace JobSeeker.Controllers
{
    public class DashboardController : Controller
    {
        // GET: Dashboard
        jobseekerWebEntities4 db = new jobseekerWebEntities4();

        public ActionResult Overview()
        {
            if (ModelState.IsValid)
            {
                int id = Convert.ToInt32(CustomSession.GetSession().get("id"));
                freelancer fr = db.freelancers.Where(temp => temp.id == id).SingleOrDefault();
                return View(new object[] { CustomSession.GetSession(), fr });
            }

            return View((Object)CustomSession.GetSession());        
        }

        public ActionResult MyJobs()
        {
            if (ModelState.IsValid)
            {
                int id = Convert.ToInt32(CustomSession.GetSession().get("id"));
                List<job> jobs = db.jobs.Where(x => x.posted_by == id).ToList();
                return View(new object[] { CustomSession.GetSession(), jobs });
            }

            return Redirect("Dashboard/Overview");
        }

        public ActionResult JobApplications(int? id)
        {
            if (ModelState.IsValid)
            {
                int[] applicantsIDs = db.applications.Where(x => x.job_id == id).Select(temp => temp.applied_id).ToArray();

                List<ApplicantViewModel> applicantsList = new List<ApplicantViewModel>();

                foreach (int applicantID in applicantsIDs)
                {
                    var res = (from u in db.users
                               join f in db.freelancers on u.id equals f.id
                               where u.id == applicantID
                               select new ApplicantViewModel
                               {
                                   id = u.id,
                                   user_name = u.user_name,
                                   mail = u.mail,
                                   name = u.name,
                                   phone_no = u.phone_no,
                                   billing_info = u.billing_info,
                                   picture = u.picture,
                                   earned = f.earned,
                                   completed = f.completed,
                                   rating = f.rating,

                               }).SingleOrDefault();
                    applicantsList.Add(res);
                }

                return View(new Object[] { (Object)CustomSession.GetSession(), (Object)applicantsList });
            }
            return View((Object)CustomSession.GetSession());
        }

        public ActionResult CreateJob()
        {
            return View((Object)CustomSession.GetSession());
        }

        [HttpPost]
        public ActionResult CreateJob(job job)
        {
            if (ModelState.IsValid)
            {
                job.posted_by = Convert.ToInt32(CustomSession.GetSession().get("id"));

                db.jobs.Add(job);
                db.SaveChanges();

                return Redirect("Dashboard/MyJobs");
            }

            return View((Object)CustomSession.GetSession());
        }
    }
}