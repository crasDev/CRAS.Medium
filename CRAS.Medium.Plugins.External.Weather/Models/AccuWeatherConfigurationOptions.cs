namespace CRAS.Medium.Plugins.External.Weather.Models
{
    public class AccuWeatherConfigurationOptions
    {
        /// <summary>
        /// The Api Key for accessing AccuWeather
        /// </summary>
        public string? ApiKey { get; set; }

        /// <summary>
        /// The url to request data relative to the Location
        /// </summary>
        public string? LocationUrl { get; set; }

        /// <summary>
        /// The url to request data relative to the Forecast
        /// </summary>
        public string? ForecastUrl { get; set; }
    }
}
