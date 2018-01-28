using System;

namespace MyLib
{
    public class Square
    {
        /// <summary>
        ///     delegate void (double)
        /// </summary>
        /// <param name="tmp">new square side size</param>
        public delegate void SquareSizeChanged(double tmp);

        /// <summary>
        ///     Right point
        /// </summary>
        private Point _right;

        /// <summary>
        ///     Constructor
        /// </summary>
        /// <param name="right">right point</param>
        /// <param name="left">left point</param>
        public Square(Point left, Point right)
        {
            _right = right;
            Left = left;
        }

        /// <summary>
        ///     Left point
        /// </summary>
        public Point Left { get; }

        /// <summary>
        ///     Right point property
        /// </summary>
        public Point Right
        {
            get => _right;
            set
            {
                _right = value;
                OnSquareSizeChanged(getSideSize());
            }
        }

        /// <summary>
        ///     Return side of square
        /// </summary>
        /// <returns>double</returns>
        private double getSideSize()
        {
            return Math.Sqrt(Math.Pow(Left.X - Right.X, 2) + Math.Pow(Left.Y - Right.Y, 2));
        }

        /// <summary>
        ///     event for change of size
        /// </summary>
        public event SquareSizeChanged OnSquareSizeChanged;
    }
}