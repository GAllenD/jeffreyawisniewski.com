using System.Collections.Generic;

namespace Jeff.Model.View
{
    public class ItemListForm
    {
        public ItemListForm()
        {
            Items = new Dictionary<string, string>();
        }

        public Dictionary<string, string> Items { get; set; }  
    }
}
