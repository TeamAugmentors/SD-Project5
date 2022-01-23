using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobSeekerWeb.CustomUtils
{
    public static class CustomSession
    {

        public static SessionObject session = new SessionObject();

        public static SessionObject GetSession()
        {
            return session; 
        }
    }
}