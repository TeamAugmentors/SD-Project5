using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JobSeekerWeb.Models;
using JobSeekerWeb.CustomUtils;
using System.Diagnostics;
using System.Net;
using System.Net.Mail;
using System.Web.Services;

namespace JobSeeker.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        [HttpPost]
        public ActionResult SignIn(user user)
        {
            if (CustomSession.GetSession().get("mail") != null)
            {
                Response.Redirect("/Dashboard/Overview#dashboard__overview");
                return null;
            }
            string query = "SELECT * FROM users";
            List<user> u = DatabaseConnector.getConnection().users.SqlQuery(query).ToList();
            foreach (var x in u)
            {
                if (user.mail == x.mail && user.password == x.password)
                {

                    if (x.verified == 0)
                    {
                        return RedirectToAction("Verify", new { link = "" });
                    }

                    CustomSession.GetSession().set(new String[] { "id", "name", "mail", "username", "phoneNo", "billingInfo", "picture", "token" },
                        new Object[] { x.id, x.name, x.mail, x.user_name, x.phone_no, x.billing_info, x.picture, null });

                    Response.Redirect("/Dashboard/Overview#dashboard__overview");
                }
            }
            return View();
        }

        [HttpPost]
        public ActionResult otpVerification(int otp)
        {
            return View();
        }
        public ActionResult SignIn()
        {
            if (CustomSession.GetSession().get("mail") != null)
            {
                Response.Redirect("/Dashboard/Overview#dashboard__overview");
                return null;
            }
            return View();
        }

        [HttpPost]
        public ActionResult SignUp(user user)
        {
            if (CustomSession.GetSession().get("mail") != null)
            {
                Response.Redirect("/Dashboard/Overview#dashboard__overview");
                return null;
            }
            //string query = $"INSERT INTO user (name, user_name, mail, password) VALUES ('{@user.name}', '{@user.user_name}', '{@user.mail}', '{@user.password}')";
            if (ModelState.IsValid)
            {
                string email = DatabaseConnector.getConnection().users.Where(temp => temp.mail == user.mail).Select(temp => temp.mail).SingleOrDefault();   

                if(email == null)
                {
                    user.verifylink = RandomString(35);


                    DatabaseConnector.getConnection().users.Add(user);
                    DatabaseConnector.getConnection().SaveChanges();

                    makeInstances(user.mail);

                    //send mail
                    sendMail(user.mail, user.verifylink);

                    Response.Redirect("SignIn");
                }
                else
                {
                    return View();
                }
            }
            return View();
        }

        [HttpPost]
        public ActionResult addDatabase(string name, string user_name, string email, string picture, string token)
        {
            if (ModelState.IsValid)
            {
                user u = DatabaseConnector.getConnection().users.Where(x => x.mail == email).SingleOrDefault();
                if (u != null)
                {
                    //u.name = name;
                    //u.user_name = user_name;
                    //u.picture = picture;
                    u.token = token;
                    DatabaseConnector.getConnection().SaveChanges();

                    CustomSession.GetSession().set(new String[] { "id", "name", "mail", "username", "phoneNo", "billingInfo", "picture", "token" },
                      new Object[] { u.id, u.name, u.mail, u.user_name, u.phone_no, u.billing_info, u.picture, u.token });
                }
                else
                {
                    user newUser = new user();

                    newUser.user_name = user_name;
                    newUser.mail = email;
                    newUser.password = null;
                    newUser.name = name;
                    newUser.phone_no = null;
                    newUser.billing_info = null;
                    newUser.picture = picture;
                    newUser.ban = 0;
                    newUser.token = token;

                    string query = $"INSERT INTO users(user_name, mail, name, picture, token) values('{newUser.user_name}', '{newUser.mail}', '{newUser.name}', '{newUser.picture}', '{newUser.token}')";
                    DatabaseConnector.getConnection().Database.ExecuteSqlCommand(query);

                    makeInstances(newUser.mail);

                    int id = DatabaseConnector.getConnection().users.Where(temp => temp.mail == email).Select(temp => temp.id).FirstOrDefault();

                    CustomSession.GetSession().set(new String[] { "id", "name", "mail", "username", "phoneNo", "billingInfo", "picture", "token" },
                      new Object[] { id, newUser.name, newUser.mail, newUser.user_name, newUser.phone_no, newUser.billing_info, newUser.picture, newUser.token });
                }

                Response.Redirect("/Dashboard/Overview#dashboard__overview");
            }

            return View();
        }

        public ActionResult SignUp()
        {
            if (CustomSession.GetSession().get("mail") != null)
            {
                Response.Redirect("/Dashboard/Overview#dashboard__overview");
                return null;
            }
            return View();
        }

        public ActionResult Verify(string link)
        {
            ViewBag.Link = link;
            if (ModelState.IsValid)
            {
                user user = DatabaseConnector.getConnection().users.Where(temp => temp.verifylink == link).SingleOrDefault();

                if (user != null)
                {
                    user.verified = 1;
                    DatabaseConnector.getConnection().SaveChanges();
                    SignIn(user);
                }
            }
            return View();
        }

        public void makeInstances(string mail)
        {
            if (ModelState.IsValid && mail != null)
            {
                string query = $"SELECT id FROM users where mail = '{mail}'";

                int id = DatabaseConnector.getConnection().users.Where(temp => temp.mail == mail).Select(temp => temp.id).SingleOrDefault();

                string query1 = $"INSERT INTO freelancer(id) values({id})";
                string query2 = $"INSERT INTO hirer(id) values({id})";

                DatabaseConnector.getConnection().Database.ExecuteSqlCommand(query1);
                DatabaseConnector.getConnection().Database.ExecuteSqlCommand(query2);
            }

        }

        private static Random random = new Random();

        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789abcdefghijklmnopqrstuvwxyz";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public void sendMail(string mailAddress, string link)
        {
            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

            mail.From = new MailAddress("jobseekerIntel@tech.com");
            mail.To.Add(mailAddress);
            mail.Subject = "JobSeeker Verification";
            mail.Body = "Please click the link to verify your JobSeeker account " + "https://localhost:44301/" + "User/Verify?link=" + link;

            SmtpServer.Port = 587;
            SmtpServer.Credentials = new System.Net.NetworkCredential("jobseekerbangladeshonline@gmail.com", "Secretplace");

            SmtpServer.EnableSsl = true;

            SmtpServer.Send(mail);
        }

    }
}