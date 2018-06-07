// Алексей Рябичев
// Ryabichev_Seminar_4_04 Lib FileLines.cs
// 2018 06 02 10:33 AM

using System.Collections;
using System.IO;

namespace Lib
{
    public class FileLines : IEnumerable
    {
        public StreamReader input;
        private string _fileName;

        public FileLines(string fileName)
        {
            _fileName = fileName;
            input = new StreamReader(fileName);
        }

        public IEnumerator GetEnumerator()
        {
            return new FileEnumerator(this);
        }

        class FileEnumerator : IEnumerator
        {
            private FileLines _fileLines;
            private string _resultString;

            public FileEnumerator(FileLines fileLines)
            {
                _fileLines = fileLines;
            }

            public bool MoveNext()
            {
                _resultString = _fileLines.input.ReadLine();
                if (_resultString != null)
                    return true;
                else
                {
                    Reset();
                    return false;
                }
            }

            public void Reset()
            {
                _fileLines.input?.Close();
                _fileLines.input = new StreamReader(_fileLines._fileName);
            }

            public object Current => _resultString;
        }
    }
}