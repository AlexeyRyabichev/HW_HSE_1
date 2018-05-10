using System;
using System.Collections.Generic;
using System.IO;
using Lib.Exceptions;
using Lib.Words;

namespace Ryabichev_Seminar_10_05
{
    internal class Program
    {
        private static bool _q;
        private static bool _s;
        private static bool _c;
        private static bool _p;
        private static bool _l;
        private static string _inputFileName;
        private static readonly string _outputFileName = "output.txt";
        private static string _mainString;
        private static readonly Dictionary<int, List<string>> Words = new Dictionary<int, List<string>>();
        private static readonly Dictionary<int, List<string>> RandomWords = new Dictionary<int, List<string>>();
        private static readonly Dictionary<int, List<string>> RealWords = new Dictionary<int, List<string>>();
        private static readonly Dictionary<int, List<string>> Headwords = new Dictionary<int, List<string>>();
        private static readonly Dictionary<int, List<string>> Acronyms = new Dictionary<int, List<string>>();

        private static void Main(string[] args)
        {
            try
            {
                CheckFlags(args);
            }
            catch (FileException e)
            {
                Console.WriteLine(e.Message);
                return;
            }
            catch (FlagException e)
            {
                Console.WriteLine(e.Message);
                return;
            }

            if (_inputFileName != null)
                try
                {
                    ReadFromFile();
                }
                catch (FileException e)
                {
                    Console.WriteLine(e.Message);
                    return;
                }
            else
                ReadFromConsole();

            if (_mainString == null)
            {
                Console.WriteLine("String doesn't contain any characters");
                return;
            }

            FillDictionaries();
            RunFlags();

            Console.WriteLine("Finished");
            Console.ReadKey();
        }

        /// <summary>
        ///     Fill dictionaries of words
        /// </summary>
        private static void FillDictionaries()
        {
            List<Word> words = new List<Word>();
            foreach (string word in _mainString.Split())
            {
                if (Words.ContainsKey(word.Length))
                    Words[word.Length].Add(word);
                else
                    Words.Add(word.Length, new List<string> {word});

                words.Add(new Word(word));

                if (IsRandomWord(word))
                {
                    if (RandomWords.ContainsKey(word.Length))
                        RandomWords[word.Length].Add(word);
                    else
                        RandomWords.Add(word.Length, new List<string> {word});
                    words.Add(new RandomWord(word));
                }

                if (IsRealWord(word))
                {
                    if (RealWords.ContainsKey(word.Length))
                        RealWords[word.Length].Add(word);
                    else
                        RealWords.Add(word.Length, new List<string> {word});
                    words.Add(new RealWord(word));
                }

                if (IsHeadWord(word))
                {
                    if (Headwords.ContainsKey(word.Length))
                        Headwords[word.Length].Add(word);
                    else
                        Headwords.Add(word.Length, new List<string> {word});
                    words.Add(new Headword(word));
                }

                if (IsAcronym(word))
                {
                    if (Acronyms.ContainsKey(word.Length))
                        Acronyms[word.Length].Add(word);
                    else
                        Acronyms.Add(word.Length, new List<string> {word});
                    words.Add(new Acronym(word));
                }
            }
        }

        /// <summary>
        ///     Check if word is acronym
        /// </summary>
        /// <param name="word">word</param>
        /// <returns>bool</returns>
        private static bool IsAcronym(string word)
        {
            return word == word.ToUpper();
        }

        /// <summary>
        ///     Check if word is headword
        /// </summary>
        /// <param name="word">word</param>
        /// <returns>bool</returns>
        private static bool IsHeadWord(string word)
        {
            if (word[0].ToString() != word[0].ToString().ToUpper())
                return false;
            for (int i = 1; i < word.Length; i++)
                if (word[i] < 'a' && word[i] > 'z')
                    return false;

            return true;
        }

        /// <summary>
        ///     Check if word is random word
        /// </summary>
        /// <param name="word">word</param>
        /// <returns>bool</returns>
        private static bool IsRandomWord(string word)
        {
            foreach (char c in word)
                if (c < '0' && c > '9' && c < 'a' && c > 'z' && c < 'A' && c > 'Z')
                    return false;

            return true;
        }

        /// <summary>
        ///     Run all checked flags
        /// </summary>
        private static void RunFlags()
        {
            if (_s) _mainString = _mainString.Replace("  ", " ");
            if (_c) PrintToFileOnlyRealWordsAndSpaces();
            if (_p) PrintStaticstic();
            if (_l) PrintInfoAboutLength();
        }

        /// <summary>
        ///     Print info to console
        /// </summary>
        private static void PrintInfoAboutLength()
        {
            if (Words.Count != 0)
                foreach (int key in Words.Keys)
                {
                    Console.Write($"Слово (длина {key}): ");
                    foreach (string word in Words[key]) Console.Write($"{word}, ");
                    Console.Write("\n");
                }

            if (RandomWords.Count != 0)
                foreach (int key in RandomWords.Keys)
                {
                    Console.Write($"Произвольное слово (длина {key}): ");
                    foreach (string word in RandomWords[key]) Console.Write($"{word}, ");
                    Console.Write("\n");
                }

            if (RealWords.Count != 0)
                foreach (int key in RealWords.Keys)
                {
                    Console.Write($"Настоящее слово (длина {key}): ");
                    foreach (string word in RealWords[key]) Console.Write($"{word}, ");
                    Console.Write("\n");
                }
        }

