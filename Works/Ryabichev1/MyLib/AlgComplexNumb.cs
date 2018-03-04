using System;

namespace MyLib
{
    public struct AlgComplexNumb : IComparable<AlgComplexNumb>
    {
        private readonly double _x;
        private readonly double _y;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="x">X</param>
        /// <param name="y">Y</param>
        public AlgComplexNumb(string x, string y)
        {
            if (!(double.TryParse(x, out _x) && double.TryParse(y, out _y)))
                throw new ArgumentOutOfRangeException("Arguments aren't double type");
        }

        public double X => _x;

        public double Y => _y;

        /// <summary>
        /// Compare two numbers
        /// </summary>
        /// <param name="other">other number</param>
        /// <returns></returns>
        public int CompareTo(AlgComplexNumb other)
        {
            return Absolute > other.Absolute ? 1 : -1;
        }

        /// <summary>
        /// Show number in string view
        /// </summary>
        /// <returns>string view</returns>
        public override string ToString()
        {
            return $"z = {X:f3} + {Y:f3} * i";
        }

        public double Absolute => Math.Sqrt(Math.Pow(X, 2) + Math.Pow(Y, 2));
    }
}