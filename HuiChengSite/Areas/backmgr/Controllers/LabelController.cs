using HuiChengSite.Common;
using HuiChengSite.Filters;
using HuiChengSite.Models;
using HuiChengSite.Repository;
using HuiChengSite.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HuiChengSite.Areas.backmgr.Controllers
{
    public class LabelController : Controller
    {
        private LabelService _labelService;
        private ArticleLabelService _articleLabelService;

        public LabelController(LabelService labelService, ArticleLabelService articleLabelService)
        {
            _labelService = labelService;
            _articleLabelService = articleLabelService;
        }

        public JsonResult GetAll()
        {
            try
            {
                var models = _labelService.GetAll();
                return Json(new { code = 200, data = models }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                LogService.Instance.AddAsync(Models.Level.Error, ex);
                return Json(new { code = 500, msg = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult GetLablesByArticle(int articleId)
        {
            try
            {
                var models = _labelService.GetLablesByArticle(articleId);
                return Json(new { code = 200, data = models }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                LogService.Instance.AddAsync(Models.Level.Error, ex);
                return Json(new { code = 500, msg = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public JsonResult Add(string LabelName)
        {
            try
            {
                if (string.IsNullOrEmpty(LabelName))
                    throw new ValidateException(409, "标签名称不能为空");

                Label model = new Label();
                model.Name = LabelName;
                int labelId = _labelService.Add(model);

                return Json(new { code = 200, msg = "ok", id = labelId });
            }
            catch (ValidateException ex)
            {
                LogService.Instance.AddAsync(Level.Error, ex);
                return Json(new { code = ex.Code, msg = ex.Message });
            }
            catch (Exception ex)
            {
                LogService.Instance.AddAsync(Level.Error, ex);
                return Json(new { code = 500, msg = ex.Message });
            }
        }

    }
}