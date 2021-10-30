using System;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using System.Threading.Tasks;
using System.IO;
using HtmlAgilityPack;
using System.Text.RegularExpressions;

namespace AirportNavigationApp.ViewModels
{
    public class FlightsViewModel : BaseViewModel
    {
        public FlightsViewModel()
        {
            Title = "About";
            WebScraperCommand = new Command(async () => await WebScraper()); // Right now, this task will take data from the specified website and display
                                                                             // It to android debugger console (in the future it will display directly
                                                                             // To user)
        }

        private Task WebScraper()
        {

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
                }

                //Flight #
                foreach (var item in doc.DocumentNode.SelectNodes("//td[@class='c2']"))
                {
                    output = item.OuterHtml;        // here, output is currently the entire line of html
                    int pFrom = output.IndexOf(">") + ">".Length;
                    int pTo = output.LastIndexOf("<");
                    String result = output.Substring(pFrom, pTo - pFrom);   //Substring takes in (first index, last index)
                    Console.WriteLine(result);                              // Now printing only the Flight #
                }

                //To
                foreach (var item in doc.DocumentNode.SelectNodes("//td[@class='c3']"))
                {
                    output = item.OuterHtml;        // here, output is currently the entire line of html
                    int pFrom = output.IndexOf(">") + ">".Length;
                    int pTo = output.LastIndexOf("<");
                    String result = output.Substring(pFrom, pTo - pFrom);   //Substring takes in (first index, last index)
                    Console.WriteLine(result);                              // Now printing only the "To" of the flight data
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
                }

                //Scheduled/Departure Time
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
                    Console.WriteLine(result);                             // Now printing only the Gate
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Some or all of the flight data cannot be read at this time.");
                Console.WriteLine("Please try again later, and report this issue if the error persists");
                Console.WriteLine("Error: " + e);
            }
            return Task.CompletedTask; // Task must be marked completed
        }

        public ICommand WebScraperCommand { get; }
    }
}
