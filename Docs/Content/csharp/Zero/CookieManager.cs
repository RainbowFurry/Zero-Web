using System;
using System.Web.Mvc;

namespace Zero_Web.Content.csharp.Zero
{
    public class CookieManager : Controller
    {

        //Speichern von Cookies fehlt + ClearAll

        /// <summary>
        /// TEST
        /// </summary>
        private void test()
        {

            string cookievalue;
            if (Request.Cookies["cookie"] != null)
            {
                cookievalue = Request.Cookies["cookie"].Value.ToString();
            }
            else
            {
                Response.Cookies["cookie"].Value = "cookie value";
            }

        }

        /// <summary>
        /// Create the Cookies needed for Zero_Web
        /// </summary>
        private void CreateCookies()
        {

            CreateCookie("UserName", "MaxMustermann");
            CreateCookie("NickName", "MaxMuster");
            CreateCookie("Language", "de-De");
            CreateCookie("Email", "test.test@test.de");
            CreateCookie("Lizense", "0000-0000-0000-0000");

            CreateCookie("MainColor", "#436262");
            CreateCookie("Theme", "Dark Theme");

        }

        /// <summary>
        /// Clear all Cookies
        /// </summary>
        private void ClearCookies()
        {
            //
        }


        /// <summary>
        /// Create the Cookies
        /// </summary>
        private void CreateCookie(String cookieName, String cookieContent)
        {
            Response.Cookies[cookieName].Value = cookieContent;
        }

        /// <summary>
        /// Delete the Cookie you want to
        /// </summary>
        /// <param name="cookieName"></param>
        private void DeleteCookie(String cookieName)
        {
            if (Request.Cookies[cookieName] != null)
            {
                Response.Cookies[cookieName].Expires = DateTime.Now.AddDays(-1);
            }
        }

        /// <summary>
        /// Return the Cookie you are looking for
        /// </summary>
        /// <param name="cookieName"></param>
        /// <returns></returns>
        private String GetCookie(String cookieName)
        {
            return Request.Cookies[cookieName].Value.ToString();
        }

    }
}