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
        Swipe,
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum AllRoomStatus
    {
        Coming,
        InProgress,
        InterestedIn,
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum MyRoomStatus
    {
        Coming,
        Archived,
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum DescriptorSelectionType
    {
        SingleSelection,
        MultiSelection,
        Measurement,
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum MessageStatus
    {
        Sent,
        Delivered,
        Read,
    }

    public enum RoomsSortBy
    {
        RecentlyCreated,
        NumberOfParticipants,
        ScheduleDate,
    }
}
