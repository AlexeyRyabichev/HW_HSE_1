// Алексей Рябичев alexe
// 2018 05 10 8:07 PM

using System;

namespace Lib.Exceptions
{
    public class FileException : Exception
    {
        public FileException(string message) : base(message)
        {
        }
    }
}