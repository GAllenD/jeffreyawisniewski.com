using System.Linq;
using System.Web.Mvc;
using Jeff.Data;
using Jeff.Model.Domain;
using Jeff.Model.View;

namespace JeffWeb.Controllers
{
    public class BioController : ConfigurableController
    {
        public ActionResult Index()
        {
            var viewModel = new BioView
            {
                BioText = _pageConfigurations.Single().Text
            };

            return View(viewModel);
        }

        public override PageType Page()
        {
            return PageType.Bio;
        }

    }
}
