using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Jeff.Data;
using Jeff.Model.Domain;
using JeffWeb.Services;

namespace JeffWeb.Controllers
{
    public class GalleryController : ConfigurableController
    {
        private List<PageConfiguration> _pageConfigurations;
        private PhotoReader _photoReader;

        public GalleryController()
        {
            _photoReader = new PhotoReader();
        }

        public override PageType Page()
        {
            return PageType.Galley;
        }

        public ActionResult Index()
        {
            return View(_photoReader.GetGalleries().OrderBy(g => g.Order).ToList());
        }
    }
}
