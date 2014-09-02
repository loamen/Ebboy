using Ebboy.Core.Helpers.Email;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Ebboy.Core.Helpers
{
    /// <summary>
    /// 邮件发送帮助
    /// </summary>
    /// 创 建 者：Loamen.com
    public static class EmailHelper
    {
        private static string stmpHost = ConfigurationManager.AppSettings["stmpHost"];
        private static string stmpPort = ConfigurationManager.AppSettings["stmpPort"];
        private static string sendEmail = ConfigurationManager.AppSettings["sendEmail"];
        private static string sendEmailPassword = ConfigurationManager.AppSettings["sendEmailPassword"];

        /// <summary>
        /// 发送邮件到指定Email
        /// </summary>
        /// <param name="mail"></param>
        /// 创 建 者：Loamen.com
        public static bool Send(this EmailModel mail)
        {
            if (null == mail) throw new ArgumentNullException("mail");

            if (null == mail.MailAddress || mail.MailAddress.Length < 1) throw new ArgumentNullException("MailAddress");

            using (MailMessage message = new MailMessage())
            {
                foreach (string address in mail.MailAddress)
                {
                    message.To.Add(new MailAddress(address));
                }

                message.From = new MailAddress(mail.FromMailAddress, mail.FromUser);
                message.Subject = mail.Title;
                message.SubjectEncoding = mail.EnCoding;
                message.Body = mail.Content;
                message.BodyEncoding = mail.EnCoding;
                message.IsBodyHtml = mail.IsHtml;

                int port = 25;

                int.TryParse(stmpPort, out port);

                var client = new SmtpClient(stmpHost, port);

                if (port != 25)
                {
                    client.EnableSsl = true;
                }
                client.UseDefaultCredentials = true;
                client.Credentials = new NetworkCredential(sendEmail, sendEmailPassword);

                bool success = true;

                try
                {
                    client.Send(message);
                }
                catch
                {
                    success = false;
                }

                return success;
            }
        }
    }
}
