using System;
using System.Reflection;
using App.Configuration;
using App.Stocks.Models;
using AutoMapper;
using Castle.Facilities.AspNetCore;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Microsoft.Extensions.DependencyInjection;

namespace App.Web
{
    // TODO add description
    public partial class Startup
    {
        static readonly WindsorContainer Container = new WindsorContainer();

        // TODO add description
        void RegisterMapper(IServiceCollection services)
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
        }
        IServiceProvider GetServiceProvider(IServiceCollection services)
        {
            var container = Container;

            RegisterMapper(services);

            RegisterComponents(container);

            InitializeModules(container);

            var windsorServiceProvider = services.AddWindsor(container);

            return windsorServiceProvider;
        }

        void RegisterComponents(WindsorContainer container)
        {
            RegisterTransientServices(container);

            RegisterSingletoneServices(container);

            RegisterModules(container);
        }

        void RegisterTransientServices(WindsorContainer container)
        {
            container.Register(GetFromAssemblyDescriptor()
                .BasedOn<ITransientDependency>()
                .WithService.Self()
                .WithService.AllInterfaces()
                .LifestyleTransient());
        }

        void RegisterSingletoneServices(WindsorContainer container)
        {
            container.Register(GetFromAssemblyDescriptor()
                .BasedOn<ISingletoneDependency>()
                .WithService.Self()
                .WithService.AllInterfaces()
                .LifestyleSingleton());
        }

        void RegisterModules(WindsorContainer container)
        {
            container.Register(GetFromAssemblyDescriptor()
                .BasedOn<IModule>()
                .WithService.Self()
                .WithService.FromInterface(typeof(IModule))
                .LifestyleSingleton());
        }

        FromAssemblyDescriptor GetFromAssemblyDescriptor() => Classes.FromAssemblyInThisApplication(Assembly.GetEntryAssembly());

        // TODO add logging
        void InitializeModules(WindsorContainer container)
        {
            var modules = container.ResolveAll<IModule>();

            foreach(var module in modules)
            {
                module.Initialize(container);
            }
        }
    }
}
