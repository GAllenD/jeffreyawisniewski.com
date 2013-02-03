using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Jeff.Model.Domain
{
    public class PageData
    {
        public PageType PageType { get; set; }
        public string Text { get; set; }
        public string EmailAddress { get; set; }
        public string MediaName { get; set; }
        public string MediaUrl { get; set; }
    }

    public enum PageType
    {
        None,
        News,
        Home,
        Bio,
        Video,
        Galley,
        Voice,
        Press,
        Contact
    }
}
