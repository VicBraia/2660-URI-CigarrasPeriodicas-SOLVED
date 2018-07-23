using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CigarrasPeriodicas
{
    class Program
    {
        public static ulong N, L, currentCycle = 1, bestCycle, lifeTime = 1;
        public static string[] line;

        public static ulong MDC(ulong a, ulong b)
        {
            if (a == 0) return b;
            else return MDC(b % a, a);
        }

        public static ulong MMC(ulong a, ulong b)
        {
            return a * b / MDC(a, b);
        }

        public static void FindLifeTime()
        {
            for (ulong i = 0; i <= L; i++)
            {
                ulong cycle = MMC(currentCycle, i);

                if (cycle > bestCycle && cycle <= L)
                {
                    bestCycle = cycle;
                    lifeTime = i;
                }
            }
        }

        static void Main(string[] args)
        {
            line = Console.ReadLine().Split();
            N = ulong.Parse(line[0]);
            L = ulong.Parse(line[1]);

            line = Console.ReadLine().Split();
            for (ulong i = 0; i < N; i++)
            {
                ulong n = ulong.Parse(line[i]);
                currentCycle = MMC(currentCycle, n);
            }
            bestCycle = currentCycle;

            FindLifeTime();

            Console.WriteLine(lifeTime);
        }
    }
}
