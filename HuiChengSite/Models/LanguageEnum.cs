using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HuiChengSite.Models
{
    public class LanguageModel
    {
        public const string LANGUAGE = "lang";

        public static LanguageEnum GetLang()
        {
            var obj = HttpContext.Current.Session[LANGUAGE];
            if (obj == null)
                return LanguageEnum.ZhCn;
            else
                return (LanguageEnum)obj;
        }
    }
    public enum LanguageEnum
    {
        /// <summary>
        /// 中文
        /// </summary>
        ZhCn = 0,
        /// <summary>
        /// 英文
        /// </summary>
        En = 1
    }
}