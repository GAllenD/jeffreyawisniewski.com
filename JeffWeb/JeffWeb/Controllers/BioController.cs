using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Jeff.Model.View;

namespace JeffWeb.Controllers
{
    public class BioController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            BioForm form;

            if (Session["bioForm"] == null)
            {
                form = new BioForm();
            }
            else
            {
                form = Session["bioForm"] as BioForm;
            }

            return View(form);
        }

    }
}
