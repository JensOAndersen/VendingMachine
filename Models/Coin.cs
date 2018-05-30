using System;

namespace Models
{
    /*
     * The coin class is inherited to various sub-types, 
     * to distinguish the different coinages easily
     */
    public abstract class Coin
    {
        private readonly int value;
        public Coin(int value){
            this.value = value;
        }
        public int Value
        {
            get { return value; }
        }

        public override string ToString()
        {
            return this.GetType().Name;
        }
    }

    public class Penny : Coin
    {
        public Penny(int value = 1) : base(value)
        {            
        }

    }

    public class Nickel : Coin
    {
        public Nickel(int value = 5) : base(value)
        {
        }
    }

    public class Dime : Coin
    {
        public Dime(int value = 10) : base(value)
        {
        }
    }

    public class Quarter : Coin
    {
        public Quarter(int value = 25) : base(value)
        {
        }
    }
}
