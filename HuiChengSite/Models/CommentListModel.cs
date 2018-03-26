using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HuiChengSite.Models
{
    public class CommentListQuery
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public string Order { get; set; }

        public string ArticleId { get; set; }

        public CommentListQuery()
        {
            this.PageSize = 10;
        }
    }

    public class CommentListModelResult
    {
        public IList<Comment> List { get; set; }
        public int TotalCount { get; set; }
    }

    public class CommentInfoListQuery
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public string Order { get; set; }

        public string ArticleId { get; set; }

        public CommentInfoListQuery()
        {
            this.PageSize = 10;
        }
    }

    public class CommentInfoListModelResult
    {
        public IList<CommentInfo> List { get; set; }
        public int TotalCount { get; set; }
    }
}