using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace Zero_Web.Content.csharp.Zero
{
    public class MailManager
    {

        /*ToDo
         Remove Login Data to email and make it more secure...
        make it more variable to send the mail to the right person...
         */

        //Infos : https://www.e-iceblue.com/Knowledgebase/Spire.Email/Spire.Email-Program-Guide/Send-Email-with-Attachment-in-C-VB.NET.html

        private static String email = "darkwolfcraft.net@gmail.com";
        private static MailMessage mailMessage;

        /// <summary>
        /// Create the Email and send it to DarkWolfCraft.net@gmail.com
        /// </summary>
        public static void sendMail(string heading, string content)
        {
            mailMessage = new MailMessage(email, email, heading, content);
            createAndSendMail();
        }

        /// <summary>
        /// Send the Mail to the defined Values
        /// </summary>
        private static void createAndSendMail()
        {

            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
            smtpClient.EnableSsl = true;
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = new NetworkCredential(email, "JasonJT14Killer14JonasJT14");

            try
            {
                smtpClient.Send(mailMessage);
                //LogFileManager.createLogEntrence("DWC_VoiceAssistent has successfully send a new Mail");
            }
            catch (Exception ex)
            {
                //LogFileManager.createLogExeptionEntrence(ex);
            }

        }

    }
}