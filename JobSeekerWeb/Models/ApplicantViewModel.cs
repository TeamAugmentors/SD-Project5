using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobSeekerWeb.Models
{
    public class ApplicantViewModel
    {
        public int id { get; set; }
        public string user_name { get; set; }
        public string mail { get; set; }
        public string name { get; set; }
        public string phone_no { get; set; }
        public string billing_info { get; set; }
        public string picture { get; set; }
        public string earned { get; set; }
        public int completed { get; set; }
        public string rating { get; set; }
    }
}