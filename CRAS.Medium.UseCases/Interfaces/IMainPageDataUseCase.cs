using CRAS.Medium.Plugins.External.Weather.Models;

namespace CRAS.Medium.UseCases.PagesUseCases
{
    public interface IMainPageDataUseCase
    {
        Task<AccuWeatherLocationResponse> ExecuteAsync(string myIp);
    }
}