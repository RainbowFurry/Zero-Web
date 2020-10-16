using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OpenIdConnect;
using MongoDB.Bson;
using System;
using System.Web;
using System.Web.Mvc;
using Zero_Web.Content.csharp.Zero;
using Zero_Web.database;
using Zero_Web.Models;
using Zero_Web.Security;

namespace Zero_Web.Controllers
{
    public class AccountController : Controller
    {

        private readonly HashPassword hashPassword = new HashPassword();

        public ActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Registration(User viewUser)
        {
            if (string.IsNullOrEmpty(viewUser.Email) ||
                string.IsNullOrEmpty(viewUser.NickName) ||
                string.IsNullOrEmpty(viewUser.Password) ||
                string.IsNullOrEmpty(viewUser.ConfirmPassword))
            {
                ViewBag.Error = "Registration failed.";
                return RedirectToAction("Registration", "Account");
            }
            viewUser.ID = Guid.NewGuid().ToString();
            viewUser.Password = hashPassword.CreateHash(viewUser.Password);
            viewUser.ConfirmPassword = hashPassword.CreateHash(viewUser.ConfirmPassword);

            if (MongoDBManager.Instance.CreateEntry("User", viewUser.ToBsonDocument()))
            {
                return RedirectToAction("Login", "Account");
            }
            else
            {
                ViewBag.Error = "Registration failed. (System side)";
                return RedirectToAction("Registration", "Account");
            }
        }
        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Success()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Account account)
        {
            if (string.IsNullOrEmpty(account.LoginName) ||
                string.IsNullOrEmpty(account.LoginPassword) ||
                MongoDBManager.Instance.UserModel.Login(account.LoginName, hashPassword.CreateHash(account.LoginPassword)) == null)
            {
                ViewBag.Error = "Login failed.";
                return RedirectToAction("Login", "Account");
            }
            SessionPersister.Username = account.LoginName;
            return RedirectToAction("Success", "Account");
        }

        public ActionResult Logout()
        {
            SessionPersister.Username = string.Empty;
            return RedirectToAction("Login", "Account");
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