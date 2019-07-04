namespace task2
{
    using System.Web.Mvc;
    using System.Web.Optimization;
    using System.Web.Routing;
    using Ninject;
    using Ninject.Modules;
    using Ninject.Web.Common;
    using Ninject.Web.Mvc;
    using task2.BLL.Infrastructure;
    using task2.BLL.Interfaces;
    using task2.BLL.Services;
    using task2.Util;

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            // Внедрение зависимостей.
            NinjectModule serviceModule = new ServiceModule("DefaultConnection");
            var kernel = new StandardKernel(serviceModule);
            kernel.Bind<IPeopleService>().To<PeopleService>().InRequestScope();
            DependencyResolver.SetResolver(new NinjectDependencyResolver(kernel));
        }
    }
}
