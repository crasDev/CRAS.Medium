using CRAS.Medium.Plugins.External.Weather.Contracts;
using CRAS.Medium.Plugins.External.Weather.Models;

namespace CRAS.Medium.UseCases.PagesUseCases
{
    public class MainPageDataUseCase : IMainPageDataUseCase
    {
        private readonly IWeatherService weatherService;

        public MainPageDataUseCase(IWeatherService weatherService)
        {
            this.weatherService = weatherService;
        }


        public async Task<AccuWeatherLocationResponse> ExecuteAsync(string myIp)
        {
            // First we get the Location

            // Then we get the forecast

            // Then we get the user details if any

            // we return the full page object with data

            return await GetLocationAsync(myIp);
        }

        private async Task<AccuWeatherLocationResponse> GetLocationAsync(string myIp)
        {
            var location = await this.weatherService.GetLocationByIpAsync(myIp);

            return location;
        }
    }
}
