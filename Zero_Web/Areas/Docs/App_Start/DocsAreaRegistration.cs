using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Zero_Web
{
    public class DocsAreaRegistration : AreaRegistration
    {

        public override string AreaName
        {

            get
            {
                return "Docs";
            }

        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Docs_default",
                "Docs/{controller}/{action}/{id}",
                new { controller = "Docs", action = "Index", id = UrlParameter.Optional },
                new string[] { "Docs.Controllers" }
            );
        }

    }
}