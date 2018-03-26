using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HuiChengSite.Common
{
    public class Configer
    {
        public static string Get(string name)
        {
            return System.Configuration.ConfigurationManager.AppSettings[name];
        }

        public static void Set(string name,string val)
        {
            System.Configuration.ConfigurationManager.AppSettings[val] = val;
        }
    }
}