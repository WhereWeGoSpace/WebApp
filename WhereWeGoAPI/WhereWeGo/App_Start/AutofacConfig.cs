using System.Reflection;
using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using Utility.Logging.NLog.Autofac;
using WhereWeGo.IoC;

namespace WhereWeGo.App_Start
{
    public class AutofacWebapiConfig
    {
        public static IContainer Container;

        public static void Initialize(HttpConfiguration config)
        {
            Initialize(config, RegisterServices(new ContainerBuilder()));
        }

        public static void Initialize(HttpConfiguration config, IContainer container)
        {
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }

        private static IContainer RegisterServices(ContainerBuilder builder)
        {
            //Register your Web API controllers.  
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            AutofacRegister.Register(builder);

            builder.RegisterModule(new NLogLoggerAutofacModule());

            //Set the dependency resolver to be Autofac.  
            Container = builder.Build();

            return Container;
        }

    }

}