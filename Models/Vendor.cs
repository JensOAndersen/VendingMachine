using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Vendor
    {
        private readonly IInventory inventory;
        private List<Coin> deposits = new List<Coin>();

        public Vendor(IInventory inventory)
        {
            this.inventory = inventory;
        }

        public IInventory Inventory
        {
            get { return inventory; }
        }

        /// <summary>
        /// Deposits a coin into the vending machine
        /// </summary>
        /// <param name="coin">Accepts various coinages of types: Penny, Nickel, Dime, Quaryer</param>
        public void Deposit(Coin coin)
        {
            Console.WriteLine($"Deposited a {coin}");
            deposits.Add(coin);
        }

        //Lists the current inventory of the shop
        public void ListInventory()
        {
            foreach (var item in inventory.Items)
            {
                Console.WriteLine(item);
            }
        }

        /// <summary>
        /// Returns all inserted Coins to the user
        /// </summary>
        public void Refund()
        {
            if (deposits.Count > 0)
            {
                foreach (var coin in deposits)
                {
                    Console.WriteLine($"Refunded a {coin}");
                }

                deposits.Clear();
            }
            else
            {
                Console.WriteLine("You didnt have anything to refund");
            }

        }

        /// <summary>
        /// Gets the total value of all coins inserted into the vending machine
        /// </summary>
        /// <returns></returns>
        public int GetDepositedAmount()
        {
            int amount = 0;

            foreach (var coin in deposits)
            {
                amount += coin.Value;
            }

            return amount;
        }

        /// <summary>
        /// Buys an item from the vending machine and tells user whether it succeeded or not
        /// </summary>
        /// <param name="itemName">Item name must exist in the list of items</param>
        public void BuyItem(string itemName)
        {
            VendorItem item = inventory.Items.Find(x => x.Name == itemName);
            if (item != null)
            {
                int depositedAmount = GetDepositedAmount();

                if (item.Value <= depositedAmount)
                {
                    Console.WriteLine($"You bought a {item} for {item.Value}");

                    int changeAmount = depositedAmount - item.Value;

                    if (changeAmount > 0)
                    {
                        Console.WriteLine("You recieve following coins as change, for a total of: " + changeAmount + " Cent(s)");
                        var coinsInChange = GetChange(changeAmount);
                        foreach (var coin in coinsInChange)
                        {
                            Console.WriteLine(coin);
                        }
                    }
                    else
                    {
                        Console.WriteLine("You paid right on target!");
                    }

                    Console.WriteLine("Thank you for using our Vendor");
                }
                else
                {
                    Console.WriteLine("Sorry, you didnt have enough money");
                }
            } else
            {
                Console.WriteLine("Sorry, couldnt find your product");
            }

        }

        private List<Coin> GetChange(int changeAmount)
        {
            var returnCoins = new List<Coin>();

            while (changeAmount > 0)
            {
                if (changeAmount >= 25)
                {
                    returnCoins.Add(new Quarter());
                    changeAmount -= 25;
                }
                else if (changeAmount >= 10)
                {
                    returnCoins.Add(new Dime());
                    changeAmount -= 10;
                }
                else if (changeAmount >= 5)
                {
                    returnCoins.Add(new Nickel());
                    changeAmount -= 5;
                }
                else if (changeAmount >= 1)
                {
                    returnCoins.Add(new Penny());
                    changeAmount -= 1;
                }
            }

            return returnCoins;
        }
    }
}
