using System;
using System.Linq;
using System.Net.Mail;
using System.Web.Mvc;
using Jeff.Model.Domain;
using Jeff.Model.View;
using JeffWeb.Models.Services;

namespace JeffWeb.Controllers
{
    public class ContactController : ConfigurableController
    {
        private Emailer _emailer;
        private string _email;
        private const string SUCCESS_MESSAGE = "Email successful!  I look forward to hearing from you.";
        private const string FAILURE_MESSAGE = "An error has occurred.  Please try again later.";

        public ContactController()
        {
            _emailer = new Emailer();
            _email = GetCurrentPageConfigurations().Single().EmailAddress;
        }

        public override PageType Page()
        {
            return PageType.Contact;
        }

        public ActionResult Index()
        {
            return View(GetEmptyDisplayForm());
        }

        public ActionResult Send(ContactForm form)
        {

            try
            {
                var message = string.Concat("Email From:", form.Name, "(", form.ContactInfo, ")", Environment.NewLine, form.Message);

                var mailMessage = new MailMessage("info@jeffreyawisniewski.com", _email, form.Subject, message);

                _emailer.Send(mailMessage);

                form = GetEmptyDisplayForm();
                form.SendStatusMessage = SUCCESS_MESSAGE;

            }
            catch (Exception e)
            {
                form = GetEmptyDisplayForm();
                form.SendStatusMessage = FAILURE_MESSAGE;

            }


            return View("Index", form);
        }

        public ContactForm GetEmptyDisplayForm()
        {
            

            return new ContactForm
            {
                DisplayEmail = _email
            };
        }
    }
}
