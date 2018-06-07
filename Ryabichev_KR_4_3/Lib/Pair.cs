// Алексей Рябичев
// Ryabichev_KR_4_3 Lib Pair.cs
// 2018 06 07 2:41 PM

using System;
using System.Runtime.Serialization;

namespace Lib
{
    [Serializable]
    [DataContract]
    public class Pair<T, U> : IComparable<Pair<T, U>> where U : IComparable
    {
        /// <summary>
        ///     Standart constructor
        /// </summary>
        public Pair()
        {
        }

        /// <summary>
        ///     Constructor with two items
        /// </summary>
        /// <param name="item1">First item</param>
        /// <param name="item2">Second item</param>
        public Pair(T item1, U item2)
        {
            Item1 = item1;
            Item2 = item2;
        }

        [DataMember] public T Item1 { get; set; }

        [DataMember] public U Item2 { get; set; }

        /// <inheritdoc />
        public int CompareTo(Pair<T, U> other)
        {
            return Item2.CompareTo(other.Item2);
        }


        /// <inheritdoc />
        public override string ToString()
        {
            return $"Item 1: {Item1}\tItem 2: {Item2}";
        }
    }
}