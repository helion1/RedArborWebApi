using Autofac;
using RedArbor.Application.Services.Interfaces;
using RedArbor.Application.Services.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace RedArbor.WebApi.Registers
{
    public static class ApiRegister
    {
        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<EmployeeService>().As<IEmployeeService>();

            //builder.RegisterAssemblyTypes(Assembly.Load(nameof(RedArbor.Application.Services.Interfaces)))
            //    .Where(x => x.Namespace.Contains("Interfaces"))
            //    .As(x => x.GetInterfaces().FirstOrDefault(i => i.Name == "I" + x.Name));

            return builder.Build();
        }
    }
}