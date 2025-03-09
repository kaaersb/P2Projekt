using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace FlyBooking.BLL
{
    public class FlightResponse
    {
        [JsonProperty("best_flights")]
        public List<FlightGroup> BestFlights { get; set; }

        [JsonProperty("other_flights")]
        public List<FlightGroup> OtherFlights { get; set; }
    }

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
    public class AirportInfo
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("date")]
        public string Date { get; set; }

        [JsonProperty("time")]
        public string Time { get; set; }
    }

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
