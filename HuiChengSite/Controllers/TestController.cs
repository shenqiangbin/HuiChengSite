using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HuiChengSite.Controllers
{
    public class TestController : Controller
    {        
        public ActionResult Index()
        {
            var file = Server.MapPath("~/xss.txt");
            var str = System.IO.File.ReadAllText(file);
            return Content(str);
        }        

        [HttpPost]
        public ActionResult Add(string data)
        {
            try
            {                
                var file = Server.MapPath("~/xss.txt");
                System.IO.File.AppendAllText(file,data);
                return Content("ok");
            }
            catch (Exception)
            {
                return Content("fail");
            }            
        }
    }
}