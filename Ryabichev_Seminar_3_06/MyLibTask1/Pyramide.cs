using System;

namespace MyLibTask1
{
    public class Pyramide : ITransform
    {
        public double B { get; set; }
        public double H { get; set; }

        public void Transform(double coef)
        {
            B *= coef;
            H *= coef;
        }

        public override string ToString()
        {
            return $"Pyraminde volume: {1.0 / 3 * H * Math.Pow(B, 2):f3}\tSide square: {0.5 * B * H:f3}";
        }
    }
}