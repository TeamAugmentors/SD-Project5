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
        //string query = "SELECT * FROM job ";

        // GET: Explore
        static int id = Convert.ToInt32(CustomSession.GetSession().get("id"));
        int[] jobIds = DatabaseConnector.getConnection().applications.Where(a => a.applied_id == id).Select(a => a.job_id).ToArray();
        public ActionResult Jobs()
        {
            if(ModelState.IsValid)
            {
                List<job> jobList = DatabaseConnector.getConnection().jobs.Where(x => x.posted_by != id).ToList();
                
                return View(new Object[] { CustomSession.GetSession(), jobList, jobIds});
            }
            return Redirect("Explore/Jobs");
        }

        [HttpPost]
        public ActionResult Jobs(int? tk_min, int? tk_max, string category = "None")
        {
            if(ModelState.IsValid)
            {
                ViewBag.tk_min = tk_min;    
                ViewBag.tk_max = tk_max;    

                List<job> jobList;
                if (category == "None")
                {
                    jobList = DatabaseConnector.getConnection().jobs.Where(x => x.posted_by != id).Where(temp => temp.salary >= tk_min).Where(temp => temp.salary <= tk_max).ToList();
                }
                else
                {
                    jobList = DatabaseConnector.getConnection().jobs.Where(x => x.posted_by != id).Where(temp => temp.salary >= tk_min).Where(temp => temp.salary <= tk_max).Where(temp => temp.category == category).ToList();
                }
                return View(new Object[] { CustomSession.GetSession(), jobList, jobIds });
            }
            return Redirect("Explore/Jobs");
        }

        [Route("Explore/JobDetails/{job_id}")]
        public ActionResult JobDetails(int job_id)
        {
            if (ModelState.IsValid)
            {
                var card = DatabaseConnector.getConnection().jobs.Where(temp => temp.id == job_id).SingleOrDefault();

                HirerViewModel res = (from u in DatabaseConnector.getConnection().users
                                      join hr in DatabaseConnector.getConnection().hirers on u.id equals hr.id
                                      where u.id == card.posted_by
                                      select new HirerViewModel
                                      {
                                          id = u.id,
                                          user_name = u.user_name,
                                          mail = u.mail,
                                          name = u.name,
                                          phone_no = u.phone_no,
                                          billing_info = u.billing_info,
                                          picture = u.picture,
                                          spent = hr.spent,
                                          hired = hr.hired,
                                          rating = hr.rating,

                                      }).SingleOrDefault();

                List<string> files = DatabaseConnector.getConnection().jobfiles.Where(temp => temp.job_id == card.id).Select(temp => temp.sample_files).ToList();
                List<string> images = DatabaseConnector.getConnection().jobimages.Where(temp => temp.job_id == card.id).Select(temp => temp.sample_images).ToList();

                return View(new object[] { card, res, files, images });
            }

            return View();
        }

        [HttpPost]
        public ActionResult Apply(application application)
        {

            if(ModelState.IsValid)
            {
                string query = $"insert into applications values({application.job_id}, {application.applied_id})";
                DatabaseConnector.getConnection().Database.ExecuteSqlCommand(query);
                //DatabaseConnector.getConnection().SaveChanges();
                return Redirect("/Dashboard/Overview#dashboard__overview");
            }
            return Redirect("Explore/Jobs");
        }
    }
   
}