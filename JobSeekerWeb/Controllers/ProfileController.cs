using JobSeekerWeb.CustomUtils;
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
        int id = Convert.ToInt32(JobSeekerWeb.CustomUtils.CustomSession.GetSession().get("id"));


        public ActionResult Edit()
        {
            user tempUser = DatabaseConnector.getConnection().users.Where(temp => temp.id == id).SingleOrDefault();
            return View(tempUser);
        }

        [HttpPost]
        public ActionResult Edit(user user, HttpPostedFileBase userImg, string confirmPass)
        {
            user tempUser = DatabaseConnector.getConnection().users.Where(temp => temp.id == id).SingleOrDefault();
            if (ModelState.IsValid)
            {
                if (userImg != null)
                {
                    var fileName = $"{CustomSession.GetSession().get("id")}{Path.GetExtension(userImg.FileName)}";
                    var directoryToSave = Server.MapPath(Url.Content("~/DatabaseImg"));

                    var pathToSave = Path.Combine(directoryToSave, fileName);
                    userImg.SaveAs(pathToSave);
                    tempUser.picture = fileName;
                }

                tempUser.name = user.name;
                tempUser.mail = user.mail;
                tempUser.phone_no = user.phone_no;
                tempUser.billing_info = user.billing_info;

                if (CustomSession.GetSession().get("token") == null)
                {
                    tempUser.password = user.password ?? tempUser.password;
                }
                JobSeekerWeb.CustomUtils.CustomSession.GetSession().set("picture", tempUser.picture);

                DatabaseConnector.getConnection().SaveChanges();

                CustomSession.GetSession().set(new String[] { "id", "name", "mail", "username", "phoneNo", "billingInfo", "picture", "token" },
                      new Object[] { tempUser.id, tempUser.name, tempUser.mail, tempUser.user_name, tempUser.phone_no, tempUser.billing_info, tempUser.picture, tempUser.token });

                return Redirect("/Dashboard/Overview#dashboard__overview");
            }
            return View(tempUser);
        }
    }
}