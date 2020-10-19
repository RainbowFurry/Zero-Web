using System;
using System.Resources;

namespace Zero_Web.Resources.Error
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

            if (resourceManager.GetString(searchWord) != null)
                return resourceManager.GetString(searchWord);
            else
                return "NULL";

        }

    }
}