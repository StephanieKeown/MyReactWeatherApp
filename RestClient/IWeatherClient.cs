using DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RestClient
{
    public interface IWeatherClient
    {
        Task<WeatherForecastDto> GetWeatherForecast(string url); 
    }
}
