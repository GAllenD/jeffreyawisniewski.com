using System.Collections.Generic;
using System.Linq;

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
    }
}