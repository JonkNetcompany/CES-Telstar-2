using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using Autofac;
using CES_Telstar.Services;

namespace CES_Telstar
{
    public class WebApiApplication : HttpApplication
    {
        protected void Application_Start()
        {
            var container = RegisterServices();

            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }

        private ContainerBuilder RegisterServices()
        {
            var container = new ContainerBuilder();

            container.RegisterType<SecurityService>().As<ISecurityService>();

            return container;
        }
    }
}
