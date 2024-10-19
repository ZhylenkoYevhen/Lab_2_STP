using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MySwaggerApi.Controllers
{
    [ApiController]  // Вказує, що цей контролер обробляє запити на рівні API
    [Route("api/[controller]")]  // Визначає шлях до контролера в URL
    [Produces("application/json")]  // Вказує, що всі відповіді контролера будуть у форматі JSON
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        /// <summary>
        /// Gets a list of weather forecasts.
        /// </summary>
        /// <returns>A list of weather forecasts</returns>
        [HttpGet]  // Вказує, що цей метод обробляє HTTP GET запити
        [ProducesResponseType(typeof(IEnumerable<WeatherForecast>), 200)]  // Описує тип відповіді та HTTP статус код для успішного запиту
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }

    public class WeatherForecast
    {
        public DateOnly Date { get; set; }
        public int TemperatureC { get; set; }
        public string Summary { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
    }
}
