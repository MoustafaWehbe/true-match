using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace api.Models
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum MediaType
    {
        Image = 0,
        Video = 1,
    }
    [JsonConverter(typeof(StringEnumConverter))]
    public enum MatchOrigin
    {
        LiveStream,
        Swipe
    }
    [JsonConverter(typeof(StringEnumConverter))]
    public enum Gender
    {
        Man,
        Woman
    }
}
