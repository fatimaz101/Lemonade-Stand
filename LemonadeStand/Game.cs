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

        public void RunGame()
        {
            //Insert game intro here
            //Welcome to game..Day 1

            days[0].weather.GenerateForecast();
             

            Store store = new Store();

            CreatePlayerObjects();
            store.NewInventory(player);
            store.AskForStore(player);
            store.NewInventory(player);
       
           
            




            //weather.GenerateWeather();

       }
    }

}
