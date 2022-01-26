using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JobSeekerWeb.Controllers
{
    public class DestroyController : Controller
    {
        // GET: Logout
        public ActionResult Logout()
        {
            CustomUtils.CustomSession.GetSession().clear();
            return Redirect("/Home/Index");
        }
    }
}