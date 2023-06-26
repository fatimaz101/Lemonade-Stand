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
        int day = 1;
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



        public void GameSpace()
        {
            Console.WriteLine("                ");
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


        public void RunWeek()
        {

            CreatePlayerObjects();
            double startingMoney = player.wallet.Money; //capture starting day cash in wallet
            int day = 1;
            for (int i = 0; i < 7; i++)
            {

                double checkMoney = player.wallet.Money;//make this its own method/////////////make this a method
                if (checkMoney < .25)
                {


                    if(player.inventory.lemons.Count < (player.recipe.numberOfLemons) || player.inventory.sugarCubes.Count < (player.recipe.numberOfSugarCubes) || player.inventory.iceCubes.Count < (player.recipe.numberOfIceCubes) || player.inventory.cups.Count < 1)
                    {
                        Console.WriteLine("Sorry you ran out money and you dont have enough stock to make another pitcher.Game over");

                        System.Environment.Exit(0);
                    }

                    
                }

                GameSpace();
                GameSpace();


                Console.WriteLine($"Starting Day {day}");
                days[0].weather.GenerateForecast();

                day++;

                double morningCash = player.wallet.Money;

                GameSpace();
                store.NewInventory(player);
                store.AskForStore(player);
                GameSpace();
                player.recipe.DisplayRecipe();
                player.ChangeRecipe();
                GameSpace();
                int pitchers = UserInterface.GetNumberOfPitchers();
                GameSpace();
                player.CheckPitcher(pitchers);

                player.PricePerCup();
                days[i].weather.GenerateWeather();

                int n = Convert.ToInt32((days[i].CalcDemand()) * (.8));//to get number of customer objects (demand based on weather)


                Console.WriteLine("Okay,lets start selling!.Good Luck");
                GameSpace();
                player.AmtOfLemonade(pitchers);

                for (int x = 0; x < n; x++)
                {
                    Customer customer = new Customer();
                    days[i].customers.Add(customer);
                    days[i].customers[x].cost = player.chargingPrice;


                    bool answer = days[i].customers[x].ComeToCounter();

                    //write something for demand depending on reciecpe amount of indg customers wont buy lemonade
                    

                    if (answer == true)
                    {

                        player.SellLemonade(player.lemonadeYouCanSell, pitchers);

                          



                    }
                    else if (answer == false)
                    {
                        Thread.Sleep(150);
                        Console.WriteLine("Customer passed you by");

                    }

                    

                }
                Console.WriteLine($"You had {days[i].customers.Count} customers come today");

                int testvar = 10;
                GameSpace();
                GameSpace();

                double nightCash = player.wallet.Money;

                EndOfDay(startingMoney, morningCash, nightCash);

                

                Thread.Sleep(4000);


            }
        }






        // orgcash ir orginal money   new cash is morning starting money    total cash is end of day money       total profit is the weeks profit profit is daily profit
        //starting money//startodaymoney//moneymade//
        public void EndOfDay(double orgCash,double newCash,double totalCash)
        {
            double profit = totalCash - newCash;

            Console.WriteLine($"Day Over");
            double totalProfit = 0;


            

            if (profit > 0)
            {


                Console.WriteLine($"You made {profit} dollars today.Nice!");

                totalProfit = totalCash - orgCash;
                Console.WriteLine($"Your total profit so far this week is {totalProfit} dollars");
                Console.WriteLine($"And you have {totalCash} dollars in your wallet now.");

                //subtract wallet money from starting money gives you the total week profit or loss
                //subtract old wallet money from that day to updated wallet from the end of the day
                //for loop those numbers for different messages


            }
            else if (profit == 0)
            {
                Console.WriteLine("You broke even today");
                totalProfit = totalCash - orgCash;
                Console.WriteLine($"Your total profit so far this week is {totalProfit} dollars");

            }
            else if (profit < 0)
            {
                Console.WriteLine($"You lost {profit} today.Better luck next time");
                totalProfit = totalCash - orgCash;
                Console.WriteLine($"Your total profit so far this week is {totalProfit} dollars");

            }


        }



            public void RunGame()
            {
            Console.WriteLine("This is the Lemonade Stand Game");
            Console.WriteLine("You have a week to make as much money as possible");
            Console.WriteLine("In this game you have the power to change the price,go to the store,and change your recipe");
            Console.WriteLine("Setting the price too high can make people not want to buy your lemonade");
            Console.WriteLine("Make sure you have enough stock or you wont be able to sell!");
            Console.WriteLine("Weather will play a big part in demand so make sure you listen to the weather forecast");
            GameSpace();
            Console.WriteLine("Good Luck");
            //write a better intro 

            RunWeek();


            if (player.wallet.Money < .25)
            {
                GameSpace();
                Console.WriteLine("You ran out of money so your stand went out of businesss! Better luck next week :(");
            }

            GameSpace();
            Console.WriteLine("Game Over.");
           
            //we will have a game over scenario here
            //possibily if they run out of money but if not its fine




        }
        
        }
    }
