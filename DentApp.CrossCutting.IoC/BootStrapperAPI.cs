using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;

using SimpleInjector;
using DentApp.Security;
using SimpleInjector.Integration.AspNetCore;
using DentApp.Application.Interfaces;
using DentApp.Application;
using DentApp.Domain.Interfaces.Service;
using DentApp.Domain.Interfaces.Repository;
using DentApp.Infra.Data.Repository;
using DentApp.Infra.Data.Context;
using DentApp.Domain.Services;

namespace DentApp.CrossCutting.IoC
{
    public class BootStrapperAPI
    {
        public static void RegisterServices(IApplicationBuilder app, Container container)
        {
            // Lifestyle.Transient => Uma instancia para cada solicitacao;
            // Lifestyle.Singleton => Uma instancia unica para a classe
            // Lifestyle.Scoped => Uma instancia unica para o request            

            app.UseSimpleInjectorAspNetRequestScoping(container);
            container.Options.DefaultScopedLifestyle = new AspNetRequestLifestyle();

            container.RegisterMvcControllers(app);

            container.RegisterSingleton(app.ApplicationServices.GetService<ILoggerFactory>());

            container.Register<IHttpContextAccessor, HttpContextAccessor>(Lifestyle.Singleton);
            container.Register<IIdentityHelper, IdentityHelper>(Lifestyle.Singleton);
            
            container.Register<IEmployeeAppService, EmployeeAppService>(Lifestyle.Scoped);
            container.Register<IEmployeeService, EmployeeService>(Lifestyle.Scoped);
            container.Register<IEmployeeRepository, EmployeeRepository>(Lifestyle.Scoped);

            container.Register<MongoDBContextOptions>(Lifestyle.Scoped);
            container.RegisterInitializer<MongoDBContextOptions>(options =>
            {
                options.ConnectionString = "mongodb://localhost:27017";
                options.DataBaseName = "dentapp";
            });
            container.Register<MongoDBContext>(Lifestyle.Scoped);


            container.Register(typeof(IBaseRepository<>), typeof(BaseRepository<>));

            container.Verify();

        }
    }
}
