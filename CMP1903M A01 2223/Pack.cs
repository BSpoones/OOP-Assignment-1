using System;
using System.Collections.Generic;
using System.Linq;
using static CMP1903M_A01_2223.CardShuffle;

namespace CMP1903M_A01_2223
{
    public class Pack
    /*
     * Pack class
     * 
     * This class contains functions to create a card pack,
     * as well as shuffle and deal cards.
     */
    {
        public List<Card> cardPack =  makePack();

        public static bool shuffleCardPack(int shuffleType)
            /*
            * Shuffles the card pack using the chosen shuffle method.
            * Uses the 3 available shuffle methods:
            * - Fisher-Yates shuffle (https://en.wikipedia.org/wiki/Fisher–Yates_shuffle)
            * - Riffle shuffle (https://www.youtube.com/watch?v=o-KBNdbJOGk)
            * - No shuffle
            */
        {
            ShuffleType shuffle = getShuffleType(shuffleType);
            switch (shuffle)
            {
                case ShuffleType.Fisheryates:
                    return fisherShuffle(Program.PACK.cardPack);
                case ShuffleType.Riffle:
                    return riffleShuffle(Program.PACK.cardPack);
                case ShuffleType.None:
                    return noShuffle(Program.PACK.cardPack);
                default:
                    throw new ArgumentOutOfRangeException("Invalid input");
            }
        }
        private static ShuffleType getShuffleType(int shuffleType)
        /*
         * Converts an integer shuffle type to an enum value
         * from ShuffleType
         */
        {
            switch (shuffleType)
            {
                case 1:
                    return ShuffleType.Fisheryates;
                case 2:
                    return ShuffleType.Riffle;
                case 3:
                    return ShuffleType.None;
                default: 
                    throw new ArgumentOutOfRangeException("Invalid shuffle type");
            }
        }

        public static Card deal()
        {
            /*
            * Deals one card from the top of the deck
            */

            if (Program.PACK.cardPack.Count < 1)
            {
                throw new ArgumentOutOfRangeException("No cards left to deal");
            }
            Card dealtCard = Program.PACK.cardPack.First();
            // Dealing a card means it is removed from the pack
            Program.PACK.cardPack.Remove(dealtCard);
            return dealtCard;
        }
        public static List<Card> dealCard(int amount)
        {
            //Deals the number of cards specified by 'amount'

            // Getting the cards
            // NOTE: Error handling not required as the smallest value between amount and card count is used
            List<Card> dealtCards = Program.PACK.cardPack.GetRange(0, Math.Min(amount, Program.PACK.cardPack.Count()));
            Program.PACK.cardPack.RemoveRange(0, Math.Min(amount, Program.PACK.cardPack.Count()));
            return dealtCards;
        }

         public static List<Card> makePack()
        {
            /*
             * Creates a list of 52 card objects
             */
            List<Card> cardPack = new List<Card>();
            // Creating an unsorted card pack
            foreach (Card.SuitType suit in Enum.GetValues(typeof(Card.SuitType)))
            {
                // Each card suit
                for (int j = 1; j <= 13; j++)
                {
                    // Each card value
                    cardPack.Add(new Card(suit, j));
                }
            }
            return cardPack;
        }
        public static void OutputPack(List<Card> cardPack)
        {
            /*
             * Outputs a given card pack line by line to the console
             */
            foreach (Card card in cardPack)
            {
                Console.WriteLine(card.ToString());
            }
        }
    }
    
}
