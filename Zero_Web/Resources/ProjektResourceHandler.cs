using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Web;
using Zero.Web.Resources;

namespace Zero_Web.Resources
{
    public class ProjektResourceHandler
    {

        private static ResourceManager resourceManager;

        public static String loadDBValueSettings(String searchWord)
        {
            resourceManager = new ResourceManager(typeof(ProjektResources));

            if (resourceManager.GetString(searchWord) != null)
                return resourceManager.GetString(searchWord);
            else
                return "NULL";

        }

    }
}