using Autofac.Integration.Mvc;
using HuiChengSite.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HuiChengSite.Filters
{
    public class UserAuthorizeAttribute : AuthorizeAttribute
    {
        private bool isAuthorize;
        private string actionUrl;

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            base.HandleUnauthorizedRequest(filterContext);
            if (isAuthorize)//如果认证了，只是没有权限则展示无权限界面
            {
                if (filterContext.RequestContext.HttpContext.Request.IsAjaxRequest())
                {
                    //filterContext.RequestContext.HttpContext.Response.AddHeader("userstatus", "timeout");
                    filterContext.RequestContext.HttpContext.Response.AddHeader("userstatus", "unauthorize");
                    var content = new ContentResult();
                    content.Content = "对不起，无权操作";
                    filterContext.Result = content;
                }
                else
                {
                    filterContext.Result = new RedirectResult("/backmgr/account/unauthorize");
                }

              
            }

        }

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            bool skipAuthorization = filterContext.ActionDescriptor.IsDefined(typeof(AllowAnonymousAttribute), inherit: true)
                            || filterContext.ActionDescriptor.ControllerDescriptor.IsDefined(typeof(AllowAnonymousAttribute), inherit: true);

            if (skipAuthorization)
            {
                return;
            }

            var controllerName = (filterContext.RouteData.Values["controller"]).ToString().ToLower();
            var actionName = (filterContext.RouteData.Values["action"]).ToString().ToLower();
            var areaName = (filterContext.RouteData.DataTokens["area"] == null ? "" : filterContext.RouteData.DataTokens["area"]).ToString().ToLower();

            if (string.IsNullOrEmpty(areaName))
                actionUrl = "/" + controllerName + "/" + actionName;
            else
                actionUrl = "/" + areaName + "/" + controllerName + "/" + actionName;


            base.OnAuthorization(filterContext);
        }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            isAuthorize = base.AuthorizeCore(httpContext);
            if (isAuthorize)
            {
                var permissionService = AutofacDependencyResolver.Current.GetService(typeof(PermissionService)) as PermissionService;
                //bool canAccess = IsInRole(httpContext.User.Identity.Name, actionUrl);
                bool canAccess = permissionService.CanAccess(httpContext.User.Identity.Name, actionUrl);
                return canAccess;
            }
            else
            {
                return false;
            }

        }

        protected override HttpValidationStatus OnCacheAuthorization(HttpContextBase httpContext)
        {
            return base.OnCacheAuthorization(httpContext);
        }

        private bool IsInRole(string account, string url)
        {
            //todo:添加角色验证代码
            //var menuService = AutofacDependencyResolver.Current.GetService(typeof(MenuService)) as MenuService;
            //return menuService.CanAccess(ContextUser.RoleId, actionUrl);
            //if (account != "admin" && url == "/user/index")
            //    return false;
            //else
            //    return true;
            return true;
        }
    }
}