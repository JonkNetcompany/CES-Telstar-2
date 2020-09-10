using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using CES_Telstar.Services;
using Persistence.Context;

namespace CES_Telstar
{
    public class WebApiApplication : HttpApplication
    {
        protected void Application_Start()
        {
            var container = RegisterServices();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);

            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }

        private IContainer RegisterServices()
        {
            var container = new ContainerBuilder();

            container.RegisterControllers(Assembly.GetExecutingAssembly());
            container.RegisterApiControllers(Assembly.GetExecutingAssembly());

            container.RegisterType<RouteContext>();

            container.RegisterType<BookingService>().As<IBookingService>();
            container.RegisterType<PackageService>().As<IPackageService>();
            container.RegisterType<RouteService>().As<IRouteService>();
            container.RegisterType<SecurityService>().As<ISecurityService>();

            return container.Build();
        }
    }
}
