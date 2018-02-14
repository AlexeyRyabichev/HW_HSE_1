using System;

namespace MyLib4
{
    public class IsChangedEventArgs : EventArgs
    {
        public int X { get; }

        public IsChangedEventArgs(int x)
        {
            X = x;
        }
    }
}