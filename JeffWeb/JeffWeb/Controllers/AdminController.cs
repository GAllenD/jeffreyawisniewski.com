using System.Web.Mvc;
using Jeff.Model.View;

namespace JeffWeb.Controllers
{
    public class AdminController : Controller
    {
        //
        // GET: /Admin/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Save(AdminForm form)
        {
            return null;
        }
    }
}
