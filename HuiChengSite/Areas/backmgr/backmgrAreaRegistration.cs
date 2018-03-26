using System.Web.Mvc;

namespace HuiChengSite.Areas.backmgr
{
    public class backmgrAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "backmgr";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "backmgr_default",
                "backmgr/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "HuiChengSite.Areas.backmgr.Controllers" }
            );
        }
    }
}