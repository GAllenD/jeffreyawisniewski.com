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
                foreach (var pageConfiguration in pageConfigurations)
                {
                    var entry = _entities.PageConfigurations.FirstOrDefault(p => p.PageConfigurationIdentifier == pageConfiguration.PageConfigurationIdentifier);

                    if (entry == null)
                    {
                        _entities.PageConfigurations.Add(pageConfiguration);
                        continue;
                    }

                    entry.PageConfigurationIdentifier = pageConfiguration.PageConfigurationIdentifier;
                    entry.EmailAddress = pageConfiguration.EmailAddress;
                    entry.MediaName = pageConfiguration.MediaName;
                    entry.MediaUrl = pageConfiguration.MediaUrl;
                    entry.Page = pageConfiguration.Page;
                    entry.Text = pageConfiguration.Text;
                    entry.Title = pageConfiguration.Title;
                    entry.Credit = pageConfiguration.Credit;

                    // remove old entries
                    //var entriesToDelete = from e in _entities select e where e != null

                    //foreach (var deleteEntry in entriesToDelete)
                    //{
                    //    _entities.PageConfigurations.Remove(deleteEntry);
                    //}
                }

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