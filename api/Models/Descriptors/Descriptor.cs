using System.Text.Json.Serialization;

namespace api.Models
{
    public class Descriptor
    {
        [JsonPropertyName("id")]
        public string? Id { get; set; }
        [JsonPropertyName("prompt")]
        public string? Prompt { get; set; }
        [JsonPropertyName("subPrompt")]
        public string? SubPrompt { get; set; }
        [JsonPropertyName("type")]
        public string? Type { get; set; }
        [JsonPropertyName("iconUrl")]
        public string? IconUrl { get; set; }
        [JsonPropertyName("iconUrls")]
        public List<IconUrl>? IconUrls { get; set; }
        [JsonPropertyName("backgroundText")]
        public string? BackgroundText { get; set; }
        [JsonPropertyName("searchBackgroundText")]
        public string? SearchBackgroundText { get; set; }
        [JsonPropertyName("measurableDetails")]
        public MeasurableDetails? MeasurableDetails { get; set; }
        [JsonPropertyName("sectionId")]
        public int? SectionId { get; set; }
        [JsonPropertyName("sectionName")]
        public string? SectionName { get; set; }
        [JsonPropertyName("matchGroupKey")]
        public string? MatchGroupKey { get; set; }
        [JsonPropertyName("discoveryPreferencesEnabled")]
        public bool DiscoveryPreferencesEnabled { get; set; }
        [JsonPropertyName("minSelections")]
        public int? MinSelections { get; set; }
        [JsonPropertyName("maxSelections")]
        public int? MaxSelections { get; set; }
        [JsonPropertyName("shouldLocalizeChoices")]
        public bool ShouldLocalizeChoices { get; set; }
        [JsonPropertyName("choices")]
        public List<Choice>? Choices { get; set; }
    }
}