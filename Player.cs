using System;
using System.Collections.Generic;

namespace Game24
{
    public class Player
    {
        public string Name { get; set; }
        public List<Card> Hand { get; set; }
        
        public Player(string name)
        {
            Name = name;
            Hand = new List<Card>();
        }

        public Card Draw(Deck someDeck)
        {
            // draws a card from a deck
            Card gotCard = someDeck.Deal();
            // adds it to the player's hand
            Hand.Add(gotCard);
            // returns the Card
            return gotCard;
        }

        public Card Discard(int whichCard)
        {
            // discards the Card at the specified index from the player's hand 
            if(whichCard < 0 || whichCard >= Hand.Count)
            {
                return null;
            }
            Card discardedCard = Hand[whichCard];
            Hand.RemoveAt(whichCard);
            // returns this Card or null if the index does not exist
            return discardedCard;
        }



        public void DisplayHand()
        {
            foreach (Card c in Hand)
            {
                if(c.Suit == "Hearts"){
                    if(c.Val == 10){
                        System.Console.Write($@"
.------.                                    
|{c.StringVal}  _ |
|( \/ )|
| \  / |
|  \/{c.StringVal}|
'------'");
                    }
                    else{
                        System.Console.Write($@"
.------.                                    
|{c.StringVal}_  _ |
|( \/ )|
| \  / |
|  \/ {c.StringVal}|
'------'");
                    }
                }
                if(c.Suit == "Diamonds"){
                    if(c.Val == 10){
                        System.Console.Write($@"
.------.
|{c.StringVal}/\  |
| /  \ |
| \  / |
|  \/{c.StringVal}|
'------'");
                    }
                    else{
                        System.Console.Write($@"
.------.
|{c.StringVal} /\  |
| /  \ |
| \  / |
|  \/ {c.StringVal}|
'------'");
                    }
                }
                if(c.Suit == "Clubs"){
                    if(c.Val == 10){
                        System.Console.Write($@"
.------.
|{c.StringVal}_   |
| ( )  |
|(_x_) |
|  Y {c.StringVal}|
'------'");
                    }
                    else{
                        System.Console.Write($@"
.------.
|{c.StringVal} _   |
| ( )  |
|(_x_) |
|  Y  {c.StringVal}|
'------'");
                    }
                }
                if(c.Suit == "Spades"){
                    if(c.Val == 10){
                        System.Console.Write($@"
.------.
|{c.StringVal}.   |
| / \  |
|(_,_) |
|  I {c.StringVal}|
'------'");
                    }
                    else{
                        System.Console.Write($@"
.------.
|{c.StringVal} .   |
| / \  |
|(_,_) |
|  I  {c.StringVal}|
'------'");
                    }
                }    
            }
            System.Console.WriteLine();
            foreach (Card c in Hand)
            {
                if(c.Suit == "Hearts")
                {
                    System.Console.Write(" [ ♥ " + c.Val + " ] ");
                }
                if(c.Suit == "Diamonds")
                {
                    System.Console.Write(" [ ♦ " + c.Val + " ] ");
                }
                if(c.Suit == "Clubs")
                {
                    System.Console.Write(" [ ♣ " + c.Val + " ] ");
                }
                if(c.Suit == "Spades")
                {
                    System.Console.Write(" [ ♠ " + c.Val + " ] ");
                }                
            }
        }
    }
}