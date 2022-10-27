using Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NLog.Fluent;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyEmployeesWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        //we have injected our repository inside the controller
        //for larger-scale applications, we would create an additional business layer between our
        //controllers and repository logic and our RepositoryManager service would
        //be injected inside that Business layer
        //public readonly IRepositoryManager _repository;

        //public WeatherForecastController(IRepositoryManager repository) 
        //{
        //    _repository = repository;
        //}

        //private static readonly string[] Summaries = new[]
        //{
        //    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        //};

        //private readonly ILogger<WeatherForecastController> _logger;

        //private ILoggerManager _logger;
        //public WeatherForecastController(ILoggerManager logger)
        //{
        //    _logger = logger;
        //}

        //[HttpGet]
        //public IEnumerable<WeatherForecast> Get()
        //{
        //    var rng = new Random();
        //    return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        //    {
        //        Date = DateTime.Now.AddDays(index),
        //        TemperatureC = rng.Next(-20, 55),
        //        Summary = Summaries[rng.Next(Summaries.Length)]
        //    })
        //    .ToArray();
        //}

        //[HttpGet]
        //public IEnumerable<string> Get() 
        //{
        //    _logger.LogInfo("Here is Info message");
        //    _logger.LogDebug("Here is Debug message");
        //    _logger.LogWarning("Here is Warning message");
        //    _logger.LogError("Here is Error message");

        //    return new string[] { "value 1", "value 2" };
        //}

        [HttpGet]
        public ActionResult<IEnumerable<string>> Get() 
        {
            return new string[] { "value1", "value2" };
        }
    }
}
