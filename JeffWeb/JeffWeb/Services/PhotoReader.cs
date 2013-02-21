using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using Jeff.Model.Domain;

namespace JeffWeb.Services
{
    public class PhotoReader
    {
        private static string GALLERY_FOLDER = "/Dev/Content/media/Photos";

        public List<Gallery> GetGalleries()
        {
            var galleries = new List<Gallery>();


            var dirInfo = new DirectoryInfo(HttpContext.Current.Server.MapPath(GALLERY_FOLDER));

            var directories = dirInfo.GetDirectories();

            foreach (var dir in directories)
            {
                var gallery = new Gallery
                {
                    Name = dir.Name
                };

                dir.GetFiles().ToList().ForEach(f => gallery.FileNames.Add(f.Name));

                galleries.Add(gallery);
            }

            return galleries;
        }
    }
}