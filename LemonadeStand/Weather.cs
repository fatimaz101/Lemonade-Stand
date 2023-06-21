using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    internal class Weather
    {
        public string condition;
        public int temperature;
        private List<string> weatherConditions = new List<string>
        {
            "sunny","cloudy","a chance of rain","partly sunny", "partly cloudy",
        };
        public string predictedForecast;
       


        public Weather()
        {
            
        }
        public string GenerateForecast()
        {
            Random rand = new Random();
            int randIndex = rand.Next(weatherConditions.Count);
            string forecast = weatherConditions[randIndex];  //returns a random forecast
            Console.WriteLine($"Today's forecast is {forecast}");
            return forecast;
        }

        public void GenerateWeather()
        {
            Random rand = new Random();

            int tempreture = rand.Next(50, 100); // returns a random temp
            int randId = rand.Next(weatherConditions.Count);
            string condition = weatherConditions[randId];



            Console.WriteLine($"The weather today is {tempreture} degrees and {condition}");

            

        }

        
    }
}
