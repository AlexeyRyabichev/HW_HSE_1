using System;

namespace MyLib
{
    public class Dot
    {
        /// <summary>
        ///     delegate void(Dot)
        /// </summary>
        /// <param name="dot">dot</param>
        public delegate void CoordChanged(Dot dot);

        private static readonly Random _random = new Random(DateTime.Now.Millisecond);

        /// <summary>
        ///     Constructor
        /// </summary>
        /// <param name="x">x</param>
        /// <param name="y">y</param>
        public Dot(double x = 0, double y = 0)
        {
            X = x;
            Y = y;
        }

        /// <summary>
        ///     X property
        /// </summary>
        public double X { get; private set; }

        /// <summary>
        ///     Y property
        /// </summary>
        public double Y { get; private set; }

        /// <summary>
        ///     event for coordinates changing
        /// </summary>
        public event CoordChanged OnCoordChanged;

        /// <summary>
        ///     Randomly change coordinates
        /// </summary>
        public void DotFlow()
        {
            for (int i = 0; i < 10; i++)
            {
                X = (_random.Next() % 2 == 0 ? 1 : -1) * (_random.Next(0, 11) - _random.NextDouble());
                Y = (_random.Next() % 2 == 0 ? 1 : -1) * (_random.Next(0, 11) - _random.NextDouble());

                if (X < 0 && Y < 0)
                    OnCoordChanged(this);
            }
        }
    }
}