        /// <summary>
        ///     Print statistic to console
        /// </summary>
        private static void PrintStaticstic()
        {
            if (!File.Exists(_outputFileName))
            {
                Console.WriteLine("Output file don't exists");
                return;
            }

            string inputString = File.ReadAllText(_inputFileName);
            string outputString = File.ReadAllText(_outputFileName);

            List<string> wordsInput = new List<string>();
            List<string> randomWordsInput = new List<string>();
            List<string> realWordsInput = new List<string>();
            List<string> headwordsInput = new List<string>();
            List<string> acronymsInput = new List<string>();
            List<string> wordsOutput = new List<string>();
            List<string> randomWordsOutput = new List<string>();
            List<string> realWordsOutput = new List<string>();
            List<string> headwordsOutput = new List<string>();
            List<string> acronymsOutput = new List<string>();

            foreach (string word in inputString.Split())
            {
                wordsInput.Add(word);

                if (IsRandomWord(word))
                    randomWordsInput.Add(word);

                if (IsRealWord(word))
                    realWordsInput.Add(word);

                if (IsHeadWord(word))
                    headwordsInput.Add(word);

                if (IsAcronym(word))
                    acronymsInput.Add(word);
            }

            foreach (string word in inputString.Split())
            {
                wordsOutput.Add(word);

                if (IsRandomWord(word))
                    randomWordsOutput.Add(word);

                if (IsRealWord(word))
                    realWordsOutput.Add(word);

                if (IsHeadWord(word))
                    headwordsOutput.Add(word);

                if (IsAcronym(word))
                    acronymsOutput.Add(word);
            }

            Console.WriteLine($"Символы: входной {inputString.Length}; выходной {outputString.Length}\n" +
                              $"Строки: входной {inputString.Split('\n').Length}; выходной {outputString.Split('\n').Length}\n" +
                              $"Слова: входной {wordsInput.Count}; выходной {wordsOutput.Count}\n" +
                              $"Произвольные слова: входной {randomWordsInput.Count}; выходной {randomWordsOutput.Count}\n" +
                              $"Настоящие слова: входной {realWordsInput.Count}; выходной {realWordsOutput.Count}\n" +
                              $"Заглавные слова: входной {headwordsInput.Count}; выходной {headwordsOutput.Count}\n" +
                              $"Акронимы: входной {acronymsInput.Count}; выходной {acronymsOutput.Count}\n");
        }

        /// <summary>
        ///     Print to file real words and spaces after them
        /// </summary>
        private static void PrintToFileOnlyRealWordsAndSpaces()
        {
            string toFile = "";

            for (int i = 0; i < _mainString.Length; i++)
            {
                string word = GetNextWord(i);
                i += word.Length;

                if (!IsRealWord(word)) continue;

                toFile += word;

                while (i < _mainString.Length && IsSpace(_mainString[i]))
                {
                    toFile += _mainString[i];
                    i += 1;
                }

                i -= 1;
            }

            File.WriteAllText(_outputFileName, toFile);
        }

        /// <summary>
        ///     Check if word is real word
        /// </summary>
        /// <param name="word">word</param>
        /// <returns>bool</returns>
        private static bool IsRealWord(string word)
        {
            foreach (char c in word)
                if (!(c >= 'a' && c <= 'z' || c >= 'A' && c <= 'Z'))
                    return false;

            return true;
        }

        /// <summary>
        ///     Check if character is space
        /// </summary>
        /// <param name="c">character</param>
        /// <returns>bool</returns>
        private static bool IsSpace(char c)
        {
            return c == ' ' || c == '\t' || c == '\n';
        }

        private static string GetNextWord(int index)
        {
            string word = "";

            while (index < _mainString.Length && !IsSpace(_mainString[index]))
            {
                word += _mainString[index];
                index += 1;
            }

            return word;
        }

        /// <summary>
        ///     Check flags from input arguments
        /// </summary>
        /// <param name="args">input arguments</param>
        private static void CheckFlags(string[] args)
        {
            bool isPreviousFileName = false;
            foreach (string s in args)
                switch (s)
                {
                    case "-q":
                        _q = true;
                        break;
                    case "-s":
                        _s = true;
                        break;
                    case "-c":
                        _c = true;
                        break;
                    case "-p":
                        _p = true;
                        break;
                    case "-l":
                        _l = true;
                        break;
                    default:
                        if (s[0] != '-')
                            if (isPreviousFileName)
                            {
                                throw new FileException("TOO MANY FILES");
                            }
                            else
                            {
                                _inputFileName = s;
                                isPreviousFileName = true;
                            }
                        else
                            throw new FlagException($"{s} INVALID FLAG");

                        break;
                }

            if ((_s || _c) && _q)
                throw new FlagException("CONFLICTING FLAGS");
        }

        /// <summary>
        ///     Read text from file
        /// </summary>
        private static void ReadFromFile()
        {
            if (File.Exists(_inputFileName))
                _mainString = File.ReadAllText(_inputFileName);
            else
                throw new FileException($"{_inputFileName} CANNOT OPEN");
        }

        /// <summary>
        ///     Read text from console
        /// </summary>
        private static void ReadFromConsole()
        {
            _mainString = Console.ReadLine();
        }
    }
}