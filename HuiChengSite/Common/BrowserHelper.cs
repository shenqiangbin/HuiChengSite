using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace HuiChengSite.Common
{
    public class BrowserHelper
    {
        public static bool IsPhone()
        {
            string userAgent = HttpContext.Current.Request.UserAgent;
            Regex b = new Regex(@"AppleWebKit.*Mobile.*");
            return b.IsMatch(userAgent);
        }

    }
}