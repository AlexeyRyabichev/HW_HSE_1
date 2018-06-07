// Алексей Рябичев
// Ryabichev_KR_4_3 Lib Journal.cs
// 2018 06 07 2:46 PM

using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Json;
using System.Xml.Serialization;

namespace Lib
{
    [Serializable]
    [DataContract]
    public class Journal
    {
        private static readonly BinaryFormatter BinaryFormatter = new BinaryFormatter();
        private static readonly XmlSerializer XmlSerializer = new XmlSerializer(typeof(Journal));

        private static readonly DataContractJsonSerializer JsonSerializer =
            new DataContractJsonSerializer(typeof(Journal));

        [DataMember] private List<Pair<string, uint>> _results = new List<Pair<string, uint>>();

        /// <summary>
        ///     Standart constructor
        /// </summary>
        public List<Pair<string, uint>> Results
        {
            get => _results;
            set => _results = value;
        }

        public static Journal operator +(Journal journal, Pair<string, uint> element)
        {
            journal.Results.Add(element);
            return journal;
        }

        /// <summary>
        ///     Enumerator for class
        /// </summary>
        /// <returns>next Pair element</returns>
        public IEnumerator<Pair<string, uint>> GetEnumerator()
        {
            List<Pair<string, uint>> list = new List<Pair<string, uint>>(Results);
            list.Sort();
            foreach (Pair<string, uint> pair in list) yield return pair;
        }

        /// <summary>
        ///     Custom enumerator for class
        /// </summary>
        /// <param name="end">how many elements</param>
        /// <returns>next Pair element</returns>
        public IEnumerable<Pair<string, uint>> GetEnumeratorWithEnd(int end)
        {
            List<Pair<string, uint>> list = new List<Pair<string, uint>>(Results);
            list.Sort();
            list.Reverse();

            if (end >= list.Count) end = list.Count - 1;

            for (int i = 0; i <= end; i++) yield return list[i];
        }


        public void SerializeBinary(string path)
        {
            using (FileStream fileStream = new FileStream(path, FileMode.Create))
            {
                BinaryFormatter.Serialize(fileStream, this);
                fileStream.Close();
            }
        }

        public void SerializeXml(string path)
        {
            using (FileStream fileStream = new FileStream(path, FileMode.Create))
            {
                XmlSerializer.Serialize(fileStream, this);
                fileStream.Close();
            }
        }

        public void SerializeJson(string path)
        {
            using (FileStream fileStream = new FileStream(path, FileMode.Create))
            {
                JsonSerializer.WriteObject(fileStream, this);
                fileStream.Close();
            }
        }

        public static Journal DeserializeBinary(string path)
        {
            using (FileStream fileStream = new FileStream(path, FileMode.Open))
            {
                Journal journal = (Journal) BinaryFormatter.Deserialize(fileStream);
                fileStream.Close();
                return journal;
            }
        }

        public static Journal DeserializeXml(string path)
        {
            using (FileStream fileStream = new FileStream(path, FileMode.Open))
            {
                Journal journal = (Journal) XmlSerializer.Deserialize(fileStream);
                fileStream.Close();
                return journal;
            }
        }

        public static Journal DeserializeJson(string path)
        {
            using (FileStream fileStream = new FileStream(path, FileMode.Open))
            {
                Journal journal = (Journal) JsonSerializer.ReadObject(fileStream);
                fileStream.Close();
                return journal;
            }
        }
    }
}