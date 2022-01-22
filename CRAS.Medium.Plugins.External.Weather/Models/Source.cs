using Newtonsoft.Json;

namespace CRAS.Medium.Plugins.External.Weather.Models
{
    public class Source
    {
        public string? DataType { get; set; }
        [JsonProperty(PropertyName = "Source")]
        public string? SourceData { get; set; }
        public int SourceId { get; set; }
        public string? PartnerSourceUrl { get; set; }
    }
}
