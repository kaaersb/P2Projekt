using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;
using System.Net.Http;

namespace FlyBooking.DAL
{
    public class FlightDataAccess
    {
        private readonly HttpClient _httpClient;

        public FlightDataAccess()
        {
            _httpClient = new HttpClient();
        }

        public async Task<T> GetDataFromApiAsync<T>(string url)
        {
            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync(url);
                response.EnsureSuccessStatusCode();

                string json = await response.Content.ReadAsStringAsync();
                T data = JsonConvert.DeserializeObject<T>(json);

                Console.WriteLine("Data: " + data);

                return data;
            }
            catch (Exception e)
            {
                    throw new Exception("Fejl ved hentning af data fra API: " + e.Message);
            }
        }
    }
}
