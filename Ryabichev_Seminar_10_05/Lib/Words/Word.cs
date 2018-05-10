// Алексей Рябичев alexe
// 2018 05 10 7:52 PM

using Lib.Interfaces;

namespace Lib.Words
{
    public class Word : IWord
    {
        /// <summary>
        /// Create element of Word class
        /// </summary>
        /// <param name="word">word</param>
        public Word(string word)
        {
            Content = word;
            Length = word.Length;
        }

        /// <inheritdoc />
        public int Length { get; }

        /// <inheritdoc />
        public string Content { get; }
    }
}