using System;
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
        public Day(string name)
        {
            this.name = name;
            weather = new Weather();
        }

        
    }
}
