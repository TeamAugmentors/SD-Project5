using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobSeekerWeb.CustomUtils
{
    public class SessionObject
    {
        private Dictionary<string, string> Map = new Dictionary<string, string>();

        public void set(string key, object value)
        {   
            String strValue = value.ToString();
            Map[key] = strValue;   
        }

        public void set(String[] keys, Object[] values)
        {
           for (int i = 0; i < keys.Length; i++)
            {
                String key = keys[i];
                String value = "";
                if (values[i] != null)
                {
                    value = values[i].ToString();
                }
 
                Map[key] = value;
            }
        }

        public string[] getAll() => Map.Keys.ToArray();

        public string get(string key) 
        {
            if (Map.ContainsKey(key))
                return Map[key];
            else
                return null;
        }

        public void clear()
        {
            Map.Clear();    
        }
    }
}