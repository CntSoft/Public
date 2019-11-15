using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using VanChi.FMS.Web.Common;

namespace VanChi.FMS.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            //
            routes.MapRoute(
              name: "MultiLanguage",
              url: "{lang}/{controller}/{action}/{id}",
              constraints: new { lang = @"(\w{2}-\w{2})" }, //@"(\w{2})|(\w{2}-\w{2})" //vi or vi-VN
              defaults: new { controller = Constant.Controller_Home, action = Constant.Action_Index, id = UrlParameter.Optional, lang = UrlParameter.Optional }
          );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
