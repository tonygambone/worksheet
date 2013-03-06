using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Worksheet
{
    class NumberBond
    {
        private static Random rand = new Random();

        private NumberBond() {}

        public int? Sum { get; private set; }
        public int? Addend1 { get; private set; }
        public int? Addend2 { get; private set; }

        public static IEnumerable<NumberBond> GetNumberBonds(int sum)
        {
            for (int a1 = 0; a1 <= sum / 2; a1++)
                yield return new NumberBond
                {
                    Sum = sum,
                    Addend1 = a1,
                    Addend2 = sum - a1,
                };
        }

        public static NumberBond GetRandomNumberBond(int sum)
        {
            var a1 = rand.Next(0, sum);
            return new NumberBond { Sum = sum, Addend1 = a1, Addend2 = sum - a1 };
        }

        public static IEnumerable<NumberBond> GetRandomNumberBonds()
        {
            while (true)
            {
                var sum = rand.Next(0, 11);
                yield return GetRandomNumberBond(sum);
            }
        }

        public static IEnumerable<NumberBond> GetRandomNumberBondProblems()
        {
            foreach (var b in GetRandomNumberBonds())
            {
                switch (rand.Next(0, 3))
                {
                    case 0:
                        b.Sum = null; break;
                    case 1:
                        b.Addend1 = null; break;
                    case 2:
                        b.Addend2 = null; break;
                }
                yield return b;
            }
        }

        public override string ToString()
        {
            var sum = Sum.HasValue ? Sum.Value.ToString() : "_";
            var a1 = Addend1.HasValue ? Addend1.Value.ToString() : "_";
            var a2 = Addend2.HasValue ? Addend2.Value.ToString() : "_";
            return string.Format("{0} + {1} = {2}", 
                a1, 
                a2, 
                sum);
        }
    }
}
