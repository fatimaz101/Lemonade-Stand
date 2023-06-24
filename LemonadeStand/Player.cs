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
        public double chargingPrice;
        int z = 0;


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



        }

        public void PricePerCup()
        {
            Console.WriteLine("How much do you want to charge per cup. (Beware, setting it too high may cause customers to not buy your lemonade");
            string pricePer = Console.ReadLine();
            this.chargingPrice = Convert.ToInt32(pricePer);
            recipe.price = chargingPrice;


        }
        public void SellLemonade()// this may not work and you might to delete items from the list to get the righ number or items left in inventory
        {


            
            if (z < 7)
            {
                wallet.AcceptMoney(chargingPrice);
                z++;
            }
            else if(z==7)
                {

                int updatedLemon = inventory.lemons.Count() - recipe.numberOfLemons;
                updatedLemon = inventory.lemons.Count();
                int updatedSugar = inventory.sugarCubes.Count() - recipe.numberOfSugarCubes;
                updatedSugar = inventory.sugarCubes.Count();
                int updatedIce = inventory.iceCubes.Count() - recipe.numberOfIceCubes;
                updatedIce = inventory.iceCubes.Count();
                int updatedCups = inventory.cups.Count() - 1;
                updatedCups = inventory.cups.Count();

                wallet.AcceptMoney(chargingPrice);
                z = 0;
            }
            
            




        }

        public void UpdatedWallet()
        {
            Console.WriteLine($"You now have {wallet.Money}");
        }

        public void CheckInventory()
        {
            
        }

        
    }

    }

