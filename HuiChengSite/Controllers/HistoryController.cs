using HuiChengSite.Common;
using HuiChengSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HuiChengSite.Controllers
{
    //发展历程
    public class HistoryController : Controller
    {
        public ActionResult Index()
        {
            var model = GetModel();
            return View(model);
        }

        private HistoryModel GetModel()
        {
            if (LanguageModel.GetLang() == LanguageEnum.En)
                return JsonHelper.GetEn<HistoryModel>("HistoryModel");

            return JsonHelper.GetZhCn<HistoryModel>("HistoryModel");
        }
    }

    public class HistoryModel
    {
        public string PageTitle { get; set; }
        public string Content { get; set; }
    }
}