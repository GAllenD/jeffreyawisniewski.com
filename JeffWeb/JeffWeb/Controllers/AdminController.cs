using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Jeff.Data;
using Jeff.Model.Domain;
using Jeff.Model.View;

namespace JeffWeb.Controllers
{
    public class AdminController : ConfigurableController
    {
        private IEnumerable<PageConfiguration> _pageConfiguration;

        public override PageType Page()
        {
            return PageType.None;
        }

        public ActionResult Index()
        {
            _pageConfiguration = GetCurrentPageConfigurations(true);

            var form = MapToForm();

            return View(form);
        }

        public ActionResult Save(AdminForm form)
        {
            return null;
        }

        private AdminForm MapToForm()
        {
            return new AdminForm
            {
                EmailAddress = _pageConfiguration.FirstOrDefault(p => p.Page == PageType.Contact.ToString()).EmailAddress,
                BioText = _pageConfiguration.FirstOrDefault(p => p.Page == PageType.Bio.ToString()).Text,
                VoiceEntries = _pageConfiguration.Where(p => p.Page == PageType.Voice.ToString()).ToDictionary(p => p.MediaName, p => p.MediaUrl)
            };
        }

        private void MapToPageConfiguration(AdminForm form)
        {
            
        }
    }
}
