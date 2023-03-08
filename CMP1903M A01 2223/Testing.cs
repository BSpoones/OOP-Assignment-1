using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CMP1903M_A01_2223.CardShuffle;

namespace CMP1903M_A01_2223
{
    public class Testing
    {
        public static void Test()
        {
            /*
             * Requirements for testing:
             * 
             * - Create pack instance
             * - Shuffle the pack with all 3 methods
             * - Deal 1 card
             * - Deal x cards based on user input
             */

            // Pack instance already created in Program

            // Shuffling the pack
            Console.WriteLine("Shuffling cards");
            Pack.shuffleCardPack(ShuffleType.Fisheryates);
            Pack.shuffleCardPack(ShuffleType.Riffle);
            Pack.shuffleCardPack(ShuffleType.None);

            // Deals one card
            Console.WriteLine(Pack.deal().ToString());

            // Dealing x cards
            int cardCount;
            while (true)
            {
                try
                {
                    // Taking user input
                    Console.WriteLine("Select number of cards to deal: ");
                    cardCount = int.Parse(Console.ReadLine());

                    // Value check
                    if (0 < cardCount && cardCount <= Program.PACK.cardPack.Count())
                    {
                        break;
                    }
                    else
                    {
                        throw new ArgumentOutOfRangeException("Invalid number of cards");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }

            // Fetching cards
            List<Card> dealtCards = Pack.dealCard(cardCount);
            Console.WriteLine($"Showing all {cardCount} card{(cardCount > 1 ? "s" : "")}");
            foreach (Card dealtCard in dealtCards)
            {
                Console.WriteLine(dealtCard.ToString());
            }
        }
    }
}
