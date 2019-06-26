using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using task2.BLL.Interfaces;
using task2.BLL.Services;

namespace task2.Util
{
    public class PeopleModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IPeopleService>().To<PeopleService>();
        }
    }
}