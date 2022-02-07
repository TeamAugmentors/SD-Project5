using JobSeekerWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobSeekerWeb.CustomUtils
{
    public static class DatabaseConnector
    {
        private static jobseekerWebEntities5 db = new jobseekerWebEntities5();

        public static jobseekerWebEntities5 getConnection()
        {
            return db;
        }
    }
}