using VanChi.Business.Common;
using VanChi.FMS.Web.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;

namespace System.Web.Mvc
{
    public class TemporaryAuthorize : AuthorizeAttribute, IAuthorizationFilter
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            //Null httpContext
            if (httpContext == null) throw new ArgumentNullException(Constant.HttpContext);

            var roleUser = ((ClaimsIdentity)httpContext.User.Identity).Claims.FirstOrDefault(x => x.Type == ClaimTypes.Role)?.Value;

            if (roleUser != AppUserRole.Temporary.ToString())
            {
                return false;
            }

            return base.AuthorizeCore(httpContext);
        }
    }
}