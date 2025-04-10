using System.Collections.Generic;
using Newtonsoft.Json;

namespace FlyBooking.BLL
{
    public class Flight
    {
        [JsonProperty("departure_airport")]
        public AirportInfo DepartureAirport { get; set; }

        [JsonProperty("arrival_airport")]
        public AirportInfo ArrivalAirport { get; set; }

        [JsonProperty("duration")]
        public int Duration { get; set; }

        [JsonProperty("airplane")]
        public string Airplane { get; set; }

        [JsonProperty("airline")]
        public string Airline { get; set; }

        [JsonProperty("airline_logo")]
        public string AirlineLogo { get; set; }

        [JsonProperty("travel_class")]
        public string TravelClass { get; set; }

        [JsonProperty("flight_number")]
        public string FlightNumber { get; set; }

        [JsonProperty("is_overnight")]
        public bool IsOvernight { get; set; }

        [JsonProperty("extensions")]
        public List<string> Extensions { get; set; }

        [JsonProperty("detected_extensions")]
        public DetectedExtensions DetectedExtensions { get; set; }

        public decimal Price { get; set; }

    }
}
