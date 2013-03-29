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

        public static IEnumerable<NumberBond> GetAllNumberBonds()
        {
            for (int i = 0; i <= 10; i++)
            {
                foreach (var bond in GetNumberBonds(i))
                {
                    yield return bond;
                }
            }
        }

        public static IEnumerable<NumberBond> GetRandomNumberBondProblems()
        {
            var bonds = GetAllNumberBonds().ToList();
            var count = bonds.Count;
            NumberBond bond;

            while (true)
            {
                bond = (NumberBond)bonds[rand.Next(0, count)].MemberwiseClone();
                switch (rand.Next(0, 3))
                {
                    case 0:
                        bond.Sum = null; break;
                    case 1:
                        bond.Addend1 = null; break;
                    case 2:
                        bond.Addend2 = null; break;
                }
                yield return bond;
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
