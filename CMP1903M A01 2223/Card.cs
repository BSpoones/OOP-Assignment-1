using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903M_A01_2223
{
    public class Card
    {
        //Base for the Card class.
        //Value: numbers 1 - 13
        //Suit: numbers 1 - 4
        //The 'set' methods for these properties could have some validation
        public int Value { get; set; }
        public int Suit { get; set; }

        public Card(int suit, int value)
        {
            Suit = suit;
            Value = value;
        }
        
        public enum SuitType{
            Spades = 1,
            Clubs = 2,
            Hearts = 3,
            Diamonds = 4
        
        }
        public override string ToString(){
            return $"Card: {Value} of {((SuitType)Suit).ToString()}";

    }
    
    }
}
