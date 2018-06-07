using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Ученик:  Рябичев Алексей Михайлович
 * Ггруппа: БПИ176 (11)
 * Дата:    2017.mm.dd
 * Задача:  
 */

namespace Task7
{
    class Program
    {
        static void Main(string[] args)
        {
            do
            {
                try
                {

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