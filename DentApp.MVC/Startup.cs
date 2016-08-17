﻿using System;
using System.Diagnostics;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;

using DentApp.Security;

namespace DentApp.MVC
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();

            if (env.IsDevelopment())
            {
                // This will push telemetry data through Application Insights pipeline faster, allowing you to view results immediately.
                builder.AddApplicationInsightsSettings(developerMode: true);
            }
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddApplicationInsightsTelemetry(Configuration);

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton<IIdentityHelper, IdentityHelper>();

            services.AddDistributedMemoryCache();

            double timeOut = double.MinValue;
            double.TryParse(Configuration["Session:TimeOut"], out timeOut);                

            services.AddSession(options =>
            {
                options.CookieName = Configuration["Session:CookieName"];
                options.IdleTimeout = TimeSpan.FromMinutes(timeOut);
            });

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory
                .WithFilter(new FilterLoggerSettings
                    {
                        { "Microsoft", LogLevel.Warning },
                        { "System", LogLevel.Warning },
                        { "DentApp", LogLevel.Debug }
                    })
                .AddConsole();

            // add Trace Source logging
            var testSwitch = new SourceSwitch("sourceSwitch", "Logging");
            testSwitch.Level = SourceLevels.Error;
            loggerFactory.AddTraceSource(testSwitch, new TextWriterTraceListener(writer: Console.Out));
            
            loggerFactory.AddDebug();

            app.UseSession();
            app.Use(async (context, next) =>
            {
                if (context.Session.GetString("__id__") == null)
                {
                    context.Session.SetString("__id__", "1221");
                }

                await next.Invoke();
            });
            app.UseApplicationInsightsRequestTelemetry();

            app.UseCookieAuthentication(new CookieAuthenticationOptions()
            {
                AuthenticationScheme = "DentAppCookieMiddlewareInstance",
                LoginPath = new PathString("/Account/Login"),
                AccessDeniedPath = new PathString("/Account/Forbidden"),
                AutomaticAuthenticate = true,
                AutomaticChallenge = true/*,
                Events = new CookieAuthenticationEvents
                {
                    // Set other options
                    OnRedirectToAccessDenied = OnAccessDenied.RedirectOnAccessDenied
                }*/
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseApplicationInsightsExceptionTelemetry();

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Account}/{action=Login}/{id?}");
            });
        }
    }
}
