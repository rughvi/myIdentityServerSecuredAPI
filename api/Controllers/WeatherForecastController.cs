using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.config;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace api.Controllers
{
    [ApiController]
    [Authorize]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IdentityServerConfiguration _options;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IOptions<IdentityServerConfiguration> options)
        {
            _logger = logger;
            _options = options.Value;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
