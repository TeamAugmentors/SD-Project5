using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JobSeeker.Controllers
{
    public class ExploreController : Controller
    {
        // GET: Explore
        public ActionResult Jobs()
        {
            return View();
        }
        public ActionResult JobDetails()
        {
            return View();
        }
    }
}