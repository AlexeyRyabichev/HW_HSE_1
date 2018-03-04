namespace MyLib2
{
    public struct Coords
    {
        public double X;
        public double Y;

        public Coords(double x, double y)
        {
            X = x;
            Y = y;
        }

        public override string ToString()
        {
            return $"X: {X}\tY: {Y}";
        }
    }
}