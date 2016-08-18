using Microsoft.AspNetCore.Builder;
using SimpleInjector;
using SimpleInjector.Integration.AspNetCore;

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

            container.Verify();

            // App
            //container.RegisterPerWebRequest<IClienteAppService, ClienteAppService>();

            // Domain
            //container.RegisterPerWebRequest<IClienteService, ClienteService>();

            // Infra Dados
            //container.RegisterPerWebRequest<IClienteRepository, ClienteRepository>();
            //container.RegisterPerWebRequest<IEnderecoRepository, EnderecoRepository>();
            //container.RegisterPerWebRequest<IUnitOfWork, UnitOfWork>();
            //container.RegisterPerWebRequest<CrudModalDDDContext>();

            //container.Register(typeof (IRepository<>), typeof (Repository<>));
        }
    }
}
