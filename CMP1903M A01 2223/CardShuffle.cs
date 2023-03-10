using System;
using System.Collections.Generic;

namespace CMP1903M_A01_2223
{
    public class CardShuffle
    /*
     * This class contains 2 shuffle algorithms
     * Fisher-Yates shuffle and Riffle shuffle
     * Contains enum to convert shuffle type to int
     */
    {
        public enum ShuffleType
        {
            Fisheryates = 1,
            Riffle = 2,
            None = 3
        }

        public static bool fisherShuffle(List<Card> cards)
        {
            /*
             * Fisher-Yates shuffle works by iterating through the deck,
             * swapping the current card with a random card all the way
             * through the deck until 52 swaps have occured
             */
            // Ensuring that a 52 card deck is used
            if (cards.Count != 52)
            {
                throw new ArgumentOutOfRangeException("Invalid deck length");
            }

            for (int i = cards.Count - 1; i > 0; i--)
            {
                // Finding a random card to swap with
                int j = Program.random.Next(i + 1);

                // Swapping the cards around
                (cards[j], cards[i]) = (cards[i], cards[j]);
            }
            Program.PACK.cardPack = cards;
            return true;
        }

        public static bool riffleShuffle(List<Card> cards) { 
            // Riffle shuffle works by splitting a deck in two, then
            // combining them one at a time from each half

            // Ensuring that a 52 card deck is used
            if (cards.Count != 52)
            {
                throw new ArgumentOutOfRangeException("Invalid deck length");
            }

            // Splitting deck in two
            // No rounding required as it's forced to be an even number (52)
            int halfway = cards.Count / 2; 

            // Splitting the deck in two
            List<Card> leftHalf = cards.GetRange(0, halfway);
            List<Card> rightHalf = cards.GetRange(halfway, cards.Count - halfway);

            // Combining the half-decks
            List<Card> shuffledCards = new List<Card>();
            for (int i = 0; i<halfway; i++)
            {
                shuffledCards.Add(leftHalf[i]);
                shuffledCards.Add(rightHalf[i]);
            }
            Program.PACK.cardPack = shuffledCards;
            return true;
        }
        public static bool noShuffle(List<Card> cards)
        {
            // noShuffle method returns the cards exactly as they
            // were given
            Program.PACK.cardPack = cards;
            return true;
        }
    }
}
