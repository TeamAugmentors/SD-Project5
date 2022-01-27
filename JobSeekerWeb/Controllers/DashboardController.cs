using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JobSeekerWeb.Models;
using JobSeekerWeb.CustomUtils;

namespace JobSeeker.Controllers
{
    public class DashboardController : Controller
    {
        // GET: Dashboard
        jobseekerWebEntities db = new jobseekerWebEntities();
        public ActionResult Overview()
        {
            return View((Object)CustomSession.GetSession());
        }

        public ActionResult MyJobs()
        {
            if (ModelState.IsValid)
            {
                int id = Convert.ToInt32(CustomSession.GetSession().get("id"));
                List<job> jobs = db.jobs.Where(x => id == x.id).ToList();
                return View(new object[] { CustomSession.GetSession(), jobs });
            }

            return Redirect("Dashboard/Overview");
        }

        public ActionResult JobApplications(int id)
        {
            var applications = db.applications.Where(x => x.job_id == id).ToList();
            var appliedList = new List<freelancer>();
            foreach (var applicationId in applications)
            {
                appliedList.Add(db.freelancers.Where(freelancer => freelancer.id == applicationId.applied_id).SingleOrDefault());
            }

            return View(new Object[] { (Object)CustomSession.GetSession() , (Object)appliedList}); 
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