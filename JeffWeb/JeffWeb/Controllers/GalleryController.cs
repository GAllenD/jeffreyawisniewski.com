using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Jeff.Data;
using Jeff.Model.Domain;

namespace JeffWeb.Controllers
{
    public class GalleryController : ConfigurableController
    {
        private List<PageConfiguration> _pageConfigurations;

        public override PageType Page()
        {
            return PageType.Galley;
        }

        public ActionResult Index()
        {
            return View();
        }
    }
}
