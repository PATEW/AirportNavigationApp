using AirportNavigationApp.Models;
using AirportNavigationApp.ViewModels;
using AirportNavigationApp.Views;
using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Text.RegularExpressions;

namespace AirportNavigationApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]

    public partial class FlightsPage : ContentPage
    {
        public string viewMessage = "Select Airport on Ticket Page";
        public List<string> listAirline;
        public List<string> listFlightNum;
        public List<string> listDestination;
        public List<string> listStatus;
        public List<string> listSchedT;
        public List<string> listUptT;
        public List<string> listGate;

        // these keep track of how many lines of the grid to show (public so that buttons can use them)
        int maxLines = 30;
        int minLines = 0;

        public FlightsPage()
        {
            InitializeComponent();
            BindingContext = this;
            createHeader();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            if (!App._Airport.Equals("Please Select An Airport"))
            {
                ViewMessage = " Flight Information For: " + App._Airport;
                updateFlightInfo();
                updateGrid();
            }
        }

        public void updateFlightInfo()
        {
            listAirline = new List<string>();
            listFlightNum = new List<string>();
            listDestination = new List<string>();
            listStatus = new List<string>();
            listSchedT = new List<string>();
            listUptT = new List<string>();
            listGate = new List<string>();

            try  // Keep the app from crashing incase there are ever problems reaching the website
            {
                //HTML agility pack from projectNUget package
                HtmlAgilityPack.HtmlWeb web = new HtmlAgilityPack.HtmlWeb();
                HtmlAgilityPack.HtmlDocument doc = web.Load("https://tracker.flightview.com/FVAccess2/tools/fids/fidsDefault.asp?accCustId=FVWebFids&fidsId=20001&fidsInit=departures&fidsApt=" + App._Airport + "&fidsFilterAl=&fidsFilterDepap=");
                string output; //empty string to hold raw output from web

                //Airline
                foreach (var item in doc.DocumentNode.SelectNodes("//td[@class='ffAlLbl']"))
                {
                    output = item.OuterHtml;            // here, output is currently the entire line of html 
                    int pFrom = output.IndexOf(">") + ">".Length;
                    int pTo = output.LastIndexOf("<");
                    String result = output.Substring(pFrom, pTo - pFrom);   //Substring takes in (first index, last index)
                    Console.WriteLine(result);                              // Now printing only the Airline
                    listAirline.Add(result);
                }

                //Flight #
                foreach (var item in doc.DocumentNode.SelectNodes("//td[@class='c2']"))
                {
                    output = item.OuterHtml;        // here, output is currently the entire line of html
                    int pFrom = output.IndexOf(">") + ">".Length;
                    int pTo = output.LastIndexOf("<");
                    String result = output.Substring(pFrom, pTo - pFrom);   //Substring takes in (first index, last index)
                    Console.WriteLine(result);                              // Now printing only the Flight #
                    listFlightNum.Add(result);
                }

                //Destination
                foreach (var item in doc.DocumentNode.SelectNodes("//td[@class='c3']"))
                {
                    output = item.OuterHtml;        // here, output is currently the entire line of html
                    int pFrom = output.IndexOf(">") + ">".Length;
                    int pTo = output.LastIndexOf("<");
                    String result = output.Substring(pFrom, pTo - pFrom);   //Substring takes in (first index, last index)
                    Console.WriteLine(result);                              // Now printing only the "To" of the flight data
                    listDestination.Add(result);
                }

                //Status
                foreach (var item in doc.DocumentNode.SelectNodes("//td[@class='c4']"))
                {
                    output = item.OuterHtml;        // This one is different, the output is a long block of html that needs to be trimmed twice
                    int pFrom = output.IndexOf("'") + "'".Length;
                    int pTo = output.LastIndexOf("a");
                    String firstTrim = output.Substring(pFrom, pTo - pFrom);    // First trim
                    int pFrom2 = firstTrim.IndexOf(">") + ">".Length;
                    int pTo2 = firstTrim.LastIndexOf("<");
                    String result = firstTrim.Substring(pFrom2, pTo2 - pFrom2); // Second trim
                    Console.WriteLine(result);      // Now printing only the Status of the flight data
                    listStatus.Add(result);
                }

                //Scheduled/updated Time
                foreach (var item in doc.DocumentNode.SelectNodes("//*[@id=\"fvData\"]"))
                {
                    int lastFound = 1; // Int that keeps track of the last found location of a time

                    while (lastFound != 0) // This will repeat until there are no more cases of "-->" in the file
                    {
                        output = item.OuterHtml;    // The Time does not use a class and thus output is now equal to the entire html file
                        int pFrom = output.IndexOf("-->", lastFound) + "-->".Length;    // Parse the page for an arrow (used before every time) with the value of last found if it already found one
                        lastFound = output.IndexOf("-->", lastFound) + 1; // Make lastFound equal to the value of the last found arrow plus one
                        int pTo = output.IndexOf("</", lastFound);
                        String result = output.Substring(pFrom, pTo - pFrom); // Trim output

                        if (lastFound != 0) // if this is not here then it will print entire file at the end
                        {

                            // cut "&#160;" that's in middle of every string (has to do with how they store time in html)
                            string space = " ";
                            result = Regex.Replace(result, "&#160;", space); //Replace all 5 characters above with just a space


                            Console.WriteLine(result);

                            // this will keep track of scheduled/updated time
                            bool counter = false;

                            if (counter == false)
                            {
                                listSchedT.Add(result);
                                counter = true;
                            }
                            else
                            {
                                listUptT.Add(result);
                                counter = false;
                            }
                        }
                    }
                }

                //Gate
                foreach (var item in doc.DocumentNode.SelectNodes("//td[@class='c7']"))
                {
                    output = item.OuterHtml;                            //here, output is currently the entire line of html
                    int pFrom = output.IndexOf(">") + ">".Length;
                    int pTo = output.LastIndexOf("<");
                    String result = output.Substring(pFrom, pTo - pFrom);   //Substring takes in (first index, last index)
                    
                    // if the website has no gate, it will grab "&nbsp;", we will replace this with "N/A"
                    String noGate = "N/A";
                    result = Regex.Replace(result, "&nbsp;", noGate);

                    Console.WriteLine(result);      // Now printing only the Gate
                    listGate.Add(result);
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("Some or all of the flight data cannot be read at this time.");
                Console.WriteLine("Please try again later, and report this issue if the error persists");
                Console.WriteLine("Error: " + e);
            }
        }

        public void createHeader()
        {
            var flightNumberHeader = new Label
            {
                Text = "Flight #",
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center,
                TextColor = Color.White
            };
            gridHeader.Children.Add(flightNumberHeader, 0, 0);
            Grid.SetRowSpan(flightNumberHeader, 2);

            var destinationHeader = new Label
            {
                Text = "Target",
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center,
                TextColor = Color.White
            };
            gridHeader.Children.Add(destinationHeader, 1, 0);
            Grid.SetRowSpan(destinationHeader, 2);

            var airlineHeader = new Label
            {
                Text = "Airline",
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center,
                TextColor = Color.White
            };
            gridHeader.Children.Add(airlineHeader, 2, 0);
            Grid.SetRowSpan(airlineHeader, 2);

            var locationHeader = new Label
            {
                Text = "Terminal-Gate",
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center,
                TextColor = Color.White
            };
            gridHeader.Children.Add(locationHeader, 3, 0);
            Grid.SetRowSpan(locationHeader, 2);

            var departureTimeHeader = new Label
            {
                Text = "Time",
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center,
                TextColor = Color.White
            };
            gridHeader.Children.Add(departureTimeHeader, 4, 0);
            Grid.SetRowSpan(departureTimeHeader, 2);

            var statusHeader = new Label
            {
                Text = "Status",
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center,
                TextColor = Color.White
            };
            gridHeader.Children.Add(statusHeader, 5, 0);
            Grid.SetRowSpan(statusHeader, 2);

            BoxView border = new BoxView
            {
                HeightRequest = 1,
                Color = Color.White,
                VerticalOptions = LayoutOptions.End,
            };
            gridHeader.Children.Add(border, 0, 1);
            Grid.SetColumnSpan(border, 6);
        }

        public void updateGrid()
        {
            // CREATE GRID _______________________________________________________________________
            // The amount of rows to be created based on how many airline entries were scraped
            Grid productGrid = new Grid();
            int AmountofLines;
            bool showNext = false;
            bool showPrev = false;


            // if the listAirline.count > 30, then only display the first 30
            if (listAirline.Count < 30) {
                 AmountofLines = listAirline.Count;
            } 
            else
            {
                AmountofLines = maxLines;

                // this bool lets the program know to show a show next button
                showNext = true;

            }
            
            // if the minLines > 0 (meaning you are on a page other than 1) show the Prevbutton
            if (minLines > 0)
            {
                showPrev = true;
            }
            else
            {
                showPrev = false;
            }

            // prevents a bug where there will be a large gap before subsuquent pages after pressing next
            int RelativeRowIndex = 0;

            for (int rowIndex = minLines; rowIndex < AmountofLines; rowIndex++)
            {
                BoxView border1 = new BoxView
                {
                    HeightRequest = 1,
                    Color = Color.White,
                    VerticalOptions = LayoutOptions.End,
                };
                productGrid.Children.Add(border1, 0, RelativeRowIndex);

                try
                {
                    var labelAirline = new Label
                    {
                        Text = listAirline[rowIndex],
                        VerticalOptions = LayoutOptions.Center,
                        HorizontalOptions = LayoutOptions.Center,
                        TextColor = Color.White
                    };
                    productGrid.Children.Add(labelAirline, 2, RelativeRowIndex);
                }
                catch
                {
                    var labelAirline = new Label
                    {
                        Text = " ",
                        VerticalOptions = LayoutOptions.Center,
                        HorizontalOptions = LayoutOptions.Center,
                        TextColor = Color.White
                    };
                    productGrid.Children.Add(labelAirline, 2, RelativeRowIndex);
                }
                BoxView border2 = new BoxView
                {
                    HeightRequest = 1,
                    Color = Color.White,
                    VerticalOptions = LayoutOptions.End,
                };
                productGrid.Children.Add(border2, 1, RelativeRowIndex);

                try
                {
                    var labelFlightNum = new Label
                    {
                        Text = listFlightNum[rowIndex],
                        VerticalOptions = LayoutOptions.Center,
                        HorizontalOptions = LayoutOptions.Center,
                        TextColor = Color.White
                    };
                    productGrid.Children.Add(labelFlightNum, 0, RelativeRowIndex);
                }
                catch
                {
                    var labelFlightNum = new Label
                    {
                        Text = " ",
                        VerticalOptions = LayoutOptions.Center,
                        HorizontalOptions = LayoutOptions.Center,
                        TextColor = Color.White
                    };
                    productGrid.Children.Add(labelFlightNum, 0, RelativeRowIndex);
                }
                BoxView border3 = new BoxView
                {
                    HeightRequest = 1,
                    Color = Color.White,
                    VerticalOptions = LayoutOptions.End,
                };
                productGrid.Children.Add(border3, 2, RelativeRowIndex);

                try
                {
                    var labelDestination = new Label
                    {
                        Text = listDestination[rowIndex],
                        VerticalOptions = LayoutOptions.Center,
                        HorizontalOptions = LayoutOptions.Center,
                        TextColor = Color.White
                    };
                    productGrid.Children.Add(labelDestination, 1, RelativeRowIndex);
                }
                catch
                {
                    var labelDestination = new Label
                    {
                        Text = " ",
                        VerticalOptions = LayoutOptions.Center,
                        HorizontalOptions = LayoutOptions.Center,
                        TextColor = Color.White
                    };
                    productGrid.Children.Add(labelDestination, 1, RelativeRowIndex);
                }
                BoxView border4 = new BoxView
                {
                    HeightRequest = 1,
                    Color = Color.White,
                    VerticalOptions = LayoutOptions.End,
                };
                productGrid.Children.Add(border4, 3, RelativeRowIndex);

                try
                {
                    var labelStatus = new Label
                    {
                        Text = listStatus[rowIndex],
                        VerticalOptions = LayoutOptions.Center,
                        HorizontalOptions = LayoutOptions.Center,
                        TextColor = Color.White
                    };
                    productGrid.Children.Add(labelStatus, 5, RelativeRowIndex);
                }
                catch
                {
                    var labelStatus = new Label
                    {
                        Text = " ",
                        VerticalOptions = LayoutOptions.Center,
                        HorizontalOptions = LayoutOptions.Center,
                        TextColor = Color.White
                    };
                    productGrid.Children.Add(labelStatus, 5, RelativeRowIndex);
                }
                BoxView border5 = new BoxView
                {
                    HeightRequest = 1,
                    Color = Color.White,
                    VerticalOptions = LayoutOptions.End,
                };
                productGrid.Children.Add(border5, 4, RelativeRowIndex);

                try
                {
                    var labelUptT = new Label
                    {
                        Text = listSchedT[rowIndex],
                        VerticalOptions = LayoutOptions.Center,
                        HorizontalOptions = LayoutOptions.Center,
                        TextColor = Color.White
                    };
                    productGrid.Children.Add(labelUptT, 4, RelativeRowIndex);
                }
                catch
                {
                    var labelUptT = new Label
                    {
                        Text = " ",
                        VerticalOptions = LayoutOptions.Center,
                        HorizontalOptions = LayoutOptions.Center,
                        TextColor = Color.White
                    };
                    productGrid.Children.Add(labelUptT, 4, RelativeRowIndex);
                }
                BoxView border6 = new BoxView
                {
                    HeightRequest = 1,
                    Color = Color.White,
                    VerticalOptions = LayoutOptions.End,
                };
                productGrid.Children.Add(border6, 5, RelativeRowIndex);

                try
                {
                    var labelGate = new Label
                    {
                        Text = listGate[rowIndex],
                        VerticalOptions = LayoutOptions.Center,
                        HorizontalOptions = LayoutOptions.Center,
                        TextColor = Color.White
                    };
                    productGrid.Children.Add(labelGate, 3, RelativeRowIndex);
                }
                catch
                {
                    var labelGate = new Label
                    {
                        Text = " ",
                        VerticalOptions = LayoutOptions.Center,
                        HorizontalOptions = LayoutOptions.Center,
                        TextColor = Color.White
                    };
                    productGrid.Children.Add(labelGate, 3, RelativeRowIndex);
                }

                // add 1 to the relative row index
                RelativeRowIndex += 1;
            }

            if (showNext == true && minLines < listAirline.Count)
            {
                var showNextButton = new Button {

                    Text = "Next",
                    VerticalOptions = LayoutOptions.Center,
                    HorizontalOptions = LayoutOptions.Center,
                    TextColor = Color.White,

                };
                productGrid.Children.Add(showNextButton, 3, RelativeRowIndex);
                showNextButton.Clicked += nextButtonAction;

            }

            if (showPrev == true)
            {
                var showPrevButton = new Button
                {

                    Text = "Previous",
                    VerticalOptions = LayoutOptions.Center,
                    HorizontalOptions = LayoutOptions.Center,
                    TextColor = Color.White,
                };
                productGrid.Children.Add(showPrevButton, 2, RelativeRowIndex);
                showPrevButton.Clicked += prevButtonAction;

            }

            flightView.Content = productGrid;
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


        private void nextButtonAction(object sender, EventArgs e)
        {
            // change the value of maxLines/minLines and update the grid again
            maxLines += 30;
            minLines += 30;
            // update the grid again
            updateGrid();
        }


        private void prevButtonAction(object sender, EventArgs e)
        {
            // change the value of maxLines/minLines and update the grid again
            maxLines -= 30;
            minLines -= 30;
            // update the grid again
            updateGrid();
        }

    }
}