using Autofac;
using Autofac.Integration.WebApi;
using RedArbor.Application.Services.Interfaces;
using RedArbor.Application.Services.Service;
using RedArbor.Infrastructure.Repository.Interfaces.Interfaces;
using RedArbor.Infrastructure.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;

namespace RedArbor.WebApi.App_Start
{
    public class IocApiConfig
    {

        public static void Configure()
        {
            var builder = new ContainerBuilder();
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterType<EmployeeService>().As<IEmployeeService>();
            builder.RegisterType<EmployeeRepository>().As<IEmployeeRepository>();
            var container = builder.Build();
            var resolver = new AutofacWebApiDependencyResolver(container);
            GlobalConfiguration.Configuration.DependencyResolver = resolver;
        }
    }
}