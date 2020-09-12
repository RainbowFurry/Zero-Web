using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Zero_Web
{
    public class ClientAreaRegistration : AreaRegistration
    {

        public override string AreaName
        {

            get
            {
                return "Client";
            }

        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Client_default",
                "Client/{controller}/{action}/{id}",
                new { controller = "Client", action = "Index", id = UrlParameter.Optional },
                new string[] { "Client.Controllers" }
            );
        }

    }
}