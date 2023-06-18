using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using UserTaskManagement.Services.Data;
using UserTaskManagement.Services.Repositories;

namespace UserTaskManagement.Services
{
    public class ServiceDependencyRegistrar : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UserService>().As<IUserService>().InstancePerLifetimeScope();
            //builder.RegisterType<ProductAttributeLookUpService>().As<IProductAttributeLookUpService>().InstancePerLifetimeScope();
            //builder.RegisterType<ProductAttributeService>().As<IProductAttributeService>().InstancePerLifetimeScope();
            base.Load(builder);
        }
    }
}
