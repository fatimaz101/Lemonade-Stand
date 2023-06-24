﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    internal class Day
    {
        public string name;
        public Weather weather;
        public List<Customer> customers;
        public int saleDemand = 0;
        public Day(string name)
        {
            this.name = name;
            weather = new Weather();
        }

        public int CalcDemand() //using weather and condition
        {
            
            if (weather.condition == "partly sunny" || weather.condition == "sunny")
            {
                saleDemand += 80;
                CalcDemand2();
                
                
            }
            else if(weather.condition=="cloudy" || weather.condition=="partly cloudy")
            {
                saleDemand += 65;
                CalcDemand2();
                

            }else if (weather.condition=="a chance of rain")
            {
                saleDemand += 45;
                CalcDemand2();
                
            }else if(weather.condition=="it is raining")
            {
                saleDemand += 30;
                CalcDemand2();
                
            }
            return saleDemand;
        }
        
        
        public void CalcDemand2()                     //calc demand for temperature 
        {
            if (weather.temperature >= 50 || weather.temperature < 65)
            {
                saleDemand -= 20;

            }
            else if (weather.temperature >= 65 || weather.temperature < 75)
            {
                saleDemand -= 5;
            }
            else if (weather.temperature >= 75 || weather.temperature <= 90)
            {
                saleDemand += 15;
            }
            else if(weather.temperature>=90)
            {
                saleDemand += 20;
            }
        }
    }
}
