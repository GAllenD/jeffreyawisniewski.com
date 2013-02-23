using System.Collections.Generic;

namespace Jeff.Model.Domain
{
    public class Gallery
    {
        public Gallery()
        {
            FileNames = new List<string>();
        }

        public int Order { get; set; }
        public string Name { get; set; }
        public string FolderName { get; set; }

        public List<string> FileNames { get; set; }
    }
}
