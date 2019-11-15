using VanChi.Business.Interface;
using VanChi.FMS.Web.Common;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace VanChi.FMS.Web
{
    public class OAuthAuthorize : OAuthAuthorizationServerProvider
    {
        #region Properties  
        public IBusiness Business { get; set; }

        /// <summary>  
        /// Public client ID property.  
        /// </summary>  
        private readonly string _PublicClientId;

        #endregion

        #region Constructors
        public OAuthAuthorize()
        {
        }
        public OAuthAuthorize(string publicClientId)
        {
            this.Business = Autofac.GetBusiness();
            //TODO: Pull from configuration  
            if (publicClientId == null)
            {
                throw new ArgumentNullException(publicClientId);
            }
            // Settings.  
            _PublicClientId = publicClientId;
        }

        #endregion

        #region Override Methods

        #region Grant resource owner credentials override method

        /// <summary>  
        /// Grant resource owner credentials overload method
        /// </summary>  
        /// <param name="context">Context parameter</param>  
        /// <returns>Returns when task is completed</returns>  
        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            // Initialization.  
            string user = context.UserName;
            string password = context.Password;

            // Verification.  
            var data = await this.Business.UserInfo_AuthLogin(user, password);
            if (data != null)
            {
                var claims = new List<Claim>();
                claims.Add(new Claim(ClaimTypes.Name, data.UserName));

                // Setting Claim Identities for OAUTH 2 protocol.  
                ClaimsIdentity oAuthClaimIdentity = new ClaimsIdentity(claims, OAuthDefaults.AuthenticationType);
                oAuthClaimIdentity.AddClaim(new Claim(Constant.ClientID, context.ClientId));
                ClaimsIdentity cookiesClaimIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationType);

                // Setting user authentication.  
                AuthenticationProperties properties = CreateProperties(data.UserName, data.UserRoles, data.FullName);
                AuthenticationTicket ticket = new AuthenticationTicket(oAuthClaimIdentity, properties);

                // Grant access to authorize user.  
                context.Validated(ticket);
                context.Request.Context.Authentication.SignIn(cookiesClaimIdentity);
            }
            else
            {
                context.SetError(Constant.Invalid_Grant, Constant.Invalid_Grant_Message);
                return;
            }
        }

        #endregion

        #region Token endpoint override method

        /// <summary>  
        /// Token endpoint override method  
        /// </summary>  
        /// <param name="context">Context parameter</param>  
        /// <returns>Returns when task is completed</returns>  
        public override Task TokenEndpoint(OAuthTokenEndpointContext context)
        {
            foreach (KeyValuePair<string, string> property in context.Properties.Dictionary)
            {
                // Adding.  
                context.AdditionalResponseParameters.Add(property.Key, property.Value);
            }
            // Return info.  
            return Task.FromResult<object>(null);
        }

        #endregion

        #region Validate Client authntication override method  

        /// <summary>  
        /// Validate Client authntication override method  
        /// </summary>  
        /// <param name="context">Contect parameter</param>  
        /// <returns>Returns validation of client authentication</returns>  
        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            // Resource owner password credentials does not provide a client ID.  
            //if (context.ClientId == null)
            //{
            //    // Validate Authoorization.  
            //    context.Validated();
            //}

            string clientId;
            string clientSecret;
            context.TryGetFormCredentials(out clientId, out clientSecret);
            if (!string.IsNullOrEmpty(clientId) && clientId == _PublicClientId)
            {
                context.Validated(clientId);
            }
            return base.ValidateClientAuthentication(context);

            // Return info.  
            //return Task.FromResult<object>(null);
        }

        #endregion

        #region Validate client redirect URI override method  

        /// <summary>  
        /// Validate client redirect URI override method  
        /// </summary>  
        /// <param name="context">Context parmeter</param>  
        /// <returns>Returns validation of client redirect URI</returns>  
        public override Task ValidateClientRedirectUri(OAuthValidateClientRedirectUriContext context)
        {
            // Verification.  
            if (context.ClientId == _PublicClientId)
            {
                // Initialization.  
                Uri expectedRootUri = new Uri(context.Request.Uri, "/");

                // Verification.  
                if (expectedRootUri.AbsoluteUri == context.RedirectUri)
                {
                    // Validating.  
                    context.Validated();
                }
            }
            // Return info.  
            return Task.FromResult<object>(null);
        }

        #endregion

        #endregion

        #region Private Methods

        #region Create Authentication properties method 

        /// <summary>  
        /// Create Authentication properties method
        /// </summary>  
        /// <param name="userName">User name parameter</param>  
        /// <returns>Returns authenticated properties.</returns>  
        private static AuthenticationProperties CreateProperties(string userName, object userRole, string fullName)
        {
            // Settings.  
            IDictionary<string, string> data = new Dictionary<string, string>
            {
                { "username", userName },
                { "fullname", fullName }
                //{ "UserRole", string.Join(",", userRole) },
            };
            // Return info.  
            return new AuthenticationProperties(data);
        }

        #endregion

        #endregion
    }
}