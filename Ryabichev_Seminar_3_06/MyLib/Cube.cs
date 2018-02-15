using System;

namespace MyLib
{
    public class Cube : Figure
    {
        public Cube(double side)
        {
            _side = side;
        }

        public override double Square() => Math.Pow(_side, 2) * 6;

        public override double Volume() => Math.Pow(_side, 3);
    }
}