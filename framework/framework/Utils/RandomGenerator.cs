using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAutomation.Utils
{
    class RandomGenerator
    {
        private static readonly Random random = new Random();

        public static int GetRandomDaysQuantity()
        {
            return random.Next() % 9 + 1;
        }
    }
}
