using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Zero_Web
{
    public class PortalAreaRegistration : AreaRegistration
    {

        public override string AreaName
        {

            get
            {
                return "Portal";
            }

        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Portal_default",
                "Portal/{controller}/{action}/{id}",
                new { controller = "Portal", action = "Index", id = UrlParameter.Optional },
                new string[] { "Portal.Controllers" }
            );
        }

    }
}