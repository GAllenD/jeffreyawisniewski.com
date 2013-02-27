using System.Net.Mail;

namespace JeffWeb.Services
{
    public interface IEmailer
    {
        void Send(MailMessage email);
    }
}