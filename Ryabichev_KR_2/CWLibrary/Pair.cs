// Алексей Рябичев
// Ryabichev_KR_2 CWLibrary Pair.cs
// 2018 06 14 1:48 PM

using System;

namespace CWLibrary
{
    [Serializable]
    public class Pair<T, U> : IComparable<Pair<T, U>> where U : IComparable
    {
        /// <summary>
        ///     Constructor
        /// </summary>
        public Pair()
        {
        }

        /// <summary>
        ///     Constructor
        /// </summary>
        /// <param name="item1">First item</param>
        /// <param name="item2">Second item</param>
        public Pair(T item1, U item2)
        {
            Item1 = item1;
            Item2 = item2;
        }

        /// <summary>
        ///     First item
        /// </summary>
        public T Item1 { get; set; }

        /// <summary>
        ///     Second item
        /// </summary>
        public U Item2 { get; set; }

        /// <summary>
        ///     Comparison method
        /// </summary>
        /// <param name="other">other item</param>
        /// <returns>int</returns>
        public int CompareTo(Pair<T, U> other)
        {
            return Item2.CompareTo(other.Item2);
        }

        /// <summary>
        ///     Element to string
        /// </summary>
        /// <returns>string</returns>
        public override string ToString()
        {
            return $"Item1: {Item1}\tItem2: {Item2}";
        }
    }
}