using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    internal class Customer
    {
        public Weather weather;
        public List<string> possibilities;



        public Customer()
        {
            possibilities.Clear();
            possibilities.Add("true");
            possibilities.Add("false");
    }

        public void BuyLemonade()
        {
            //try to make a true of fale list where you add more so the probalitiy goes higher like that

            if (weather.condition == "sunny")
            {





            }










        }
    }
}
