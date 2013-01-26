using System.Collections.Generic;

namespace Jeff.Model.View
{
    public class ItemListView
    {
        public ItemListView()
        {
            Items = new Dictionary<string, string>();
        }

        public Dictionary<string, string> Items { get; set; }  
    }
}
