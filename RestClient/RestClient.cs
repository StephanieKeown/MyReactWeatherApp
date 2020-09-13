using DTO;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Http.Json;
using Newtonsoft.Json;

namespace RestClient
{
    public abstract class RestClient //why isthis abstract? becasue its inherited from but not all necessarily implemented?
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly HttpClient client;

        protected RestClient(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        //WeatherForecastDto forecast;
        string forecast;
        String errorString;

        protected async Task<T> GetAsync<T>(string url) //this should be a generic task<t>
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "https://www.metaweather.com/api/location/44544");

            var client = _clientFactory.CreateClient();         

            HttpResponseMessage response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                //forecast = await response.Content.ReadFromJsonAsync<WeatherForecastDto>();
                forecast = await response.Content.ReadAsStringAsync();
            }
            else
            {
                errorString = "Error encountered while retreiving weather data" + " " + response.ReasonPhrase;
            }
            return JsonConvert.DeserializeObject<T>(forecast); //returnng the dto as t did not work, neither as string, why do i have to do this conversio here? is it to serialise to whatever the caller expects?
        }
    }
}
