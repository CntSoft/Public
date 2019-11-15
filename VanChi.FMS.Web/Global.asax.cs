using AutoMapper;
using VanChi.Business.DTO;
using VanChi.FMS.Web.Common;
using log4net.Config;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Security.Claims;
using System.Web;
using System.Web.Helpers;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace VanChi.FMS.Web
{
    public class App : System.Web.HttpApplication
    {
        #region Variables and Properties

        /// <summary>
        /// Resource
        /// </summary>
        public static Dictionary<string, ResourceDTO> DicResources = new Dictionary<string, ResourceDTO>();

        /// <summary>
        /// Cache provider
        /// </summary>
        public static CacheService CacheProvider = new CacheService();

        /// <summary>
        /// PageSize
        /// </summary>
        public static int PageSize = 20;

        /// <summary>
        /// en-EN
        /// </summary>
        public const string Culture = "en-EN";

        /// <summary>
        /// dd/MM/yyyy
        /// </summary>
        public const string DatePattern = "dd/MM/yyyy";

        /// <summary>
        /// dd/MM/yyyy HH:MM:ss
        /// </summary>
        public const string DatePatternHMS = "dd/MM/yyyy HH:MM:ss";

        /// <summary>
        /// Language default
        /// </summary>
        public static string LanguageDefault = string.IsNullOrEmpty(ConfigurationManager.AppSettings[Constant.LanguageDefault_Key].ToString()) ? Constant.Language_Vietnamese : ConfigurationManager.AppSettings[Constant.LanguageDefault_Key].ToString().ToLower();

        /// <summary>
        /// Public identifier
        /// </summary>
        public static string Client_Id = string.IsNullOrEmpty(ConfigurationManager.AppSettings[Constant.ClientId_Key].ToString()) ? String.Empty : ConfigurationManager.AppSettings[Constant.ClientId_Key].ToString().ToLower();

        #endregion
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            DataAnnotationsModelValidatorProvider.RegisterAdapterFactory(typeof(RequiredAttribute), (metadata, controllerContext, attribute) => new VanChi.FMS.Web.Common.RequiredAttributeAdapter(metadata, controllerContext, (RequiredAttribute)attribute));
            DataAnnotationsModelValidatorProvider.RegisterAdapter(typeof(ExEmailAttribute), typeof(RegularExpressionAttributeAdapter));
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AntiForgeryConfig.UniqueClaimTypeIdentifier = ClaimTypes.Name;
            Mapper.Initialize(x => { x.AddProfile<MappingProfile>(); });
            // Initialize log4net
            XmlConfigurator.Configure();
        }
        protected void Application_PreSendRequestHeaders(object sender, EventArgs e)
        {
            var m_Headers = HttpContext.Current.Response.Headers;
            HttpContext.Current.Response.Headers.Remove("Server");
            HttpContext.Current.Response.Headers.Remove("X-AspNet-Version");
            HttpContext.Current.Response.Headers.Remove("X-AspNetMvc-Version");
            HttpContext.Current.Response.Headers.Remove("X-Powered-By");
        }
    }
}
