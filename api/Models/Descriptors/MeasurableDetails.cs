using System.Text.Json.Serialization;

namespace api.Models
{
    public class MeasurableDetails
    {
        [JsonPropertyName("min")]
        public int? Min { get; set; }
        [JsonPropertyName("max")]
        public int? Max { get; set; }
        [JsonPropertyName("unitOfMeasure")]
        public string? UnitOfMeasure { get; set; }
        [JsonPropertyName("defaultUnitOfMeasure")]
        public string? DefaultUnitOfMeasure { get; set; }
    }
}