using System.Collections.Generic;
using Jeff.Model.Domain;

namespace Jeff.Data
{
    public interface IDataRepository
    {
        void Save(IEnumerable<PageConfiguration> pageConfigurations);
        List<PageConfiguration> GetPageConfigurations();
        List<PageConfiguration> GetPageConfigurations(PageType pageType);
    }
}