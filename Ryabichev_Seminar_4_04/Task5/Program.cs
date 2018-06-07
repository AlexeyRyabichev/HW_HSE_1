using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lib;

/*
 * Ученик:  Рябичев Алексей Михайлович
 * Ггруппа: БПИ176 (11)
 * Дата:    2017.mm.dd
 * Задача:  
 */

namespace Task5
{
    class Program
    {
        static void Main(string[] args)
        {
            do
            {
                try
                {
                    object[] values = {1, 2, 3, 4, 5, 6};

                    for (int i = 0; i < 6; i++)
                    {
                        IteratorSample iteratorSample = new IteratorSample(values, i);
                        foreach (object o in iteratorSample)
                        {
                            Console.Write($"{o}\t");
                        }
                        Console.Write("\n");
                    }

                    Console.Write("\n\nBackward\n\n");

                    for (int i = 0; i < 6; i++)
                    {
                        IteratorSampleBackward iteratorSampleBackward = new IteratorSampleBackward(values, i);
                        foreach (object o in iteratorSampleBackward)
                        {
                            Console.Write($"{o}\t");
                        }
                        Console.Write("\n");
                    }

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                Console.WriteLine("Press Esc to exit or another button to continue");
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }
    }
}