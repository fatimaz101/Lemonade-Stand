using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Player
    {
        // member variables (HAS A)
        public string name;
        public Inventory inventory;
        public Wallet wallet;
        public Recipe recipe;


        // constructor (SPAWNER)
        public Player()
        {
            inventory = new Inventory();
            wallet = new Wallet();
            recipe = new Recipe();
        }

        // member methods (CAN DO)
        public void ChangeRecipe()
        {
            Console.WriteLine("Do you want to change your recipe? (Y/N");
            string answer;
            answer = Console.ReadLine();
            if (answer == "Y" || answer == "y")
            {
                Console.WriteLine("How many lemons per cup?");
                recipe.numberOfLemons = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("How many sugar cubes per cup?");
                recipe.numberOfSugarCubes = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("How many ice cubes per cup?");
                recipe.numberOfIceCubes = Convert.ToInt32(Console.ReadLine());
                recipe.DisplayRecipe();

            }
            else if (answer == "N"||answer=="n")
            {
                //may be not needed since saying no will contunie app
            }

            
        }

    }
}
