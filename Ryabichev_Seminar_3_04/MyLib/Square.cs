namespace MyLib
{
    public class Square : Figure
    {
        private const double Coeff = 2.0 / 3;

        public Square(double side)
        {
            Side = side;
        }

        public override void IsIncreasedEventHadler(object sender, IsIncreasedEventsArgs args)
        {
            Side *= args.X * Coeff;
        }

        public override string ToString() => $"Square with side: {Side:f3}";
    }
}