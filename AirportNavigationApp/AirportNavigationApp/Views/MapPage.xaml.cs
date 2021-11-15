using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AirportNavigationApp.Views
{
    public partial class MapPage : ContentPage
    {
        public string viewMessage = "You are viewing the map for: " + App._Airport;
        public string oldAirport;

        public MapPage()
        {
            InitializeComponent();
            BindingContext = this;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            viewMessage = "You are viewing the map for: " + App._Airport;
            if (! App._Airport.Equals(oldAirport))
                if (App._Airport.Equals("DAB")) {
                    showDaytonaMain();
                }
                else if (App._Airport.Equals("PHX"))
                {
                    showDaytonaMain();
                }
            oldAirport = App._Airport;

        }

        void OnMapButtonClicked(object sender, EventArgs args) {

            MapLayout.Children.Clear();
            var mainMap = new Image
            {
                Source = "lax.png"
            };

            var mapButton = new ImageButton
            {
                Source = "icon_about.png",
                BackgroundColor = Color.Transparent,
            };
            AbsoluteLayout.SetLayoutBounds(mapButton, new Rectangle(0.88, 0.35, 100, 100));
            AbsoluteLayout.SetLayoutFlags(mapButton, AbsoluteLayoutFlags.PositionProportional);

            MapLayout.Children.Add(mainMap);
            MapLayout.Children.Add(mapButton);
        }

        void showDayonaMainButton(object sender, EventArgs args)
        {
            showDaytonaMain();
        }

        void showDaytonaMain() {
            MapLayout.Children.Clear();

            var mainMap = new Image
            {
                Source = "DAB.png",
                BackgroundColor = Color.Transparent,
            };

            var terminalButton = new ImageButton
            {
                Source = "pin_escalator.png",
                BackgroundColor = Color.Transparent,
            };
            terminalButton.Clicked += showDaytonaTerminal;
            AbsoluteLayout.SetLayoutBounds(terminalButton, new Rectangle(0.5385, 0.7, 100, 100));
            AbsoluteLayout.SetLayoutFlags(terminalButton, AbsoluteLayoutFlags.PositionProportional);

            var parkingButton = new ImageButton
            {
                Source = "pin_escalator.png",
                BackgroundColor = Color.Transparent,
            };
            parkingButton.Clicked += showDaytonaTerminal;
            AbsoluteLayout.SetLayoutBounds(parkingButton, new Rectangle(0.29, 0.08, 100, 100));
            AbsoluteLayout.SetLayoutFlags(parkingButton, AbsoluteLayoutFlags.PositionProportional);

            var parkingButton1 = new ImageButton
            {
                Source = "pin_escalator.png",
                BackgroundColor = Color.Transparent,
            };
            parkingButton1.Clicked += showDaytonaTerminal;
            AbsoluteLayout.SetLayoutBounds(parkingButton1, new Rectangle(0.8, 0.08, 100, 100));
            AbsoluteLayout.SetLayoutFlags(parkingButton1, AbsoluteLayoutFlags.PositionProportional);

            var dogRestroom = new ImageButton
            {
                Source = "pin_Escalator.png",
                BackgroundColor = Color.Transparent,
            };
            dogRestroom.Clicked += showDaytonaTerminal;
            AbsoluteLayout.SetLayoutBounds(dogRestroom, new Rectangle(0.93, 0.42, 100, 100));
            AbsoluteLayout.SetLayoutFlags(dogRestroom, AbsoluteLayoutFlags.PositionProportional);

            var mainEnteranceButton = new ImageButton
            {
                Source = "pin_escalator.png",
                BackgroundColor = Color.Transparent,
            };
            mainEnteranceButton.Clicked += showDaytonaTerminal;
            AbsoluteLayout.SetLayoutBounds(mainEnteranceButton, new Rectangle(.354, .493, 100, 100));
            AbsoluteLayout.SetLayoutFlags(mainEnteranceButton, AbsoluteLayoutFlags.PositionProportional);

            var ticketCounterButton = new ImageButton
            {
                Source = "pin_escalator.png",
                BackgroundColor = Color.Transparent,
            };
            ticketCounterButton.Clicked += showDaytonaTerminal;
            AbsoluteLayout.SetLayoutBounds(ticketCounterButton, new Rectangle(.39, .6, 100, 100));
            AbsoluteLayout.SetLayoutFlags(ticketCounterButton, AbsoluteLayoutFlags.PositionProportional);

            var baggageClaimButton = new ImageButton
            {
                Source = "pin_escalator.png",
                BackgroundColor = Color.Transparent,
            };
            baggageClaimButton.Clicked += showDaytonaTerminal;
            AbsoluteLayout.SetLayoutBounds(baggageClaimButton, new Rectangle(.78, .75, 100, 100));
            AbsoluteLayout.SetLayoutFlags(baggageClaimButton, AbsoluteLayoutFlags.PositionProportional);

            var rentalCounterButton = new ImageButton
            {
                Source = "pin_escalator.png",
                BackgroundColor = Color.Transparent,
            };
            rentalCounterButton.Clicked += showDaytonaTerminal;
            AbsoluteLayout.SetLayoutBounds(rentalCounterButton, new Rectangle(.72, .53, 100, 100));
            AbsoluteLayout.SetLayoutFlags(rentalCounterButton, AbsoluteLayoutFlags.PositionProportional);

            var restroomButton = new ImageButton
            {
                Source = "pin_restroom.png",
                BackgroundColor = Color.Transparent,
            };
            restroomButton.Clicked += showDaytonaTerminal;
            AbsoluteLayout.SetLayoutBounds(restroomButton, new Rectangle(0.47, 0.73, 100, 100));
            AbsoluteLayout.SetLayoutFlags(restroomButton, AbsoluteLayoutFlags.PositionProportional);

            MapLayout.Children.Add(mainMap);
            MapLayout.Children.Add(terminalButton);
            MapLayout.Children.Add(dogRestroom);
            MapLayout.Children.Add(parkingButton);
            MapLayout.Children.Add(parkingButton1);
            MapLayout.Children.Add(mainEnteranceButton);
            MapLayout.Children.Add(ticketCounterButton);
            MapLayout.Children.Add(baggageClaimButton);
            MapLayout.Children.Add(rentalCounterButton);
            MapLayout.Children.Add(restroomButton);
        }



        void showDaytonaTerminal(object sender, EventArgs args)
        {
            MapLayout.Children.Clear();

            var mainMap = new Image
            {
                Source = "DAB_terminal.png"
            };

            var gateButton = new ImageButton
            {
                Source = "icon_about.png",
                BackgroundColor = Color.Transparent,
            };
            gateButton.Clicked += showDaytonaGate;
            AbsoluteLayout.SetLayoutBounds(gateButton, new Rectangle(0.525, 0.647, 50, 50));
            AbsoluteLayout.SetLayoutFlags(gateButton, AbsoluteLayoutFlags.PositionProportional);

            var mainButton = new ImageButton
            {
                Source = "icon_about.png",
                BackgroundColor = Color.Transparent,
            };
            mainButton.Clicked += showDayonaMainButton;
            AbsoluteLayout.SetLayoutBounds(mainButton, new Rectangle(0.572, 0.263, 50, 50));
            AbsoluteLayout.SetLayoutFlags(mainButton, AbsoluteLayoutFlags.PositionProportional);

            MapLayout.Children.Add(mainMap);
            MapLayout.Children.Add(gateButton);
            MapLayout.Children.Add(mainButton);
        }

        void showDaytonaGate(object sender, EventArgs args)
        {
            MapLayout.Children.Clear();

            var mainMap = new Image
            {
                Source = "DAB_gate.png",
            };

            var terminalButton = new ImageButton
            {
                Source = "icon_about.png",
                BackgroundColor = Color.Transparent,
            };
            terminalButton.Clicked += showDaytonaTerminal;
            AbsoluteLayout.SetLayoutBounds(terminalButton, new Rectangle(0.058, 0.465, 50, 50));
            AbsoluteLayout.SetLayoutFlags(terminalButton, AbsoluteLayoutFlags.PositionProportional);

            var restroomButton = new ImageButton
            {
                Source = "pin_restroom.png",
                BackgroundColor = Color.Transparent,
            };
            restroomButton.Clicked += showDaytonaTerminal;
            AbsoluteLayout.SetLayoutBounds(restroomButton, new Rectangle(0.67, 0.58, 100, 100));
            AbsoluteLayout.SetLayoutFlags(restroomButton, AbsoluteLayoutFlags.PositionProportional);

            MapLayout.Children.Add(mainMap);
            MapLayout.Children.Add(terminalButton);
            MapLayout.Children.Add(restroomButton);
        }

        public string ViewMessage
        {
            get { return viewMessage; }
            set
            {
                viewMessage = value;
                OnPropertyChanged(nameof(ViewMessage));
            }
        }
    }
}
