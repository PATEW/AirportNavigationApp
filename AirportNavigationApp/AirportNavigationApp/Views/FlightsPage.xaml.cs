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
        public List<string> listAirline;
        public List<string> listFlightNum;
        public List<string> listDestination;
        public List<string> listStatus;
        public List<string> listSchedT;
        public List<string> listUptT;
        public List<string> listGate;

        void OnUpdateClicked(object sender, EventArgs args) {
            updateFlightInfo();
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
                HtmlAgilityPack.HtmlDocument doc = web.Load("https://tracker.flightview.com/FVAccess2/tools/fids/fidsDefault.asp?accCustId=FVWebFids&fidsId=20001&fidsInit=departures&fidsApt=DAB&fidsFilterAl=&fidsFilterDepap=");
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
                            result = Regex.Replace(result, "&#160;", space); //Replace each of the 5 characters above with just a space


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
                    Console.WriteLine(result);      // Now printing only the Gate
                    listGate.Add(result);
                }



                // CREATE GRID _______________________________________________________________________

                // The amount of rows to be created based on how many airline entries were scraped
                int AmountofLines = listAirline.Count;
                int AmountofColumns = 7; //hard coded amount of columns based on how much information we wish to display

                for (int i=0; i< AmountofColumns; i++)
                {
                    productGrid.ColumnDefinitions.Add(new ColumnDefinition());
                }


                for (int rowIndex = 0; rowIndex < AmountofLines; rowIndex++)
                {
                    try
                    {
                        var labelAirline = new Label
                        {
                            Text = listAirline[rowIndex],
                            VerticalOptions = LayoutOptions.Center,
                            HorizontalOptions = LayoutOptions.Center
                        };
                        productGrid.Children.Add(labelAirline, 0, rowIndex);
                    }
                    catch
                    {
                        var labelAirline = new Label
                        {
                            Text = " ",
                            VerticalOptions = LayoutOptions.Center,
                            HorizontalOptions = LayoutOptions.Center
                        };
                        productGrid.Children.Add(labelAirline, 0, rowIndex);
                    }
                    
                    try
                    {
                        var labelFlightNum = new Label
                        {
                            Text = listFlightNum[rowIndex],
                            VerticalOptions = LayoutOptions.Center,
                            HorizontalOptions = LayoutOptions.Center
                        };
                        productGrid.Children.Add(labelFlightNum, 1, rowIndex);
                    }
                    catch
                    {
                        var labelFlightNum = new Label
                        {
                            Text = " ",
                            VerticalOptions = LayoutOptions.Center,
                            HorizontalOptions = LayoutOptions.Center
                        };
                        productGrid.Children.Add(labelFlightNum, 1, rowIndex);
                    }
                    
                    try
                    {
                        var labelDestination = new Label
                        {
                            Text = listDestination[rowIndex],
                            VerticalOptions = LayoutOptions.Center,
                            HorizontalOptions = LayoutOptions.Center
                        };
                        productGrid.Children.Add(labelDestination, 2, rowIndex);
                    }
                    catch
                    {
                        var labelDestination = new Label
                        {
                            Text = " ",
                            VerticalOptions = LayoutOptions.Center,
                            HorizontalOptions = LayoutOptions.Center
                        };
                        productGrid.Children.Add(labelDestination, 2, rowIndex);
                    }
                    
                    try
                    {
                        var labelStatus = new Label
                        {
                            Text = listStatus[rowIndex],
                            VerticalOptions = LayoutOptions.Center,
                            HorizontalOptions = LayoutOptions.Center
                        };
                        productGrid.Children.Add(labelStatus, 3, rowIndex);
                    }
                    catch
                    {
                        var labelStatus = new Label
                        {
                            Text = " ",
                            VerticalOptions = LayoutOptions.Center,
                            HorizontalOptions = LayoutOptions.Center
                        };
                        productGrid.Children.Add(labelStatus, 3, rowIndex);
                    }
                    
                    try
                    {
                        var labelUptT = new Label
                        {
                            Text = listUptT[rowIndex],
                            VerticalOptions = LayoutOptions.Center,
                            HorizontalOptions = LayoutOptions.Center
                        };
                        productGrid.Children.Add(labelUptT, 4, rowIndex);
                    }
                    catch
                    {
                        var labelUptT = new Label
                        {
                            Text = " ",
                            VerticalOptions = LayoutOptions.Center,
                            HorizontalOptions = LayoutOptions.Center
                        };
                        productGrid.Children.Add(labelUptT, 4, rowIndex);
                    }
                    
                    try
                    {
                        var labelGate = new Label
                        {
                            Text = listGate[rowIndex],
                            VerticalOptions = LayoutOptions.Center,
                            HorizontalOptions = LayoutOptions.Center
                        };
                        productGrid.Children.Add(labelGate, 5, rowIndex);
                    }
                    catch
                    {
                        var labelGate = new Label
                        {
                            Text = " ",
                            VerticalOptions = LayoutOptions.Center,
                            HorizontalOptions = LayoutOptions.Center
                        };
                        productGrid.Children.Add(labelGate, 5, rowIndex);
                    }
                } 




            }
            catch (Exception e)
            {
                Console.WriteLine("Some or all of the flight data cannot be read at this time.");
                Console.WriteLine("Please try again later, and report this issue if the error persists");
                Console.WriteLine("Error: " + e);
            }
        }

        public FlightsPage()
        {
            InitializeComponent();

            BindingContext = this;
        }
    }
}