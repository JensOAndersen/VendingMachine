using System;
using Business;
using Models;
using System.Reflection;
using Ninject;
using Ninject.Modules;
namespace VendingMachine
{
    class Program
    {
        static Vendor vendor;
        static void Main(string[] args)
        {
            var kernel = DIVendor.GetKernel();
            
            //You can swap this with another inventorytype, ie DrinkInventory
            vendor = new Vendor(kernel.Get<FoodInventory>());

            Console.WriteLine("Velcome to our vending stand, please pick a menu item: ");
            while (true)
            {
                Console.WriteLine("To see all items for sale press 'a'");
                Console.WriteLine("To Deposit coins into the vending machine, press 's'");
                Console.WriteLine("To get a refund press 'd'");
                Console.WriteLine("To buy an item press 'f'");

                ConsoleKeyInfo info = Console.ReadKey(true);
                switch (info.Key)
                {
                    case ConsoleKey.A:
                        vendor.ListInventory();
                        Console.ReadKey(true);
                        break;
                    case ConsoleKey.S:
                        Deposit();
                        break;
                    case ConsoleKey.D:
                        vendor.Refund();
                        Console.ReadKey(true);
                        break;
                    case ConsoleKey.F:
                        BuyItem();
                        Console.ReadKey(true);
                        break;
                }
                Console.Clear();
            }
        }
        static void BuyItem()
        {
            Console.WriteLine("The following items are for sale:");
            vendor.ListInventory();
            Console.WriteLine("Write your choice:");

            string choice = Console.ReadLine();

            vendor.BuyItem(choice);
        }

        static void Deposit()
        {
            bool depositing = true;
            Console.WriteLine("Press 'E' to exit deposit screen");
            Console.WriteLine("press 'p' to add a penny");
            Console.WriteLine("press 'n' to add a nickel");
            Console.WriteLine("Press 'd' to add a dime");
            Console.WriteLine("press 'q' to add a quarter");
            while (depositing)
            {
                ConsoleKeyInfo info = Console.ReadKey(true);
                switch (info.Key)
                {
                    case ConsoleKey.P:
                        vendor.Deposit(CoinType.Penny);
                        break;
                    case ConsoleKey.N:
                        vendor.Deposit(CoinType.Nickel);
                        break;
                    case ConsoleKey.D:
                        vendor.Deposit(CoinType.Dime);
                        break;
                    case ConsoleKey.Q:
                        vendor.Deposit(CoinType.Quarter);
                        break;
                    case ConsoleKey.E:
                        depositing = false;
                        break;
                }
            }
            Console.Clear();
        }
    }
}
