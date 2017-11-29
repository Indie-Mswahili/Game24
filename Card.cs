using System;

namespace Game24
{
    public class Card
    {
        public string Suit { get; set; }
        public string StringVal { get; set; }
        public int Val { get; set; }

        public Card(string suit, string stringVal, int val)
        {
            this.Suit = suit;
            this.StringVal = stringVal;
            this.Val = val;
        }

        public override string ToString()
        {
            return $"{StringVal} of {Suit}";
        }
    }
}