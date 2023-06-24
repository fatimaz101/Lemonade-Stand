using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    internal class Game
    {
        private Player player;
        private List<Day> days;
        private int currentDay;
        public Store store = new Store();
        public Game()
        {

            days = new List<Day>
            {
            new Day("DayOne"),
            new Day("DayTwo"),
            new Day("DayThree"),
            new Day("DayFour"),
            new Day("DayFive"),
            new Day("DaySix"),
            new Day("DaySeven")
             };
             
           
            

        }

        public void CreatePlayerObjects()
        {
            player=new Player();

            Console.WriteLine("Before we start, what's your name");
            player.name = Console.ReadLine();
        }

        public void AskForStore(Player player)
        {
            Console.WriteLine("Do you want to go to the store? (Y/N)");
            string answer = Console.ReadLine();
            if (answer == "Y" || answer == "y")
            {
               
                store.SellLemons(player);
                
                store.SellSugarCubes(player);
                store.SellIceCubes(player);
                store.SellCups(player);

            }
            else if (answer == "N" || answer == "n")
            {
                Console.WriteLine("Okay, lets stick with what we have");
            }
            else
            {
                Console.WriteLine("Please type Y or N, try again");
                AskForStore(player);
            }


        }


        public void EndOfDay()
        {


            Console.WriteLine("Day Over");
            Console.WriteLine($"



        }





        public void RunGame()
        {
            //Insert game intro here
            //Welcome to game..Day 1
            //for loop for the days of the week

            

            CreatePlayerObjects();
            double startingMoney = player.wallet.Money();

            //for loop here for amount of days

            for (int i = 0; i < 7; i++)
            {

                days[0].weather.GenerateForecast();


                



                store.NewInventory(player);
                store.AskForStore(player);
                store.NewInventory(player);
                player.ChangeRecipe();
                int pitchers = UserInterface.GetNumberOfPitchers();//need to connect this to cups of lemonade
                //take out number of ing it takes to make the amt of pitch from inventory
                //make sure they can make those amount of pitchers
                player.CheckPitcher(pitchers);
                
                player.PricePerCup();
                days[i].weather.GenerateWeather();

                int n = Convert.ToInt32((days[i].CalcDemand()) * (.6));//to get number of customer objects (demand based on weather)

                
                Console.WriteLine("Okay,lets start selling!.Good Luck");
                

                for (int x = 0; x < n; x++)
                {
                    Customer customer = new Customer();
                    days[i].customers.Add(customer);
                    days[i].customers[x].cost = player.chargingPrice;


                    bool answer = days[i].customers[x].ComeToCounter();

                    if (answer==true)
                    {
                        
                        player.SellLemonade();
                        bool enoughItems;
                       
                        
                        

                    }
                    else if (answer ==false)
                    {

                        Console.WriteLine("Customer passed you by");

                    }


                    //day over message
                    //print how much they earned and how many customers came
                    //i++
                }


                















            }


            //days[0].weather.GenerateForecast();


            //Store store = new Store();



            //store.NewInventory(player);
            //store.AskForStore(player);
            //store.NewInventory(player);
            //player.ChangeRecipe();
            //UserInterface.GetNumberOfPitchers(); //unsure if this will work or how to connect to real
            //player.PricePerCup();
            //days[0].weather.GenerateWeather();
            //days[0].CalcDemand();

            ////not sure if we instnatied custoer objets yet



            //// for loop here for customers
            ////need to figure out how to get the amount of customers in days class list and why they are that much

            //player.chargingPrice = days[0].customers[0].cost; //could need to be in day class


            //days[0].customers[0].ComeToCounter();//to see price  //going to replace 0 with i
            //days[0].customers[0].DidTheyBuy();//to get true or false ///may have to put these last two methods in the day class
            //player.SellLemonade(); //to reduce the number of items in the inventory follwing the reciepe
            ////days[0].customers[0].trueOrFalse
            //player.UpdatedWallet();

            
              
            
       
           
            




           

       }
    }

}
