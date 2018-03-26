using HuiChengSite.Models;
using HuiChengSite.Repository;
using HuiChengSite.Service;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HuiChengSite.Controllers
{
    public class DefaultController : Controller
    {
        public DefaultController()
        {
            
        }

        public ActionResult Index()
        {           
            return View();
        }
    }
}