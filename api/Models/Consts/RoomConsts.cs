namespace api.Models
{
    public static class RoomConstants
    {
        public const int TheRoomIsValidFor = 10; // 10 mins

        // TODO: should be calculated automatically based on the number of rounds and the duration of each one
        public const int TotalRoundsDuration = 15; // 15 mins

        public const int NumberOfSystemQuestionsPerRoom = 3;
    }
}
