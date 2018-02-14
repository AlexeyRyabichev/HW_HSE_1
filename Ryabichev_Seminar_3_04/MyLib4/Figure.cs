namespace MyLib4
{
    public abstract class Figure
    {
        public double Side { get; protected set; }

        public abstract void IsIncreasedEventHandler(object sender, IsChangedEventArgs args);
    }
}