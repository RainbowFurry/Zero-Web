using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Zero_Web
{
    public class APIAreaRegistration : AreaRegistration
    {

        public override string AreaName
        {

            get
            {
                return "API";
            }

        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "API_default",
                "API/{controller}/{action}/{id}",
                new { controller = "API", action = "Index", id = UrlParameter.Optional },
                new string[] { "API.Controllers" }
            );
        }

    }
}