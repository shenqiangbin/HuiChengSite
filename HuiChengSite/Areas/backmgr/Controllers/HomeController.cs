using HuiChengSite.Common;
using HuiChengSite.Filters;
using HuiChengSite.Models;
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
    public class HomeController : Controller
    {
        private ArticleService _articleService;
        private PermissionService _permissionService;

        public HomeController(ArticleService articleService, PermissionService permissionService)
        {
            _articleService = articleService;
            _permissionService = permissionService;
        }

        public ActionResult Index(int? page = 1)
        {
            ArticleListQuery query = new ArticleListQuery();
            query.PageIndex = Convert.ToInt32(page);
            query.PageSize = 10;
            query.PublishStatus = PublishStatus.All;

            if (_permissionService.OnlyAccessSelf(ContextUser.Email, Permission.HuiChengSiteList))
                query.TheUserData = ContextUser.Email;


            ArticleListModelResult result = _articleService.GetPaged(query);
            var pageList = new StaticPagedList<Article>(result.List, query.PageIndex, query.PageSize, result.TotalCount);

            return View(pageList);
        }
    }
}