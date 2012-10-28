using System.Collections.Generic;
using System.Linq;
using Jeff.Model.Domain;

namespace Jeff.Data
{
    public class DataRepository
    {
        private DBEntities _entities;
        public DataRepository()
        {
            _entities = new DBEntities();
        }

        public List<PageConfiguration> GetPageConfigurations()
        {
            return _entities.PageConfigurations.ToList();
        }

        public List<PageConfiguration> GetPageConfigurations(PageType pageType)
        {
            var page = pageType.ToString();

            return _entities.PageConfigurations.Where(p => p.Page == page).ToList();
        }
    }
}