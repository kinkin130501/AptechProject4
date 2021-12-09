using FourN.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;


namespace FourN.AdminSite.Helper
{
    public static class SendEmail
    {
        public static bool SendMail(EmailObject emailObject)
        {
            try
            {
                string to = emailObject.EmailTo; //email.To;
                /*string cc = emailObject.EmailCc;*/
                string subject = emailObject.EmailSubject;
                string body = emailObject.EmailContent;

                MailMessage ms = new MailMessage();
                ms.From = new MailAddress("cocoxcited.server@gmail.com");
                ms.To.Add(new MailAddress(to));
                ms.Subject = subject;
                ms.Body = body;
                ms.IsBodyHtml = true;

                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                smtp.UseDefaultCredentials = false;
                smtp.EnableSsl = true;
                smtp.Credentials = new System.Net.NetworkCredential("cocoxcited.server@gmail.com", "xjxzadxirdkjoaxs");
                smtp.Send(ms);
                return true;
            }
            catch(Exception ex) { return false; }
        }
    }
}
