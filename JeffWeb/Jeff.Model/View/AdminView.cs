using System.Collections.Generic;

namespace Jeff.Model.View
{
    public class AdminView
    {
        public AdminView()
        {
            VoiceEntries = new List<AdminItem>();
            VideoEntries = new List<AdminItem>();
        }

        public string EmailAddress { get; set; }
        public string HomeHtml { get; set; }
        public string BioText { get; set; }
        //public Dictionary<string, string> VoiceEntries { get; set; }
        //public Dictionary<string, string> VideoEntries { get; set; }

        public List<AdminItem> VoiceEntries { get; set; }
        public List<AdminItem> VideoEntries { get; set; } 

        
    }

    public class AdminItem
    {
        public long PageConfigurationIdentifier { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
    }

}
