using System.Collections.Generic;

namespace Jeff.Model.View
{
    public class AdminForm
    {
        public AdminForm()
        {
            VoiceEntries = new Dictionary<string, string>();
        }

        public string EmailAddress { get; set; }
        public string BioText { get; set; }
        public Dictionary<string, string> VoiceEntries { get; set; }
    }
}
