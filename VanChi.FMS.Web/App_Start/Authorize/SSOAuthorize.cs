using VanChi.FMS.Web.Common;
using System;
using System.Configuration;
using System.Web.Mvc;

namespace VanChi.FMS.Web
{
    public class SSOAuthorize : AuthorizeAttribute
    {
        private string Url { get; set; }
        public SSOAuthorize(string url)
            : base()
        {
            this.Url = url;
        }
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            if (!filterContext.HttpContext.Request.IsAuthenticated)
            {
                string loginModeValue = ConfigurationManager.AppSettings[Constant.ModeOfLogin_Key];
                if (!string.IsNullOrEmpty(loginModeValue))
                {
                    string[] stValue = loginModeValue.Split(new string[] { "###" }, StringSplitOptions.None);
                    int loginMode = Convert.ToInt32(stValue[0]);
                }

                string sourceUrl = filterContext.HttpContext.Request.Url.OriginalString;
                string authUrl = string.Empty;
                if (string.IsNullOrEmpty(authUrl))
                {
                    authUrl = string.Format("{0}&Source={1}", this.Url, sourceUrl);
                }
                if (!string.IsNullOrEmpty(authUrl))
                {
                    filterContext.HttpContext.Response.Redirect(authUrl);
                }
            }

            base.HandleUnauthorizedRequest(filterContext);
        }
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (AuthorizeCore(filterContext.HttpContext))
            {
                base.OnAuthorization(filterContext);
            }
            else
            {
                HandleUnauthorizedRequest(filterContext);
            }
        }
    }
}