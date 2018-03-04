using System;

namespace MyLib2
{
    public class Circle
    {
        private double _radius;

        public Circle(double radius, double x, double y)
        {
            _radius = radius;
            Coords = new Coords {X = x, Y = y};
        }

        public double Radius
        {
            get => _radius;
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException("Radius can't be less than zero");
                _radius = value;
            }
        }

        public Coords Coords { get; set; }

        public override string ToString()
        {
            return $"X: {Coords.X}\tY: {Coords.Y}\tRadius: {Radius}";
        }
    }
}