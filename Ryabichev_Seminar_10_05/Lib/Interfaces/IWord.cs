// Алексей Рябичев alexe
// 2018 05 10 7:54 PM

namespace Lib.Interfaces
{
    public interface IWord
    {
        /// <summary>
        /// Length of word
        /// </summary>
        int Length { get; }

        /// <summary>
        /// Word
        /// </summary>
        string Content { get; }
    }
}