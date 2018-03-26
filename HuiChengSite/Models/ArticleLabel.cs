using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HuiChengSite.Models
{
    /// <summary>
    /// 文章&标签关系表
    /// </summary>
    public class ArticleLabel
    {
        public int LabelId { get; set; }
        public int ArticleId { get; set; }
        public string CreateUser { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime UpdateTime { get; set; }
        public int Enable { get; set; }
    }
}