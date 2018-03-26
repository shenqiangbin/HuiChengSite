using HuiChengSite.Models;
using HuiChengSite.Filters;
using HuiChengSite.Service;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HuiChengSite.Areas.backmgr.Controllers
{
    [UserAuthorize]
    public class LogController : Controller
    {
        private LogService _LogService;

        public LogController(LogService LogService)
        {
            _LogService = LogService;
        }

        public ActionResult Index()
        {
            LogService.Instance.AddAsync(Level.Error, "msg");
            return Content("hello baby");
        }

        public ActionResult List(int? page = 1)
        {
            LogListQuery query = new LogListQuery();
            query.PageIndex = Convert.ToInt32(page);
            query.PageSize = 8;

            LogListModelResult result = _LogService.GetPaged(query);
            var pageList = new StaticPagedList<Log>(result.List, query.PageIndex, query.PageSize, result.TotalCount);

            return View(pageList);
        }
    }
}