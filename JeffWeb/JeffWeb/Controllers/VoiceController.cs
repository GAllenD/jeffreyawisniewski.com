using System.Web.Mvc;
using Jeff.Data;
using Jeff.Model.Domain;
using Jeff.Model.View;

namespace JeffWeb.Controllers
{
    public class VoiceController : ConfigurableController
    {
        public VoiceController(IDataRepository repository) : base(repository)
        {
        }

        public ActionResult Index()
        {
            var form = new ItemListView();

            foreach (var config in PageConfigurations)
            {
                form.Items.Add(config.MediaName,config.MediaUrl);
            }

            return View(form);
        }

        public override PageType Page()
        {
            return PageType.Voice;
        }
        
    }
}
