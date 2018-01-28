using System;
using MyLib;

/*
 * Ученик:  Рябичев Алексей Михайлович
 * Ггруппа: БПИ176 (11)
 * Дата:    2017.01.28
 * Задача:  • В библиотеке классов описать:
                – событийный делегат CoordChanged, представляющий методы одним параметром
                    типа Dot, возвращающие значение void.
                – класс Dot – точка на плоскости с двумя вещественными координатами. В классе
                    разместите:
                        – событие OnCoordChanged с типом CoordChanged;
                        – метод DotFlow(), который в цикле присваивает координатам точки 10 раз случайные
                            вещественные значения из диапазона (-10; 10). Если обе координаты точки
                            отрицательные значения – запускать событие OnCoordChanged, и передавать в него
                            ссылку на объект.
            • В основной программе:
                – описать статический метод PrintInfo(A), возвращающий значение void и выводящий в
                    консоль координаты объекта A типа Dot, переданного в качестве параметра.
                – В методе Main() получить от пользователя две вещественные координаты X и Y.
                    Создать объект D типа Dot с координатами X и Y. Подписать метод PrintInfo() на
                    событие OnCoordChanged. Запустить для объекта D метод DotFlow().
 */

namespace Task2
{
    class Program
    {
        private static void SquareConsoleInfo(double a) => Console.WriteLine($"Square side size: {a:f2}\n");

        private static void Main(string[] args)
        {
            do
            {
                try
                {
                    //Вывожу длину диагонали, а не стороны, т.к. пользователь может ввести координаты, которые изменят квадрат на прямоугольник
                    Console.Write("Enter left point x:");
                    double leftX = double.Parse(Console.ReadLine() ?? throw new ArgumentNullException("Input is null"));
                    Console.Write("Enter left point y:");
                    double lefty = double.Parse(Console.ReadLine() ?? throw new ArgumentNullException("Input is null"));
                    Console.Write("Enter right point x:");
                    double rightX =
                        double.Parse(Console.ReadLine() ?? throw new ArgumentNullException("Input is null"));
                    Console.Write("Enter right point x:");
                    double rightY =
                        double.Parse(Console.ReadLine() ?? throw new ArgumentNullException("Input is null"));

                    Square square = new Square(new Point(leftX, lefty), new Point(rightX, rightY));
                    square.OnSquareSizeChanged += SquareConsoleInfo;

                    do
                    {
                        Console.Write("\n\nEnter right point x:");
                        rightX = double.Parse(Console.ReadLine() ?? throw new ArgumentNullException("Input is null"));
                        Console.Write("Enter right point x:");
                        rightY = double.Parse(Console.ReadLine() ?? throw new ArgumentNullException("Input is null"));

                        square.Right = new Point(rightX, rightY);

                        Console.WriteLine("Press Esc to exit or another button to change coordinates");
                    } while (Console.ReadKey().Key != ConsoleKey.Escape);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

                Console.WriteLine("Press Esc to exit or another button to start again");
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }
    }
}