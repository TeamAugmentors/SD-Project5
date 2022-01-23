using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobSeekerWeb.CustomUtils
{
    public class SessionObject
    {
        private Dictionary<string, string> Map = new Dictionary<string, string>();

        public void set(string key, string value)
        {
            Map[key] = value;   
        }

        public string get(string key)
        {
            return Map[key];
        }

        public void clear()
        {
            Map.Clear();    
        }
    }
}