using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Zero_Web.Models
{
    public class Settings
    {

        /*
         All this Settings are stored on the WebServer.
        In the Main Program the Program gets the files from the
        WebServer by logging in to the Server.
        So the Client has always the Server Settings of the logged
        in User to dispalay.
         */

        public string UserID { get; set; }
        public string MainColor { get; set; }
        public string Theme { get; set; }
        public string Language { get; set; }
        public bool Autostart { get; set; }

    }
}