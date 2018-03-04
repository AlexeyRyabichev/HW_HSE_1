using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyLib1;

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
            Random random = new Random(DateTime.Now.Millisecond);
            do
            {
                try
                {
                    TestClass[] classes = new TestClass[1000000];
                    TestStruct[] structs = new TestStruct[1000000];

                    for (int i = 0; i < classes.Length; i++)
                    {
                        classes[i] = new TestClass {X = random.Next()};
                        structs[i] = new TestStruct {X = random.Next()};
                    }

                    Stopwatch sw = new Stopwatch();
                    sw.Start();
                    Array.Sort(structs); // сортируем массив структур
                    sw.Stop();
                    PrintTime(sw.Elapsed);
                    sw.Start();
                    Array.Sort(classes); // сортируем массив объектов классов
                    sw.Stop();
                    PrintTime(sw.Elapsed);

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

                Console.WriteLine("Press Esc to exit or another button to continue");
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }

        public static void PrintTime(TimeSpan timesp)
        {
            string elapsedTime =
                String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                    timesp.Hours, timesp.Minutes, timesp.Seconds,
                    timesp.Milliseconds / 10);
            Console.WriteLine("RunTime: " + elapsedTime);
        }
    }
}