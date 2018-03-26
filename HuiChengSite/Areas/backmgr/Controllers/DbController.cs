using HuiChengSite.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HuiChengSite.Areas.backmgr.Controllers
{
    [UserAuthorize]
    public class DbController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Download()
        {
            var dbFile = AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "HuiChengSite.db3";
            System.IO.File.Copy(dbFile, "d:/abc.db3", true);
            string fileName = $"{DateTime.Now.ToShortDateString()} - HuiChengSite.db3";
            return File("d:/abc.db3", "application/octet-stream", HttpContext.Request.Browser.Browser == "IE" ? Url.Encode(fileName) : fileName);
        }
    }
}