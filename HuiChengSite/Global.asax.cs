using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.Http;
using HuiChengSite.App_Start;
using System.Web.Optimization;
using HuiChengSite.Common;
using System.IO;

namespace HuiChengSite
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            AutofacHelper.Inject();

            RegisterGlobalFilters(GlobalFilters.Filters);

            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        private void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HuiChengSite.Filters.ExcepitonFilter());
        }

        protected void Application_AuthorizeRequest(object sender, System.EventArgs e)
        {
            SessionHelper.SetUser();
        }
        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            //using (StreamWriter _testData = new StreamWriter(Server.MapPath("~/data.txt"), true))
            //{
            //    _testData.WriteLine(Request.Url.ToString());
            //}
        }


    }
}