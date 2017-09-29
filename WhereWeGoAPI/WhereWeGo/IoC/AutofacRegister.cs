using Autofac;
using WhereWeGo.Models;

namespace WhereWeGo.IoC
{
    public class AutofacRegister
    {
        public static void Register(ContainerBuilder builder)
        {
            builder.RegisterType<TestService>()
                   .As<ITestService>()
                   .InstancePerRequest();
        }
    }
}