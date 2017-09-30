using Autofac;
using WhereWeGoAPI.Models.Implements;
using WhereWeGoAPI.Models.Interfaces;

namespace WhereWeGoAPI.IoC
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