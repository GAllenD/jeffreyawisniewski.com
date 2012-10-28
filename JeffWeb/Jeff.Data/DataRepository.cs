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

        public void Save(IEnumerable<PageConfiguration> pageConfigurations)
        {
            using (_entities = new DBEntities())
            {
                _entities.SaveChanges();
            }
        }

        public List<PageConfiguration> GetPageConfigurations()
        {
            using (_entities = new DBEntities())
            {
                return _entities.PageConfigurations.ToList();
            }
        }

        public List<PageConfiguration> GetPageConfigurations(PageType pageType)
        {
            var page = pageType.ToString();

            using(_entities = new DBEntities())
            {
                return _entities.PageConfigurations.Where(p => p.Page == page).ToList();
            }
        }
    }
}