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

using System.Collections.ObjectModel;
using FlyBooking.BLL;
using Newtonsoft.Json;

namespace FlyBooking.UI
{
    public partial class MainWindow : Window
    {
        private readonly FlightService _flightService;

        // Liste til at binde til UI
        public ObservableCollection<Flight> Flights { get; set; }

        CreateUserWindow createUserWindow = new CreateUserWindow();

        // Eksempel på forslag - tilpas med de relevante lufthavne
        private List<string> departureSuggestions = new List<string>
        {
            "København",
            "Kastrup Lufthavn/EKCH/CPH",
            "Aalborg",
            "Billund"
        };

        public MainWindow()
        {
            InitializeComponent();

            // Initialisere FlightService objekt
            _flightService = new FlightService();

            // Initialiser ObservableCollection
            Flights = new ObservableCollection<Flight>();

            // Bind collection til ListBox
            listFlights.ItemsSource = Flights;
        }

        private async void btnGetFlights_Click(object sender, RoutedEventArgs e)
        {
            string engine = "google_flights";
            string flight_type = "round_trip";

            string departure_id = "";
            departure_id = departureAirport.Text.ToUpper().Trim();

            string arrival_id = "";
            arrival_id = arrivalAirport.Text.ToUpper().Trim();

            if (string.IsNullOrEmpty(departure_id) || string.IsNullOrEmpty(arrival_id))
            {
                return;
            }

            string outbound_date = "";
            DateTime? selectedDateOutbound = datePickerOutbound.SelectedDate;
            if (selectedDateOutbound.HasValue)
            {
                outbound_date = selectedDateOutbound.Value.ToString("yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
            }

            string return_date = "";
            DateTime? selectedDateInbound = datePickerInbound.SelectedDate;
            if (selectedDateInbound.HasValue)
            {
                return_date = selectedDateInbound.Value.ToString("yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
            }


            try
            {
                var flightData = await _flightService.GetFlightsAsync(engine, flight_type, departure_id, arrival_id, outbound_date, return_date);

                if (flightData == null || (flightData.BestFlights == null && flightData.OtherFlights == null))
                {
                    MessageBox.Show("Ingen flydata modtaget.");
                    return;
                }

                Flights.Clear();

                // Tilføj fly fra både BestFlights og OtherFlights, og sæt prisen fra FlightGroup
                foreach (var flightGroup in flightData.BestFlights)
                {
                    foreach (var flight in flightGroup.Flights)
                    {
                        flight.Price = flightGroup.Price;  // <-- Tilføjer prisen fra FlightGroup til hvert Flight
                        Flights.Add(flight);
                    }
                }

                foreach (var flightGroup in flightData.OtherFlights)
                {
                    foreach (var flight in flightGroup.Flights)
                    {
                        flight.Price = flightGroup.Price;  // <-- Tilføjer prisen fra FlightGroup til hvert Flight
                        Flights.Add(flight);
                    }
                }

                Console.WriteLine(JsonConvert.SerializeObject(flightData, Formatting.Indented));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Fejl ved hentning af flydata: " + ex.Message);
            }
        }
        // event handler for createUser button
        private void OpenCreateUserWindow_Click(object sender, RoutedEventArgs e)
        {
            CreateUserWindow createUserWindow = new CreateUserWindow();
            createUserWindow.Owner = this; // Set the main window as the owner of the user creation window
            createUserWindow.ShowDialog(); // Show the user creation window as a dialog
        }

        /*private void departureAirport_TextChanged(object sender, TextChangedEventArgs e)
        {
            string departureAirport = sender.ToString();
            
        }

        private void arrivalAirport_TextChanged(object sender, TextChangedEventArgs e)
        {
            string arrivalAirport = sender.ToString();
        }
        */

        // Håndterer tekstændringer i afgangs-tekstfeltet
        private void departureAirport_TextChanged(object sender, TextChangedEventArgs e)
        {
            string query = departureAirport.Text.Trim().ToLower();

            if (departureAirport == null || listDepartureSuggestions == null)   
            {
                // Log eller returner for at undgå fejlen midlertidigt
                return;
            }

            // Skjul forslag hvis standardtekst vises eller feltet er tomt
            if (string.IsNullOrEmpty(query) || query == "fra?")
            {
                listDepartureSuggestions.Visibility = Visibility.Collapsed;
                listDepartureSuggestions.ItemsSource = null;
                return;
            }

            // Filtrer forslagene ud fra det indtastede
            var filtered = departureSuggestions
                           .Where(s => s.ToLower().Contains(query))
                           .ToList();

            if (filtered.Any())
            {
                listDepartureSuggestions.ItemsSource = filtered;
                listDepartureSuggestions.Visibility = Visibility.Visible;
            }
            else
            {
                listDepartureSuggestions.Visibility = Visibility.Collapsed;
            }
        }

        // Håndterer når et forslag vælges i ListBox’en
        private void lstDepartureSuggestions_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (listDepartureSuggestions.SelectedItem != null)
            {
                departureAirport.Text = listDepartureSuggestions.SelectedItem.ToString();
                listDepartureSuggestions.Visibility = Visibility.Collapsed;
                // Flyt evt. fokus til næste felt
                arrivalAirport.Focus();
            }
        }

        private void arrivalAirport_TextChanged(object sender, TextChangedEventArgs e)
        {
            // Implementer evt. samme logik for destination, hvis nødvendigt


        }
    }
}
