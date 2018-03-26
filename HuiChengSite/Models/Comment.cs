using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HuiChengSite.Models
{
    public class Comment
    {
        public int CommentId { get; set; }
        public int ArticleId { get; set; }
        public string UserName { get; set; }
        public string Content { get; set; }
        public int ParentId { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime UpdateTime { get; set; }
        public int Enable { get; set; }

        /*扩展属性*/
        public IEnumerable<Comment> Children { get; set; }
    }

    /*后台评论管理使用*/
    public class CommentInfo
    {
        public int CommentId { get; set; }
        public int ArticleId { get; set; }
        public string UserName { get; set; }
        public string Content { get; set; }
        public int ParentId { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime UpdateTime { get; set; }
        public int Enable { get; set; }

        /*扩展属性*/
        public string ArticleTitle { get; set; }
    }
}