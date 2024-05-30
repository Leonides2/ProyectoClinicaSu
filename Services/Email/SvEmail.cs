using Entidades;
using System.Net.Mail;
using System.Net;


namespace Services.Email
{
    public class SvEmail : ISvEmail
    {

        public void SendEmail(string to, string subject, string message, GmailSettings settings)
        {
            string body = "<!DOCTYPE html>\r\n<html>\r\n" +
                "<head>\r\n  " +
                "</head>\r\n" +
                "<body style=\"width: 100%;\">\r\n    " +
                "<h2 style=\"font-family: 'Lucida Sans', 'Lucida Sans Regular', 'Lucida Grande', 'Lucida Sans Unicode';\">" + subject + " </h2>\r\n    " +
                "<h3 style=\"font-family: 'Lucida Sans', 'Lucida Sans Regular', 'Lucida Grande', 'Lucida Sans Unicode';\"> " + message + "</h3>\r\n\r\n    " +
                 "</body>\r\n</html>";
            try
            {
                var client = new SmtpClient(settings.Server, settings.Port)
                {
                    Credentials = new NetworkCredential(settings.Username, settings.Password),
                    EnableSsl = true,
                };


                var mailMessage = new MailMessage
                {
                    From = new MailAddress(settings.Username!),
                    Subject = subject,
                    Body = body,
                    IsBodyHtml = true
                };

                mailMessage.To.Add(new MailAddress(to));

                client.Send(mailMessage);

            }
            catch (Exception ex)
            {
                throw new Exception("Can't send the email", ex);
            }
        }
    }
}
