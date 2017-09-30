using Autofac;
using Autofac.Integration.WebApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using Utility.Logging.NLog.Autofac;
using WhereWeGoAPI.App_Start;

namespace WhereWeGoAPI
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);

            AutofacWebapiConfig.Initialize(GlobalConfiguration.Configuration);
        }
    }
}
