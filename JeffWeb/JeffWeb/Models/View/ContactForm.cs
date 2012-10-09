using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JeffWeb.Models.View
{
    public class ContactForm
    {
        public string Name { get; set; }
        public string ContactInfo { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
    }
}