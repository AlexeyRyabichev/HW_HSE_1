using System;

namespace MyLib
{
    public class SquareClass : Figure
    {
        public SquareClass(double side)
        {
            _side = side;
        }

        public override double Square() => Math.Pow(_side, 2);

        public override double Volume()
        {
            throw new NotImplementedException();
        }
    }
}