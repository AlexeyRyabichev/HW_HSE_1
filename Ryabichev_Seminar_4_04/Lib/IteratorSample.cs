// Алексей Рябичев
// Ryabichev_Seminar_4_04 Lib IteratorSample.cs
// 2018 06 02 10:25 AM

using System.Collections;

namespace Lib
{
    public class IteratorSample : IEnumerable
    {
        private object[] values;
        private int start;

        public IteratorSample(object[] values, int start)
        {
            this.values = values;
            this.start = start;
        }

        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < values.Length; i++)
            {
                yield return values[(i + start) % values.Length];
            }
        }
    }
}