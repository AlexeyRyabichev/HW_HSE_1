using System;

namespace MyLib
{
    public class Triangle : Figure
    {
        public override double Square() => Math.Pow(_side, 2) * Math.Sqrt(3.0 / 16);

        public override double Volume()
        {
            throw new NotImplementedException();
        }

        public Triangle(double side)
        {
            _side = side;
        }
    }
}