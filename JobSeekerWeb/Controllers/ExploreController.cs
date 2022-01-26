using JobSeekerWeb.CustomUtils;
using JobSeekerWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JobSeeker.Controllers
{
    public class ExploreController : Controller
    {
        jobseekerWebEntities db = new jobseekerWebEntities();
        string query = "SELECT * FROM job";

        // GET: Explore

        public ActionResult Jobs()
        {
            List<job> jobList = db.jobs.SqlQuery(query).ToList();
            return View(new Object[] { (Object)CustomSession.GetSession(), (Object)jobList });
        }

        [HttpPost]
        public ActionResult Jobs(int? tk_min, int? tk_max, string category = "None")
        {
            List<job> jobList;
            if (category == "None")
            {
                jobList = db.jobs.Where(temp => temp.salary >= tk_min).Where(temp => temp.salary <= tk_max).ToList();
            }
            else
            {
                jobList = db.jobs.Where(temp => temp.salary >= tk_min).Where(temp => temp.salary <= tk_max).Where(temp => temp.category == category).ToList();
            }
            return View(new Object[] { (Object)CustomSession.GetSession(), (Object)jobList });
        }

        public ActionResult JobDetails()
        {
            return View();
        }
    }
}