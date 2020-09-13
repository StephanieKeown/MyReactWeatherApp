using DTO;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace RestClient
{
    public class WeatherClient :  RestClient, IWeatherClient
    {
        public WeatherClient(IHttpClientFactory clientFactory) : base(clientFactory) //wth?
        {

        }

        public async Task<WeatherForecastDto> GetWeatherForecast(string url)
        {
            return await GetAsync<WeatherForecastDto>(url);
        }
}
}
