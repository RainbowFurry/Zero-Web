using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Web;
using Zero.Web.Resources;

namespace Zero_Web.Resources
{
    public class ResourceTranslate
    {

        //Create ALL DBS INSTAND
        //in the right spot - folder

        private String[] languages = { "English", "French", "Italian", "Russia", "Spanish", "China" }; //German is default

        private String[] hashDB_Key = new String[1000];
        private String[] hashDB_Value = new String[1000];
        private int position = 0;

        public ResourceTranslate()
        {
            loadLanguages(@"C:\Users\DarkS\Documents\HeimServer\German.resx");//Kann man die Source Datei angeben???
        }

        /// <summary>
        /// Load all Languages that should be created
        /// </summary>
        /// <param name="languagePath"></param>
        private void loadLanguages(String languagePath)
        {
            for (int i = 0; i < languages.Length; i++)
            {
                position = i;

                loadContenetForDB(languagePath);
                writeContentToDB(languagePath);
            }
        }

        /// <summary>
        /// Get the Content from the Main Resources
        /// </summary>
        /// <param name="languagePath"></param>
        private void loadContenetForDB(String languagePath)
        {
            ResXResourceReader resxReader = new ResXResourceReader(languagePath);

            int step = -1;

            foreach (DictionaryEntry entry in resxReader)
            {
                Console.WriteLine("Key: " + entry.Key);
                Console.WriteLine("Value: " + entry.Value);

                if (entry.Value != null && entry.Key != null)
                {

                    step++;
                    hashDB_Key[step] = entry.Key.ToString();
                    hashDB_Value[step] = entry.Value.ToString();

                }

            }


        }

        /// <summary>
        /// Create the new Languages in the same Directory
        /// </summary>
        /// <param name="languagePath"></param>
        private void writeContentToDB(String languagePath)
        {

            ResXResourceWriter resx = new ResXResourceWriter(languagePath + languages[position] + @".resx");

            for (int i = 0; i < hashDB_Value.Length; i++)
            {
                if (hashDB_Key[i] != null && hashDB_Value[i] != null)
                    resx.AddResource(hashDB_Key[i], hashDB_Value[i]);//TranslateText.translateText(hashDB_Value[i]).Result);
            }
            resx.Generate();

        }

    }
}