using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AirportNavigationApp.Views
{
    public partial class TicketPage : ContentPage
    {
        private string destination;
        private string airline;
        private string terminal;
        private string departureTime;
        private string status;
        private string flightNum;

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

        async void OnEnterClicked(object sender, EventArgs args)
        {
            flightNum = entry.Text;
            FlightsPage flightPage = new FlightsPage();
            flightPage.updateFlightInfo();
            for(int i = 0; i < flightPage.listFlightNum.Count; i++) {
                if (flightPage.listFlightNum[i].Equals(flightNum)) {
                    Destination = flightPage.listDestination[i];
                    Airline = flightPage.listAirline[i];
                    Terminal = flightPage.listGate[i];
                    Status = flightPage.listStatus[i];
                    DepartureTime = flightPage.listSchedT[i];
                    break;
                }
            }

        }

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
        }

        public TicketPage()
        {
            InitializeComponent();
            BindingContext = this;

            Destination = "N/A";
            Airline = "N/A";
            Terminal = "N/A";
            DepartureTime = "N/A";
            Status = "N/A";
        }
    }
}