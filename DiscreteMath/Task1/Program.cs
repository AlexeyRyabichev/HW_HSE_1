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
            do
            {
                try
                {
                    //Graph graph = FillGraph();
                    //Graph graph = TestGraph();
                    //Graph graph = MineGraph();

                    Console.WriteLine("Тестовый граф");
                    RunAllTests(TestGraph());

                    Console.WriteLine("\n\n\n\nГраф 185 варианта");
                    RunAllTests(MineGraph());
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

                Console.WriteLine("Press Esc to exit or another button to continue");
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }

        private static void RunAllTests(Graph graph)
        {
            PrintAdjancencyMatrix(graph);
        }

        private static void PrintAdjancencyMatrix(Graph graph)
        {
            Console.WriteLine("Весовая матрица смежности:");
            Array.ForEach(graph.WeightAdjacencyMatrix,
                row =>
                {
                    Array.ForEach(row, value => Console.Write($"{value}\t"));
                    Console.Write("\n");
                });
        }

        private static Graph MineGraph()
        {
            Graph graph = new Graph();
            int[,] vertices = {{1, 4}, {4, 3}, {8, 2}, {1, 5}, {9, 5}, {3, 0}};

            for (int i = 0; i < 6; i++)
                graph.AddVertex(new Vertex(vertices[i, 0], vertices[i, 1]));

            return graph;
        }

        private static Graph TestGraph()
        {
            Graph graph = new Graph();
            int[,] vertices = {{4, 1}, {4, 3}, {2, 7}, {9, 6}, {10, 7}, {6, 10}};

            for (int i = 0; i < 6; i++)
                graph.AddVertex(new Vertex(vertices[i, 0], vertices[i, 1]));

            return graph;
        }

        private static Graph FillGraph()
        {
            Graph graph = new Graph();

            Console.Write("Enter number of vertices: ");
            int number = int.Parse(Console.ReadLine() ?? throw new ArgumentNullException("Input is null"));

            for (int i = 0; i < number; i++)
            {
                Console.Write("Enter x: ");
                int x = int.Parse(Console.ReadLine() ?? throw new ArgumentNullException("Input is null"));
                Console.Write("Enter y: ");
                int y = int.Parse(Console.ReadLine() ?? throw new ArgumentNullException("Input is null"));
                graph.AddVertex(new Vertex(x, y));
            }

            return graph;
        }
    }
}