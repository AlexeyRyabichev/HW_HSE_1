using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyLib4;

/*
 * Ученик:  Рябичев Алексей Михайлович
 * Ггруппа: БПИ176 (11)
 * Дата:    2017.mm.dd
 * Задача:  
 */

namespace Task4
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
                    Transformer transformer = new Transformer();
                    Figure[] figures = new Figure[10];

                    for (int i = 0; i < figures.Length; i++)
                    {
                        Figure tmp = random.Next() % 2 == 0 ? (Figure) new Square(random.Next(5, 15) + random.NextDouble()) : new Triangle(random.Next(5, 15) + random.NextDouble());
                        transformer.OnChangeSize += tmp.IsIncreasedEventHandler;
                        figures[i] = tmp;
                    }

                    Array.ForEach(figures, figure => Console.WriteLine(figure.ToString()));

                    int n;
                    bool flag = false;
                    do
                    {
                        Console.Write("Enter N: ");
                        if (int.TryParse(Console.ReadLine(), out n))
                        {
                            if (n <= 1)
                                Console.WriteLine("Please, enter N bigger than 1");
                            else
                                flag = true;
                        }
                        else
                            Console.WriteLine("String is not int type");
                    } while (!flag);



                    for (int i = 0; i < n; i++)
                    {
                        Console.WriteLine($"\nChanged {i + 1} times: ");
                        transformer.ChangeSize(random.Next(3, 8));
                        Array.ForEach(figures, figure => Console.WriteLine(figure.ToString()));
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