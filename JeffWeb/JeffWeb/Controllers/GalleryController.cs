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
        private readonly IPhotoReader _photoReader;

        public GalleryController(IDataRepository repository, IPhotoReader reader)
            : base(repository)
        {
            _photoReader = reader;
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
