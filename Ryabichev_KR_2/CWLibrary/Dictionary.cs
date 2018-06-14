// Алексей Рябичев
// Ryabichev_KR_2 CWLibrary Dictionary.cs
// 2018 06 14 1:53 PM

using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace CWLibrary
{
    [Serializable]
    public class Dictionary
    {
        public static Random Random = new Random(DateTime.Now.Millisecond);
        private int _locale;
        private List<Pair<string, string>> _words;

        /// <summary>
        ///     Free constructor
        /// </summary>
        public Dictionary()
        {
        }

        /// <summary>
        ///     Constructor
        /// </summary>
        /// <param name="words">words</param>
        public Dictionary(List<Pair<string, string>> words)
        {
            _words = words;
            _locale = Random.Next(2);
        }

        /// <summary>
        ///     Locale type
        /// </summary>
        public int Locale
        {
            get => _locale;
            set => _locale = value;
        }

        /// <summary>
        ///     Words getter
        /// </summary>
        public List<Pair<string, string>> Words => _words;

        /// <summary>
        ///     Add method
        /// </summary>
        /// <param name="word">word</param>
        public void Add(Pair<string, string> word)
        {
            _words.Add(word);
        }

        /// <summary>
        ///     Add method
        /// </summary>
        /// <param name="s1">first string</param>
        /// <param name="s2">second string</param>
        public void Add(string s1, string s2)
        {
            _words.Add(new Pair<string, string>(s1, s2));
        }

        /// <summary>
        ///     Standart IEnumerator
        /// </summary>
        /// <returns>next element</returns>
        public IEnumerator GetEnumerator()
        {
            List<Pair<string, string>> copy = new List<Pair<string, string>>(_words);
            copy.Sort((pair1, pair2) => _locale == 1 ? pair1.CompareTo(pair2) : pair1.Item1.CompareTo(pair2.Item1));
            foreach (Pair<string, string> pair in copy) yield return pair;
        }

        /// <summary>
        ///     IEnumeartor with length
        /// </summary>
        /// <param name="length">length of word</param>
        /// <returns>next word</returns>
        public IEnumerable EnumeratorWithLength(int length)
        {
            List<Pair<string, string>> copy = new List<Pair<string, string>>(_words);
            copy.Sort((pair1, pair2) => _locale == 1 ? pair1.CompareTo(pair2) : pair1.Item1.CompareTo(pair2.Item1));
            foreach (Pair<string, string> pair in copy)
                if (_locale == 0 && pair.Item1.Length == length || _locale == 1 && pair.Item2.Length == length)
                    yield return pair;
        }

        /// <summary>
        ///     Serailization method
        /// </summary>
        /// <param name="path">path to file</param>
        public void MySerialize(string path)
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            try
            {
                FileStream fileStream = new FileStream(path, FileMode.Create);
                binaryFormatter.Serialize(fileStream, this);
                fileStream.Close();
                Console.WriteLine("Serialization finished");
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine("File not found\n" + e.Message);
            }
        }

        /// <summary>
        ///     Deserialization method
        /// </summary>
        /// <param name="path">path to file</param>
        /// <returns>Dictionary element</returns>
        public static Dictionary MyDeserialize(string path)
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            try
            {
                FileStream fileStream = new FileStream(path, FileMode.Open);
                Dictionary dictionary = (Dictionary) binaryFormatter.Deserialize(fileStream);
                fileStream.Close();
                Console.WriteLine("Deserialization finished");
                return dictionary;
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine("File not found\n" + e.Message);
            }

            return new Dictionary(new List<Pair<string, string>>());
        }
    }
}