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
    public class CommentController : Controller
    {
        private CommentService _commentService;

        public CommentController(CommentService commentService)
        {
            _commentService = commentService;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List(int? page = 1)
        {
            CommentInfoListQuery listModel = new CommentInfoListQuery();
            listModel.PageIndex = Convert.ToInt32(page);
            listModel.PageSize = 10;

            CommentInfoListModelResult result = _commentService.GetInfoPaged(listModel);

            if (result.List.Count == 0 && result.TotalCount != 0 && page != 1)
            {
                page--;
                return RedirectToAction("list", new { page = page });
            }

            var pageList = new StaticPagedList<CommentInfo>(result.List, listModel.PageIndex, listModel.PageSize, result.TotalCount);

            return View(pageList);
        }

        [HttpPost]
        public ActionResult Delete(string commentId)
        {
            try
            {
                _commentService.Remove(Convert.ToInt32(commentId));
                return Json(new { code = 200, msg = "ok" });
            }
            catch (Exception ex)
            {
                LogService.Instance.AddAsync(Level.Error, ex);
                return Json(new { code = 500, msg = "error" });
            }
        }
    }
}