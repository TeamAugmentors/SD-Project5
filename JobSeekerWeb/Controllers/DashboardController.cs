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
        public ActionResult Overview()
        {

            //string name = Session["name"].ToString();
            //string user_name = Session["user_name"].ToString();
            //string mail = Session["mail"].ToString();
            //string phone_no = Session["phone_no"].ToString();
            //string billind_info = Session["billind_info"].ToString();
            //string picture = Session["picture"].ToString();

            CustomSession.GetSession().set("id", "10");

            return View((Object)CustomSession.GetSession());
        }
    }
}