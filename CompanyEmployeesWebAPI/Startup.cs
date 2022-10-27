using CompanyEmployeesWebAPI.Extensions;
using Contracts;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Win32;
using NLog;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Runtime.ConstrainedExecution;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Collections.Specialized.BitVector32;
using static System.Net.Mime.MediaTypeNames;
using static System.Net.WebRequestMethods;


/// When we open the Startup class, we can find the constructor and the two
///methods which we’ll extend quite a few times(bastantes veces) during our application
///development
/// 
/// La aplicacion necesita servicios para funcionar, aqui 
/// we configure the embedded or custom services that our application needs.
/// 
/// ConfigureServices : Configura nuestros servicios
/// 
/// A service is a reusable part of the code that adds some functionality to our application.
/// 
/// In the Configure method, we are going to add different middleware(software intermedio)
/// components to the application’s request pipeline.
/// 
/// Since larger(entre mas grande) applications could potentially contain a lot of different services
/// Podemos terminar con mucho desorden y código ilegible en el Método ConfigureServices.
/// 
/// we can structure the code into logical blocks and separate those blocks into extension methods.
/// 
/// CORS (Cross-Origin Resource Sharing)(Intercambio de recursos de origen cruzado) 
/// is a mechanism(mecanismo) to give(dar) or restrict(restringir)
/// access rights(derechos de acceso) to applications from different domains.
/// 
namespace CompanyEmployeesWebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            //Configuring logger service for loggin messages
            //we are using NLog’s LogManager static class with the
            //LoadConfiguration method to provide a path to the configuration file.
            LogManager.LoadConfiguration(String.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));

            //The next thing we need to do is to add the logger service inside the .NET
            //Core’s IOC container.There are three ways to do that
            //By calling the services.AddSingleton method, we can create a
            //service the first time we request it and then every subsequent
            //request will call the same instance of the service.This means that all
            //components share the same service every time they need it and the
            //same instance will be used for every method call.
            //By calling the services.AddScoped method, we can create
            //a service once per request.That means whenever we send an HTTP
            //request to the application, a new instance of the service will be
            //created.
            //By calling the services.AddTransient method, we can create a
            //service each time the application requests it.This means that if
            //multiple components need the service, it will be created again for
            //every single component request.

            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //methods to support CORS and IIS integration 
            services.ConfigureCors();
            services.ConfigureIISIntegration();

            //servico de Logger NLog
            services.ConfigureLoggerService();

            //Every time we want to use a logger service, all we need to do is to inject
            //it into the constructor of the class that needs it

            //This type of injecting a class is called Dependency Injection

            //Context service to the IOC right above(arriba) the Controller
            services.ConfigureSqlContext(Configuration);

            services.ConfigureRepositoryManager();

            services.AddAutoMapper(typeof(Startup));

            //services.AddControllers();

            //Configure the controller to response in format XML

            services.AddControllers(config =>
            {
                config.RespectBrowserAcceptHeader = true;
                //restringir solo un formato
                //the server that if the client tries to negotiate for the media type the
                //server doesn’t support, it should return the 406 Not Acceptable status code
                config.ReturnHttpNotAcceptable = true;
            }).AddXmlDataContractSerializerFormatters()
            .AddCustomCSVFormatter();
           
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerManager logger)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            // add mandatory methods to our Configure method:
            else
            {
                app.UseHsts();
            }
            // 

            app.ConfigureExceptionHandler(logger);
            app.UseHttpsRedirection();


            // add mandatory methods to our Configure method:
            app.UseStaticFiles();
            app.UseCors("CorsPolicy");
            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.All
            });
            //


            //app.UseForwardedHeaders() will forward proxy headers to the
            //current request. This will help us during application deployment.
            // app.UseStaticFiles() enables using static files for the request. If
            //we don’t set a path to the static files directory, it will use a wwwroot
            //folder in our project by default.
            // app.UseHsts() will add middleware for using HSTS, which adds the
            //Strict - Transport - Security header.

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            //In the ConfigureServices method, instead(en cambio) of AddMvc() as used in 2.2
            // now we have AddControllers(). This method registers only the
            //controllers in IServiceCollection and not Views or Pages because they
            //are not required in the Web API project which we are building

            //In the Configure method, we have UseRouting() and
            //UseAuthorization() methods.They add routing and authorization
            //features to our application, respectively.

            //the UseEndpoints() method with the
            //MapControllers() method, which adds an endpoint for the controller’s
            //action to the routing without specifying any routes.

            //Microsoft advises(aconseja) that the order of adding different middlewares to the
            //application builder is very important. So the UseRouting() method
            //should be called before the UseAuthorization() method and
            //UseCors() or UseStaticFiles() have to be called before the
            //UseRouting() method.
        }
    }
}
