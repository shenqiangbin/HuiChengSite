using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HuiChengSite.Models
{
    public class ArticleListQuery
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public string Order { get; set; }

        /// <summary>
        /// 展示指定人的数据
        /// </summary>
        public string TheUserData { get; set; }

        public PublishStatus PublishStatus { get; set; }

        public ArticleListQuery()
        {
            this.PageSize = 10;
            this.PublishStatus = PublishStatus.Published;
        }
    }

    public class ArticleListModelResult
    {
        public IList<Article> List { get; set; }
        public int TotalCount { get; set; }
    }
}