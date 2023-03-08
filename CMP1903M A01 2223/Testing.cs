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
        public Testing()
        {

            Program.PACK.outputPack();
            Program.PACK.shuffleCardPack(ShuffleType.Fisheryates);
            Console.WriteLine("Shuffling");
            Program.PACK.outputPack();

            Console.WriteLine("Dealing");
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(Program.PACK.deal().ToString());
            }
        }
    }
}
