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

            container.Register<ILoginAppService, LoginAppService>(Lifestyle.Singleton);
            container.Register<ILoginService, LoginService>(Lifestyle.Singleton);
            container.Register<ILoginRepository, LoginRepository>(Lifestyle.Singleton);

            container.Register<MongoDBContext>(Lifestyle.Singleton);

            container.Register(typeof (IBaseRepository<>), typeof (BaseRepository<>));

            container.Verify();
            
        }
    }
}
