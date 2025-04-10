using Newtonsoft.Json;

namespace FlyBooking.BLL
{
    public class DetectedExtensions
    {
        [JsonProperty("carbon_emission")]
        public int CarbonEmission { get; set; }

        [JsonProperty("seat_type")]
        public string SeatType { get; set; }

        [JsonProperty("legroom_short")]
        public string LegroomShort { get; set; }

        [JsonProperty("legroom_long")]
        public string LegroomLong { get; set; }
    }
}
