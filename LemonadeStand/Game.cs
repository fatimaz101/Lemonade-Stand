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
        // orgcash ir orginal money   new cash is morning starting money    total cash is end of day money       total profit is the weeks profit profit is daily profit
        //starting money//startodaymoney//moneymade//
        public void EndOfDay(double orgCash,double newCash,double totalCash)
        {
            double profit = totalCash - newCash;

            Console.WriteLine("Day Over");
            double totalProfit = 0;


            profit = newCash - totalCash;

            if (profit > 0)
            {


                Console.WriteLine($"You made {profit} dollars today.Nice!");

                totalProfit = totalCash - orgCash;
                Console.WriteLine($"Your total profit so far this week is {totalProfit} dollars");

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
            Console.WriteLine("Good Luck");


            CreatePlayerObjects();
                double startingMoney = player.wallet.originalMoney;//captures starting cash before game

                //for loop here for amount of days

                for (int i = 0; i < 7; i++)
                {

                Console.WriteLine($"Starting Day {i + 1}");
                    days[0].weather.GenerateForecast();



                double morningCash = player.wallet.startOfDayMoney;


                    store.NewInventory(player);
                    store.AskForStore(player);
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

                        if (answer == true)
                        {

                            player.SellLemonade();
                            




                        }
                        else if (answer == false)
                        {

                            Console.WriteLine("Customer passed you by");

                        }

                    double nightCash = player.wallet.moneyMade;

                    EndOfDay(startingMoney, morningCash, nightCash);

                    i++;
                    }




                    


                }







            }
        
        }
    }
