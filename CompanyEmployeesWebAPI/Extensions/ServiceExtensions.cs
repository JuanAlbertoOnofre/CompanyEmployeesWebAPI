using Contracts;
using Entities;
using LoggerService;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

///
///An extension method is inherently a static method. What makes it
///different from other static methods is that it accepts this as the first
///parameter, and this represents the data type of the object which(cual) will be
///using that extension method
///An extension method must be defined inside a static class. This kind of
///method extends the behavior(comportamiento) of a type in .NET. Once we define an
///extension method, it can be chained(encadenado) multiple times on the same type of
///object
namespace CompanyEmployeesWebAPI.Extensions
{
    public static class ServiceExtensions
    {
        //If we want to send requests from a different domain to our application,
        //configuring CORS is mandatory.So, to start off, we’ll add a code that
        //allows all requests from all origins to be sent to our API:

        //we should be more restrictive with those settings in the production environment.More
        //precisely, as restrictive as possible.

        //Instead(en cambio) of the AllowAnyOrigin() method which(el cual) allows requests(peticiones) from any
        //source(fuente), we can use the WithOrigins("https://example.com") which will
        //allow requests only from that concrete source.Also, instead of
        //AllowAnyMethod() that allows all HTTP methods, we can use
        //WithMethods("POST", "GET") that will allow only specific HTTP methods.
        //Furthermore(es mas), you can make the same changes for the AllowAnyHeader()
        //method by using, for example, the WithHeaders("accept", "contenttype") method to allow only specific headers.

        public static void ConfigureCors(this IServiceCollection services) =>
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder =>
                builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());
            });

        //ASP.NET Core applications are by default self-hosted, and if we want to
        //host our application on IIS, we need to configure an IIS integration which
        //will eventually help us with the deployment to IIS.

        //Configuracion del IIS

        //We do not initialize any of the properties inside the options because we
        //are fine with the default values for now.But if you need to fine-tune the
        //configuration right away, you might want to take a look at the possible
        //options:
        //
        //AutomaticAuthentication | true
        //if true, the authentication middleware sets the httpContext.User an responds to generic
        //challenges(retos), si false, the authentication middleware only provides an identity(HttpContext.User)
        //and responds to challenges when explicity requestes by the
        //AuthenticationSchema, Windows Authentication must be enable in IIS for AutomaticAuthentication to fuction
        //
        //AuthenticationDisplayName || null
        //Sets ths disply name shown(mostrado) to user on login pages
        //
        //ForwardClientCertificate || true
        //if true and the MS-ASPNETCORE-CLIENT request(peticion) header is present the
        //HttpContext.Connection.ClientCertificate is populated(poblado)
        //
        public static void ConfigureIISIntegration(this IServiceCollection services) =>
            services.Configure<IISOptions>(options => { });

        public static void ConfigureLoggerService(this IServiceCollection services) =>
            services.AddScoped<ILoggerManager, LoggerManager>();


        //public static void ConfigureSqlContext(this IServiceCollection services,
        //    IConfiguration configuration) =>
        //    services.AddDbContext<RepositoryContext>(opts =>
        //    opts.UseSqlServer());

        //to be able to use the UseSqlServer method, we need to install the Microsoft.EntityFrameworkCore.SqlServer
        public static void ConfigureSqlContext(this IServiceCollection services,
            IConfiguration configuration) =>
            services.AddDbContext<RepositoryContext>(opts =>
            opts.UseSqlServer(configuration.GetConnectionString("sqlConnection"), b=>
            b.MigrationsAssembly("CompanyEmployeesWebAPI")));

        //we have to install an additional ef core library: Microsoft.EntityFrameworkCore.Tools
        //to migrate the model to a real database
        //Usamos MigrationAsembly porque el modelo no lo tenemso en el proyecto principal
        //Tenemos que hacer este cambio porque el ensamblado de migración no está en nuestro
        //proyecto principal, sino en el proyecto Entidades.Entonces, solo cambiamos el proyecto.
        //para el montaje de migración
        //Add-Migration DatabaseCreation
        //Para cargarlo a la DB
        //Update-Database
        //public static void ConfigureRepositoryManager(this IServiceCollection services)=>
        //    services.AddScoped<IRepositoryManager, IRepositoryManager>();
    }
}
