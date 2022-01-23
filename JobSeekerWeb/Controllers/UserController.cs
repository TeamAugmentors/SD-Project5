using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JobSeekerWeb.Models;
using JobSeekerWeb.CustomUtils;

namespace JobSeeker.Controllers
{
    public class UserController : Controller
    {
        jobseekerWebEntities db = new jobseekerWebEntities();
        // GET: User
        [HttpPost]
        public ActionResult SignIn(user user)
        {
            string query = "SELECT * FROM users";
            List<user> u = db.users.SqlQuery(query).ToList();
            foreach(var x in u)
            {
                if(user.mail == x.mail && user.password == x.password)
                {

      
                    //Session["id"] = x.id;
                    //Session["name"] = x.name;
                    //Session["mail"] = x.mail;
                    //Session["user_name"] = x.user_name;
                    //Session["phone_no"] = x.phone_no;
                    //Session["billind_info"] = x.billing_info;
                    //Session["picture"] = x.picture;


                    Response.Redirect("/Dashboard/Overview");
                }
            }
            return View();
        }
        public ActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignUp(user user)
        {
            //string query = $"INSERT INTO user (name, user_name, mail, password) VALUES ('{@user.name}', '{@user.user_name}', '{@user.mail}', '{@user.password}')";
            if(ModelState.IsValid)
            {
                db.users.Add(user);
                db.SaveChanges();

                string query = $"SELECT id FROM users where mail = '{user.mail}'";
                
                var id = db.users.Where(temp => temp.mail == user.mail).Select(temp => temp.id).SingleOrDefault();
                
                string query1 = $"INSERT INTO freelancer(id) values({id})";
                string query2 = $"INSERT INTO hirer(id) values({id})";
                
                db.Database.ExecuteSqlCommand(query1);
                db.Database.ExecuteSqlCommand(query2);

                Response.Redirect("SignIn");
            }
            return View();
        }
        public ActionResult SignUp()
        {

            return View();
        }

    }
}