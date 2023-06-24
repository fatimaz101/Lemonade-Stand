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
        public double cost;
        public bool trueOrFalse;



        public Customer()
        {
            possibilities.Clear();
            possibilities.Add("true");
            possibilities.Add("true");
            possibilities.Add("true");
            possibilities.Add("false");
            possibilities.Add("false");
            possibilities.Add("false");
        }

        public bool ComeToCounter()
        {
            //try to make a true of fale list where you add more so the probalitiy goes higher like that
            
            if (cost>= 0 && cost < 1)
            {

                possibilities.Add("true");
                possibilities.Add("true");
                possibilities.Add("true");
                possibilities.Add("true");
                DidTheyBuy();

                

            }
            else if(cost>=1 && cost < 2)
            {
                possibilities.Add("true");
                possibilities.Add("true");
                DidTheyBuy();
                

            }
            else if(cost>=2 && cost < 3)
            {
                possibilities.Add("true");
                possibilities.Add("true");
                possibilities.Add("false");
                possibilities.Add("false");
                possibilities.Add("false");
                DidTheyBuy();

                

            }
            else if(cost>=3 && cost < 4)
            {
                possibilities.Add("true");
                possibilities.Add("false");
                possibilities.Add("false");
                possibilities.Add("false");
                possibilities.Add("false");
                possibilities.Add("false");
                DidTheyBuy();
               

            }
            else if(cost >=4 && cost <=5)
            {
                possibilities.Add("false");
                possibilities.Add("false");
                possibilities.Add("false");
                possibilities.Add("false");
                possibilities.Add("false");
                DidTheyBuy();
                
            }
            else if (cost > 5)
            {
                possibilities.Add("false");
                possibilities.Add("false");
                possibilities.Add("false");
                possibilities.Add("false");
                possibilities.Add("false");
                possibilities.Add("false");
                possibilities.Add("false");
                possibilities.Add("false");
                DidTheyBuy();
                
            }

            return trueOrFalse;




        }


        public void DidTheyBuy()//checks whether it was true or false did they buy or not
        {

            Random rnd = new Random();
            int inx = rnd.Next(possibilities.Count);
            if (possibilities[inx]=="true")
            {
                trueOrFalse = true;
                


            }else if (possibilities[inx] == "false")
            {
                trueOrFalse = false;
                

            }
            

           
        }
        
        




    }


}
