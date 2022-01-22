using CRAS.Medium.Plugins.External.Weather.Contracts;
using CRAS.Medium.Plugins.External.Weather.Exceptions;
using CRAS.Medium.Plugins.External.Weather.Models;
using Newtonsoft.Json;

namespace CRAS.Medium.Plugins.External.Weather.Implementation
{
    public  class WeatherService : IWeatherService
    {
        private readonly AccuWeatherConfigurationOptions options;
        private HttpClient httpClient;

        public WeatherService(AccuWeatherConfigurationOptions options, HttpClient httpClient)
        {
            this.options = options ?? throw new ArgumentNullException(nameof(options));
            this.httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        public async Task<AccuWeatherLocationResponse> GetLocationByIpAsync(string myIp)
        {
            try
            {
               
                if (string.IsNullOrWhiteSpace(options.LocationUrl))
                {
                    throw new WeatherServiceException($"The property {nameof(options.LocationUrl)} cannot be null or empty for this request.");
                }

                httpClient.BaseAddress = new Uri($"{options.LocationUrl}?apikey={options.ApiKey}&q={myIp}&language=pt-PT&details=true");

                var request = new HttpRequestMessage(HttpMethod.Get, $"{options.LocationUrl}?apikey={options.ApiKey}&q={myIp}&language=pt-PT&details=true");

                var response = await httpClient.SendAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    var resultString = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<AccuWeatherLocationResponse>(resultString);
                }
                else
                {
                    throw new WeatherServiceException($"Http Request to {options.LocationUrl} failed with the following information : STATUS = {response.StatusCode}, MESSAGE = {response.ReasonPhrase}");
                }
            }
            catch (WeatherServiceException ex)
            {
                // log and record on database in he future before passing on, and prepare a default answer 
                throw ex;
            }
        }
    }
}
