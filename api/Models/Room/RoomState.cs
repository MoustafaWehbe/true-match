using System.Text.Json;
using System.Text.Json.Serialization;
using api.Dtos;

namespace api.Models
{
    public class RoomState
    {
        [JsonPropertyName("currentRound")]
        public int? CurrentRound { get; set; }

        [JsonPropertyName("timeRemainingForRoundBeforePause")]
        public int? TimeRemainingForRoundBeforePause { get; set; }

        [JsonPropertyName("isRoundPaused")]
        public bool? IsRoundPaused { get; set; }

        [JsonPropertyName("roundQuestions")]
        public List<SystemQuestionDto>? RoundQuestions { get; set; }

        [JsonPropertyName("roundStartTime")]
        public DateTime? RoundStartTime { get; set; }

        [JsonPropertyName("rounds")]
        public List<RoomContentDto>? Rounds { get; set; }
    }
}