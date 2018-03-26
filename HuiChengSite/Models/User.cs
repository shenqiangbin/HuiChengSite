using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HuiChengSite.Models
{
    /// <summary>
    /// 用户
    /// </summary>
    public class User
    {
        public int UserId { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
        public string Phone { get; set; }

        public DateTime CreatedTime { get; set; }
        public DateTime? UpdateTime { get; set; }
        /// <summary>
        /// 删除标识：（0：已删除，1：未删除）
        /// </summary>
        public int Enable { get; set; }
    }

    
}