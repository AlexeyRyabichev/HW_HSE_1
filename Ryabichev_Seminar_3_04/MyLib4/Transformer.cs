using System;

namespace MyLib4
{
    public class Transformer
    {
        public event EventHandler<IsChangedEventArgs> OnChangeSize;
        public void ChangeSize(int x) => OnChangeSize?.Invoke(this, new IsChangedEventArgs(x));
    }
}