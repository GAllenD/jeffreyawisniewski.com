using System.Linq;
using System.Web.Mvc;
using Jeff.Data;
using Jeff.Model.Domain;
using Jeff.Model.View;

namespace JeffWeb.Controllers
{
    public class BioController : ConfigurableController
    {
        public BioController(IDataRepository repository) : base(repository)
        {
        }

        public ActionResult Index()
        {
            var viewModel = new BioView
            {
                BioText = PageConfigurations.Single().Text
            };

            return View(viewModel);
        }

        public override PageType Page()
        {
            return PageType.Bio;
        }

    }
}
