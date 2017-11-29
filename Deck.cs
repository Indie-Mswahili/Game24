using System;
using System.Collections.Generic;

namespace Game24
{
    public class Deck
    {
        public List<Card> Cards { get; set; }

        public Deck()
        {
            Reset();
            Shuffle();
        }

        public Card Deal()
        {
            // selects the "top-most" card
            Card dealtCard = Cards[0];
            // removes it from the list of cards
            Cards.RemoveAt(0);
            // returns the Card
            return dealtCard;
        }

        public void Reset()
        {
            Cards = new List<Card>();
            string[] suits = {"Hearts", "Diamonds", "Clubs", "Spades" };
            string[] names = {"A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K"};
            foreach (string s in suits)
            {
                for(int i = 0; i < names.Length; i++)
                {
                    Cards.Add(new Card(s, names[i], i + 1));
                }                
            }
            System.Console.WriteLine(Cards.Count);
        }

        public void Shuffle()
        {
            Random rnd = new Random();
            for (int i = 0; i < Cards.Count; i++)
            {
                int otherIndex = rnd.Next(0, Cards.Count);
                // swap card at i with card at otherIndex
                Card temp = Cards[otherIndex];
                Cards[otherIndex] = Cards[i];
                Cards[i] = temp;
            }
        }

        public override string ToString() 
        {
            foreach (Card c in Cards)
            {
                System.Console.WriteLine(c);
            }
            return $"{Cards.Count} cards in the deck";
        }
    }
}