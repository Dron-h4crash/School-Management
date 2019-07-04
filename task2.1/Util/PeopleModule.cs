namespace task2.Util
{
    using Ninject.Modules;
    using task2.BLL.Interfaces;
    using task2.BLL.Services;

    public class PeopleModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IPeopleService>().To<PeopleService>();
        }
    }
}