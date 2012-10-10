using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using JeffWeb.Models.Services;
using JeffWeb.Models.View;

namespace JeffWeb.Controllers
{
    public class ContactController : Controller
    {
        private Emailer _emailer;
        private const string SUCCESS_MESSAGE = "Email successful!  I look forward to hearing from you.";
        private const string FAILURE_MESSAGE = "An error has occurred.  Please try again later.";

        public ContactController()
        {
            _emailer = new Emailer();
        }

        public ActionResult Index()
        {
            return View(new ContactForm());
        }

        public ActionResult Send(ContactForm form)
        {

            try
            {
                var message = string.Concat("Email From:", form.Name, "(", form.ContactInfo, ")", Environment.NewLine, form.Message);

                var mailMessage = new MailMessage("info@jeffreyawisniewski.com", "gregdzezinski@gmail.com", form.Subject, message);

                _emailer.Send(mailMessage);

                form = new ContactForm{SendStatusMessage = SUCCESS_MESSAGE};
            }
            catch (Exception e)
            {
                form = new ContactForm { SendStatusMessage = FAILURE_MESSAGE };
            }


            return View("Index", form);
        }
    }
}
