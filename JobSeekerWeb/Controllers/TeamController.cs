using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JobSeeker.Controllers
{
    public class TeamController : Controller
    {
        // GET: Team
        public ActionResult Member()
        {
            return View();
        }
    }
}