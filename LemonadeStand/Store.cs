using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Store
    {
        // member variables (HAS A)
        private double pricePerLemon;
        private double pricePerSugarCube;
        private double pricePerIceCube;
        private double pricePerCup;

        // constructor (SPAWNER)
        public Store()
        {
            pricePerLemon = .5;
            pricePerSugarCube = .1;
            pricePerIceCube = .01;
            pricePerCup = .25;
        }

        // member methods (CAN DO)
        public void SellLemons(Player player)
        {
            int lemonsToPurchase = UserInterface.GetNumberOfItems("lemons");
            double transactionAmount = CalculateTransactionAmount(lemonsToPurchase, pricePerLemon);
            if(player.wallet.Money >= transactionAmount)
            {
                player.wallet.PayMoneyForItems(transactionAmount);
                player.inventory.AddLemonsToInventory(lemonsToPurchase);
            }else if (player.wallet.Money < transactionAmount)
            {
                Console.WriteLine($"Sorry you can't afford that. You only have {player.wallet.Money} dollars.Try Again.");
                SellIceCubes(player);
                
            }
        }

        public void SellSugarCubes(Player player)
        {
            int sugarToPurchase = UserInterface.GetNumberOfItems("sugar");
            double transactionAmount = CalculateTransactionAmount(sugarToPurchase, pricePerSugarCube);
            if(player.wallet.Money >= transactionAmount)
            {
                PerformTransaction(player.wallet, transactionAmount);
                player.inventory.AddSugarCubesToInventory(sugarToPurchase);
            }else if (player.wallet.Money < transactionAmount)
            {
                Console.WriteLine($"Sorry you can't afford that. You only have {player.wallet.Money} dollars.Try Again.");
                SellIceCubes(player);
                ;
            }
        }

        public void SellIceCubes(Player player)
        {
            int iceCubesToPurchase = UserInterface.GetNumberOfItems("ice cubes");
            double transactionAmount = CalculateTransactionAmount(iceCubesToPurchase, pricePerIceCube);
            if(player.wallet.Money >= transactionAmount)
            {
                PerformTransaction(player.wallet, transactionAmount);
                player.inventory.AddIceCubesToInventory(iceCubesToPurchase);
            }else if (player.wallet.Money < transactionAmount)
            {
                Console.WriteLine($"Sorry you can't afford that. You only have {player.wallet.Money} dollars.Try Again.");
                SellIceCubes(player);
;           }
        }

        public void SellCups(Player player)
        {
            int cupsToPurchase = UserInterface.GetNumberOfItems("cups");
            double transactionAmount = CalculateTransactionAmount(cupsToPurchase, pricePerCup);
            if(player.wallet.Money >= transactionAmount)
            {
                PerformTransaction(player.wallet, transactionAmount);
                player.inventory.AddCupsToInventory(cupsToPurchase);
            }else if (player.wallet.Money < transactionAmount)
            {
                Console.WriteLine($"Sorry you can't afford that. You only have {player.wallet.Money} dollars.Try Again.");
                SellIceCubes(player);
                ;
            }
        }

        private double CalculateTransactionAmount(int itemCount, double itemPricePerUnit)
        {
            double transactionAmount = itemCount * itemPricePerUnit;
            return transactionAmount;
        }

        private void PerformTransaction(Wallet wallet, double transactionAmount)
        {
            wallet.PayMoneyForItems(transactionAmount);
        }

        public void AskForStore(Player player)
        {
            Console.WriteLine("Do you want to go to the store? (Y/N)");
            string answer = Console.ReadLine();
            if (answer == "Y" ||answer =="y")
            {
                SellLemons(player);
                SellSugarCubes(player);
                SellIceCubes(player);
                SellCups(player);
                NewInventory(player);
                
            }else if(answer == "N"|| answer=="n")
            {
                Console.WriteLine("Okay, lets stick with what we have");
            }
            else
            {
                Console.WriteLine("Please type Y or N, try again");
                AskForStore(player);
            }

            
        }



        public void NewInventory(Player player)
        {
            int newLemon = player.inventory.lemons.Count;
            int newSugar = player.inventory.sugarCubes.Count;
            int newIce = player.inventory.iceCubes.Count;
            int newCups = player.inventory.cups.Count;
            Console.WriteLine($"You now have {newLemon} lemons.");
            Console.WriteLine($" {newSugar} sugar cubes.");
            Console.WriteLine($"{newIce} ice cubes.");
            Console.WriteLine($" and {newCups} cups");



        }
    }


}
