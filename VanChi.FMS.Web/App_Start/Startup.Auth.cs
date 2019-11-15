using VanChi.FMS.Web.Common;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OAuth;
using Owin;
using System;

namespace VanChi.FMS.Web
{
    public partial class Startup
    {
        #region Variables and Properties

        /// <summary>  
        /// OAUTH options property.  
        /// </summary>  
        public static OAuthAuthorizationServerOptions OAuthOptions { get; private set; }
        /// <summary>  
        /// Public client ID property.  
        /// </summary>  
        public static string PublicClientId { get; private set; }

        #endregion

        #region Methods
        public void ConfigureAuth(IAppBuilder app)
        {
            #region Cookie

            // Enable the application to use a cookie to store information for the signed in user
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                //CookieHttpOnly = true,
                //ExpireTimeSpan = TimeSpan.FromDays(1),
                //SlidingExpiration = false,
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString(Constant.Login)
            });
            // Use a cookie to temporarily store information about a user logging in with a third party login provider
            app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);

            #endregion

            #region OAuth

            // Configure the application for OAuth based flow  
            // PublicClientId = Constant.PublicClientId;
            PublicClientId = App.Client_Id;
            OAuthOptions = new OAuthAuthorizationServerOptions
            {
                TokenEndpointPath = new PathString(Constant.ApiToken),
                Provider = new OAuthAuthorize(PublicClientId),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(1),
                AllowInsecureHttp = true //Don't do this in production ONLY FOR DEVELOPING: ALLOW INSECURE HTTP!  
            };

            // Enable the application to use bearer tokens to authenticate users  
            app.UseOAuthBearerTokens(OAuthOptions);

            // Enables the application to temporarily store user information when they are verifying the second factor in the two-factor authentication process.  
            app.UseTwoFactorSignInCookie(DefaultAuthenticationTypes.TwoFactorCookie, TimeSpan.FromMinutes(5));

            // Enables the application to remember the second login verification factor such as phone or email.  
            // Once you check this option, your second step of verification during the login process will be remembered on the device where you logged in from.  
            // This is similar to the RememberMe option when you log in.  
            app.UseTwoFactorRememberBrowserCookie(DefaultAuthenticationTypes.TwoFactorRememberBrowserCookie);

            #endregion
        }

        #endregion
    }
}