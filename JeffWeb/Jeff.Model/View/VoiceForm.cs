using System.Collections.Generic;

namespace Jeff.Model.View
{
    public class VoiceForm
    {
        public VoiceForm()
        {
            Items = new Dictionary<string, string>();
        }

        public Dictionary<string, string> Items { get; set; }  
    }
}
