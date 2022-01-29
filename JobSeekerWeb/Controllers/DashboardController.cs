using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JobSeekerWeb.Models;
using JobSeekerWeb.CustomUtils;
using System.Data.SqlClient;
using System.IO;

namespace JobSeeker.Controllers
{
    public class DashboardController : Controller
    {
        // GET: Dashboard
        public ActionResult Overview()
        {
            if (ModelState.IsValid)
            {
                int id = Convert.ToInt32(CustomSession.GetSession().get("id"));
                freelancer fr = DatabaseConnector.getConnection().freelancers.Where(temp => temp.id == id).SingleOrDefault();
                List<activeorder> activeOrders = DatabaseConnector.getConnection().activeorders.Where(temp => temp.user_id == id).ToList();
                List<application> applications = DatabaseConnector.getConnection().applications.Where(temp => temp.applied_id == id).ToList();

                List<MyJobsViewModel> jobInfo = new List<MyJobsViewModel>();
                List<MyJobsViewModel> appliedJobInfo = new List<MyJobsViewModel>();

                foreach (activeorder order in activeOrders)
                {
                    var x = DatabaseConnector.getConnection().jobs.Where(temp => temp.id == order.job_id).Select( temp => new MyJobsViewModel { Id = temp.id, name = temp.name, details = temp.details }).SingleOrDefault();
                    jobInfo.Add(x);
                }

                foreach (application apply in applications)
                {
                    var x = DatabaseConnector.getConnection().jobs.Where(temp => temp.id == apply.job_id).Select(temp => new MyJobsViewModel { Id = temp.id, name = temp.name, details = temp.details }).SingleOrDefault();
                    appliedJobInfo.Add(x);
                }

                return View(new object[] { CustomSession.GetSession(), fr, jobInfo, appliedJobInfo });
            }

            return View((Object)CustomSession.GetSession());        
        }

        public ActionResult MyJobs()
        {
            if (ModelState.IsValid)
            {
                int id = Convert.ToInt32(CustomSession.GetSession().get("id"));
                List<job> jobs = DatabaseConnector.getConnection().jobs.Where(x => x.posted_by == id).Where( x => x.hired_id == null).ToList();
                return View(new object[] { CustomSession.GetSession(), jobs });
            }

            return Redirect("Overview");
        }
        static int? currentJobId;
        public ActionResult JobApplications(int? id)
        {
            if (ModelState.IsValid)
            {
                currentJobId = id;
                int[] applicantsIDs = DatabaseConnector.getConnection().applications.Where(x => x.job_id == id).Select(temp => temp.applied_id).ToArray();

                List<ApplicantViewModel> applicantsList = new List<ApplicantViewModel>();

                foreach (int applicantID in applicantsIDs)
                {
                    var res = (from u in DatabaseConnector.getConnection().users
                               join f in DatabaseConnector.getConnection().freelancers on u.id equals f.id
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
            return Redirect("Overview");
        }

        [HttpPost]
        public ActionResult HireUser(int? applicantId)
        {
            if (ModelState.IsValid)
            {
                var instance = DatabaseConnector.getConnection().jobs.Where(temp => temp.id == currentJobId).SingleOrDefault();
                instance.hired_id = applicantId;
                DatabaseConnector.getConnection().SaveChanges();

                return Redirect("MyJobs");
            }

            return Redirect("Overview");
        }
        public ActionResult CreateJob()
        {
            return View((Object)CustomSession.GetSession());
        }

        [HttpPost]
        public ActionResult CreateJob(job job, HttpPostedFileBase[] jobImages, HttpPostedFileBase[] jobFiles)
        {
            if (ModelState.IsValid)
            {
                job.posted_by = Convert.ToInt32(CustomSession.GetSession().get("id"));

                DatabaseConnector.getConnection().jobs.Add(job);

                DatabaseConnector.getConnection().SaveChanges();

                foreach (var item in jobImages)
                {
                    if (item == null)
                        continue;

                    var extension = Path.GetExtension(item.FileName);

                    var result = (DatabaseConnector.getConnection().jobimages).OrderByDescending(x => x.serial).Select(x => x.serial).FirstOrDefault();
                    var renamedFile = $"{++result}{Path.GetExtension(item.FileName)}";

                    var directorytosave = Server.MapPath(Url.Content("~/jobimages"));
                    var pathtosave = Path.Combine(directorytosave, renamedFile);
                    item.SaveAs(pathtosave);

                    //db

                    var jobId = (DatabaseConnector.getConnection().jobs).OrderByDescending(x => x.id).Select(x => x.id).FirstOrDefault();

                    DatabaseConnector.getConnection().jobimages.Add(new jobimage
                    {
                        job_id = jobId,
                        sample_images = renamedFile
                    });

                    DatabaseConnector.getConnection().SaveChanges();
                }

                foreach (var item in jobFiles)
                {
                    if (item == null)
                        continue;

                    var extension = Path.GetExtension(item.FileName);

                    var result = (DatabaseConnector.getConnection().jobfiles).OrderByDescending(x => x.serial).Select(x => x.serial).FirstOrDefault();
                    var renamedFile = $"{++result}{Path.GetExtension(item.FileName)}";

                    var directorytosave = Server.MapPath(Url.Content("~/JobFiles"));
                    var pathtosave = Path.Combine(directorytosave, renamedFile);
                    item.SaveAs(pathtosave);

                    //db

                    var jobId = (DatabaseConnector.getConnection().jobs).OrderByDescending(x => x.id).Select(x => x.id).FirstOrDefault();

                    DatabaseConnector.getConnection().jobfiles.Add(new jobfile
                    {
                        job_id = jobId,
                        sample_files = renamedFile
                    });

                    DatabaseConnector.getConnection().SaveChanges();
                }

                return Redirect("MyJobs");
            }

            return View((Object)CustomSession.GetSession());
        }

    }

}