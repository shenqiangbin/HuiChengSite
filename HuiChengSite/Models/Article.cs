using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HuiChengSite.Models
{
    /// <summary>
    /// 文章
    /// </summary>
    public class Article
    {
        public int ArticleId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        /// <summary>
        /// 内容级别：（0：正常 1：置顶 2：精华）
        /// </summary>
        public int ContentLevel { get; set; }
        /// <summary>
        /// 发布状态：（0：未发布，1：已发布）
        /// </summary>
        public int PublishStatus { get; set; }
        /// <summary>
        /// 展示的创建时间
        /// </summary>
        public DateTime DisplayCreatedTime { get; set; }
        /// <summary>
        /// 关键字
        /// </summary>
        public string KeyWords { get; set; }
        /// <summary>
        /// url标题
        /// </summary>
        public string UrlTitle { get; set; }
        /// <summary>
        /// url标题数字（需要唯一）
        /// </summary>
        public string UrlTitleNum { get; set; }

        public string CreateUser { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTime UpdateTime { get; set; }
        /// <summary>
        /// 删除标识：（0：已删除，1：未删除）
        /// </summary>
        public int Enable { get; set; }
    }

    public enum ContentLevel
    {
        /// <summary>
        /// 正常
        /// </summary>
        Common = 0,
        /// <summary>
        /// 置顶
        /// </summary>
        Top = 1,
        /// <summary>
        /// 精华
        /// </summary>
        Good = 2
    }

    public enum PublishStatus
    {
        /// <summary>
        /// 未发布
        /// </summary>
        Not = 0,
        /// <summary>
        /// 已发布
        /// </summary>
        Published = 1,
        /// <summary>
        /// 全部
        /// </summary>
        All = 2,
    }
}