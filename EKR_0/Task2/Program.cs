using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Task2
{
    class Program
    {
        private const string FileName = "../../../" + "data.txt";

        public static void Main(string[] args)
        {
            TextReader reader = new StreamReader(FileName);

            string s = reader.ReadLine();

            while (s != null)
            {
                Console.WriteLine(s);
                s = reader.ReadLine();
            }
            
            Processing processing = new Processing(FileName);

            foreach (Data data in processing)
            {
                Console.WriteLine(data);
            }

            var datas = from data in processing orderby (data.D / data.M) descending select data;

            foreach (Data data in datas)
            {
                Console.WriteLine(data);
            }
        }
    }
}