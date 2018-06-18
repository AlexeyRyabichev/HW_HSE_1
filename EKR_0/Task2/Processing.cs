using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace Task2
{
    public class Processing : IEnumerable<Data>
    {
        private string _fileName;
        private TextReader _textReader;

        public Processing(string fileName)
        {
            _fileName = fileName;
        }

        public IEnumerator<Data> GetEnumerator()
        {
            return new InternalClass(this);
        }
        
        class InternalClass : IEnumerator<Data>
        {
            private Data _element;
            private Processing _processing;

            public InternalClass(Processing processing)
            {
                _processing = processing;
                processing._textReader = new StreamReader(_processing._fileName);
            }

            public void Dispose()
            {
                throw new System.NotImplementedException();
            }

            public bool MoveNext()
            {
                string s = _processing._textReader.ReadLine();
                if (s != null)
                {
                    _element = new Data(s);
                    return true;
                }
                Reset();
                return false;
            }

            public void Reset()
            {
                _processing._textReader = new StreamReader(_processing._fileName);
            }

            public Data Current => _element;

            object IEnumerator.Current => Current;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return  new InternalClass(this);
        }
    }
}