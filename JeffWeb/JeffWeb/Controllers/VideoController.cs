using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Jeff.Data;
using Jeff.Model.Domain;
using Jeff.Model.View;

namespace JeffWeb.Controllers
{
    public class VideoController : ConfigurableController
    {
        public ActionResult Index()
        {
            var form = new ItemListForm();

            foreach (var config in _pageConfigurations)
            {
                form.Items.Add(config.MediaName, config.MediaUrl);
            }

            return View(form);
        }

        public override PageType Page()
        {
            return PageType.Video;
        }
    }
}
