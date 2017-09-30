using Autofac;
using WhereWeGo.Models.Implements;
using WhereWeGo.Models.Interfaces;

namespace WhereWeGo.IoC
{
    public class AutofacRegister
    {
        public static void Register(ContainerBuilder builder)
        {
            builder.RegisterType<JourneyService>()
                .As<IJourneyService>()
                .InstancePerRequest();

            builder.RegisterType<IssueTicketService>()
                .As<IIssueTicketService>()
                .InstancePerRequest();

            builder.RegisterType<CheckOutService>()
                .As<ICheckOutService>()
                .InstancePerRequest();
        }
    }
}