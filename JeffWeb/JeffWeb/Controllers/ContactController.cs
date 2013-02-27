using System;
using System.Linq;
using System.Net.Mail;
using System.Web.Mvc;
using Jeff.Data;
using Jeff.Model.Domain;
using Jeff.Model.View;
using JeffWeb.Services;

namespace JeffWeb.Controllers
{
    public class ContactController : ConfigurableController
    {
        private readonly IEmailer _emailer;
        private readonly string _email;
        private const string SUCCESS_MESSAGE = "Email successful!  I look forward to hearing from you.";
        private const string FAILURE_MESSAGE = "An error has occurred.  Please try again later.";


        public ContactController(IDataRepository repository, IEmailer emailer)
            : base(repository)
        {
            _emailer = emailer;
            _email = PageConfigurations.Single().EmailAddress;
        }

        public override PageType Page()
        {
            return PageType.Contact;
        }

        public ActionResult Index()
        {
            return View(GetEmptyDisplayForm());
        }

        public ActionResult Send(ContactView form)
        {

            try
            {
                var message = string.Concat("Email From:", form.Name, "(", form.ContactInfo, ")", Environment.NewLine, form.Message);

                var mailMessage = new MailMessage("info@jeffreyawisniewski.com", _email, form.Subject, message);

                _emailer.Send(mailMessage);

                form = GetEmptyDisplayForm();
                form.SendStatusMessage = SUCCESS_MESSAGE;

            }
            catch
            {
                form = GetEmptyDisplayForm();
                form.SendStatusMessage = FAILURE_MESSAGE;

            }


            return View("Index", form);
        }

        public ContactView GetEmptyDisplayForm()
        {
            return new ContactView
            {
                DisplayEmail = _email
            };
        }
    }
}
