using System.Text.Json.Serialization;

namespace api.Models
{
    public class Choice
    {
        [JsonPropertyName("id")]
        public string? Id { get; set; }

        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("style")]
        public string? Style { get; set; }

        [JsonPropertyName("emoji")]
        public string? Emoji { get; set; }

        [JsonPropertyName("iconUrls")]
        public List<IconUrl>? IconUrls { get; set; }

        [JsonPropertyName("matchGroupKey")]
        public string? MatchGroupKey { get; set; }
    }
}
