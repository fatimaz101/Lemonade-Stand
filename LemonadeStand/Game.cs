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

        public void GameIntro()
        {
            Console.WriteLine("This is the Lemonade Stand Game");
            Console.WriteLine("You have a week to make as much money as possible");
            Console.WriteLine("In this game you have the power to change the price,go to the store,and change your recipe");
            Console.WriteLine("Setting the price too high can make people not want to buy your lemonade");
            Console.WriteLine("Make sure you have enough stock or you wont be able to sell!");
            Console.WriteLine("Weather will play a big part in demand so make sure you listen to the weather forecast");
            GameSpace();
            Console.WriteLine("Good Luck");
        }


        public void GameSpace()
        {
            Console.WriteLine("                ");
        }



        public int DoesItTasteGood()
        {
            if (player.recipe.numberOfLemons < 2 || player.recipe.numberOfLemons > 7 || player.recipe.numberOfSugarCubes < 4 || player.recipe.numberOfSugarCubes > 11 || player.recipe.numberOfIceCubes < 6 || player.recipe.numberOfIceCubes > 26)
            {
                return 4;
            }
            else
            {
                return 0;
            }
        }

        public void IsGameValid()
        {
            double checkMoney = player.wallet.Money;
            if (checkMoney < .25)
            {


                if (player.inventory.lemons.Count < (player.recipe.numberOfLemons) || player.inventory.sugarCubes.Count < (player.recipe.numberOfSugarCubes) || player.inventory.iceCubes.Count < (player.recipe.numberOfIceCubes) || player.inventory.cups.Count < 8)
                {

                    GameSpace();
                    Console.WriteLine("Sorry you ran out money and you didn't have enough stock to make another pitcher");
                    GameSpace();

                    System.Environment.Exit(0);
                }
                GameSpace();
                GameSpace();
                Console.WriteLine("Warning!!");
                Console.WriteLine("You dont have enough money to buy anything. You really need to make money today");

            }
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
            double startingMoney = player.wallet.Money; //capture orignal amount in wallet
            int day = 1;
            for (int i = 0; i < 7; i++)
            {

                IsGameValid();

                GameSpace();
                GameSpace();


                Console.WriteLine($"Starting Day {day}");
                days[0].weather.GenerateForecast();

                day++;

                double morningCash = player.wallet.Money; //capture starting day cash amout

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

                int n = Convert.ToInt32((days[i].CalcDemand()) * (.6));//creates number of customers based on weather(demand)


                Console.WriteLine("Okay,lets start selling!.Good Luck");
                GameSpace();
                player.AmtOfLemonade(pitchers);

                for (int x = 0; x < n; x++)
                {

                    days[i].AddCustomers();
                    days[i].customers[x].cost = player.chargingPrice;

                    int taste = DoesItTasteGood();//checks to see if lemonade is within normal standards
                    bool answer = days[i].customers[x].ComeToCounter(taste);

                    

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

                player.lemonadeYouCanSell = 0;
                Console.WriteLine($"You had {days[i].customers.Count} customers come today");

                int testvar = 10;
                GameSpace();
                GameSpace();

                double nightCash = player.wallet.Money;

                EndOfDay(startingMoney, morningCash, nightCash);

                

                Thread.Sleep(4000);


            }
        }






        
        public void EndOfDay(double orgCash,double newCash,double totalCash)
        {
            double profit = totalCash - newCash;

            Console.WriteLine($"Day Over");
            double totalProfit = 0;


            

            if (profit > 0)
            {


                Console.WriteLine($"You made {Math.Round(profit, 2)} dollars today.Nice!");

                totalProfit = totalCash - orgCash;
                Console.WriteLine($"Your total profit this week is {Math.Round(totalProfit, 2)}dollars");
                Console.WriteLine($"And you have {Math.Round(totalCash, 2)}  dollars in your wallet now.");


            }
            else if (profit == 0)
            {
                Console.WriteLine("You broke even today");
                totalProfit = totalCash - orgCash;
                Console.WriteLine($"Your total profit this week is {Math.Round(totalProfit, 2)} dollars");

            }
            else if (profit < 0)
            {
                Console.WriteLine($"You lost {Math.Round(profit, 2)} dollars today.Better luck next time");
                totalProfit = totalCash - orgCash;
                Console.WriteLine($"Your total profit this week is {Math.Round(totalProfit, 2)} dollars");
                Console.WriteLine($"And you have {Math.Round(totalCash, 2)}  dollars in your wallet now.");
                
            }


        }



            public void RunGame()
            {
            GameIntro();
            

            RunWeek();



            GameSpace();
            Console.WriteLine("Game Over.");
           
            




        }
        
        }
    }
