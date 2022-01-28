using JobSeekerWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobSeekerWeb.CustomUtils
{
    public static class DatabaseConnector
    {
        private static jobseekerWebEntities db = new jobseekerWebEntities();

        public static jobseekerWebEntities getConnection()
        {
            return db;
        }
    }
}