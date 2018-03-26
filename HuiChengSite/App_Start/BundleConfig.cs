using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace HuiChengSite.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            //bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
            //            "~/Scripts/jquery-{version}.js"));     

            bundles.Add(new StyleBundle("~/Content/css").Include("~/Content/site.css"));
            bundles.Add(new StyleBundle("~/Content/mcss").Include("~/Content/msite.css"));

            bundles.Add(new StyleBundle("~/Content/index").Include("~/Content/index.css", "~/Content/PagedList.css"));
            bundles.Add(new StyleBundle("~/Content/mindex").Include("~/Content/mindex.css", "~/Content/PagedList.css"));

            bundles.Add(new StyleBundle("~/Content/detail").Include("~/Content/detail.css"));
            bundles.Add(new StyleBundle("~/Content/mdetail").Include("~/Content/mdetail.css"));

            bundles.Add(new StyleBundle("~/Content/backindex").Include("~/Content/backindex.css", "~/Content/PagedList.css"));
            bundles.Add(new StyleBundle("~/Content/backLogList").Include("~/Content/backLogList.css", "~/Content/PagedList.css"));

            bundles.Add(new StyleBundle("~/Content/commentList").Include("~/Content/commentList.css", "~/Content/PagedList.css"));

            bundles.Add(new ScriptBundle("~/Scripts/backcommon").Include("~/Scripts/backcommon.js"));

            bundles.Add(new ScriptBundle("~/Scripts/ueditor/js").Include(
                        "~/Scripts/ueditor/ueditor.config.js",
                        "~/Scripts/ueditor/ueditor.all.min.js"
                        ));

            bundles.Add(new ScriptBundle("~/Scripts/ueditor/lang/zh-cn/zh").Include(
                        "~/Scripts/ueditor/lang/zh-cn/zh-cn.js"
                        ));

            bundles.Add(new ScriptBundle("~/Scripts/rsa/js").Include(
                "~/Scripts/Rsa/Barrett.js",
                "~/Scripts/Rsa/BigInt.js",
                "~/Scripts/Rsa/RSA.js",
                "~/Scripts/Rsa/RSAClient.js"));

            bundles.Add(new ScriptBundle("~/Scripts/erweima/js").Include(
                    "~/Scripts/erweima/utf.js",
                    "~/Scripts/erweima/jquery.qrcode.js"
                    ));

            bundles.Add(new ScriptBundle("~/Scripts/business/articledetail").Include(
                "~/Scripts/prettify.load.js",
                "~/Scripts/business/articledetail.js"
                ));

        }
    }
}