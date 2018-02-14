namespace MyLib
{
    public abstract class Figure
    {
        public double Side { get; protected set; }

        public abstract void IsIncreasedEventHadler(object sender, IsIncreasedEventsArgs args);
    }
}