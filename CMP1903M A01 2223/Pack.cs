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

        public static bool shuffleCardPack(ShuffleType shuffleType)
        /*
         * Shuffles the card pack using the chosen shuffle method.
         * Uses the 3 available shuffle methods:
         * - Fisher-Yates shuffle (https://en.wikipedia.org/wiki/Fisher–Yates_shuffle)
         * - Riffle shuffle (https://www.youtube.com/watch?v=o-KBNdbJOGk)
         * - No shuffle
         */
        {
            switch (shuffleType)
            {
                case ShuffleType.Fisheryates:
                    Program.PACK.cardPack = fisherShuffle(Program.PACK.cardPack);
                    break;
                case ShuffleType.Riffle:
                    Program.PACK.cardPack = riffleShuffle(Program.PACK.cardPack);
                    break;
                case ShuffleType.None:
                    // Do nothing since cards is already unshuffled
                    break;
                default:
                    throw new ArgumentOutOfRangeException("Invalid input");
            }
            return true;
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
            return Program.PACK.cardPack.GetRange(0, Math.Min(amount, Program.PACK.cardPack.Count()));
        }

        public static List<Card> makePack()
        {
            List<Card> cardPack = new List<Card>();
            // Creating an unsorted card pack
            for (int i = 1; i <= 4; i++)
            {
                // Each card suit
                for (int j = 1; j <= 13; j++)
                {
                    // Each card value
                    // Console.WriteLine(i.ToString() + " " + j.ToString());
                    cardPack.Add(new Card(i, j));
                }
            }
            return cardPack;
        }
        public static void OutputPack(List<Card> cardPack)
        {
            foreach (Card card in cardPack)
            {
                Console.WriteLine(card.ToString());
            }
        }
    }
    
}
