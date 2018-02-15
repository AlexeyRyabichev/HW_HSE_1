namespace MyLib
{
    public abstract class Figure : ISquare, IVolume
    {
        protected double _side;

        public double Side => _side;

        public abstract double Square();

        public abstract double Volume();
    }
}