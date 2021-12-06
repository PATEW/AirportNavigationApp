using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AirportNavigationApp.Views
{
    public partial class MapPage : ContentPage
    {

        // Attributes.
        public string viewMessage = " Select Airport on Ticket Page";
        public string oldAirport;
        public double scaleCurrent = 0.5;

        // Properties.
        public double ScaleCurrent
        {
            get { return scaleCurrent; }
            set
            {
                scaleCurrent = value;
            }
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

        // Initialize MapPage.
        public MapPage()
        {
            InitializeComponent();
            BindingContext = this;
        }
        
        // Update MapPage when called by user.
        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (!App._Airport.Equals(oldAirport))
            {
                if (App._Airport.Equals("DAB"))
                {
                    ViewMessage = " Map Information For: " + App._Airport;
                    BackgroundColor = Color.White;
                    showDaytonaMain();
                }
                else if (App._Airport.Equals("PHX"))
                {
                    ViewMessage = " Map Information For: " + App._Airport;
                    BackgroundColor = Color.FromHex("#F0F0F0");
                    showPrescottMain();
                }
            }
            oldAirport = App._Airport;
        }

        void showDaytonaMain() {
            MapScroll.ScrollToAsync(100, 0, false);
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

        void showDayonaMainButton(object sender, EventArgs args)
        {
            showDaytonaMain();
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
            MapScroll.ScrollToAsync(350, 0, false);
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
            MapScroll.ScrollToAsync(0, 0, false);
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

        void showPrescottMainButton(object sender, EventArgs args)
        {
            showPrescottMain();
        }
        void showPrescottMain()
        {
            MapScroll.ScrollToAsync(1000, 0, false);
            MapLayout.Children.Clear();

            var mainMap = new Image
            {
                Source = "PHX.png",

            };

            var terminalButton3 = new ImageButton
            {
                Source = "pin_3.png",
                BackgroundColor = Color.Transparent,
            };
            terminalButton3.Clicked += showPrescottTerminal3;
            AbsoluteLayout.SetLayoutBounds(terminalButton3, new Rectangle(0.41, 0.45, 100, 100));
            AbsoluteLayout.SetLayoutFlags(terminalButton3, AbsoluteLayoutFlags.PositionProportional);

            var terminalButton4 = new ImageButton
            {
                Source = "pin_4.png",
                BackgroundColor = Color.Transparent,
            };
            terminalButton4.Clicked += showPrescottTerminal4;
            AbsoluteLayout.SetLayoutBounds(terminalButton4, new Rectangle(0.66, 0.45, 100, 100));
            AbsoluteLayout.SetLayoutFlags(terminalButton4, AbsoluteLayoutFlags.PositionProportional);

            var parkingButton = new ImageButton
            {
                Source = "pin_1.png",
                BackgroundColor = Color.Transparent,
            };
            parkingButton.Clicked += parkingAlert;
            AbsoluteLayout.SetLayoutBounds(parkingButton, new Rectangle(0.90, 0.6, 100, 100));
            AbsoluteLayout.SetLayoutFlags(parkingButton, AbsoluteLayoutFlags.PositionProportional);

            MapLayout.Children.Add(mainMap);
            MapLayout.Children.Add(terminalButton3);
            MapLayout.Children.Add(terminalButton4);
            MapLayout.Children.Add(parkingButton);
        }

        void showPrescottTerminal3(object sender, EventArgs args)
        {
            MapLayout.Children.Clear();

            var mainMap = new Image
            {
                Source = "PHXTerminal3.png",
                BackgroundColor = Color.Transparent,
            };

            var restroomButton1 = new ImageButton
            {
                Source = "pin_restroom.png",
                BackgroundColor = Color.Transparent,
            };
            restroomButton1.Clicked += restroomAlert;
            AbsoluteLayout.SetLayoutBounds(restroomButton1, new Rectangle(0.85, 0.1, 100, 100));
            AbsoluteLayout.SetLayoutFlags(restroomButton1, AbsoluteLayoutFlags.PositionProportional);

            var restroomButton2 = new ImageButton
            {
                Source = "pin_restroom.png",
                BackgroundColor = Color.Transparent,
            };
            restroomButton2.Clicked += restroomAlert;
            AbsoluteLayout.SetLayoutBounds(restroomButton2, new Rectangle(0.75, 0.36, 100, 100));
            AbsoluteLayout.SetLayoutFlags(restroomButton2, AbsoluteLayoutFlags.PositionProportional);

            var restroomButton3 = new ImageButton
            {
                Source = "pin_restroom.png",
                BackgroundColor = Color.Transparent,
            };
            restroomButton3.Clicked += restroomAlert;
            AbsoluteLayout.SetLayoutBounds(restroomButton3, new Rectangle(0.94, 0.69, 100, 100));
            AbsoluteLayout.SetLayoutFlags(restroomButton3, AbsoluteLayoutFlags.PositionProportional);

            var restroomButton4 = new ImageButton
            {
                Source = "pin_restroom.png",
                BackgroundColor = Color.Transparent,
            };
            restroomButton4.Clicked += restroomAlert;
            AbsoluteLayout.SetLayoutBounds(restroomButton4, new Rectangle(0.62, 0.68, 100, 100));
            AbsoluteLayout.SetLayoutFlags(restroomButton4, AbsoluteLayoutFlags.PositionProportional);

            var restroomButton5 = new ImageButton
            {
                Source = "pin_restroom.png",
                BackgroundColor = Color.Transparent,
            };
            restroomButton5.Clicked += restroomAlert;
            AbsoluteLayout.SetLayoutBounds(restroomButton5, new Rectangle(0.55, 0.95, 100, 100));
            AbsoluteLayout.SetLayoutFlags(restroomButton5, AbsoluteLayoutFlags.PositionProportional);

            var restroomButton6 = new ImageButton
            {
                Source = "pin_restroom.png",
                BackgroundColor = Color.Transparent,
            };
            restroomButton6.Clicked += restroomAlert;
            AbsoluteLayout.SetLayoutBounds(restroomButton6, new Rectangle(0.11, 0.95, 100, 100));
            AbsoluteLayout.SetLayoutFlags(restroomButton6, AbsoluteLayoutFlags.PositionProportional);

            var barButton1 = new ImageButton
            {
                Source = "pin_bar.png",
                BackgroundColor = Color.Transparent,
            };
            barButton1.Clicked += bar1Alert;
            AbsoluteLayout.SetLayoutBounds(barButton1, new Rectangle(0.75, 0.69, 100, 100));
            AbsoluteLayout.SetLayoutFlags(barButton1, AbsoluteLayoutFlags.PositionProportional);

            var barButton2 = new ImageButton
            {
                Source = "pin_bar.png",
                BackgroundColor = Color.Transparent,
            };
            barButton2.Clicked += bar1Alert;
            AbsoluteLayout.SetLayoutBounds(barButton2, new Rectangle(0.69, 0.69, 100, 100));
            AbsoluteLayout.SetLayoutFlags(barButton2, AbsoluteLayoutFlags.PositionProportional);

            var foodButton1 = new ImageButton
            {
                Source = "pin_food.png",
                BackgroundColor = Color.Transparent,
            };
            foodButton1.Clicked += food1Alert;
            AbsoluteLayout.SetLayoutBounds(foodButton1, new Rectangle(0.73, 0.10, 100, 100));
            AbsoluteLayout.SetLayoutFlags(foodButton1, AbsoluteLayoutFlags.PositionProportional);

            var foodButton2 = new ImageButton
            {
                Source = "pin_food.png",
                BackgroundColor = Color.Transparent,
            };
            foodButton2.Clicked += food1Alert;
            AbsoluteLayout.SetLayoutBounds(foodButton2, new Rectangle(0.73, 0.14, 100, 100));
            AbsoluteLayout.SetLayoutFlags(foodButton2, AbsoluteLayoutFlags.PositionProportional);

            var foodButton3 = new ImageButton
            {
                Source = "pin_food.png",
                BackgroundColor = Color.Transparent,
            };
            foodButton3.Clicked += food1Alert;
            AbsoluteLayout.SetLayoutBounds(foodButton3, new Rectangle(0.88, 0.59, 100, 100));
            AbsoluteLayout.SetLayoutFlags(foodButton3, AbsoluteLayoutFlags.PositionProportional);

            var foodButton4 = new ImageButton
            {
                Source = "pin_food.png",
                BackgroundColor = Color.Transparent,
            };
            foodButton4.Clicked += food1Alert;
            AbsoluteLayout.SetLayoutBounds(foodButton4, new Rectangle(0.42, 0.95, 100, 100));
            AbsoluteLayout.SetLayoutFlags(foodButton4, AbsoluteLayoutFlags.PositionProportional);

            var foodButton5 = new ImageButton
            {
                Source = "pin_food.png",
                BackgroundColor = Color.Transparent,
            };
            foodButton5.Clicked += food1Alert;
            AbsoluteLayout.SetLayoutBounds(foodButton5, new Rectangle(0.34, 0.95, 100, 100));
            AbsoluteLayout.SetLayoutFlags(foodButton5, AbsoluteLayoutFlags.PositionProportional);

            var foodButton6 = new ImageButton
            {
                Source = "pin_food.png",
                BackgroundColor = Color.Transparent,
            };
            foodButton6.Clicked += food1Alert;
            AbsoluteLayout.SetLayoutBounds(foodButton6, new Rectangle(0.37, 1.003, 100, 100));
            AbsoluteLayout.SetLayoutFlags(foodButton6, AbsoluteLayoutFlags.PositionProportional);

            var escalatorButton1 = new ImageButton
            {
                Source = "pin_escalator.png",
                BackgroundColor = Color.Transparent,
            };
            escalatorButton1.Clicked += escalator1Alert;
            AbsoluteLayout.SetLayoutBounds(escalatorButton1, new Rectangle(0.70, 0.59, 100, 100));
            AbsoluteLayout.SetLayoutFlags(escalatorButton1, AbsoluteLayoutFlags.PositionProportional);

            var escalatorButton2 = new ImageButton
            {
                Source = "pin_escalator.png",
                BackgroundColor = Color.Transparent,
            };
            escalatorButton2.Clicked += escalator1Alert;
            AbsoluteLayout.SetLayoutBounds(escalatorButton2, new Rectangle(0.50, 0.67, 100, 100));
            AbsoluteLayout.SetLayoutFlags(escalatorButton2, AbsoluteLayoutFlags.PositionProportional);

            var infoButton1 = new ImageButton
            {
                Source = "pin_info.png",
                BackgroundColor = Color.Transparent,
            };
            infoButton1.Clicked += infoAlert;
            AbsoluteLayout.SetLayoutBounds(infoButton1, new Rectangle(0.76, 0.61, 100, 100));
            AbsoluteLayout.SetLayoutFlags(infoButton1, AbsoluteLayoutFlags.PositionProportional);

            var infoButton2 = new ImageButton
            {
                Source = "pin_info.png",
                BackgroundColor = Color.Transparent,
            };
            infoButton2.Clicked += infoAlert;
            AbsoluteLayout.SetLayoutBounds(infoButton2, new Rectangle(0.94, 0.67, 100, 100));
            AbsoluteLayout.SetLayoutFlags(infoButton2, AbsoluteLayoutFlags.PositionProportional);

            var gateButton1_1 = new ImageButton
            {
                Source = "pin_Gate1.png",
                BackgroundColor = Color.Transparent,
            };
            gateButton1_1.Clicked += gateAlert;
            AbsoluteLayout.SetLayoutBounds(gateButton1_1, new Rectangle(0.83, 0.36, 100, 100));
            AbsoluteLayout.SetLayoutFlags(gateButton1_1, AbsoluteLayoutFlags.PositionProportional);

            var gateButton1_2 = new ImageButton
            {
                Source = "pin_Gate2.png",
                BackgroundColor = Color.Transparent,
            };
            gateButton1_2.Clicked += gateAlert;
            AbsoluteLayout.SetLayoutBounds(gateButton1_2, new Rectangle(0.75, 0.30, 100, 100));
            AbsoluteLayout.SetLayoutFlags(gateButton1_2, AbsoluteLayoutFlags.PositionProportional);

            var gateButton1_3 = new ImageButton
            {
                Source = "pin_Gate3.png",
                BackgroundColor = Color.Transparent,
            };
            gateButton1_3.Clicked += gateAlert;
            AbsoluteLayout.SetLayoutBounds(gateButton1_3, new Rectangle(0.83, 0.25, 100, 100));
            AbsoluteLayout.SetLayoutFlags(gateButton1_3, AbsoluteLayoutFlags.PositionProportional);

            var gateButton1_5 = new ImageButton
            {
                Source = "pin_Gate5.png",
                BackgroundColor = Color.Transparent,
            };
            gateButton1_5.Clicked += gateAlert;
            AbsoluteLayout.SetLayoutBounds(gateButton1_5, new Rectangle(0.83, 0.04, 100, 100));
            AbsoluteLayout.SetLayoutFlags(gateButton1_5, AbsoluteLayoutFlags.PositionProportional);

            var gateButton1_6 = new ImageButton
            {
                Source = "pin_Gate6.png",
                BackgroundColor = Color.Transparent,
            };
            gateButton1_6.Clicked += gateAlert;
            AbsoluteLayout.SetLayoutBounds(gateButton1_6, new Rectangle(0.75, 0.04, 100, 100));
            AbsoluteLayout.SetLayoutFlags(gateButton1_6, AbsoluteLayoutFlags.PositionProportional);

            var gateButton1_7 = new ImageButton
            {
                Source = "pin_Gate7.png",
                BackgroundColor = Color.Transparent,
            };
            gateButton1_7.Clicked += gateAlert;
            AbsoluteLayout.SetLayoutBounds(gateButton1_7, new Rectangle(0.83, 0.0, 100, 100));
            AbsoluteLayout.SetLayoutFlags(gateButton1_7, AbsoluteLayoutFlags.PositionProportional);

            var gateButton2_1 = new ImageButton
            {
                Source = "pin_Gate1.png",
                BackgroundColor = Color.Transparent,
            };
            gateButton2_1.Clicked += gateAlert;
            AbsoluteLayout.SetLayoutBounds(gateButton2_1, new Rectangle(0.93, 0.95, 100, 100));
            AbsoluteLayout.SetLayoutFlags(gateButton2_1, AbsoluteLayoutFlags.PositionProportional);

            var gateButton2_2 = new ImageButton
            {
                Source = "pin_Gate2.png",
                BackgroundColor = Color.Transparent,
            };
            gateButton2_2.Clicked += gateAlert;
            AbsoluteLayout.SetLayoutBounds(gateButton2_2, new Rectangle(0.93, 0.99, 100, 100));
            AbsoluteLayout.SetLayoutFlags(gateButton2_2, AbsoluteLayoutFlags.PositionProportional);

            var gateButton2_3 = new ImageButton
            {
                Source = "pin_Gate3.png",
                BackgroundColor = Color.Transparent,
            };
            gateButton2_3.Clicked += gateAlert;
            AbsoluteLayout.SetLayoutBounds(gateButton2_3, new Rectangle(0.85, 1.003, 100, 100));
            AbsoluteLayout.SetLayoutFlags(gateButton2_3, AbsoluteLayoutFlags.PositionProportional);

            var gateButton2_4 = new ImageButton
            {
                Source = "pin_Gate4.png",
                BackgroundColor = Color.Transparent,
            };
            gateButton2_4.Clicked += gateAlert;
            AbsoluteLayout.SetLayoutBounds(gateButton2_4, new Rectangle(0.70, 1.003, 100, 100));
            AbsoluteLayout.SetLayoutFlags(gateButton2_4, AbsoluteLayoutFlags.PositionProportional);

            var gateButton2_5 = new ImageButton
            {
                Source = "pin_Gate5.png",
                BackgroundColor = Color.Transparent,
            };
            gateButton2_5.Clicked += gateAlert;
            AbsoluteLayout.SetLayoutBounds(gateButton2_5, new Rectangle(0.62, 1.003, 100, 100));
            AbsoluteLayout.SetLayoutFlags(gateButton2_5, AbsoluteLayoutFlags.PositionProportional);

            var gateButton2_6 = new ImageButton
            {
                Source = "pin_Gate6.png",
                BackgroundColor = Color.Transparent,
            };
            gateButton2_6.Clicked += gateAlert;
            AbsoluteLayout.SetLayoutBounds(gateButton2_6, new Rectangle(0.44, 1.003, 100, 100));
            AbsoluteLayout.SetLayoutFlags(gateButton2_6, AbsoluteLayoutFlags.PositionProportional);

            var gateButton2_7 = new ImageButton
            {
                Source = "pin_Gate7.png",
                BackgroundColor = Color.Transparent,
            };
            gateButton2_7.Clicked += gateAlert;
            AbsoluteLayout.SetLayoutBounds(gateButton2_7, new Rectangle(0.26, 1.003, 100, 100));
            AbsoluteLayout.SetLayoutFlags(gateButton2_7, AbsoluteLayoutFlags.PositionProportional);

            var gateButton2_8 = new ImageButton
            {
                Source = "pin_Gate8.png",
                BackgroundColor = Color.Transparent,
            };
            gateButton2_8.Clicked += gateAlert;
            AbsoluteLayout.SetLayoutBounds(gateButton2_8, new Rectangle(0.19, 1.003, 100, 100));
            AbsoluteLayout.SetLayoutFlags(gateButton2_8, AbsoluteLayoutFlags.PositionProportional);

            var backButton = new ImageButton
            {
                Source = "pin_back.png",
                BackgroundColor = Color.Transparent,
            };
            backButton.Clicked += showPrescottMainButton;
            AbsoluteLayout.SetLayoutBounds(backButton, new Rectangle(0, 0, 100, 100));
            AbsoluteLayout.SetLayoutFlags(backButton, AbsoluteLayoutFlags.PositionProportional);

            MapLayout.Children.Add(mainMap);
            MapLayout.Children.Add(restroomButton1);
            MapLayout.Children.Add(restroomButton2);
            MapLayout.Children.Add(restroomButton3);
            MapLayout.Children.Add(restroomButton4);
            MapLayout.Children.Add(restroomButton5);
            MapLayout.Children.Add(restroomButton6);
            MapLayout.Children.Add(barButton1);
            MapLayout.Children.Add(barButton2);
            MapLayout.Children.Add(foodButton1);
            MapLayout.Children.Add(foodButton2);
            MapLayout.Children.Add(foodButton3);
            MapLayout.Children.Add(foodButton4);
            MapLayout.Children.Add(foodButton5);
            MapLayout.Children.Add(foodButton6);
            MapLayout.Children.Add(escalatorButton1);
            MapLayout.Children.Add(escalatorButton2);
            MapLayout.Children.Add(infoButton1);
            MapLayout.Children.Add(infoButton2);
            MapLayout.Children.Add(gateButton1_1);
            MapLayout.Children.Add(gateButton1_2);
            MapLayout.Children.Add(gateButton1_3);
            MapLayout.Children.Add(gateButton1_5);
            MapLayout.Children.Add(gateButton1_6);
            MapLayout.Children.Add(gateButton1_7);
            MapLayout.Children.Add(gateButton2_1);
            MapLayout.Children.Add(gateButton2_2);
            MapLayout.Children.Add(gateButton2_3);
            MapLayout.Children.Add(gateButton2_4);
            MapLayout.Children.Add(gateButton2_5);
            MapLayout.Children.Add(gateButton2_6);
            MapLayout.Children.Add(gateButton2_7);
            MapLayout.Children.Add(gateButton2_8);
            MapLayout.Children.Add(backButton);
        }
        void showPrescottTerminal4(object sender, EventArgs args)
        {
            MapScroll.ScrollToAsync(250, 0, false);
            MapLayout.Children.Clear();

            var mainMap = new Image
            {
                Source = "PHXTerminal4.png",
                BackgroundColor = Color.Transparent,
            };

            var GateButton2 = new ImageButton
            {
                Source = "pin_Gate2.png",
                BackgroundColor = Color.Transparent,
            };
            GateButton2.Clicked += gateAlert;
            AbsoluteLayout.SetLayoutBounds(GateButton2, new Rectangle(0.33, 0.33, 100, 100));
            AbsoluteLayout.SetLayoutFlags(GateButton2, AbsoluteLayoutFlags.PositionProportional);

            var GateButton1 = new ImageButton
            {
                Source = "pin_Gate1.png",
                BackgroundColor = Color.Transparent,
            };
            GateButton1.Clicked += gateAlert;
            AbsoluteLayout.SetLayoutBounds(GateButton1, new Rectangle(0, 0.33, 100, 100));
            AbsoluteLayout.SetLayoutFlags(GateButton1, AbsoluteLayoutFlags.PositionProportional);

            var GateButton3 = new ImageButton
            {
                Source = "pin_Gate3.png",
                BackgroundColor = Color.Transparent,
            };
            GateButton3.Clicked += gateAlert;
            AbsoluteLayout.SetLayoutBounds(GateButton3, new Rectangle(0.67, 0.33, 100, 100));
            AbsoluteLayout.SetLayoutFlags(GateButton3, AbsoluteLayoutFlags.PositionProportional);

            var GateButton4 = new ImageButton
            {
                Source = "pin_Gate4.png",
                BackgroundColor = Color.Transparent,
            };
            GateButton4.Clicked += gateAlert;
            AbsoluteLayout.SetLayoutBounds(GateButton4, new Rectangle(1, 0.33, 100, 100));
            AbsoluteLayout.SetLayoutFlags(GateButton4, AbsoluteLayoutFlags.PositionProportional);

            var GateButton7 = new ImageButton
            {
                Source = "pin_Gate7.png",
                BackgroundColor = Color.Transparent,
            };
            GateButton7.Clicked += gateAlert;
            AbsoluteLayout.SetLayoutBounds(GateButton7, new Rectangle(1, 0.82, 100, 100));
            AbsoluteLayout.SetLayoutFlags(GateButton7, AbsoluteLayoutFlags.PositionProportional);

            var GateButton6 = new ImageButton
            {
                Source = "pin_Gate6.png",
                BackgroundColor = Color.Transparent,
            };
            GateButton6.Clicked += gateAlert;
            AbsoluteLayout.SetLayoutBounds(GateButton6, new Rectangle(0.67, 0.82, 100, 100));
            AbsoluteLayout.SetLayoutFlags(GateButton6, AbsoluteLayoutFlags.PositionProportional);

            var GateButton5 = new ImageButton
            {
                Source = "pin_Gate5.png",
                BackgroundColor = Color.Transparent,
            };
            GateButton5.Clicked += gateAlert;
            AbsoluteLayout.SetLayoutBounds(GateButton5, new Rectangle(0.33, 0.82, 100, 100));
            AbsoluteLayout.SetLayoutFlags(GateButton5, AbsoluteLayoutFlags.PositionProportional);

            var ParkingButton1 = new ImageButton
            {
                Source = "pin_CarRental.png",
                BackgroundColor = Color.Transparent,
            };
            ParkingButton1.Clicked += parkingAlert;
            AbsoluteLayout.SetLayoutBounds(ParkingButton1, new Rectangle(0.84, 0.6, 100, 100));
            AbsoluteLayout.SetLayoutFlags(ParkingButton1, AbsoluteLayoutFlags.PositionProportional);

            var foodButton1 = new ImageButton
            {
                Source = "pin_food.png",
                BackgroundColor = Color.Transparent,
            };
            foodButton1.Clicked += food1Alert;
            AbsoluteLayout.SetLayoutBounds(foodButton1, new Rectangle(0.68, 0.6, 100, 100));
            AbsoluteLayout.SetLayoutFlags(foodButton1, AbsoluteLayoutFlags.PositionProportional);

            var escalator1Button = new ImageButton
            {
                Source = "pin_escalator.png",
                BackgroundColor = Color.Transparent,
            };
            escalator1Button.Clicked += escalator1Alert;
            AbsoluteLayout.SetLayoutBounds(escalator1Button, new Rectangle(0.61, 0.6, 100, 100));
            AbsoluteLayout.SetLayoutFlags(escalator1Button, AbsoluteLayoutFlags.PositionProportional);

            var escalator2Button = new ImageButton
            {
                Source = "pin_escalator.png",
                BackgroundColor = Color.Transparent,
            };
            escalator2Button.Clicked += escalator1Alert;
            AbsoluteLayout.SetLayoutBounds(escalator2Button, new Rectangle(0.39, 0.6, 100, 100));
            AbsoluteLayout.SetLayoutFlags(escalator2Button, AbsoluteLayoutFlags.PositionProportional);

            var barButton1 = new ImageButton
            {
                Source = "pin_Bar.png",
                BackgroundColor = Color.Transparent,
            };
            barButton1.Clicked += bar1Alert;
            AbsoluteLayout.SetLayoutBounds(barButton1, new Rectangle(0.31, 0.6, 100, 100));
            AbsoluteLayout.SetLayoutFlags(barButton1, AbsoluteLayoutFlags.PositionProportional);

            var ParkingButton2 = new ImageButton
            {
                Source = "pin_CarRental.png",
                BackgroundColor = Color.Transparent,
            };
            ParkingButton2.Clicked += parkingAlert;
            AbsoluteLayout.SetLayoutBounds(ParkingButton2, new Rectangle(0.22, 0.6, 100, 100));
            AbsoluteLayout.SetLayoutFlags(ParkingButton2, AbsoluteLayoutFlags.PositionProportional);

            var foodButton2 = new ImageButton
            {
                Source = "pin_food.png",
                BackgroundColor = Color.Transparent,
            };
            foodButton2.Clicked += food1Alert;
            AbsoluteLayout.SetLayoutBounds(foodButton2, new Rectangle(0, 0, 100, 100));
            AbsoluteLayout.SetLayoutFlags(foodButton2, AbsoluteLayoutFlags.PositionProportional);

            var foodButton3 = new ImageButton
            {
                Source = "pin_food.png",
                BackgroundColor = Color.Transparent,
            };
            foodButton3.Clicked += food1Alert;
            AbsoluteLayout.SetLayoutBounds(foodButton3, new Rectangle(0, 0.15, 100, 100));
            AbsoluteLayout.SetLayoutFlags(foodButton3, AbsoluteLayoutFlags.PositionProportional);

            var foodButton4 = new ImageButton
            {
                Source = "pin_food.png",
                BackgroundColor = Color.Transparent,
            };
            foodButton4.Clicked += food1Alert;
            AbsoluteLayout.SetLayoutBounds(foodButton4, new Rectangle(0.33, 0, 100, 100));
            AbsoluteLayout.SetLayoutFlags(foodButton4, AbsoluteLayoutFlags.PositionProportional);

            var foodButton5 = new ImageButton
            {
                Source = "pin_food.png",
                BackgroundColor = Color.Transparent,
            };
            foodButton5.Clicked += food1Alert;
            AbsoluteLayout.SetLayoutBounds(foodButton5, new Rectangle(0.33, 0.15, 100, 100));
            AbsoluteLayout.SetLayoutFlags(foodButton5, AbsoluteLayoutFlags.PositionProportional);

            var infoButton = new ImageButton
            {
                Source = "pin_Info.png",
                BackgroundColor = Color.Transparent,
            };
            infoButton.Clicked += infoAlert;
            AbsoluteLayout.SetLayoutBounds(infoButton, new Rectangle(0.67, 0, 100, 100));
            AbsoluteLayout.SetLayoutFlags(infoButton, AbsoluteLayoutFlags.PositionProportional);

            var foodButton6 = new ImageButton
            {
                Source = "pin_food.png",
                BackgroundColor = Color.Transparent,
            };
            foodButton6.Clicked += food1Alert;
            AbsoluteLayout.SetLayoutBounds(foodButton6, new Rectangle(0.67, 0.15, 100, 100));
            AbsoluteLayout.SetLayoutFlags(foodButton6, AbsoluteLayoutFlags.PositionProportional);


            var infoButton2 = new ImageButton
            {
                Source = "pin_Info.png",
                BackgroundColor = Color.Transparent,
            };
            infoButton2.Clicked += infoAlert;
            AbsoluteLayout.SetLayoutBounds(infoButton2, new Rectangle(1, 0.15, 100, 100));
            AbsoluteLayout.SetLayoutFlags(infoButton2, AbsoluteLayoutFlags.PositionProportional);


            var foodButton7 = new ImageButton
            {
                Source = "pin_food.png",
                BackgroundColor = Color.Transparent,
            };
            foodButton7.Clicked += food1Alert;
            AbsoluteLayout.SetLayoutBounds(foodButton7, new Rectangle(1, 0, 100, 100));
            AbsoluteLayout.SetLayoutFlags(foodButton7, AbsoluteLayoutFlags.PositionProportional);


            var restroomButton1 = new ImageButton
            {
                Source = "pin_restroom.png",
                BackgroundColor = Color.Transparent,
            };
            restroomButton1.Clicked += restroomAlert;
            AbsoluteLayout.SetLayoutBounds(restroomButton1, new Rectangle(.58, 0.48, 100, 100));
            AbsoluteLayout.SetLayoutFlags(restroomButton1, AbsoluteLayoutFlags.PositionProportional);

            var restroomButton2 = new ImageButton
            {
                Source = "pin_restroom.png",
                BackgroundColor = Color.Transparent,
            };
            restroomButton2.Clicked += restroomAlert;
            AbsoluteLayout.SetLayoutBounds(restroomButton2, new Rectangle(.42, 0.48, 100, 100));
            AbsoluteLayout.SetLayoutFlags(restroomButton2, AbsoluteLayoutFlags.PositionProportional);


            var BarButton2 = new ImageButton
            {
                Source = "pin_Bar.png",
                BackgroundColor = Color.Transparent,
            };
            BarButton2.Clicked += bar1Alert;
            AbsoluteLayout.SetLayoutBounds(BarButton2, new Rectangle(.5, 0.73, 100, 100));
            AbsoluteLayout.SetLayoutFlags(BarButton2, AbsoluteLayoutFlags.PositionProportional);


            var infoButton3 = new ImageButton
            {
                Source = "pin_Info.png",
                BackgroundColor = Color.Transparent,
            };
            infoButton3.Clicked += infoAlert;
            AbsoluteLayout.SetLayoutBounds(infoButton3, new Rectangle(.33, 1, 100, 100));
            AbsoluteLayout.SetLayoutFlags(infoButton3, AbsoluteLayoutFlags.PositionProportional);


            var ShopButton = new ImageButton
            {
                Source = "pin_Shop.png",
                BackgroundColor = Color.Transparent,
            };
            ShopButton.Clicked += shopAlert;
            AbsoluteLayout.SetLayoutBounds(ShopButton, new Rectangle(.67, 1, 100, 100));
            AbsoluteLayout.SetLayoutFlags(ShopButton, AbsoluteLayoutFlags.PositionProportional);


            var ServiceButton = new ImageButton
            {
                Source = "pin_Service.png",
                BackgroundColor = Color.Transparent,
            };
            ServiceButton.Clicked += serviceAlert;
            AbsoluteLayout.SetLayoutBounds(ServiceButton, new Rectangle(1, 1, 100, 100));
            AbsoluteLayout.SetLayoutFlags(ServiceButton, AbsoluteLayoutFlags.PositionProportional);


            var shopeButton1 = new ImageButton
            {
                Source = "pin_Shop.png",
                BackgroundColor = Color.Transparent,
            };
            shopeButton1.Clicked += shopAlert;
            AbsoluteLayout.SetLayoutBounds(shopeButton1, new Rectangle(.6, 0.73, 100, 100));
            AbsoluteLayout.SetLayoutFlags(shopeButton1, AbsoluteLayoutFlags.PositionProportional);

            var backButton = new ImageButton
            {
                Source = "pin_back.png",
                BackgroundColor = Color.Transparent,
            };
            backButton.Clicked += showPrescottMainButton;
            AbsoluteLayout.SetLayoutBounds(backButton, new Rectangle(0.16, 0, 100, 100));
            AbsoluteLayout.SetLayoutFlags(backButton, AbsoluteLayoutFlags.PositionProportional);




            MapLayout.Children.Add(mainMap);
            MapLayout.Children.Add(restroomButton1);
            MapLayout.Children.Add(restroomButton2);
            MapLayout.Children.Add(GateButton2);
            MapLayout.Children.Add(GateButton1);
            MapLayout.Children.Add(GateButton3);
            MapLayout.Children.Add(GateButton4);
            MapLayout.Children.Add(GateButton7);
            MapLayout.Children.Add(GateButton6);
            MapLayout.Children.Add(GateButton5);
            MapLayout.Children.Add(ParkingButton1);
            MapLayout.Children.Add(ParkingButton2);
            MapLayout.Children.Add(foodButton1);
            MapLayout.Children.Add(foodButton2);
            MapLayout.Children.Add(foodButton3);
            MapLayout.Children.Add(foodButton4);
            MapLayout.Children.Add(foodButton5);
            MapLayout.Children.Add(foodButton6);
            MapLayout.Children.Add(foodButton7);
            MapLayout.Children.Add(escalator1Button);
            MapLayout.Children.Add(escalator2Button);
            MapLayout.Children.Add(BarButton2);
            MapLayout.Children.Add(barButton1);
            MapLayout.Children.Add(infoButton3);
            MapLayout.Children.Add(infoButton2);
            MapLayout.Children.Add(infoButton);
            MapLayout.Children.Add(ServiceButton);
            MapLayout.Children.Add(ShopButton);
            MapLayout.Children.Add(shopeButton1);
            MapLayout.Children.Add(backButton);

        }
        private void bar1Alert(object sender, EventArgs e)
        {
            DisplayAlert("Bar Location", "Must be 21 and up.", "Done");
        }
        private void shopAlert(object sender, EventArgs e)
        {
            DisplayAlert("Shop Location", "Shop available here. Gifts and food/drinks", "Done");
        }
        private void infoAlert(object sender, EventArgs e)
        {
            DisplayAlert("Info Center", "Info center for assistance or help.", "Done");
        }
        private void food1Alert(object sender, EventArgs e)
        {
            DisplayAlert("Food Location", "Get some grub here.", "Done");
        }
        private void escalator1Alert(object sender, EventArgs e)
        {
            DisplayAlert("Escalator Location", "Escalators and stairs are availble here.", "Done");
        }
        private void gateAlert(object sender, EventArgs e)
        {
            DisplayAlert("Gate Location", "Gate for generic flights. Labeled by number on pin.", "Done");
        }


        // Zoom map in.
        private void ZoomInClicked(object sender, EventArgs args)
        {
            if (scaleCurrent <= 2)
            {
                scaleCurrent = scaleCurrent + 0.5;
            }
        }

        // Zoom map out.
        private void ZoomOutClicked(object sender, EventArgs args)
        {

            if (scaleCurrent >= 1)
            {
                scaleCurrent = scaleCurrent - 0.5;
            }
        }
    }
}
