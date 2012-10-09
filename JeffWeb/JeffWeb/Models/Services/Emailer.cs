using System.Net.Mail;

namespace JeffWeb.Models.Services
{
    public class Emailer
    {
        public void Send(MailMessage email)
        {
            var mailCient = new SmtpClient();
            
            mailCient.Send(email);
        }
    }
}