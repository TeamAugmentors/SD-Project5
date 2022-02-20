using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobSeekerWeb.CustomUtils
{
    public static class CustomSession
    {

        private static SessionObject session = new SessionObject();
        //comment
        public static SessionObject GetSession()
        {
            return session; 
        }
    }
}