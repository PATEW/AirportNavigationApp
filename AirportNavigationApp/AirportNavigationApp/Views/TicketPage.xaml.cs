﻿using System;
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
        private string gate;
        private string departureTime;
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

        public string Gate {
            get { return gate; }
            set
            {
                gate = value;
                OnPropertyChanged(nameof(Gate));
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
                    Gate = flightPage.listGate[i];
                    DepartureTime = flightPage.listSchedT[i];
                    break;
                }
            }

        }

        public TicketPage()
        {
            InitializeComponent();
            BindingContext = this;

            Destination = "N/A";
            Airline = "N/A";
            Terminal = "N/A";
            Gate = "N/A";
            DepartureTime = "N/A";
            
        }
    }
}