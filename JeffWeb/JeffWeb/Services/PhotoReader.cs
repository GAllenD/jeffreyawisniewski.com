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
        #if DEBUG
        private static string GALLERY_FOLDER = "/Content/media/Photos";
#else
        private static string GALLERY_FOLDER = "/Dev/Content/media/Photos";
        #endif



        public List<Gallery> GetGalleries()
        {
            var galleries = new List<Gallery>();


            var dirInfo = new DirectoryInfo(HttpContext.Current.Server.MapPath(GALLERY_FOLDER));

            var directories = dirInfo.GetDirectories();

            foreach (var dir in directories)
            {
                var nameParts = dir.Name.Split('_');
                var gallery = new Gallery
                {
                    Order = int.Parse(nameParts[0]),
                    Name = nameParts[1],
                    FolderName = dir.Name
                };

                dir.GetFiles().ToList().ForEach(f => gallery.FileNames.Add(f.Name));

                galleries.Add(gallery);
            }

            return galleries;
        }
    }
}