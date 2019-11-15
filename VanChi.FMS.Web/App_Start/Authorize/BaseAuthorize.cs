using VanChi.Business.Common;
using VanChi.Business.DTO;
using VanChi.FMS.Web.Common;
using VanChi.FMS.Web.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Web;
using System.Web.Routing;

namespace System.Web.Mvc
{
    public class BaseAuthorize : AuthorizeAttribute, IAuthorizationFilter
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            //Null httpContext
            if (httpContext == null) throw new ArgumentNullException(Constant.HttpContext);

            if (!base.AuthorizeCore(httpContext))
            {
                return false;
            }
            else
            {
                return base.AuthorizeCore(httpContext);
            }
        }
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            var controller = filterContext.RouteData.Values[Constant.Controller].ToString();
            var action = filterContext.RouteData.Values[Constant.Action].ToString();

            if (string.IsNullOrEmpty(action)) action = Constant.Action_Index;
            if (string.IsNullOrEmpty(controller)) action = Constant.Controller_Home;

            if (!filterContext.ActionDescriptor.IsDefined(typeof(AllowAnonymousAttribute), false) &&
               !filterContext.ActionDescriptor.ControllerDescriptor.IsDefined(typeof(AllowAnonymousAttribute), false))
            {
                if (!HavePermission(controller, action))
                {
                    filterContext.HttpContext.Response.StatusCode = 401;
                    filterContext.Result = new RedirectResult(Constant.AccessDenied);
                }
            }

            base.OnAuthorization(filterContext);
        }
        private bool HavePermission(string controller, string action)
        {
            try
            {
                var roleUser = ((ClaimsIdentity)HttpContext.Current.User.Identity).Claims.FirstOrDefault(x => x.Type == ClaimTypes.Role)?.Value;
                if (roleUser.Contains(AppUserRole.SystemAdmin.ToString()))
                {
                    return true;
                }
                else
                {
                    var roles = new AccountInfo(HttpContext.Current.User.Identity.Name, HttpContext.Current.User.Identity.Name).Permission;
                    int total = roles.Count(x => x.Controller?.ToLower() == controller.ToLower() && x.Action?.ToLower() == action.ToLower() && x.ActiveFag == AppValues.ActiveFag.StatusActive);
                    if (total > 0)
                    {
                        return true;
                    }
                }
            }
            catch
            {
            }
            return false;
        }
    }
}