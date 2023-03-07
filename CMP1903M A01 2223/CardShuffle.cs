using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903M_A01_2223
{
    class CardShuffle
    {
        public enum ShuffleType
        {
            FISHERYATES = 1,
            RIFFLE = 2,
            NONE = 3
        }

        public static List<Card> fisherShuffle(List<Card> cards)
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

            Random random = new Random();


            for (int i = cards.Count - 1; i > 0; i--)
            {
                // Finding a random card to swap with
                int j = random.Next(i + 1);

                // Swapping the cards around
                Card tempCard = cards[i];
                cards[i] = cards[j];
                cards[j] = tempCard;
            }
            return cards;
        }

        public static List<Card> riffleShuffle(List<Card> cards) { 
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

            return shuffledCards;
        }

    }
}
