using System.Text.Json.Serialization;

namespace api.Models
{
    public class AvailableDescriptorRoot
    {
        [JsonPropertyName("availableDescriptors")]
        public List<AvailableDescriptor>? AvailableDescriptors { get; set; }
    }
}
