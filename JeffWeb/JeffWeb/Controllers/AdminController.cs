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
        private IList<PageConfiguration> _pageConfiguration;

        public override PageType Page()
        {
            return PageType.None;
        }

        public ActionResult Index(bool viewFromSave = false)
        {
            _pageConfiguration = GetCurrentPageConfigurations(true);

            var form = MapToForm();

            return View("Index",form);
        }

        [ValidateInput(false)]
        public ActionResult Save(AdminView form)
        {
            MapToPageConfiguration(form);

            SaveConfigurations(_pageConfiguration);

            return Index(true);
        }

        private AdminView MapToForm()
        {
            return new AdminView
            {
                EmailAddress = _pageConfiguration.First(p => p.Page == PageType.Contact.ToString()).EmailAddress,
                HomeHtml = _pageConfiguration.First(p => p.Page == PageType.Home.ToString()).Text,
                BioText = _pageConfiguration.First(p => p.Page == PageType.Bio.ToString()).Text,
                VoiceEntries = _pageConfiguration.Where(p => p.Page == PageType.Voice.ToString()).ToDictionary(p => p.MediaName, p => p.MediaUrl),
                VideoEntries = _pageConfiguration.Where(p => p.Page == PageType.Video.ToString()).ToDictionary(p => p.MediaName, p => p.MediaUrl)
            };
        }

        private void MapToPageConfiguration(AdminView form)
        {
            _pageConfiguration = GetCurrentPageConfigurations(true);

            _pageConfiguration.First(p => p.Page == PageType.Contact.ToString()).EmailAddress = form.EmailAddress;
            _pageConfiguration.First(p => p.Page == PageType.Bio.ToString()).Text = form.BioText;
            _pageConfiguration.First(p => p.Page == PageType.Home.ToString()).Text = form.HomeHtml;

            foreach (var entry in form.ItemEntries)
            {
                var value = _pageConfiguration.FirstOrDefault(p => p.Page == PageType.Voice.ToString() && p.MediaName == entry.Key);
                
                if(value == null)
                {
                    var configuration = new PageConfiguration
                    {
                        Page = PageType.Voice.ToString(),
                        MediaName = entry.Key,
                        MediaUrl = entry.Value
                    };

                    _pageConfiguration.Add(configuration);
                    
                    continue;
                }

                value.MediaName = entry.Key;
                value.MediaUrl = entry.Value;

                foreach (var pageConfiguration in _pageConfiguration.Where(p => p.Page == PageType.Voice.ToString() && form.VoiceEntries.All(v => v.Key != p.MediaName)))
                {
                    _pageConfiguration.Remove(pageConfiguration);
                }
            }

        }
    }
}
