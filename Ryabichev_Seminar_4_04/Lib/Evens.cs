using System;
using System.Collections;
using System.Runtime.CompilerServices;

namespace Lib
{
    public class Evens : IEnumerable
    {
        public int Nmin, Nmax;

        public Evens(int nmin, int nmax)
        {
            if (nmin >= nmax)
                throw new Exception("Error");
            Nmin = nmin;
            Nmax = nmax;
        }

        public IEnumerator GetEnumerator()
        {
            for (int i = Nmin; i <= Nmax; ++i)
            {
                bool flag = false;
                for (int j = 2; j <= Math.Sqrt(i); j++)
                {
                    if (i % j == 0)
                    {
                        flag = true;
                        break;
                    }
                }
                if (!flag)
                    yield return i;
            }
        }
    }
}