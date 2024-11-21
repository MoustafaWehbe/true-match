using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace api.Models
{
    public class AvailableDescriptor
    {
        [Key]
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("sectionName")]
        public string? SectionName { get; set; }

        [JsonPropertyName("displayType")]
        public string? DisplayType { get; set; }

        [JsonPropertyName("prompt")]
        public string? Prompt { get; set; }

        [JsonPropertyName("descriptors")]
        public JsonDocument? Descriptors { get; set; }
    }
}
