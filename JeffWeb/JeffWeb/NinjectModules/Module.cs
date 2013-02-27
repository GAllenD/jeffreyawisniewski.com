using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Jeff.Data;
using JeffWeb.Services;
using Ninject.Modules;

namespace JeffWeb.NinjectModules
{
    public class Module : NinjectModule
    {
        public override void Load()
        {
            Bind<IDataRepository>().To<DataRepository>();
            Bind<IPhotoReader>().To<PhotoReader>();
            Bind<IEmailer>().To<Emailer>();
        }
    }
}