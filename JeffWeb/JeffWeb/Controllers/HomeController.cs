using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Jeff.Model.Domain;
using Jeff.Model.View;

namespace JeffWeb.Controllers
{
    public class HomeController : ConfigurableController
    {
        public ActionResult Index()
        {
            var form = new HomeView();

            form.HomeHtml = _pageConfigurations.First().Text;

            return View(form);
        }

        public override PageType Page()
        {
            return PageType.Home;
        }
    }
}
