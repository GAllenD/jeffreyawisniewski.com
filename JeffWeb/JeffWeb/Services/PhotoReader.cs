using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using Jeff.Model.Domain;

namespace JeffWeb.Services
{
    public class PhotoReader
    {
        private static string GALLERY_FOLDER = "~/Content/Media/Photos";

        public List<Gallery> GetGalleries()
        {
            var dirInfo = new DirectoryInfo(GALLERY_FOLDER);

            return null;
        }
    }
}