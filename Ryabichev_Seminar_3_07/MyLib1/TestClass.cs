using System;

namespace MyLib1
{
    public class TestClass : IComparable<TestClass>
    {
        public int X { get; set; }

        public int CompareTo(TestClass other)
        {
            return X > other.X ? 1 : -1;
        }
    }
}