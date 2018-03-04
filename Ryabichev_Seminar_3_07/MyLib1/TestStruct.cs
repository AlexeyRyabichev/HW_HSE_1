using System;

namespace MyLib1
{
    public struct TestStruct : IComparable<TestStruct>
    {
        public int X;
        
        public int CompareTo(TestStruct other)
        {
            return X > other.X ? 1 : -1;
        }
    }
}