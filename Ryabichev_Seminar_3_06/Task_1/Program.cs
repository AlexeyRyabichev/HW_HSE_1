using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyLibTask1;

/*
 * Ученик:  Рябичев Алексей Михайлович
 * Ггруппа: БПИ176 (11)
 * Дата:    2017.mm.dd
 * Задача:  
 */

namespace Task_1
{
    class Program
    {
        static void Main(string[] args)
        {
            do
            {
                try
                {
                    Circle circle = new Circle();
                    Cube cube = new Cube();
                    ITransform transform = circle;
                    Report(circle);
                    Report(cube);
                    Report(transform);

                    Pyramide pyramide = new Pyramide{B = 2, H = 3};
                    Report(pyramide);
                    pyramide.Transform(2);
                    Report(pyramide);

                    ITransform[] transforms = new ITransform[3];
                    transforms[0] = new Cube{Rib = 2};
                    transforms[1] = new Circle{Rad = 2};
                    transforms[2] = new Cylinder{H = 2, R = 3};

                    Array.ForEach(transforms, Report);
                    Array.ForEach(transforms, transform1 => transform1.Transform(2));
                    Array.ForEach(transforms, Report);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                Console.WriteLine("Press Esc to exit or another button to continue");
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }

        static void Report(ITransform transform)
        {
            Console.WriteLine($"Object type is: {transform.GetType()}\n{transform}\n");
        }
    }
}