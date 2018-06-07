// Алексей Рябичев
// Task1 Lib Journal.cs
// 2018 06 07 2:07 PM

using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace Lib
{
    [Serializable]
    public class Journal
    {
        private static readonly XmlSerializer Serializer = new XmlSerializer(typeof(Journal));

        public Journal()
        {
            Results = new List<Pair<string, double>>();
        }

        public List<Pair<string, double>> Results { get; set; }

        public static Journal operator +(Journal journal, Pair<string, double> pair)
        {
            journal.Results.Add(pair);
            return journal;
        }

        public IEnumerable<Pair<string, double>> MyItr(int end)
        {
            List<Pair<string, double>> list = new List<Pair<string, double>>(Results);
            list.Sort();

            for (int i = 0; i <= end; i++) yield return list[i];
        }

        public IEnumerator GetEnumerator()
        {
            List<Pair<string, double>> a = Results;
            a.Sort();
            a.Reverse();

            foreach (Pair<string, double> cur in a) yield return cur;
        }

        public void Serialize(string path)
        {
            using (FileStream fileStream = new FileStream(path, FileMode.Create))
            {
                Serializer.Serialize(fileStream, this);
            }

            Console.WriteLine("");
        }

        public static Journal Deserialize(string path)
        {
            using (FileStream fileStream = new FileStream(path, FileMode.Open))
            {
                return (Journal) Serializer.Deserialize(fileStream);
            }
        }
    }
}