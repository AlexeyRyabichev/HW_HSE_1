using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using Lib;

/*
 * Ученик:  Рябичев Алексей Михайлович
 * Ггруппа: БПИ176 (11)
 * Дата:    2018.06.07
 * Задача:  
 */

namespace Task
{
    internal class Program
    {
        private const string BinaryFileName = "outBin.bin";
        private const string XmlFileName = "outXML.xml";
        private const string JsonFileName = "outJSON.json";

        private static void Main(string[] args)
        {
            do
            {
                Random Random = new Random(DateTime.Now.Millisecond);
                try
                {
                    Journal journal = new Journal();

                    foreach (string tmp in File.ReadAllLines("data.txt"))
                    {
                        if (string.IsNullOrEmpty(tmp))
                            continue;

                        RegexOptions options = RegexOptions.None;
                        Regex regex = new Regex("[ ]{2,}", options);
                        string line = regex.Replace(tmp, " ");

                        string name = line.Split()[0];
                        string tmpLine = line.Split()[1];
                        uint speed = uint.Parse(line.Split()[1]);

                        journal += new Pair<string, uint>(name, speed);
                    }

                    journal.SerializeBinary(BinaryFileName);
                    journal.SerializeXml(XmlFileName);
                    journal.SerializeJson(JsonFileName);

                    Journal journalBinary = Journal.DeserializeBinary(BinaryFileName);
                    Journal journalXml = Journal.DeserializeXml(XmlFileName);
                    Journal journalJson = Journal.DeserializeJson(JsonFileName);

                    foreach (Journal tmpJournal in new List<Journal> {journalBinary, journalXml, journalJson})
                    {
                        foreach (Pair<string, uint> pair in tmpJournal) Console.WriteLine(pair.ToString());

                        Console.Write("\nLosers:\n");

                        foreach (Pair<string, uint> pair in tmpJournal.GetEnumeratorWithEnd(Random.Next(1, 6)))
                            Console.WriteLine(pair.ToString());

                        Console.Write("\n\n\n\n");
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