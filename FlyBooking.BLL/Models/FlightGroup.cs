using System.Collections.Generic;
using Newtonsoft.Json;

namespace FlyBooking.BLL
{
    public class FlightGroup
    {
        [JsonProperty("flights")]
        public List<Flight> Flights { get; set; }

        [JsonProperty("total_duration")]
        public int TotalDuration { get; set; }

        [JsonProperty("price")]
        public decimal Price { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

    }
}
