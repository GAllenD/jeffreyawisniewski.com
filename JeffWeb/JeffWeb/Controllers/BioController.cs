using System.Linq;
using System.Web.Mvc;
using Jeff.Data;
using Jeff.Model.Domain;
using Jeff.Model.View;

namespace JeffWeb.Controllers
{
    public class BioController : ConfigurableController
    {
        private PageConfiguration _pageConfiguration;

        public ActionResult Index()
        {
            _pageConfiguration = GetCurrentPageConfigurations().Single();

            var viewModel = new BioForm
            {
                BioText = _pageConfiguration.Text
            };

            return View(viewModel);
        }

        public override PageType Page()
        {
            return PageType.Bio;
        }

    }
}
