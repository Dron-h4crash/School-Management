namespace task2.BLL.Infrastructure
{
    using Ninject.Modules;
    using task2.DAL.Intefaces;
    using task2.DAL.Repositories;

    public class ServiceModule : NinjectModule
    {
        private string connectionString;

        public ServiceModule(string connection)
        {
            connectionString = connection;
        }

        public override void Load()
        {
            Bind<IUnitOfWork>().To<EFUnitOfWork>().WithConstructorArgument(connectionString);
        }
    }
}
