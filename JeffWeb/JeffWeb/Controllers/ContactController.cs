using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JeffWeb.Controllers
{
    public class ContactController : Controller
    {
        //
        // GET: /Contact/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Send()
        {
            return View("Index");
        }
    }
}
