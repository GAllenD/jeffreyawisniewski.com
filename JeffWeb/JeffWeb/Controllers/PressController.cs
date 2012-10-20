using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Jeff.Model.Domain;

namespace JeffWeb.Controllers
{
    public class PressController : ConfigurableController
    {
        //
        // GET: /Press/

        public ActionResult Index()
        {
            return View();
        }

        public override PageType Page()
        {
            return PageType.Press;
        }
    }
}
