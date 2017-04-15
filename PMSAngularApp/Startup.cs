using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.Webpack;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using EntityFrameworkPMS;
using Microsoft.EntityFrameworkCore;
using InterfaceDAL;
using InterfacesPMS;
using ORMEntitiesPMS;
using BusinessLogic.PMS;

namespace PMSAngularApp
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
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        public class AppSettings
        {
            public string ConnectionString { get; set; }
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddMvc();
            // Add EF services to the services container
            var connection = Configuration["DBConnection:ConnectionString"];
            services.AddDbContext<EUow>(x => x.UseSqlServer(connection));
            //Here we neeed to add any dependency to the concrete classes as no Unity or any other DI framework available for .net core class library

            services.AddTransient<IProject, ProjectBase>();
            services.AddTransient<IRepository<ProjectBase>,EFDataAccessLayer<ProjectBase>>();
            services.AddTransient<IRepository<PersonBase>, EFDataAccessLayer<PersonBase>>();

            services.AddTransient<ProjectBusinessLogicAbstract, ProjectBusinessLogic>();
            services.AddTransient<PersonBusinessLogicAbstract, PersonBusinessLogic>();
            services.AddTransient<IUow, EUow>().BuildServiceProvider();
            // services.AddScoped<InterfaceDAL,>
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseWebpackDevMiddleware(new WebpackDevMiddlewareOptions {
                    HotModuleReplacement = true
                });
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Project}/{action=ProjectList}/{id?}");

                routes.MapSpaFallbackRoute(
                    name: "spa-fallback",
                    defaults: new { controller = "Project", action = "ProjectList" });
            });
        }
    }
}
