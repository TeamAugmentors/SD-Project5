using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JobSeeker.Controllers
{
    public class ProfileController : Controller
    {
        // GET: Profile
        public ActionResult Edit()
        {
            return View();
        }
    }
}