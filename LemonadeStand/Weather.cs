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
        public int tempreture;
        private List<string> weatherConditions = new List<string>
        {
            "sunny","rain","cloudy","chance of rain"
        };
        public string predictedForecast;
       


        public Weather()
        {
            
        }
        public string GenerateForecast()
        {
            Random rand = new Random();
            int randIndex = rand.Next(weatherConditions.Count);
            string realForecast = weatherConditions[randIndex];  //returns a random forecast
            return realForecast;
        }

        public int GenerateWeather()
        {
            Random rand = new Random();

            int realTemp = rand.Next(50, 100); // returns a random temp

            return realTemp;
        }
    }
}
