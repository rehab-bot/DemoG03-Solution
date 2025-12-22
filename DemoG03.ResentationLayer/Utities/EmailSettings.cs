
using System.Net;
using System.Net.Mail;

namespace DemoG03.ResentationLayer.Utities
{
    public static class EmailSettings
    {
        public static void SendEmail(Email email)
        {
            var client = new SmtpClient("smtp.gmail.com", 587);
            client.EnableSsl = true;
            client.Credentials = new NetworkCredential("Rehab.Rehab@gmail.com","123");
         client.Send("Rehab.Rehab@gmail.com",email.To,email.Subject ,email.Body);
        }
    }
}
