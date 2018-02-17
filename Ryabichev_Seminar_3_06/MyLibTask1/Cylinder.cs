using System;

namespace MyLibTask1
{
    public class Cylinder : ITransform
    {
        public double R { get; set; }
        public double H { get; set; }

        public void Transform(double coef)
        {
            R *= coef;
            H *= coef;
        }

        public override string ToString()
        {
            return $"Cylinder volume: {Math.PI * Math.Pow(R, 2) * H:f3}";
        }
    }
}