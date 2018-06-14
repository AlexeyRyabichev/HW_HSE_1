using System;
using System.Collections.Generic;
using System.IO;
using CWLibrary;

/*
 * Ученик:  Рябичев Алексей Михайлович
 * Ггруппа: БПИ176 (11)
 * Дата:    2018.06.14
 * Вариант: 2
 */

namespace Task
{
    internal class Program
    {
        public static string FileName = "dictionary.txt";
        public static string SerializationFileName = "out.bin";

        private static void Main(string[] args)
        {
            do
            {
                try
                {
                    int n = 0;
                    bool flag = false;

                    #region get n

                    while (!flag)
                    {
                        Console.Write("Enter number of strings: ");
                        flag = int.TryParse(Console.ReadLine(), out n);
                        if (!flag)
                            Console.WriteLine("Wrong input, try again");
                    }

                    #endregion

                    #region write to file

                    string toWrite = "";
                    for (int i = 0; i < n; i++)
                    {
                        Console.Write("Enter first word: ");
                        toWrite += Console.ReadLine().Replace(" ", "") + "\t";
                        Console.Write("Enter second word: ");
                        toWrite += Console.ReadLine().Replace(" ", "") + "\n";
                    }

                    File.WriteAllText(FileName, toWrite);

                    #endregion

                    #region read from file

                    Dictionary dict = new Dictionary(new List<Pair<string, string>>());
                    foreach (string line in File.ReadAllLines(FileName))
                        dict.Add(line.Split('\t')[0].Replace(" ", ""), line.Split('\t')[1].Replace(" ", ""));

                    if (dict.Words.Count != n)
                        throw new ArgumentException("Wrong strings number");

                    #endregion

                    #region serailze-deserialize

                    dict.MySerialize(SerializationFileName);
                    Dictionary dict2 = Dictionary.MyDeserialize(SerializationFileName);

                    #endregion

                    #region output

                    string locale = dict2.Locale == 1 ? "english" : "русский";
                    Console.Write($"\nDictionary locale: {locale}\n\nWithout length\n");

                    foreach (Pair<string, string> pair in dict2) Console.WriteLine(pair);

                    int length = Dictionary.Random.Next(2, 8);

                    Console.Write($"\nWith length: {length}\n");

                    foreach (Pair<string, string> pair in dict2.EnumeratorWithLength(length)) Console.WriteLine(pair);

                    #endregion
                }
                catch (ArgumentException e)
                {
                    Console.Write(e.Message);
                }
                catch (FileNotFoundException e)
                {
                    Console.WriteLine("File not found\n" + e.Message);
                }
                catch (Exception e)
                {
                    Console.Write("Error\n" + e.Message);
                }

                Console.WriteLine("Press Esc to exit or another button to continue");
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }
    }
}