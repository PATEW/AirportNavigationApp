using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AirportNavigationApp.Views
{
    public partial class TicketPage : ContentPage
    {
        // Attributes
        private string destination;
        private string airline;
        private string terminal;
        private string departureTime;
        private string status;
        private string flightNum;

        // Properties
        public string Destination {
            get { return destination; }
            set 
            {
                destination = value;
                OnPropertyChanged(nameof(Destination));
}
        }
        public string Airline {
            get { return airline; }
            set
            {
                airline = value;
                OnPropertyChanged(nameof(Airline)); 
            }
        }
        public string Terminal {
            get { return terminal; }
            set
            {
                terminal = value;
                OnPropertyChanged(nameof(Terminal));
            }
        }
        public string Status
        {
            get { return status; }
            set
            {
                status = value;
                OnPropertyChanged(nameof(Status));
            }
        }
        public string DepartureTime {
            get { return departureTime; }
            set
            {
                departureTime = value;
                OnPropertyChanged(nameof(DepartureTime));
            }
        }
        
        // Initialize TicketPage.
        public TicketPage()
        {
            InitializeComponent();
            BindingContext = this;
            resetGrid();
        }

        // Method to fill grid with flight information based on flight number.
        async void OnEnterClicked(object sender, EventArgs args)
        {
            flightNum = entry.Text;
            FlightsPage flightPage = new FlightsPage();
            flightPage.updateFlightInfo();
            bool flightFound = false;
            // Loop for every departing flight at user selected airport.
            for(int i = 0; i < flightPage.listFlightNum.Count; i++) {
                // Check flights for user inputeed flight number.
                if (flightPage.listFlightNum[i].Equals(flightNum)) {
                    flightFound = true;
                    Destination = flightPage.listDestination[i];
                    Airline = flightPage.listAirline[i];
                    Terminal = flightPage.listGate[i];
                    Status = flightPage.listStatus[i];
                    DepartureTime = flightPage.listSchedT[i];
                    break;
                }
            }
            // Alert user if flight is not found.
            if (!flightFound) {
               await DisplayAlert("Flight Not Found", "Sorry, we could not locate your flight. Please ensure your flight number is correct and your departure airport is selected.", "OK");
            }

        }

        // Update App._Airport when user changes selected airport.
        private void OnPickerSelectedIndexChanged(object sender, EventArgs e)
        {
            Picker picker = sender as Picker;
            var selectedItem = picker.SelectedItem; // This is the model selected in the picker
            if (selectedItem.ToString().Equals("Daytona Beach International Airport")) {
                App._Airport = "DAB";
            }
            else if (selectedItem.ToString().Equals("Phoenix Sky Harbor International Airport"))
            {
                App._Airport = "PHX";
            }
            else if (selectedItem.ToString().Equals("Los Angeles International Airport"))
            {
                App._Airport = "LAX";
            }
            else if (selectedItem.ToString().Equals("Hartsfield-Jackson Atlanta International Airport"))
            {
                App._Airport = "ATL";
            }
            else if (selectedItem.ToString().Equals("Tampa International Airport"))
            {
                App._Airport = "TPA";
            }
            resetGrid();
        }

        // Return all grid values to N/A.
        public void resetGrid() {
            entry.Text = null;
            Destination = "N/A";
            Airline = "N/A";
            Terminal = "N/A";
            DepartureTime = "N/A";
            Status = "N/A";
        }
    }
}