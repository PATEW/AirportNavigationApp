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
        public string viewMessage = "Select Airport on Ticket Page";
        public string oldAirport;
        public double scaleCurrent = 0.5;

        public MapPage()
        {
            InitializeComponent();
            BindingContext = this;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            if (!App._Airport.Equals(oldAirport))
            {
                if (App._Airport.Equals("DAB"))
                {
                    ViewMessage = "  Map Information For: " + App._Airport;
                    BackgroundColor = Color.White;
                    showDaytonaMain();
                }
                else if (App._Airport.Equals("PHX"))
                {
                    ViewMessage = "  Map Information For: " + App._Airport;
                    BackgroundColor = Color.FromHex("#F0F0F0");
                    showPrescottMain();
                }
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
                Source = "pin_4.png",
                BackgroundColor = Color.Transparent,
            };
            terminalButton.Clicked += showDaytonaTerminal;
            AbsoluteLayout.SetLayoutBounds(terminalButton, new Rectangle(0.5385, 0.7, 100, 100));
            AbsoluteLayout.SetLayoutFlags(terminalButton, AbsoluteLayoutFlags.PositionProportional);

            var parkingButton = new ImageButton
            {
                Source = "pin_1.png",
                BackgroundColor = Color.Transparent,
            };
            parkingButton.Clicked += parkingAlert;
            AbsoluteLayout.SetLayoutBounds(parkingButton, new Rectangle(0.29, 0.08, 100, 100));
            AbsoluteLayout.SetLayoutFlags(parkingButton, AbsoluteLayoutFlags.PositionProportional);

            var parkingButton1 = new ImageButton
            {
                Source = "pin_1.png",
                BackgroundColor = Color.Transparent,
            };
            parkingButton1.Clicked += showDaytonaTerminal;
            AbsoluteLayout.SetLayoutBounds(parkingButton1, new Rectangle(0.8, 0.08, 100, 100));
            AbsoluteLayout.SetLayoutFlags(parkingButton1, AbsoluteLayoutFlags.PositionProportional);

            var dogRestroom = new ImageButton
            {
                Source = "Pin_Service.png",
                BackgroundColor = Color.Transparent,
            };
            dogRestroom.Clicked += serviceAlert;
            AbsoluteLayout.SetLayoutBounds(dogRestroom, new Rectangle(0.93, 0.42, 100, 100));
            AbsoluteLayout.SetLayoutFlags(dogRestroom, AbsoluteLayoutFlags.PositionProportional);

            var mainEnteranceButton = new ImageButton
            {
                Source = "Pin_2.png",
                BackgroundColor = Color.Transparent,
            };
            mainEnteranceButton.Clicked += arrivedAlert;
            AbsoluteLayout.SetLayoutBounds(mainEnteranceButton, new Rectangle(.354, .493, 100, 100));
            AbsoluteLayout.SetLayoutFlags(mainEnteranceButton, AbsoluteLayoutFlags.PositionProportional);

            var ticketCounterButton = new ImageButton
            {
                Source = "pin_3.png",
                BackgroundColor = Color.Transparent,
            };
            ticketCounterButton.Clicked += counterAlert;
            AbsoluteLayout.SetLayoutBounds(ticketCounterButton, new Rectangle(.39, .6, 100, 100));
            AbsoluteLayout.SetLayoutFlags(ticketCounterButton, AbsoluteLayoutFlags.PositionProportional);

            var baggageClaimButton = new ImageButton
            {
                Source = "Pin_Baggage.png",
                BackgroundColor = Color.Transparent,
            };
            baggageClaimButton.Clicked += baggageAlert;
            AbsoluteLayout.SetLayoutBounds(baggageClaimButton, new Rectangle(0.78, 0.75, 100, 100));
            AbsoluteLayout.SetLayoutFlags(baggageClaimButton, AbsoluteLayoutFlags.PositionProportional);

            var rentalCounterButton = new ImageButton
            {
                Source = "Pin_CarRental.png",
                BackgroundColor = Color.Transparent,
            };
            rentalCounterButton.Clicked += rentalAlert;
            AbsoluteLayout.SetLayoutBounds(rentalCounterButton, new Rectangle(.72, .53, 100, 100));
            AbsoluteLayout.SetLayoutFlags(rentalCounterButton, AbsoluteLayoutFlags.PositionProportional);

            var restroomButton = new ImageButton
            {
                Source = "pin_restroom.png",
                BackgroundColor = Color.Transparent,
            };
            restroomButton.Clicked += restroomAlert;
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

        private void parkingAlert(object sender, EventArgs e)
        {
            DisplayAlert("Parking", "This is the main lot for parking at Daytona Beach International Airport. Task 1 on checklist.", "Done");
        }
        private void serviceAlert(object sender, EventArgs e)
        {
            DisplayAlert("Service Animal Area", "Area designated for service animal relief.", "Done");
        }
        private void arrivedAlert(object sender, EventArgs e)
        {
            DisplayAlert("Airport Front Doors", "Main enterance for Daytona International Airport. Task 2 on checklist.", "Done");
        }
        private void counterAlert(object sender, EventArgs e)
        {
            DisplayAlert("Ticket Counter", "Check in for flight and check luggage here. Task 3 on checklist.", "Done");
        }
        private void baggageAlert(object sender, EventArgs e)
        {
            DisplayAlert("Baggage Claim", "Place to retrieve chacked luggage after flight.", "Done");
        }
        private void restroomAlert(object sender, EventArgs e)
        {
            DisplayAlert("Restrooms", "Men and Women's restrooms are available here.", "Done");
        }
        private void rentalAlert(object sender, EventArgs e)
        {
            DisplayAlert("Rental Car Counter", "Location to rent a car. Avaliable companies include: Hertz, Enterprise, Avis, Budget, Dollar, and Alamo.", "Done");
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
                Source = "pin_5.png",
                BackgroundColor = Color.Transparent,
            };
            gateButton.Clicked += showDaytonaGate;
            AbsoluteLayout.SetLayoutBounds(gateButton, new Rectangle(0.540, 0.898, 100, 100));
            AbsoluteLayout.SetLayoutFlags(gateButton, AbsoluteLayoutFlags.PositionProportional);

            var barButton = new ImageButton
            {
                Source = "pin_bar.png",
                BackgroundColor = Color.Transparent,
            };
            barButton.Clicked += barAlert;
            AbsoluteLayout.SetLayoutBounds(barButton, new Rectangle(0.690, 0.608, 100, 100));
            AbsoluteLayout.SetLayoutFlags(barButton, AbsoluteLayoutFlags.PositionProportional);
            
            var resturauntButton = new ImageButton {
                Source = "pin_food.png",
                BackgroundColor = Color.Transparent,
            };
            resturauntButton.Clicked += javaMoonAlert;
            AbsoluteLayout.SetLayoutBounds(resturauntButton, new Rectangle(0.750, 0.290, 100, 100));
            AbsoluteLayout.SetLayoutFlags(resturauntButton, AbsoluteLayoutFlags.PositionProportional);

            var securityButton = new ImageButton
            {
                Source = "pin_security.png",
                BackgroundColor = Color.Transparent,
            };
            securityButton.Clicked += securityAlert;
            AbsoluteLayout.SetLayoutBounds(securityButton, new Rectangle(.537, .708, 100, 100));
            AbsoluteLayout.SetLayoutFlags(securityButton, AbsoluteLayoutFlags.PositionProportional);

            var restroomButton = new ImageButton
            {
                Source = "pin_restroom.png",
                BackgroundColor = Color.Transparent,
            };
            restroomButton.Clicked += menRestroomAlert;
            AbsoluteLayout.SetLayoutBounds(restroomButton, new Rectangle(0.430, 0.000, 100, 100));
            AbsoluteLayout.SetLayoutFlags(restroomButton, AbsoluteLayoutFlags.PositionProportional);

            var restroomButton1 = new ImageButton
            {
                Source = "pin_restroom.png",
                BackgroundColor = Color.Transparent,
            };
            restroomButton1.Clicked += womenRestroomAlert;
            AbsoluteLayout.SetLayoutBounds(restroomButton1, new Rectangle(0.720, 0.000, 100, 100));
            AbsoluteLayout.SetLayoutFlags(restroomButton1, AbsoluteLayoutFlags.PositionProportional);

            var conventionButton = new ImageButton
            {
                Source = "pin_Info.png",
                BackgroundColor = Color.Transparent,
            };
            conventionButton.Clicked += conventionAlert;
            AbsoluteLayout.SetLayoutBounds(conventionButton, new Rectangle(0.8, 0.755, 100, 100));
            AbsoluteLayout.SetLayoutFlags(conventionButton, AbsoluteLayoutFlags.PositionProportional);

            var mainButton = new ImageButton
            {
                Source = "pin_escalator.png",
                BackgroundColor = Color.Transparent,
            };
            mainButton.Clicked += showDayonaMainButton;
            AbsoluteLayout.SetLayoutBounds(mainButton, new Rectangle(0.578, 0.200, 100, 100));
            AbsoluteLayout.SetLayoutFlags(mainButton, AbsoluteLayoutFlags.PositionProportional);

            MapLayout.Children.Add(mainMap);
            MapLayout.Children.Add(gateButton);
            MapLayout.Children.Add(mainButton);
            MapLayout.Children.Add(securityButton);
            MapLayout.Children.Add(barButton);
            MapLayout.Children.Add(resturauntButton);
            MapLayout.Children.Add(restroomButton);
            MapLayout.Children.Add(restroomButton1);
            MapLayout.Children.Add(conventionButton);
        }
        private void javaMoonAlert(object sender, EventArgs e)
        {
            DisplayAlert("Java Moon Cafe", "Quick service American cafe. Food options include: breakfast, deli items, salads, and fruits. Drink options include: coffee, juice, and soda.", "Done");
        }
        private void menRestroomAlert(object sender, EventArgs e)
        {
            DisplayAlert("Restrooms", "Men's restrooms are available here.", "Done");
        }
        private void womenRestroomAlert(object sender, EventArgs e)
        {
            DisplayAlert("Restrooms", "Women's restrooms are available here.", "Done");
        }
        private void conventionAlert(object sender, EventArgs e)
        {
            DisplayAlert("Dennis R. McGee Room", "Convention room avaliable to rent.", "Done");
        }
        private void securityAlert(object sender, EventArgs e)
        {
            DisplayAlert("Security", "TSA checkpoint. Expect seperate x-rays for belongings and your person.", "Done");
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
                Source = "pin_5.png",
                BackgroundColor = Color.Transparent,
            };
            terminalButton.Clicked += showDaytonaTerminal;
            AbsoluteLayout.SetLayoutBounds(terminalButton, new Rectangle(0.01, 0.5, 100, 100));
            AbsoluteLayout.SetLayoutFlags(terminalButton, AbsoluteLayoutFlags.PositionProportional);

            var gate1Button = new ImageButton
            {
                Source = "pin_Gate1.png",
                BackgroundColor = Color.Transparent,
            };
            gate1Button.Clicked += gate1Alert;
            AbsoluteLayout.SetLayoutBounds(gate1Button, new Rectangle(0.065, 0.75, 100, 100));
            AbsoluteLayout.SetLayoutFlags(gate1Button, AbsoluteLayoutFlags.PositionProportional);

            var gate2Button = new ImageButton
            {
                Source = "pin_Gate2.png",
                BackgroundColor = Color.Transparent,
            };
            gate2Button.Clicked += gate2Alert;
            AbsoluteLayout.SetLayoutBounds(gate2Button, new Rectangle(0.24, 0.3, 100, 100));
            AbsoluteLayout.SetLayoutFlags(gate2Button, AbsoluteLayoutFlags.PositionProportional);

            var gate3Button = new ImageButton
            {
                Source = "pin_Gate3.png",
                BackgroundColor = Color.Transparent,
            };
            gate3Button.Clicked += gate3Alert;
            AbsoluteLayout.SetLayoutBounds(gate3Button, new Rectangle(0.345, 0.75, 100, 100));
            AbsoluteLayout.SetLayoutFlags(gate3Button, AbsoluteLayoutFlags.PositionProportional);

            var gate4Button = new ImageButton
            {
                Source = "pin_Gate4.png",
                BackgroundColor = Color.Transparent,
            };
            gate4Button.Clicked += gate4Alert;
            AbsoluteLayout.SetLayoutBounds(gate4Button, new Rectangle(0.62, 0.3, 100, 100));
            AbsoluteLayout.SetLayoutFlags(gate4Button, AbsoluteLayoutFlags.PositionProportional);

            var gate5Button = new ImageButton
            {
                Source = "pin_Gate5.png",
                BackgroundColor = Color.Transparent,
            };
            gate5Button.Clicked += gate5Alert;
            AbsoluteLayout.SetLayoutBounds(gate5Button, new Rectangle(0.89, 0.75, 100, 100));
            AbsoluteLayout.SetLayoutFlags(gate5Button, AbsoluteLayoutFlags.PositionProportional);

            var gate6Button = new ImageButton
            {
                Source = "pin_Gate6.png",
                BackgroundColor = Color.Transparent,
            };
            gate6Button.Clicked += gate6Alert;
            AbsoluteLayout.SetLayoutBounds(gate6Button, new Rectangle(0.98, 0.3, 100, 100));
            AbsoluteLayout.SetLayoutFlags(gate6Button, AbsoluteLayoutFlags.PositionProportional);

            var newsButton = new ImageButton
            {
                Source = "pin_Shop.png",
                BackgroundColor = Color.Transparent,
            };
            newsButton.Clicked += newsAlert;
            AbsoluteLayout.SetLayoutBounds(newsButton, new Rectangle(0.37, 0.3, 100, 100));
            AbsoluteLayout.SetLayoutFlags(newsButton, AbsoluteLayoutFlags.PositionProportional);

            var barButton = new ImageButton
            {
                Source = "pin_bar.png",
                BackgroundColor = Color.Transparent,
            };
            barButton.Clicked += barAlert;
            AbsoluteLayout.SetLayoutBounds(barButton, new Rectangle(0.409, 0.75, 100, 100));
            AbsoluteLayout.SetLayoutFlags(barButton, AbsoluteLayoutFlags.PositionProportional);

            var cafeButton = new ImageButton
            {
                Source = "pin_food.png",
                BackgroundColor = Color.Transparent,
            };
            cafeButton.Clicked += cafeAlert;
            AbsoluteLayout.SetLayoutBounds(cafeButton, new Rectangle(0.5, 0.75, 100, 100));
            AbsoluteLayout.SetLayoutFlags(cafeButton, AbsoluteLayoutFlags.PositionProportional);

            var businessButton = new ImageButton
            {
                Source = "pin_Info.png",
                BackgroundColor = Color.Transparent,
            };
            businessButton.Clicked += businessAlert;
            AbsoluteLayout.SetLayoutBounds(businessButton, new Rectangle(0.774, 0.3, 100, 100));
            AbsoluteLayout.SetLayoutFlags(businessButton, AbsoluteLayoutFlags.PositionProportional);

            var restroomButton = new ImageButton
            {
                Source = "pin_restroom.png",
                BackgroundColor = Color.Transparent,
            };
            restroomButton.Clicked += familyRestroomAlert;
            AbsoluteLayout.SetLayoutBounds(restroomButton, new Rectangle(0.661, 0.75, 100, 100));
            AbsoluteLayout.SetLayoutFlags(restroomButton, AbsoluteLayoutFlags.PositionProportional);

            MapLayout.Children.Add(mainMap);
            MapLayout.Children.Add(terminalButton);
            MapLayout.Children.Add(gate1Button);
            MapLayout.Children.Add(gate2Button);
            MapLayout.Children.Add(gate3Button);
            MapLayout.Children.Add(gate4Button);
            MapLayout.Children.Add(gate5Button);
            MapLayout.Children.Add(gate6Button);
            MapLayout.Children.Add(newsButton);
            MapLayout.Children.Add(barButton);
            MapLayout.Children.Add(cafeButton);
            MapLayout.Children.Add(businessButton);
            MapLayout.Children.Add(restroomButton);
        }
        private void gate1Alert(object sender, EventArgs e)
        {
            DisplayAlert("Gate 1", "Gate one for general flights.", "Done");
        }
        private void gate2Alert(object sender, EventArgs e)
        {
            DisplayAlert("Gate 2", "Gate two for Delta flights.", "Done");
        }
        private void gate3Alert(object sender, EventArgs e)
        {
            DisplayAlert("Gate 3", "Gate three for American flights.", "Done");
        }
        private void gate4Alert(object sender, EventArgs e)
        {
            DisplayAlert("Gate 4", "Gate four for Delta flights.", "Done");
        }
        private void gate5Alert(object sender, EventArgs e)
        {
            DisplayAlert("Gate 5", "Gate five for general flights.", "Done");
        }
        private void gate6Alert(object sender, EventArgs e)
        {
            DisplayAlert("Gate 6", "Gate six for JetBlue flights.", "Done");
        }
        private void newsAlert(object sender, EventArgs e)
        {
            DisplayAlert("Daytona News Now", "General store. Items for sale include: media products, sncacks, drinks, and souvineers.", "Done");
        }
        private void barAlert(object sender, EventArgs e)
        {
            DisplayAlert("Junction Bar", "Alchoholic and non-alchoholic beverages are served here.", "Done");
        }
        private void cafeAlert(object sender, EventArgs e)
        {
            DisplayAlert("Sugar Mill Cafe", "Quick service American cafe. Food options include: breakfast, deli items, salads, and fruits. Drink options include: coffee, juice, and soda.", "Done");
        }
        private void businessAlert(object sender, EventArgs e)
        {
            DisplayAlert("Business Center", "Center for travelers on business. Computers, printers, outlets, and wifi are avaliable for use here.", "Done");
        }
        private void familyRestroomAlert(object sender, EventArgs e)
        {
            DisplayAlert("Restrooms", "Men and Women's restrooms are available here. Family restrooms are also provided.", "Done");
        }

        void showPrescottMain()
        {
            MapLayout.Children.Clear();

            var mainMap = new Image
            {
                Source = "PHX.png",
                BackgroundColor = Color.Transparent,
            };

            var terminalButton3 = new ImageButton
            {
                Source = "pin_4.png",
                BackgroundColor = Color.Transparent,
            };
            terminalButton3.Clicked += showDaytonaTerminal;
            AbsoluteLayout.SetLayoutBounds(terminalButton3, new Rectangle(0.411, 0.48, 100, 100));
            AbsoluteLayout.SetLayoutFlags(terminalButton3, AbsoluteLayoutFlags.PositionProportional);

            var terminalButton4 = new ImageButton
            {
                Source = "pin_4.png",
                BackgroundColor = Color.Transparent,
            };
            terminalButton4.Clicked += showDaytonaTerminal;
            AbsoluteLayout.SetLayoutBounds(terminalButton4, new Rectangle(0.655, 0.5, 100, 100));
            AbsoluteLayout.SetLayoutFlags(terminalButton4, AbsoluteLayoutFlags.PositionProportional);

            var parkingButton = new ImageButton
            {
                Source = "pin_1.png",
                BackgroundColor = Color.Transparent,
            };
            parkingButton.Clicked += parkingAlert;
            AbsoluteLayout.SetLayoutBounds(parkingButton, new Rectangle(0.29, 0.08, 100, 100));
            AbsoluteLayout.SetLayoutFlags(parkingButton, AbsoluteLayoutFlags.PositionProportional);

            var parkingButton1 = new ImageButton
            {
                Source = "pin_1.png",
                BackgroundColor = Color.Transparent,
            };
            parkingButton1.Clicked += showDaytonaTerminal;
            AbsoluteLayout.SetLayoutBounds(parkingButton1, new Rectangle(0.8, 0.08, 100, 100));
            AbsoluteLayout.SetLayoutFlags(parkingButton1, AbsoluteLayoutFlags.PositionProportional);

            var dogRestroom = new ImageButton
            {
                Source = "Pin_Service.png",
                BackgroundColor = Color.Transparent,
            };
            dogRestroom.Clicked += serviceAlert;
            AbsoluteLayout.SetLayoutBounds(dogRestroom, new Rectangle(0.93, 0.42, 100, 100));
            AbsoluteLayout.SetLayoutFlags(dogRestroom, AbsoluteLayoutFlags.PositionProportional);

            var mainEnteranceButton = new ImageButton
            {
                Source = "Pin_2.png",
                BackgroundColor = Color.Transparent,
            };
            mainEnteranceButton.Clicked += arrivedAlert;
            AbsoluteLayout.SetLayoutBounds(mainEnteranceButton, new Rectangle(.354, .493, 100, 100));
            AbsoluteLayout.SetLayoutFlags(mainEnteranceButton, AbsoluteLayoutFlags.PositionProportional);

            var ticketCounterButton = new ImageButton
            {
                Source = "pin_3.png",
                BackgroundColor = Color.Transparent,
            };
            ticketCounterButton.Clicked += counterAlert;
            AbsoluteLayout.SetLayoutBounds(ticketCounterButton, new Rectangle(.39, .6, 100, 100));
            AbsoluteLayout.SetLayoutFlags(ticketCounterButton, AbsoluteLayoutFlags.PositionProportional);

            var baggageClaimButton = new ImageButton
            {
                Source = "Pin_Baggege.png",
                BackgroundColor = Color.Transparent,
            };
            baggageClaimButton.Clicked += baggageAlert;
            AbsoluteLayout.SetLayoutBounds(baggageClaimButton, new Rectangle(.78, .75, 100, 100));
            AbsoluteLayout.SetLayoutFlags(baggageClaimButton, AbsoluteLayoutFlags.PositionProportional);

            var rentalCounterButton = new ImageButton
            {
                Source = "Pin_CarRental.png",
                BackgroundColor = Color.Transparent,
            };
            rentalCounterButton.Clicked += rentalAlert;
            AbsoluteLayout.SetLayoutBounds(rentalCounterButton, new Rectangle(.72, .53, 100, 100));
            AbsoluteLayout.SetLayoutFlags(rentalCounterButton, AbsoluteLayoutFlags.PositionProportional);

            var restroomButton = new ImageButton
            {
                Source = "pin_restroom.png",
                BackgroundColor = Color.Transparent,
            };
            restroomButton.Clicked += restroomAlert;
            AbsoluteLayout.SetLayoutBounds(restroomButton, new Rectangle(0.47, 0.73, 100, 100));
            AbsoluteLayout.SetLayoutFlags(restroomButton, AbsoluteLayoutFlags.PositionProportional);

            MapLayout.Children.Add(mainMap);
            MapLayout.Children.Add(terminalButton3);
            MapLayout.Children.Add(terminalButton4);
            MapLayout.Children.Add(dogRestroom);
            MapLayout.Children.Add(parkingButton);
            MapLayout.Children.Add(parkingButton1);
            MapLayout.Children.Add(mainEnteranceButton);
            MapLayout.Children.Add(ticketCounterButton);
            MapLayout.Children.Add(baggageClaimButton);
            MapLayout.Children.Add(rentalCounterButton);
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

        private void ZoomInClicked(object sender, EventArgs args)
        {
            if (scaleCurrent <= 2)
            {
                scaleCurrent = scaleCurrent + 0.5;
            }
            else
            {
                scaleCurrent = scaleCurrent;
            }
        }

        private void ZoomOutClicked(object sender, EventArgs args)
        {

            if (scaleCurrent >= 1)
            {
                scaleCurrent = scaleCurrent - 0.5;
            }
            else
            {

                scaleCurrent = scaleCurrent;
            }
        }

        public double ScaleCurrent
        {
            get { return scaleCurrent; }
            set
            {
                scaleCurrent = value;
            }
        }
    }
}
