using System;

namespace Models
{
    public enum CoinType
    {
        Penny,
        Nickel, 
        Dime,
        Quarter
    }
    public class Coin
    {
        private CoinType type;

        public Coin(CoinType type)
        {
            this.type = type;
        }

        public int GetValue()
        {
            int returnVal = 0;
            switch (type)
            {
                case CoinType.Penny:
                    returnVal = 1;
                    break;
                case CoinType.Nickel:
                    returnVal = 5;
                    break;
                case CoinType.Dime:
                    returnVal = 10;
                    break;
                case CoinType.Quarter:
                    returnVal = 25;
                    break;
                default:
                    break;
            }

            return returnVal;
        }

        public override string ToString()
        {
            return type.ToString();
        }
    }
}
