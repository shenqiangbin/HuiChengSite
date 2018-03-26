using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HuiChengSite.Models
{
    /// <summary>
    /// 日志
    /// </summary>
    public class Log
    {
        public int LogID { get; set; }
        public DateTime Date { get; set; }
        public string Level { get; set; }
        public string Logger { get; set; }
        public string Message { get; set; }
    }

    public enum Level
    {
        Info = 0,
        Warn = 1,
        Error = 2
    }
}
