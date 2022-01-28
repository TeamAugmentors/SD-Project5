using JobSeekerWeb.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JobSeeker.Controllers
{
    public class ProfileController : Controller
    {
        // GET: Profile
        jobseekerWebEntities4 db = new jobseekerWebEntities4();
        int id = Convert.ToInt32(JobSeekerWeb.CustomUtils.CustomSession.GetSession().get("id"));


        public ActionResult Edit()
        {
            user tempUser = db.users.Where(temp => temp.id == id).SingleOrDefault();

            return View(tempUser);
        }

        [HttpPost]
        public ActionResult Edit(user user, HttpPostedFileBase userImg, string confirmPass)
        {
            user tempUser = db.users.Where(temp => temp.id == id).SingleOrDefault();
            if (ModelState.IsValid)
            {
                if (userImg != null)
                {
                    var fileName = Path.GetFileName(userImg.FileName);
                    var directoryToSave = Server.MapPath(Url.Content("~/DatabaseImg"));

                    var pathToSave = Path.Combine(directoryToSave, fileName);
                    userImg.SaveAs(pathToSave);
                    tempUser.picture = fileName;
                }

                tempUser.name = user.name;
                tempUser.mail = user.mail;
                tempUser.phone_no = user.phone_no;
                tempUser.billing_info = user.billing_info;


                tempUser.password = user.password ?? tempUser.password;

                JobSeekerWeb.CustomUtils.CustomSession.GetSession().set("picture", tempUser.picture);

                db.SaveChanges();

                return Redirect("/Dashboard/Overview#dashboard__overview");
            }
            return View(tempUser);
        }
    }
}