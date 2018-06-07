// Алексей Рябичев
// Task1 Lib Pair.cs
// 2018 06 07 2:02 PM

using System;

namespace Lib
{
    public class Pair<T, U> : IComparable<Pair<T, U>> where U : struct, IComparable
    {
        private T item1;
        private U item2;

        public Pair(T item1, U item2)
        {
            this.item1 = item1;
            this.item2 = item2;
        }

        public int CompareTo(Pair<T, U> other)
        {
            return item2.CompareTo(other.item2);
        }

        public override string ToString()
        {
            return $"Item 1: {item1}\nItem 2: {item2}";
        }
    }
}