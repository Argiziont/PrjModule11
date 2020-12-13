using System;
using System.Collections.Generic;
using System.Linq;
using ModuleLibrary.Interfaces;

namespace ModuleLibrary
{
    public class StringBuffer: IComparator
    {
        public char[] CharArray => _charList.ToArray();

        public int Length => _charList.Count;

        private readonly List<char> _charList;
        public StringBuffer()
        {
            _charList = new List<char>();
        }
        public StringBuffer(params char[] charArr)
        {
            if (charArr == null) throw new ArgumentNullException(nameof(charArr));
            _charList = charArr.ToList();
        }
        public StringBuffer(string charArr)
        {
            if (charArr == null) throw new ArgumentNullException(nameof(charArr));
            _charList = charArr.ToCharArray().ToList();
        }
        public StringBuffer(int charArr)
        {
            _charList = charArr.ToString().ToCharArray().ToList();
        }
        public StringBuffer(float charArr)
        {
            _charList = charArr.ToString().ToCharArray().ToList();
        }
        public StringBuffer(double charArr)
        {
            _charList = charArr.ToString().ToCharArray().ToList();
        }
        public StringBuffer(decimal charArr)
        {
            _charList = charArr.ToString().ToCharArray().ToList();
        }

        /// <summary>
        /// Adds chars at start of the line
        /// </summary>
        /// <param name="appendChars">Characters</param>
        public void AppendAtStart(params char[] appendChars)
        {
            if (appendChars == null) throw new ArgumentNullException(nameof(appendChars));

            for (var i = appendChars.Length - 1; i >= 0; i--)
            {
                _charList.Insert(0, appendChars[i]);
            }
        }

        /// <summary>
        /// Adds chars at end of the line
        /// </summary>
        /// <param name="appendChars">Characters</param>
        public void AppendAtEnd(params char[] appendChars)
        {
            if (appendChars == null) throw new ArgumentNullException(nameof(appendChars));

            foreach (var appendChar in appendChars)
            {
                _charList.Add(appendChar);
            }
        }

        /// <summary>
        /// Gets substring 
        /// </summary>
        /// <param name="index">Offset</param>
        /// <returns>Substring from your line</returns>
        public char[] SubString(int index)
        {
            return new char[] { _charList[index] };
        }

        /// <summary>
        /// Gets substring 
        /// </summary>
        /// <param name="index">Offset</param>
        /// <param name="count">Number of characters</param> 
        /// <returns>Substring from your line</returns>
        public char[] SubString(int index, int count)
        {
            return _charList.GetRange(index, count).ToArray();
        }

        /// <summary>
        /// Count words in string
        /// </summary>
        public int CountWords()
        {
            var startCounting = true;
            var counter = 0;
            foreach (var t in _charList)
            {
                if (t == ' ')
                    startCounting = true;

                if (!startCounting || t == ' ') continue;
                counter++;
                startCounting = false;
            }
            return counter;
        }

        /// <summary>
        /// Count sentences in string
        /// </summary>
        public int CountSentences()
        {
            var startCounting = true;
            var counter = 0;
            foreach (var t in _charList)
            {
                if (t == '.')
                    startCounting = true;

                if (!startCounting || t == '.') continue;
                counter++;
                startCounting = false;
            }
            return counter;
        }

        public bool CompareTo(string str)
        {
            if (str == null) throw new ArgumentNullException(nameof(str));

            var charsToCompare = _charList.Where(ch => ch != ' ');
            var stringToCompare = str.Where(ch => ch != ' ');

            var charsToCompareArray = stringToCompare as char[] ?? stringToCompare.ToArray();
            var stringToCompareArray = charsToCompare as char[] ?? charsToCompare.ToArray();

            if (stringToCompareArray.Count() != charsToCompareArray.Count())
                return false;

            for (var i = 0; i < stringToCompareArray.Count(); i++)
                if (stringToCompareArray[i] != charsToCompareArray[i])
                    return false;

            return true;
        }

        public bool CompareToReverse(string str)
        {
            var charsToCompareArray = _charList.ToArray();

            if (str.Count() != charsToCompareArray.Count())
                return false;

            for (var i = charsToCompareArray.Length-1; i >=0; i--)
                if (str[i] != charsToCompareArray[i])
                    return false;

            return true;
        }
    }
}
