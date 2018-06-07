// Алексей Рябичев
// Ryabichev_Seminar_4_04 Lib IteratorSampleBackward.cs
// 2018 06 02 10:30 AM

using System.Collections;

namespace Lib
{
    public class IteratorSampleBackward : IEnumerable
    {
        private object[] values;
        private int start;

        public IteratorSampleBackward(object[] values, int start)
        {
            this.values = values;
            this.start = start;
        }

        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < values.Length; i++)
            {
                yield return values[values.Length - ((i + start) % values.Length) - 1];
            }
        }
    }
}