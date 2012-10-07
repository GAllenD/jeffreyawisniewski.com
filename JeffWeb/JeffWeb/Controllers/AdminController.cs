using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JeffWeb.Models.View;

namespace JeffWeb.Controllers
{
    public class AdminController : Controller
    {
        //
        // GET: /Admin/

        public ActionResult Index()
        {
            BioForm form;

            if(Session["bioForm"] == null)
            {
                form = new BioForm{BioText = "This is my bio.</br>What do you think?"};
            }
            else
            {
                form = Session["bioForm"] as BioForm;
            }

            return View(form);
        }

        [ValidateInput(false)]
        public ActionResult Save(BioForm form)
        {
            Session["bioForm"] = form;

            return View("index", form);
        }

    }
}
