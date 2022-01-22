using CRAS.Medium;
using CRAS.Medium.Plugins.External.Weather.Contracts;
using CRAS.Medium.Plugins.External.Weather.Implementation;
using CRAS.Medium.Plugins.External.Weather.Models;
using CRAS.Medium.UseCases.PagesUseCases;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

await LoadAppSettingsAsync(builder);

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

// Register of Core Services
builder.Services.AddMudServices();
builder.Services.AddMudBlazorDialog();

// Register external services
builder.Services.AddScoped<IWeatherService, WeatherService>(x =>
{
    var httpClient = x.GetRequiredService<HttpClient>();

    var configurationOptions = builder.Configuration.GetRequiredSection("WeatherData").Get<AccuWeatherConfigurationOptions>();
    var test = builder.Configuration.GetSection("WeatherData");

    return new WeatherService(configurationOptions, httpClient);
});

// Register Use Case services
builder.Services.AddTransient<IMainPageDataUseCase, MainPageDataUseCase>();


await builder.Build().RunAsync();

/// <summary>
/// Load appsettings.json from the  wwwroot folder
/// </summary>
/// <param name="builder"></param>
/// <returns></returns>
static async Task LoadAppSettingsAsync(WebAssemblyHostBuilder builder)
{
    // read JSON file as a stream for configuration
    var client = new HttpClient() { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) };
    // the appsettings file must be in 'wwwroot'
    using var response = await client.GetAsync("appsettings.json");
    using var stream = await response.Content.ReadAsStreamAsync();
    builder.Configuration.AddJsonStream(stream);
}
