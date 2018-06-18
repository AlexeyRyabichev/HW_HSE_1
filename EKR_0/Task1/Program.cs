using System;
using System.IO;
using System.Text.RegularExpressions;

namespace Task1
{
    class Program
    {
        private static readonly Random Random = new Random(DateTime.Now.Millisecond);
        private static string _fileName = "data.txt";
        private static int S;
        private static int X;
        private static int F;

        public static void CreateFile()
        {
            TextWriter textWriter = new StreamWriter("../../../" + _fileName);
            
            for (int i = 0; i < S; i++)
            {
                string toWrite = "";
                for (int j = 0; j < Random.Next(1, S + 1); j++)
                {
                    toWrite += Random.Next(1, F + 1) + " ";
                }

                toWrite = toWrite.Substring(1);
                textWriter.Write(toWrite);
            }
            
            textWriter.Close();
        }
        
        public static void Main(string[] args)
        {
            Console.Write("S = ");
            S = int.Parse(Console.ReadLine());
            
            Console.Write("X = ");
            X = int.Parse(Console.ReadLine());
            
            Console.Write("F = ");
            F = int.Parse(Console.ReadLine());
            
            CreateFile();

        }
    }
}