using Autofac;
using Autofac.Integration.Mvc;
using System.Web.Mvc;
using WebApplication1.Controllers;
using WebApplication1.Services;
using WebApplication1.Services.Abstractions;

namespace WebApplication1.Util
{
    public class AutofacConfig
    {
        public static void ConfigureContainer()
        {
            var builder = new ContainerBuilder();

            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            builder.RegisterType<HomeController>().InstancePerRequest();
            builder.RegisterType<ImdbService>()
                   .As<IImdbService>()
                   .InstancePerRequest();

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}