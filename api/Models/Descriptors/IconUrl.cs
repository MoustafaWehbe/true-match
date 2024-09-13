using System.Text.Json.Serialization;

namespace api.Models
{
    public class IconUrl
    {
        [JsonPropertyName("url")]
        public string? Url { get; set; }
        [JsonPropertyName("quality")]
        public string? Quality { get; set; }
        [JsonPropertyName("width")]
        public int Width { get; set; }
        [JsonPropertyName("height")]
        public int Height { get; set; }
    }
}