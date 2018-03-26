using HuiChengSite.Common;
using HuiChengSite.Models;
using HuiChengSite.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HuiChengSite.Service
{
    public class ArticleService
    {
        private ArticleRepository _articleRepository;

        public ArticleService(ArticleRepository articleRepository)
        {
            _articleRepository = articleRepository;
        }

        public int Add(Article model)
        {
            model.ContentLevel = (int)ContentLevel.Common;
            model.PublishStatus = (int)PublishStatus.Not;

            var time = DateTime.Now;

            model.DisplayCreatedTime = time;
            model.UrlTitleNum = MD5Helper.MD5ToNum(model.UrlTitle).ToString();

            if (ContextUser.IsLogined)
                model.CreateUser = ContextUser.Email;

            model.CreatedTime = time;
            model.UpdateTime = time;
            model.Enable = 1;

            var id = _articleRepository.Add(model);
            return id;
        }

        public int Update(Article model)
        {
            model.UpdateTime = DateTime.Now;
            model.UrlTitleNum = MD5Helper.MD5ToNum(model.UrlTitle).ToString();

            return _articleRepository.Update(model);
        }

        public Article GetById(string articleId)
        {
            return _articleRepository.GetById(articleId);
        }

        public Article GetByUrlTitle(string urlTitle)
        {
            var list = _articleRepository.GetByColumn("urlTitle", urlTitle);
            if (list.Count > 1)
                throw new ValidateException(409, "urltitle重复");
            else
                return list.FirstOrDefault();
        }

        public Article GetByUrlTitleNum(string urlTitleNum)
        {
            var list = _articleRepository.GetByColumn("urlTitleNum", urlTitleNum);
            if (list.Count > 1)
                throw new ValidateException(409, "urlTitleNum重复");
            else
                return list.FirstOrDefault();
        }

        public ArticleListModelResult GetPaged(ArticleListQuery listModel)
        {
            return _articleRepository.GetPaged(listModel);
        }

        public void Remove(int id)
        {
            _articleRepository.Remove(id);
        }

        public void Publish(int id)
        {
            var model = _articleRepository.GetById(id.ToString());
            if (model.PublishStatus == (int)PublishStatus.Published)
                model.PublishStatus = (int)PublishStatus.Not;
            else if (model.PublishStatus == (int)PublishStatus.Not)
                model.PublishStatus = (int)PublishStatus.Published;

            model.UpdateTime = DateTime.Now;

            _articleRepository.Update(model);
        }
    }
}