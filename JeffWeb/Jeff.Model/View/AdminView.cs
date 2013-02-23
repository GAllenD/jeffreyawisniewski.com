using System.Collections.Generic;

namespace Jeff.Model.View
{
    public class AdminView
    {
        public AdminView()
        {
            VoiceEntries = new Dictionary<string, string>();
            VideoEntries = new Dictionary<string, string>();
        }

        public string EmailAddress { get; set; }
        public string HomeHtml { get; set; }
        public string BioText { get; set; }
        public Dictionary<string, string> VoiceEntries { get; set; }
        public Dictionary<string, string> VideoEntries { get; set; }

        
    }

    public static class AdminItems 
    {


        public static Dictionary<string, string> GetItemEntries(AdminView view)
        {
            
                var entries = view.VoiceEntries;

                foreach (var videoEntry in view.VideoEntries)
                {
                    entries.Add(videoEntry.Key, videoEntry.Value);
                }

                return entries;
        } 
    }
}
