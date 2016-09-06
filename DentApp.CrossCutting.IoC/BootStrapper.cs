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
using MongoDB.Driver;

namespace DentApp.CrossCutting.IoC
{
    public class BootStrapper
    {
        public static void RegisterServices(IApplicationBuilder app, Container container)
        {
            // Lifestyle.Transient => Uma instancia para cada solicitacao;
            // Lifestyle.Singleton => Uma instancia unica para a classe
            // Lifestyle.Scoped => Uma instancia unica para o request            

            app.UseSimpleInjectorAspNetRequestScoping(container);
            container.Options.DefaultScopedLifestyle = new AspNetRequestLifestyle();
            
            container.RegisterMvcControllers(app);
            container.RegisterMvcViewComponents(app);

            container.RegisterSingleton(app.ApplicationServices.GetService<ILoggerFactory>());            
            //container.Register<ILoggerFactory, typeof (Logger<>)>(Lifestyle.Singleton);


            container.Register<IHttpContextAccessor, HttpContextAccessor>(Lifestyle.Singleton);
            container.Register<IIdentityHelper, IdentityHelper>(Lifestyle.Singleton);            

            container.Register<ILoginAppService, LoginAppService>(Lifestyle.Scoped);
            container.Register<ILoginService, LoginService>(Lifestyle.Scoped);
            container.Register<ILoginRepository, LoginRepository>(Lifestyle.Scoped);

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
            

            container.Register(typeof (IBaseRepository<>), typeof (BaseRepository<>));

            container.Verify();
            
        }
    }
}
