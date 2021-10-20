using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AirportInfo
{
    class Program
    {
        static void Main(string[] args)
        {
            //CSV: comma separated values
            ReadCSVFile();
            Console.ReadLine();
        }
        static void ReadCSVFile()
        {
            var lines = File.ReadAllLines("AirportList.csv");
            var list = new List<Airport>();
            foreach(var line in lines)
            {
                var values = line.Split(',');
                var airport = new Airport() { Code = values[0], Restaurants = values[1], Restrooms = values[2], Shops = values[3] };
                list.Add(airport);
            }
            list.ForEach(x => Console.WriteLine($"{x.Code}\t{x.Restaurants}\t{x.Restrooms}\t{x.Shops}"));
        }
    }

    public class Airport
    {
        public string Code { get; set; }
        public string Restaurants { get; set; }
        public string Restrooms { get; set; }
        public string Shops { get; set; }

    }
}
