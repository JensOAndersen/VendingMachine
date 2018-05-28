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

        public void Deposit(CoinType type)
        {
            Console.WriteLine($"Deposited a {type}");
            deposits.Add(new Coin(type));
        }

        public void ListInventory()
        {
            foreach (var item in inventory.Items)
            {
                Console.WriteLine(item);
            }
        }

        public void Refund()
        {
            if (deposits.Count > 0)
            {
                foreach (var coin in deposits)
                {
                    Console.WriteLine($"Refunded a {coin}");
                }

                deposits.Clear();
            } else
            {
                Console.WriteLine("You didnt have anything to refund");
            }

        }

        public int GetDepositedAmount()
        {
            int amount = 0;

            foreach (var item in deposits)
            {
                amount += item.GetValue();
            }

            return amount;
        }

        public void BuyItem(string itemName)
        {
            VendorItem item = inventory.Items.Find(x => x.Name == itemName);
            int depositedAmount = GetDepositedAmount();

            if (item.Value <= depositedAmount)
            {
                Console.WriteLine($"You bought a {item} for {item.Value}");

                int changeAmount = depositedAmount - item.Value;

                if (changeAmount > 0)
                {
                    Console.WriteLine("You recieve following coins as change, for a total of: " + changeAmount);
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


        }

        private List<Coin> GetChange(int changeAmount)
        {
            var returnCoins = new List<Coin>();

            while (changeAmount > 0)
            {
                if (changeAmount >= 25)
                {
                    returnCoins.Add(new Coin(CoinType.Quarter));
                    changeAmount -= 25;
                }
                else if (changeAmount >= 10)
                {
                    returnCoins.Add(new Coin(CoinType.Dime));
                    changeAmount -= 10;
                }
                else if (changeAmount >= 5)
                {
                    returnCoins.Add(new Coin(CoinType.Nickel));
                    changeAmount -= 5;
                }
                else if (changeAmount >= 1)
                {
                    returnCoins.Add(new Coin(CoinType.Penny));
                    changeAmount -= 1;
                }
            }

            return returnCoins;
        }
    }
}
