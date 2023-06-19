using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserTaskManagement.Common.Factories;
using UserTaskManagement.Common.Abstractions;
using UserTaskManagement.Common.Configuration;
using UserTaskManangement.DataAccess.Data;
using UserTaskManagement.Common.Repositories;

namespace UserTaskManangement.DataAccess
{
    public class DataAccessDependencyRegistrar : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<DbConnectionFactory>().As<IDbConnectionFactory>().InstancePerLifetimeScope();
            builder.RegisterType<AppSetting>().As<IAppSetting>().InstancePerLifetimeScope();
            builder.RegisterType<UserRepository>().As<IUserRepository>().InstancePerLifetimeScope();
            builder.RegisterType<UserTaskRepository>().As<IUserTaskRepository>().InstancePerLifetimeScope();
            base.Load(builder);
        }
    }
}
