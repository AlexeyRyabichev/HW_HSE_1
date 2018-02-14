using System;

namespace MyLib
{
    public class Transformer
    {
        public event EventHandler<IsIncreasedEventsArgs> OnIncrease;

        public void Increase(int x) =>
            OnIncrease?.Invoke(this, new IsIncreasedEventsArgs(x));
    }
}