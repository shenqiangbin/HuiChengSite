using HuiChengSite.Common;
using HuiChengSite.Filters;
using HuiChengSite.Models;
using HuiChengSite.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HuiChengSite.Areas.backmgr.Controllers
{
    [UserAuthorize]
    public class ArticleController : Controller
    {
        private ArticleService _articleService;
        private PermissionService _permissionService;
        private ArticleLabelService _articleLabelService;

        public ArticleController(ArticleService articleService, PermissionService permissionService, ArticleLabelService articleLabelService)
        {
            _articleService = articleService;
            _permissionService = permissionService;
            _articleLabelService = articleLabelService;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Add(string id)
        {
            Article model = new Article();
            ViewBag.IsNew = true;

            if (!string.IsNullOrEmpty(id))
            {
                model = _articleService.GetById(id);
                ViewBag.IsNew = false;
            }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public JsonResult Add(string articleId, string title, string content, List<int> lables, string keyWords, string urlTitle)
        {
            try
            {
                AddValidate(articleId, title, content, urlTitle);

                //新增
                if (string.IsNullOrEmpty(articleId))
                {
                    Article article = new Article();
                    article.Title = title;
                    article.Content = content;
                    article.KeyWords = keyWords;
                    article.UrlTitle = urlTitle;
                    articleId = _articleService.Add(article).ToString();

                    try
                    {
                        if (lables != null)
                        {
                            foreach (var item in lables)
                            {
                                _articleLabelService.Add(int.Parse(articleId), item);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        LogService.Instance.AddAsync(Level.Error, ex);
                        return Json(new { code = 503, msg = "文章保存成功，标签保存失败" });
                    }
                }
                else //编辑
                {
                    var model = _articleService.GetById(articleId);

                    //如果权限控制只能处理自已的数据的话
                    if (_permissionService.OnlyAccessSelf(ContextUser.Email, Permission.HuiChengSiteEdit))
                    {
                        if (model.CreateUser != ContextUser.Email)
                            return Json(new { code = 502, msg = "对不起，只能编辑自己创建的记录" });
                    }

                    model.Title = title;
                    model.Content = content;
                    model.KeyWords = keyWords;
                    model.UrlTitle = urlTitle;
                    _articleService.Update(model);

                    try
                    {
                        _articleLabelService.RemoveByArticleId(int.Parse(articleId));
                        if (lables != null)
                        {
                            foreach (var item in lables)
                            {
                                _articleLabelService.Add(int.Parse(articleId), item);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        LogService.Instance.AddAsync(Level.Error, ex);
                        return Json(new { code = 503, msg = "文章保存成功，标签保存失败" });
                    }
                }

                return Json(new { code = 200, msg = "ok", id = articleId });
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

        private void AddValidate(string articleId, string title, string content, string urlTitle)
        {
            if (ValidateHelper.IsEmpty(title))
                throw new ValidateException(101, "请填写标题");
            if (ValidateHelper.IsOverLength(title, 50))
                throw new ValidateException(102, $"标题请在50字内");
            if (ValidateHelper.IsEmpty(content))
                throw new ValidateException(101, "请填写内容");
            if (ValidateHelper.IsEmpty(urlTitle))
                throw new ValidateException(101, "请填写Url题目");

            var dbmodel = _articleService.GetByUrlTitle(urlTitle);
            if (dbmodel != null)
            {
                //如果是新增
                if (string.IsNullOrEmpty(articleId))
                    throw new ValidateException(409, "url标题已存在");
                else if (dbmodel.ArticleId.ToString() != articleId)
                    throw new ValidateException(409, "url标题已存在");
            }

            //if (ValidateHelper.IsOverLength(content, 50))
            //    throw new ValidateException(102, $"标题请在50字内");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Del(int? id)
        {
            try
            {
                if (!id.HasValue)
                    return Json(new { code = 400, msg = "id不能为空" });

                _articleService.Remove(id.Value);

                return Json(new { code = 200, msg = "ok" });
            }
            catch (Exception ex)
            {
                return Json(new { code = 500, msg = ex.Message });
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Publish(int? id)
        {
            try
            {
                if (!id.HasValue)
                    return Json(new { code = 400, msg = "id不能为空" });

                _articleService.Publish(id.Value);

                return Json(new { code = 200, msg = "ok" });
            }
            catch (Exception ex)
            {
                return Json(new { code = 500, msg = ex.Message });
            }
        }
    }
}