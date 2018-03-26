using Autofac.Integration.Mvc;
using HuiChengSite.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HuiChengSite.Common
{
    public class ContextUser
    {
        public static string Email
        {
            get
            {
                if (HttpContext.Current.User.Identity.IsAuthenticated)
                    return HttpContext.Current.User.Identity.Name;
                else
                    return "";
            }
        }

        public static bool IsLogined
        {
            get
            {
                return HttpContext.Current.User.Identity.IsAuthenticated;
            }
        }

        public static string UserName
        {
            get
            {
                var userService = AutofacDependencyResolver.Current.GetService(typeof(UserService)) as UserService;
                var user = userService.GetUserByEmail(ContextUser.Email);
                if (user != null)
                    return user.UserName;
                else
                    return "";
            }
        }
    }
}