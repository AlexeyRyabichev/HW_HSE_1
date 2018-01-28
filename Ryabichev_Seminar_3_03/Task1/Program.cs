using System;
using MyLib;

/*
 * Ученик:  Рябичев Алексей Михайлович
 * Ггруппа: БПИ176 (11)
 * Дата:    2017.01.28
 * Задача:  • В библиотеке классов описать:
                – событийный делегат SquareSizeChanged, представляющий методы c одним
                    вещественным параметром и возвращающие значение void.
                – класс Square – квадрат на плоскости. Квадрат задан координатами верхнего левого и
                    правого нижнего углов. В классе разместите:
                – событие OnSizeChanged с типом SquareSizeChanged;
                – свойства доступа к координатам определяющих углов квадрата. В коде каждого
                    свойства после изменения значения поля запускает событие OnSizeChanged, в
                    качестве параметра передаётся новое значение длины стороны квадрата.
            • В основной программе:
                – описать статический метод SquareConsoleInfo(A), возвращающий значение void и
                    выводящий в консоль, с точностью до двух знаков после запятой вещественное число
                    A, переданное в качестве параметра.
                – В методе Main() получить от пользователя координаты углов квадрата. На основе этих
                    координат создать объект S типа Square. Связать метод SquareConsoleInfo() с
                    событием OnSizeChanged объекта S. В цикле получать от пользователя координаты
                    правого нижнего угла квадрата X и Y, используя свойства объекта Square, изменять
                    координаты углов S, условие окончания цикла определить самостоятельно.
 */

namespace Task1
{
    class Program
    {
        private static void PrintInfo(Dot a) => Console.WriteLine($"X: {a.X:f3}\nY: {a.Y:f3}\n");

        private static void Main(string[] args)
        {
            do
            {
                try
                {
                    Console.Write("Enter x: ");
                    double x = double.Parse(Console.ReadLine() ?? throw new ArgumentNullException("Input was null"));
                    Console.Write("Enter y: ");
                    double y = double.Parse(Console.ReadLine() ?? throw new ArgumentNullException("Input was null"));

                    Dot d = new Dot(x, y);
                    d.OnCoordChanged += PrintInfo;

                    d.DotFlow();
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