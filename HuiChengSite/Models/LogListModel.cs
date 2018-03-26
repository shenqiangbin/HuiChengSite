using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HuiChengSite.Models
{
    public class LogListQuery
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public string Order { get; set; }

        public LogListQuery()
        {
            this.PageSize = 10;
            this.Order = "order by date desc,logId desc";
        }
    }

    public class LogListModelResult
    {
        public IList<Log> List { get; set; }
        public int TotalCount { get; set; }
    }
}