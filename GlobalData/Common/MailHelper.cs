using System.Net;
using System.Net.Mail;

namespace Utilities.Common
{
    public class MailHelper
    {
        /// <summary>
        /// Mail gönderme işlemi yapar.
        /// </summary>
        /// <param name="receiverEmailAdress"></param>
        /// <param name="subject"></param>
        /// <param name="body"></param>
        public static void SendMail(string receiverEmailAdress, string subject, string body)
        {
            // E-posta gönderenin bilgileri
            string senderEmail = "noreply@yektamak.com.tr";
            string senderPassword = "Yod43257";

            // SmtpClient ve MailMessage oluşturulması
            SmtpClient smtpClient = new SmtpClient("smtp-mail.outlook.com");
            smtpClient.Port = 587;
            smtpClient.Credentials = new NetworkCredential(senderEmail, senderPassword);
            smtpClient.EnableSsl = true;

            MailMessage mailMessage = new MailMessage(senderEmail, receiverEmailAdress, subject, body);


            // E-postanın gönderilmesi
            smtpClient.Send(mailMessage);
        }
    }
}
