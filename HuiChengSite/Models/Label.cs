using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HuiChengSite.Models
{
    /// <summary>
    /// 标签
    /// </summary>
    public class Label
    {
        public int LabelId { get; set; }
        public string Name { get; set; }
        public string CreateUser { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime UpdateTime { get; set; }
        public int Enable { get; set; }
    }
}