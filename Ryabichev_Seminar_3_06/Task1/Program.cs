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
        private static void Main(string[] args)
        {
            Random random = new Random(DateTime.Now.Millisecond);
            do
            {
                try
                {
                    Figure[] figures = new Figure[random.Next(3, 11)];

                    for (int i = 0; i < figures.Length; i++)
                        figures[i] = random.Next() % 2 == 0 ? new Cube(random.Next(1, 10)) :
                            random.Next() % 2 == 0 ? (Figure) new SquareClass(random.Next(1, 10)) :
                            new Triangle(random.Next(1, 10));

                    Array.ForEach(figures,
                        figure => Console.Write(
                            $"Figure type is: {figure.GetType()}\n\t" +
                            $"Side: {figure.Side:f3}\n\t" +
                            $"Square: {figure.Square():f3}\n\t" +
                            $"Volume: {FigureVolume(figure)}\n\n"));
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

                Console.WriteLine("Press Esc to exit or another button to continue");
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }

        private static string FigureVolume(Figure figure)
        {
            string ans;
            try
            {
                ans = figure.Volume().ToString();
            }
            catch (NotImplementedException e)
            {
                ans = "No volume for this figure";
            }

            return ans;
        }
    }
}