using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CMP1903M_A01_2223.CardShuffle;

namespace CMP1903M_A01_2223
{
    public class Pack
    {
        public List<Card> cardPack =  makePack();

        public static bool shuffleCardPack(ShuffleType shuffleType)
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
        public Card deal()
        {
            /*
            * Deals one card from the top of the deck
            */

            if (cardPack.Count < 1)
            {
                throw new ArgumentOutOfRangeException("No cards left to deal");
            }
            Card dealtCard = cardPack.First();
            // Dealing a card means it is removed from the pack
            cardPack.Remove(dealtCard);
            return dealtCard;
        }
        public List<Card> dealCard(int amount)
        {
            //Deals the number of cards specified by 'amount'
            return cardPack.GetRange(0, Math.Min(amount, cardPack.Count()));
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
        public void outputPack()
        {
            foreach (Card card in cardPack)
            {
                Console.WriteLine(card.ToString());
            }
        }
    }
    
}
