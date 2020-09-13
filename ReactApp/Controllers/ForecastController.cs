using AutoMapper;
using DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using ReactApp.Models;
using RestClient;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ReactApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ForecastController : Controller
    {
        private readonly IWeatherClient _weatherClient;
        private readonly IConfiguration _config;
        //private readonly IMapper _mapper;

        public ForecastController(IWeatherClient weatherClient, IConfiguration config)//, IMapper mapper)
        {
            _weatherClient = weatherClient;
            _config = config;
            //_mapper = mapper;
        }

        //public IActionResult Index()
        //{
        //    var weather = _weatherClient.GetWeatherForecast("https://metaweather.com/location/api/44544");
        //    return View();
        //}

        [HttpGet]
        public async Task<JsonResult> Get()
        {
            //var rng = new Random();
            //return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            //{
            //    Date = DateTime.Now.AddDays(index),
            //    TemperatureC = rng.Next(-20, 55),
            //    Summary = Summaries[rng.Next(Summaries.Length)]
            //})
            //.ToArray();
            var weather = await _weatherClient.GetWeatherForecast("https://metaweather.com/location/api/44544");

            // var result = _mapper.Map<WeatherForecastModel, WeatherForecastDto>(weather);
            //return weather; //why didnt this work, why again using the jon?
            return Json(weather);
        }
    }
}
