using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace Zero_Web.Content.csharp.Zero
{
    public class SendApplyEmail
    {

        public static void createAndSendMail(string heading, string content, HttpPostedFileBase file)
        {

            var message = new MailMessage();
            message.To.Add(new MailAddress("apply@zeroworks.de"));  // replace with valid value 
            message.From = new MailAddress("apply@zeroworks.de");  // replace with valid value
            message.Subject = heading;
            message.Body = content;
            message.IsBodyHtml = true;

            //add File
            string fileName = Path.GetFileName(file.FileName);
            message.Attachments.Add(new Attachment(file.InputStream, fileName));

            using (var smtp = new SmtpClient())
            {
                var credential = new NetworkCredential
                {
                    UserName = "apply@zeroworks.de",  // replace with valid value
                    Password = "uettanke91"  // replace with valid value
                };
                smtp.Credentials = credential;
                smtp.Host = "mail.zeroworks.de";
                smtp.Port = 587;
                smtp.EnableSsl = true;
                smtp.Send(message);
            }

        }

    }
}