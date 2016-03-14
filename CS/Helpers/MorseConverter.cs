using System;
using System.Collections.Generic;
using System.Linq;

namespace Blinky.Helpers
{
    public static class MorseConverter
    {
        static readonly Dictionary<char, string> _morse =
            new Dictionary<char, string>()
            {
                {'A' , ".-"},
                {'B' , "-..."},
                {'C' , "-.-."},
                {'D' , "-.."},
                {'E' , "."},
                {'F' , "..-."},
                {'G' , "--."},
                {'H' , "...."},
                {'I' , ".."},
                {'J' , ".---"},
                {'K' , "-.-"},
                {'L' , ".-.."},
                {'M' , "--"},
                {'N' , "-."},
                {'O' , "---"},
                {'P' , ".--."},
                {'Q' , "--.-"},
                {'R' , ".-."},
                {'S' , "..."},
                {'T' , "-"},
                {'U' , "..-"},
                {'V' , "...-"},
                {'W' , ".--"},
                {'X' , "-..-"},
                {'Y' , "-.--"},
                {'Z' , "--.."},
                {'0' , "-----"},
                {'1' , ".----"},
                {'2' , "..---"},
                {'3' , "...--"},
                {'4' , "....-"},
                {'5' , "....."},
                {'6' , "-...."},
                {'7' , "--..."},
                {'8' , "---.."},
                {'9' , "----."}
            };

        /// <summary>
        /// Convert ASCII string to Morse string.
        /// </summary>
        /// <returns></returns>
        public static string ConvertToMorse(this string input)
        {
            var morseString = 
                input
                    .ToUpper()
                    .ToCharArray()
                    .Where(c => _morse.Keys.Contains(c))
                    .Select(c => _morse[c])
                    .ToList();

            return String.Join(" ", morseString);
        }
    }
}
