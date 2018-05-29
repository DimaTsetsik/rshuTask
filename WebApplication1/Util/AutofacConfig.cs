using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
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

            builder.RegisterType<SmtpMailClient>()
                   .As<IMailClient>()
                   .InstancePerRequest();

            builder.RegisterType<MailService>()
                   .As<IMailService>()
                   .InstancePerRequest();

            builder.RegisterType<WebClientHelper>()
                   .As<IWebClientHelper>()
                   .InstancePerRequest();

            builder.RegisterType<MoviedbService>()
                   .As<IMoviedbService>()
                   .InstancePerRequest();

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}