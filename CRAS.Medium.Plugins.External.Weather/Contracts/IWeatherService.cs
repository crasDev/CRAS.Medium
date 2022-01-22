using CRAS.Medium.Plugins.External.Weather.Models;

namespace CRAS.Medium.Plugins.External.Weather.Contracts
{
    public interface IWeatherService
    {
        Task<AccuWeatherLocationResponse> GetLocationByIpAsync(string myIp);
    }
}
