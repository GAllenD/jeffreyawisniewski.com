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
        private const string CACHE_NAME = "PageData";
        private IDataRepository _repository;
        protected List<PageConfiguration> PageConfigurations;

        protected ConfigurableController(IDataRepository repository)
        {
            _repository = repository;

            PageConfigurations = GetCurrentPageConfigurations().ToList();

        }

        public abstract PageType Page();

        protected void SaveConfigurations(IEnumerable<PageConfiguration> pageConfigurations)
        {
            _repository.Save(pageConfigurations);

            System.Web.HttpContext.Current.Cache.Remove(CACHE_NAME);
        }

        public List<PageConfiguration> GetCurrentPageConfigurations(bool allPages = false)
        {
            IEnumerable<PageConfiguration> pageData = null;

            if (System.Web.HttpContext.Current.Cache[CACHE_NAME] == null)
            {
                pageData = _repository.GetPageConfigurations();

                System.Web.HttpContext.Current.Cache.Insert(CACHE_NAME, pageData);    
            }
            else
            {
                pageData = (IEnumerable<PageConfiguration>)System.Web.HttpContext.Current.Cache[CACHE_NAME];
            }


            return allPages ? pageData.ToList() : pageData.ToList().Where(p => p.Page == Page().ToString()).ToList();
        }
        
    }

    
}
