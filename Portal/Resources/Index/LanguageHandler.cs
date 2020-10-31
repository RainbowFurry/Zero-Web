using Portal.Resources.Index;
using System;
using System.Resources;

namespace Zero_Web.Resources.Login
{
    public class LanguageHandler
    {

        private static String language = "de-DE";//ConfigManager.language;
        private static ResourceManager resourceManager;

        public static String loadDBValueSettings(String searchWord)
        {
            if (language == "de-DE")
            {
                resourceManager = new ResourceManager(typeof(German));
            }
            else if (language == "en-EN")
            {
                resourceManager = new ResourceManager(typeof(English));
            }
            //else if (language == "fr-FR")
            //{
            //    resourceManager = new ResourceManager(typeof(French));
            //}
            //else if (language == "ru-RU")
            //{
            //    resourceManager = new ResourceManager(typeof(Russian));
            //}
            //else if (language == "chn-CHN")
            //{
            //    resourceManager = new ResourceManager(typeof(Chinese));
            //}
            //else if (language == "it-IT")
            //{
            //    resourceManager = new ResourceManager(typeof(Italian));
            //}
            //else if (language == "es-ES")
            //{
            //    resourceManager = new ResourceManager(typeof(Spanish));
            //}

            if (resourceManager.GetString(searchWord) != null)
                return resourceManager.GetString(searchWord);
            else
                return "NULL";

        }

    }
}