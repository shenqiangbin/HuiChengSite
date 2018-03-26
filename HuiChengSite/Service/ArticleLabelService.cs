using HuiChengSite.Common;
using HuiChengSite.Models;
using HuiChengSite.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HuiChengSite.Service
{
    public class ArticleLabelService
    {
        private ArticleLabelRepository _articleLabelRepository;

        public ArticleLabelService(ArticleLabelRepository articleLabelRepository)
        {
            _articleLabelRepository = articleLabelRepository;
        }

        public int Add(int articleId,int lableId)
        {
            var model = new ArticleLabel();
            model.ArticleId = articleId;
            model.LabelId = lableId;

            if (ContextUser.IsLogined)
                model.CreateUser = ContextUser.Email;

            var time = DateTime.Now;

            model.CreateTime = time;
            model.UpdateTime = time;
            model.Enable = 1;

            var id = _articleLabelRepository.Add(model);
            return id;
        }

        public void RemoveByArticleId(int articleId)
        {
            _articleLabelRepository.RemoveByArticleId(articleId);
        }
    }
}