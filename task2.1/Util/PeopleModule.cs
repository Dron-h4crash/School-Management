using Ninject.Modules;
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