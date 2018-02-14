namespace MyLib4
{
    public class Triangle : Figure
    {
        public override void IsIncreasedEventHandler(object sender, IsChangedEventArgs args)
        {
            Side += args.X;
        }

        public override string ToString() => $"Triangle with side: {Side:f3}";

        public Triangle(double side)
        {
            Side = side;
        }
    }
}