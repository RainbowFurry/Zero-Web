using System;
using System.Configuration;
using System.Globalization;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.Facebook;
using Microsoft.Owin.Security.Google;
using Microsoft.Owin.Security.Notifications;
using Microsoft.Owin.Security.OpenIdConnect;
using Owin;

[assembly: OwinStartup(typeof(Zero_Web.App_Start.Startup))]

namespace Zero_Web.App_Start
{
    public class Startup
    {
        /// <summary>
        /// App Startup Configuration
        /// </summary>
        /// <param name="app"></param>
        public void Configuration(IAppBuilder app)
        {
            MSConfiguration(app);
            GoogleAuthConfigure(app);
            //FacebookAuthConfigure(app);
            // Weitere Informationen zum Konfigurieren Ihrer Anwendung finden Sie unter https://go.microsoft.com/fwlink/?LinkID=316888.
        }

        public void ConfigureServices(IServiceCollection services)
        {
            //
        }

        #region Microsoft

        public void MSConfiguration(IAppBuilder app)
        {
            app.SetDefaultSignInAsAuthenticationType(CookieAuthenticationDefaults.AuthenticationType);

            app.UseCookieAuthentication(new CookieAuthenticationOptions());
            app.UseOpenIdConnectAuthentication(
                new OpenIdConnectAuthenticationOptions
                {
                    // Sets the ClientId, authority, RedirectUri as obtained from web.config
                    ClientId = ConfigurationManager.AppSettings["MS_ClientId"],
                    Authority = String.Format(CultureInfo.InvariantCulture, ConfigurationManager.AppSettings["MS_Authority"], ConfigurationManager.AppSettings["MS_Tenant"]),
                    RedirectUri = ConfigurationManager.AppSettings["MS_RedirectUri"],
                    // PostLogoutRedirectUri is the page that users will be redirected to after sign-out. In this case, it is using the home page
                    PostLogoutRedirectUri = ConfigurationManager.AppSettings["MS_RedirectUri"],
                    Scope = OpenIdConnectScope.OpenIdProfile,
                    // ResponseType is set to request the id_token - which contains basic information about the signed-in user
                    ResponseType = OpenIdConnectResponseType.IdToken,
                    // ValidateIssuer set to false to allow personal and work accounts from any organization to sign in to your application
                    // To only allow users from a single organizations, set ValidateIssuer to true and 'tenant' setting in web.config to the tenant name
                    // To allow users from only a list of specific organizations, set ValidateIssuer to true and use ValidIssuers parameter
                    TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateIssuer = false // This is a simplification
                    },
                    // OpenIdConnectAuthenticationNotifications configures OWIN to send notification of failed authentications to OnAuthenticationFailed method
                    Notifications = new OpenIdConnectAuthenticationNotifications
                    {
                        AuthenticationFailed = OnAuthenticationFailed
                    }
                }
            );
        }

        /// <summary>
        /// Handle failed authentication requests by redirecting the user to the home page with an error in the query string
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private Task OnAuthenticationFailed(AuthenticationFailedNotification<OpenIdConnectMessage, OpenIdConnectAuthenticationOptions> context)
        {
            context.HandleResponse();
            context.Response.Redirect("/?errormessage=" + context.Exception.Message);
            return Task.FromResult(0);
        }
        #endregion

        #region Google
        public void GoogleAuthConfigure(IAppBuilder app)
        {
            app.SetDefaultSignInAsAuthenticationType(CookieAuthenticationDefaults.AuthenticationType);

            app.UseGoogleAuthentication(new GoogleOAuth2AuthenticationOptions() {
            ClientId = ConfigurationManager.AppSettings["Google_ClientId"],
            ClientSecret = ConfigurationManager.AppSettings["Google_ClientSecret"],
            //CallbackPath = new PathString("/Login/Google_SignIn"),
            });
        }
        #endregion

        #region Facebook
        public void FacebookAuthConfigure(IAppBuilder app)
        {
            app.UseFacebookAuthentication(new FacebookAuthenticationOptions()
            {
                AppId = "",
                AppSecret = "",
                //CallbackPath = ""
            });
        }
        #endregion

    }
}
