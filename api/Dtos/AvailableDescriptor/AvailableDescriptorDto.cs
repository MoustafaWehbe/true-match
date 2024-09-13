using System.Text.Json;
using System.Text.Json.Serialization;
using api.Models;

namespace api.DTOs
{
    public class AvailableDescriptorDto
    {
        public int Id { get; set; }
        [JsonPropertyName("sectionName")]
        public string? SectionName { get; set; }
        [JsonPropertyName("displayType")]
        public string? DisplayType { get; set; }
        [JsonPropertyName("prompt")]
        public string? Prompt { get; set; }

        [JsonPropertyName("descriptors")]
        public List<Descriptor>? Descriptors { get; set; }
    }
}
