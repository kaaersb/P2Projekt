using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using FlyBooking.BLL;
using Newtonsoft.Json;

namespace FlyBooking.UI
{
    public partial class MainWindow : Window
    {
        private readonly FlightService _flightService;

        public MainWindow()
        {
            InitializeComponent();
            _flightService = new FlightService();
        }

        private async void btnGetFlights_Click(object sender, RoutedEventArgs e)
        {
            // Her kalder vi BLL-laget asynkront
            string engine = "google_flights";
            string flight_type = "round_trip";
            string departure_id = "JFK";        // Eksempel på parameter
            string arrival_id = "MAD";   // Eksempel på parameter
            string outbound_date = "2025-03-08";
            string return_date = "2025-03-15";

            try
            {
                var flightData = await _flightService.GetFlightsAsync(engine, flight_type, departure_id, arrival_id, outbound_date, return_date);

                if (flightData == null || flightData.flights == null)
                {
                    MessageBox.Show("Ingen data modtaget.");
                    return;
                }


                // Gør noget med flightData, fx vis dem i en ListBox, DataGrid, etc.
                // Her viser vi bare en messagebox for at vise, at vi har fået data
                MessageBox.Show(JsonConvert.SerializeObject(flightData, Formatting.Indented));
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("Fejl ved hentning af flydata: " + ex.Message);
            }
        }
    }
}