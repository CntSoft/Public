using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Http;
using Syncfusion.Licensing;
using AutoMapper;
using log4net.Config;

namespace VanChi.FMS.App
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
	    //Syncfusion Licensing Register
	    SyncfusionLicenseProvider.RegisterLicense("MDAxQDMxMzcyZTMzMmUzMFNOSno3cWlkZWhSZTBBQ3JSN2IrbW5uNS9OMHk0cWRNa1ZRcmlCR2Z1Smc9");
            AreaRegistration.RegisterAllAreas();
            Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            Mapper.Initialize(x => { x.AddProfile<MappingProfile>(); });
            // Initialize log4net
            XmlConfigurator.Configure();
        }
        public static void Register(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
