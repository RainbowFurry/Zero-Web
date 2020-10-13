using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OpenIdConnect;
using MongoDB.Bson;
using System;
using System.Web;
using System.Web.Mvc;
using Zero_Web.Content.csharp.Zero;
using Zero_Web.Models;

namespace Zero_Web.Controllers
{
    public class AuthentificationController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Registration(User user)
        {

            /*ToDo:
             Filter einbauen ob pw übereinstimmt..
            ob bereits account... somit kein 2.
            DBs aufteilen
             */

            //Create a Random UID for the User
            user.ID = Guid.NewGuid().ToString();

            //Hash Password
            HashPassword hashPassword = new HashPassword();
            user.Password = hashPassword.createHash(user.Password);
            user.ConfirmPassword = hashPassword.createHash(user.ConfirmPassword);

            //Store User Data in the DB
            database.MongoDBManager db = new database.MongoDBManager();
            db.createEntry("User", user.ToBsonDocument());

            //Clear all Registration Fields entered in the View
            ModelState.Clear();

            return View("Registration");//RedirectToAction("LogIn", "Account", new { area = "Admin" });
        }

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult ForgotPassword()
        {
            return View();
        }

        public ActionResult NewPassword()
        {
            return View();
        }

        public ActionResult ConfirmRegistratin()
        {
            return View();
        }

        #region Microsoft
        /// <summary>
        /// Send an OpenID Connect sign-in request.
        /// Alternatively, you can just decorate the SignIn method with the [Authorize] attribute
        /// </summary>
        public void MS_SignIn()
        {
            if (!Request.IsAuthenticated)
            {
                HttpContext.GetOwinContext().Authentication.Challenge(
                    new AuthenticationProperties { RedirectUri = "/" },
                    OpenIdConnectAuthenticationDefaults.AuthenticationType);
            }
        }

        /// <summary>
        /// Send an OpenID Connect sign-out request.
        /// </summary>
        public void MS_SignOut()
        {
            HttpContext.GetOwinContext().Authentication.SignOut(
                    OpenIdConnectAuthenticationDefaults.AuthenticationType,
                    CookieAuthenticationDefaults.AuthenticationType);
        }
        #endregion

        #region Google
        /// <summary>
        /// Send an OpenID Connect sign-in request.
        /// Alternatively, you can just decorate the SignIn method with the [Authorize] attribute
        /// </summary>
        public void Google_SignIn()
        {
            if (!Request.IsAuthenticated)
            {
                HttpContext.GetOwinContext().Authentication.Challenge(
                    new AuthenticationProperties { RedirectUri = "/" },
                OpenIdConnectAuthenticationDefaults.AuthenticationType);
            }
        }

        /// <summary>
        /// Send an OpenID Connect sign-out request.
        /// </summary>
        public void Google_SignOut()
        {
            HttpContext.GetOwinContext().Authentication.SignOut(
                    OpenIdConnectAuthenticationDefaults.AuthenticationType,
                    CookieAuthenticationDefaults.AuthenticationType);
        }
        #endregion

        #region Facebook
        /// <summary>
        /// Send an OpenID Connect sign-in request.
        /// Alternatively, you can just decorate the SignIn method with the [Authorize] attribute
        /// </summary>
        public void Facebook_SignIn()
        {
            if (!Request.IsAuthenticated)
            {
                HttpContext.GetOwinContext().Authentication.Challenge(
                    new AuthenticationProperties { RedirectUri = "/" },
                    OpenIdConnectAuthenticationDefaults.AuthenticationType);
            }
        }

        /// <summary>
        /// Send an OpenID Connect sign-out request.
        /// </summary>
        public void Facebook_SignOut()
        {
            HttpContext.GetOwinContext().Authentication.SignOut(
                    OpenIdConnectAuthenticationDefaults.AuthenticationType,
                    CookieAuthenticationDefaults.AuthenticationType);
        }
        #endregion

    }
}