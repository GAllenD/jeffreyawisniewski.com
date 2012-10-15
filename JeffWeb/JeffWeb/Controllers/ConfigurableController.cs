using System.Web.Mvc;
using Jeff.Data;
using Jeff.Model.Domain;
using JeffWeb.Models.Services;

namespace JeffWeb.Controllers
{
    public abstract class ConfigurableController : Controller
    {
        private DataRepository _repository;

        protected ConfigurableController()
        {
            _repository = new DataRepository();
        }

        public abstract PageType Page();
    }

    
}
