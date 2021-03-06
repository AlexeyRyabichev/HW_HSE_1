﻿// Алексей Рябичев alexe
// 2018 05 10 7:52 PM

using Lib.Interfaces;

namespace Lib.Words
{
    public class RealWord : Word, IWord
    {
        /// <summary>
        /// Create elemnt of RealWord class
        /// </summary>
        /// <param name="word">word</param>
        public RealWord(string word) : base(word)
        {
            Content = word;
            Length = word.Length;
        }

        /// <inheritdoc />
        public new int Length { get; }

        /// <inheritdoc />
        public new string Content { get; }
    }
}