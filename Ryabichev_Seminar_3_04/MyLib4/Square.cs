namespace MyLib4
{
    public class Square : Figure
    {
        public override void IsIncreasedEventHandler(object sender, IsChangedEventArgs args)
        {
            Side -= args.X;
        }

        public override string ToString() => $"Square with side: {Side:f3}";

        public Square(double side)
        {
            Side = side;
        }
    }
}