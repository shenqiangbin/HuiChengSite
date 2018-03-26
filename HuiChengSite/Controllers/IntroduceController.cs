using HuiChengSite.Common;
using HuiChengSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HuiChengSite.Controllers
{
    //公司简介
    public class IntroduceController : Controller
    {
        public ActionResult Index()
        {
            var model = GetModel();
            return View(model);
        }

        private IntroduceModel GetModel()
        {
            if (LanguageModel.GetLang() == LanguageEnum.En)
                return JsonHelper.GetEn<IntroduceModel>("IntroduceModel");

            return JsonHelper.GetZhCn<IntroduceModel>("IntroduceModel");
        }
    }

    public class IntroduceModel
    {
        public string PageTitle { get; set; }
        public string Content { get; set; }
    }
}