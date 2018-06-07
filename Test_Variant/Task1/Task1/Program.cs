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

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            do
            {
                try
                {
                    Journal journal = new Journal();
                    //foreach (object o in Journal.Deserialize("data.txt"))
                    //{
                    //    journal += (Pair<string, double>)o;
                    //}
                    //journal.Serialize("out.ser");
                    //Journal spisok = Journal.Deserialize("out.ser");
                    //Console.WriteLine("File deserialized");
                    //foreach (object o in spisok)
                    //{
                    //    Console.Write($"{o}\n");
                    //}
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