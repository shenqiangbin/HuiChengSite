using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HuiChengSite.Common
{
    public class ValidateHelper
    {
        /// <summary>
        /// 是否为空
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static bool IsEmpty(string data)
        {
            if (data == null)
                return true;

            if (string.IsNullOrEmpty(data.Trim()))
                return true;
            else
                return false;
        }

        /// <summary>
        /// 是否长度超长
        /// </summary>
        /// <param name="data"></param>
        /// <param name="maxLength"></param>
        /// <returns></returns>
        public static bool IsOverLength(string data,int maxLength)
        {
            if (data!=null)
            {
                if (data.Length > maxLength)
                    return true;
            }
            return false;
        }
    }
}