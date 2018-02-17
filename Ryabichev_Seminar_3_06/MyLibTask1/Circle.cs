using System;

namespace MyLibTask1
{
    public class Circle : ITransform
    {
        public double Rad { get; set; } = 1;

        public void Transform(double coef)
        {
            Rad *= coef;
        }

        public override string ToString()
        {
            return $"Circle square: {Math.PI * Math.Pow(Rad, 2):f3}";
        }
    }
}