using System;

namespace MyLibTask1
{
    public class Cube : ITransform
    {
        public double Rib { get; set; } = 1;

        public void Transform(double coef)
        {
            Rib *= coef;
        }

        public override string ToString()
        {
            return $"Cube volume: {Math.Pow(Rib, 3):f3}";
        }
    }
}