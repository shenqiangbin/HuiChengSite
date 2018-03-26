using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace HuiChengSite
{
    public class RouteConfig
    {
public static void RegisterRoutes(RouteCollection routes)
{
    routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
    //routes.RouteExistingFiles = true;
    CustomRoute(routes);

    routes.MapRoute(
        name: "Default",
        url: "{controller}/{action}/{id}",
        defaults: new { controller = "Default", action = "Index", id = UrlParameter.Optional },
        namespaces: new[] { "HuiChengSite.Controllers" }
    );
}

private static void CustomRoute(RouteCollection routes)
{
    // 注意在配置文件中添加 ,否则会提示404,下面的作为是访问html文件时,走mvc模块处理,而不是直接请求
    //<add name="HtmlFileHandler" path="*.html" verb="GET" type="System.Web.Handlers.TransferRequestHandler" preCondition="integratedMode,runtimeVersionv4.0"/>
    routes.MapRoute(
        name: "Articles",
        url: "articles.html",
        defaults: new { Controller = "Home", action = "Index" },
        namespaces: new[] { "HuiChengSite.Controllers" }
    );
    routes.MapRoute(
        name: "Articles-p",
        url: "articles/p{page}.html",
        defaults: new { Controller = "Home", action = "Index" },
        namespaces: new[] { "HuiChengSite.Controllers" }
    );
    routes.MapRoute(
        name: "Articles-view",
        url: "articles/{urlTitle}.html",
        defaults: new { Controller = "Home", action = "ViewArticle" },
        namespaces: new[] { "HuiChengSite.Controllers" }
    );
}
        //Articles/p{page:int}.html
        //[Route("/Article/{urlTitle}.html")]
    }
}
