using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FlyBooking.DAL;

namespace FlyBooking.BLL
{
    public class FlightService
    {
        private readonly FlightDataAccess _flightDataAcces;
        private string api_key = "z4qrWATZSi5qsEiQsL2arX6g";

        public FlightService() 
        {
            _flightDataAcces = new FlightDataAccess();
        }

        public async Task<FlightResponse> GetFlightsAsync(string engine, string flight_type, string departure_id, string arrival_id, string outbound_date, string return_date)
        {
            string url = $"https://www.searchapi.io/api/v1/search?api_key={api_key}&arrival_id={arrival_id}&departure_id={departure_id}&engine={engine}&flight_type={flight_type}&outbound_date={outbound_date}&return_date={return_date}";
            Console.WriteLine(url);

            var flightReponse = await _flightDataAcces.GetDataFromApiAsync<FlightResponse>(url);
            Console.WriteLine(flightReponse);

            return flightReponse;
        }
    }
}
