using System.Collections.Generic;
using Jeff.Model.Domain;

namespace JeffWeb.Services
{
    public interface IPhotoReader
    {
        List<Gallery> GetGalleries();
    }
}