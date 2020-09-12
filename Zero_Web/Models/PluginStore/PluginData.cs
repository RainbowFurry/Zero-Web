using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Zero_Web.Models.PluginStore
{
    public class PluginData
    {

        public string PluginID { get; set; }
        public string Name { get; set; }
        public string sDescription { get; set; }
        public string lDescription { get; set; }
        public string Author { get; set; }
        public string Version { get; set; }
        public string Image { get; set; }
        public string DownloadPath { get; set; }
        public string Docs { get; set; }

        //Community Values
        public int Downloads { get; set; }
        public int Likes { get; set; }
        public int Dislikes { get; set; }
        public int Reports { get; set; }

    }
}