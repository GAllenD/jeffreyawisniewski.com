using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Jeff.Data;
using Jeff.Model.Domain;

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

        protected void Save(IEnumerable<PageConfiguration> pageConfigurations)
        {
            _repository.Save(pageConfigurations);
        }

        public IEnumerable<PageConfiguration> GetCurrentPageConfigurations(bool allPages = false)
        {
            IEnumerable<PageConfiguration> pageData = null;

            if (System.Web.HttpContext.Current.Cache["PageData"] == null)
            {
                pageData = _repository.GetPageConfigurations();

                System.Web.HttpContext.Current.Cache.Insert("PageData", pageData);    
            }
            else
            {
                pageData = (IEnumerable<PageConfiguration>)System.Web.HttpContext.Current.Cache["PageData"];
            }


            return allPages ? pageData.ToList() : pageData.ToList().Where(p => p.Page == Page().ToString());
        }
        
    }

    
}
