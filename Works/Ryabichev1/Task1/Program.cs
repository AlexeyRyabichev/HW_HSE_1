using System;
using MyLib;

/*
 * Ученик:  Рябичев Алексей Михайлович
 * Ггруппа: БПИ176 (11)
 * Дата:    2017.mm.dd
 * Задача:  
 */

namespace Task1
{
    internal class Program
    {
        private static readonly Random random = new Random(DateTime.Now.Millisecond);

        private static void Main(string[] args)
        {
            do
            {
                try
                {
                    AlgComplexNumb[] algComplexNumbs = new AlgComplexNumb[GetNumber()];
                    for (int i = 0; i < algComplexNumbs.Length; i++)
                        algComplexNumbs[i] =
                            new AlgComplexNumb(GetRandomNumber().ToString(), GetRandomNumber().ToString());

                    Console.WriteLine("Not sorted:");
                    Array.ForEach(algComplexNumbs,
                        numb => Console.Write($"Number: {numb.ToString()}\tAbsolute: {numb.Absolute:f3}\n"));

                    Array.Sort(algComplexNumbs);

                    Console.WriteLine("\n\nSorted:");
                    Array.ForEach(algComplexNumbs,
                        numb => Console.Write($"Number: {numb.ToString()}\tAbsolute: {numb.Absolute:f3}\n"));
                }
                catch (ArgumentOutOfRangeException e)
                {
                    Console.WriteLine($"Out of range exception: {e.Message}");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

                Console.WriteLine("Press Esc to exit or another button to continue");
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }

        /// <summary>
        /// Input of array size
        /// </summary>
        /// <returns>array size</returns>
        private static int GetNumber()
        {
            int x;
            bool flag = false;
            do
            {
                Console.Write("Enter size of array: ");
                if (!(int.TryParse(Console.ReadLine(), out x) && x > 0))
                    Console.WriteLine("Size must be more then zero");
                else
                    flag = true;
            } while (!flag);

            return x;
        }

        /// <summary>
        /// Create random number
        /// </summary>
        /// <returns>random number</returns>
        private static double GetRandomNumber()
        {
            return random.Next(-10, 10) + random.NextDouble();
        }
    }
}