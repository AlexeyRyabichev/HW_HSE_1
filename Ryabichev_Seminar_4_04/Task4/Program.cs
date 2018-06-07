using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lib;

namespace Task4
{
    class Program
    {
        static void Main(string[] args)
        {
            Evens evens = new Evens(10, 100);
            foreach (var even in evens)
            {
                Console.WriteLine(even);
            }

            Console.ReadKey();
        }
    }
}
