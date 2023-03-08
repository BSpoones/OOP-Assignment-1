using System;

namespace CMP1903M_A01_2223
{
    public class Card
    /*
     * This class represents a playing card with a suit and a value
     * Contains an enum for Suit Type to convert integer to suit name
     * Contains custom ToString func to format card properly
     */
    {
        public int Value { get; set; }
        public int Suit { get; set; }

        public Card(int suit, int value)
        
        {
            Suit = suit;
            Value = value;
        }

        public enum SuitType
        // Enum for card types to provide suit names
        {
            Spades = 1,
            Clubs = 2,
            Hearts = 3,
            Diamonds = 4

        }
        public override string ToString()
        {
            return $"Card: {Value} of {((SuitType)Suit).ToString()}";

        }

    }
}
