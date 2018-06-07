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

namespace Task6
{
    class Program
    {
        static void Main(string[] args)
        {
            do
            {
                try
                {
                    FileLines fileLines = new FileLines(@"..\..\Program.cs");

                    foreach (string line in fileLines)
                        Console.WriteLine(line);

                    Console.Write("\n\nOne more time\n\n");

                    foreach (string line in fileLines)
                        Console.WriteLine(line);
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