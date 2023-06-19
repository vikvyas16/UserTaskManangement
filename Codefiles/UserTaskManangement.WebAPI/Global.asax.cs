using Autofac;
using Autofac.Integration.WebApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using UserTaskManagement.Common;
using UserTaskManagement.Common.Models;
using UserTaskManagement.Services;
using UserTaskManangement.DataAccess;
using UserTaskManangement.WebAPI.Controllers;

namespace UserTaskManangement.WebAPI
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var builder = new ContainerBuilder();
            var config = GlobalConfiguration.Configuration;

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterType<UserController>().InstancePerRequest();
            builder.RegisterType<User>();

            builder.RegisterModule(new ServiceDependencyRegistrar());
            builder.RegisterModule(new DataAccessDependencyRegistrar());
            builder.RegisterModule(new AutoMapperDependencyRegistrar());

            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}
