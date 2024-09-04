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
        Room,
        Swipe
    }
    [JsonConverter(typeof(StringEnumConverter))]
    public enum Gender
    {
        Man,
        Woman
    }
    [JsonConverter(typeof(StringEnumConverter))]
    public enum AllRoomStatus
    {
        Coming,
        InProgress,
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum MyRoomStatus
    {
        Coming,
        Archived
    }
}
