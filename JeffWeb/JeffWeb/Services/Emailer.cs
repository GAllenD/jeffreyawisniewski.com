using System.Net;
using System.Net.Mail;

namespace JeffWeb.Services
{
    public class Emailer : IEmailer
    {
        public void Send(MailMessage email)
        {
            var mailCient = new SmtpClient();
            var credentials = new NetworkCredential
            {
                UserName = "info@jeffreyawisniewski.com", 
                Password = "testing"
            };

            mailCient.Host = "dzezinski.easycgi.com";
            mailCient.Port = 587;
            mailCient.Credentials = credentials;
            
            mailCient.Send(email);
        }
    }
}