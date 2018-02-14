namespace MyLib
{
    public class Triangle : Figure
    {
        public Triangle(double side)
        {
            Side = side;
        }

        public override void IsIncreasedEventHadler(object sender, IsIncreasedEventsArgs args)
        {
            Side *= args.X;
        }

        public override string ToString() => $"Triangle with side: {Side:f3}";
    }
}