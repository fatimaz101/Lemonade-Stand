using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
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
        public int lemonadeYouCanSell;
       







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
            else if (answer == "N" || answer == "n")
            {
                Console.WriteLine("Okay,moving on.");
            }
            else
            {
                Console.WriteLine("Please type Y or N, try again");
                ChangeRecipe();
            }



        }

        public double PricePerCup()
        {
            Console.WriteLine("How much do you want to charge per cup. (Beware, setting it too high may cause customers to not buy your lemonade");
            string pricePer = Console.ReadLine();
            this.chargingPrice = Convert.ToDouble(pricePer);
            recipe.price = chargingPrice;
            return chargingPrice;


        }
        public int SellLemonade(int lemonadeAvailable, int amtOfPitchers)


        {

            //make a parameter to stop at the avaaivble cups of lemonade that goes up by one using && with bottom parameters
            //once reaches number it will sell out
            

            if (lemonadeAvailable>0)
            {

                Console.WriteLine("Cha Ching!");

                lemonadeYouCanSell--;
                wallet.AcceptMoney(chargingPrice);

                Thread.Sleep(300);

                return lemonadeYouCanSell;

            }
            else if (amtOfPitchers == 0)
            {
                Console.WriteLine("You missed a paying customer by not making any lemonade today");
                return lemonadeYouCanSell;
            }
            else 
                {

                Console.WriteLine("Sold Out!");

                Thread.Sleep(100);
                return lemonadeYouCanSell;

            }


            //when you make a pitcher for a day those amount of indg should forever be gone from the player inventory
            // and check if you have enough stuff for those ingrediants

            

        }

        public void UpdatedWallet()
        {
            Console.WriteLine($"You now have {wallet.Money}");
        }

       

        public void CheckPitcher(int amtOfPitchers)
        {


            int usableLemons = recipe.numberOfLemons * amtOfPitchers;
            int usableSugar = recipe.numberOfSugarCubes * amtOfPitchers;
            int usableIce = recipe.numberOfIceCubes * amtOfPitchers;
            int usableCups = amtOfPitchers * 8;

            if(usableLemons<=inventory.lemons.Count() && usableSugar <=inventory.sugarCubes.Count() && usableIce<=inventory.iceCubes.Count() && usableCups <= inventory.cups.Count())
            {

                int lemonsLeft = inventory.lemons.Count() - usableLemons;
                inventory.lemons.Clear();
                inventory.AddLemonsToInventory(lemonsLeft);

                int sugarLeft = inventory.sugarCubes.Count() - usableSugar;
                inventory.sugarCubes.Clear();
                inventory.AddSugarCubesToInventory(sugarLeft);

                int iceLeft = inventory.iceCubes.Count() - usableIce;
                inventory.iceCubes.Clear();
                inventory.AddIceCubesToInventory(iceLeft);

                int cupsLeft = inventory.cups.Count() - usableCups;
                inventory.cups.Clear();
                inventory.AddCupsToInventory(cupsLeft);



            }
            else
            {
                Console.WriteLine("Not enough in your inventory to make that many pitchers.Try Again.");
                int newPitcherAttempt= UserInterface.GetNumberOfPitchers();
                CheckPitcher(newPitcherAttempt);

               


            }





        }

        public int AmtOfLemonade (int amtOfPitchers)
        {
            lemonadeYouCanSell = amtOfPitchers * 8;
            return lemonadeYouCanSell;
        }
        
    }

    }

