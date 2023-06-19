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
            
        }

        public void CreatePlayerObjects()
        {
            player=new Player();

            Console.WriteLine("Before we start, what's your name");
            player.name = Console.ReadLine();
        }

        public void RunGame()
        {
            // Insert game intro here
            //Welcome to game.. Day 1
            Weather weather = new Weather();
            weather.GenerateForecast();
            //Insert game inventory here
          Store store = new Store();
            CreatePlayerObjects();
            store.AskForStore(player);




            //weather.GenerateWeather();

       }
    }

}
