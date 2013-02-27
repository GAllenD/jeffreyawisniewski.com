using System.Web.Mvc;
using Jeff.Data;
using Jeff.Model.Domain;

namespace JeffWeb.Controllers
{
    public class NewsController : ConfigurableController
    {
        public NewsController(IDataRepository repository) : base(repository)
        {
        }

        public ActionResult Index()
        {
            // Enable toggle of active or not

            return View();
        }

        public override PageType Page()
        {
            return PageType.News;
        }
    }
}
