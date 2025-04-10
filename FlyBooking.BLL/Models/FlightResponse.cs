﻿using System.Collections.Generic;
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

}
