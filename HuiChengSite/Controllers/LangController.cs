using HuiChengSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HuiChengSite.Controllers
{
    public class LangController : Controller
    {
        public ActionResult En()
        {
            Session[LanguageModel.LANGUAGE] = LanguageEnum.En;
            return Go();
        }

        public ActionResult ZhCn()
        {
            Session[LanguageModel.LANGUAGE] = LanguageEnum.ZhCn;
            return Go();
        }

        private ActionResult Go()
        {
            string url = "/";
            if (Request.UrlReferrer != null)
                url = Request.UrlReferrer.AbsoluteUri;

            return Redirect(url);
        }
    }
}