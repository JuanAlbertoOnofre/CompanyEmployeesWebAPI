using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

///
///Program.cs is the entry point to our application 
///The CreateDefaultBuilder(args) method encapsulates the UseKestrel() or the UseIISIntegration(),
///all that stuff and makes this code more readable
///
///El método CreateDefaultBuilder(args) establece los archivos predeterminados y
///variables para el proyecto y la configuración del registrador. El hecho de que el registrador
///se configura antes en el proceso de arranque significa que podemos registrar problemas
///eso también sucede durante el arranque, que fue un poco más difícil en
///Versión anterior
///
///we can call webBuilder.UseStartup<Startup>() to
///initialize the Startup class too. The Startup class is mandatory(obligatorio) in
///ASP.NET Core Web API projects. In the Startup class, we configure the
///embedded or custom services that our application needs.
///
/// A service is a reusable part of the code that adds some functionality to our application.
///


namespace CompanyEmployeesWebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
