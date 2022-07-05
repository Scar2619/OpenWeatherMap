using System;
using System.Net.Http;
using Newtonsoft.Json.Linq;

namespace OpenWeatherMap
{
    class Program
    {
        static bool cont = true;

        static void Main(string[] args)
        {
            var client = new HttpClient();
            Console.WriteLine("Would you like to check the current weather in your area? Yes or no:");
            var contResponse = Console.ReadLine().ToLower();
            if (contResponse == "yes")
            {
                cont = true;
            }
            else
            {
                cont = false;
                Environment.Exit(0);
            }

            while (cont)
            {
                Console.WriteLine("~~~~~~");
                Console.WriteLine("Please enter zipcode:");
                var zipcode = Console.ReadLine();
                Console.WriteLine("Please enter api key:");
                var apiKey = Console.ReadLine();
                var weatherURL = ($"https://api.openweathermap.org/data/2.5/weather?zip={zipcode},us&appid={apiKey}&units=imperial");

                var currentWeather = client.GetStringAsync(weatherURL).Result;
                var formatWeather = JObject.Parse(currentWeather).GetValue("main").ToString();
                Console.WriteLine(formatWeather);
                Console.WriteLine("~~~~~~~~~~~~");

                Console.WriteLine("Would you like to check a different zipcode's weather? Yes or no:");
                Console.WriteLine();
                cont = (Console.ReadLine().ToLower() == "yes") ? true : false;
            }
        }
    }
}

