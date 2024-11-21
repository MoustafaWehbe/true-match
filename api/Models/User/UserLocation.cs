using System.Text.Json.Serialization;

namespace api.Models
{
    public class UserLocation
    {
        [JsonPropertyName("longitude")]
        public decimal? Longitude { get; set; }

        [JsonPropertyName("latitude")]
        public decimal? Latitude { get; set; }

        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("placeFormatted")]
        public string? PlaceFormatted { get; set; }

        [JsonPropertyName("fullAddress")]
        public string? FullAddress { get; set; }
    }
}
