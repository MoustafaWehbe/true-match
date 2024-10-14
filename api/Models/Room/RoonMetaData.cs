using System.Text.Json.Serialization;
using api.Dtos;

namespace api.Models
{
    public class RoomMetaData
    {
        [JsonPropertyName("currentRound")]
        public int? CurrentRount { get; set; }

        [JsonPropertyName("timer")]
        public int? Timer { get; set; }

        [JsonPropertyName("isPaused")]
        public int? IsPaused { get; set; }

        [JsonPropertyName("SystemQuestions")]
        public List<SystemQuestionDto>? SystemQuestions { get; set; }
    }
}