using System.Globalization;
using System.Text.RegularExpressions;

namespace Dfe.Academisation.ExtensionMethods
{
    public static class StringExtensions
    {
        /// <summary>
        /// Applies Pascal casing to a string.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static string SplitPascalCase<T>(this T source)
        {
            return source == null
                ? string.Empty
                : Regex.Replace(source.ToString() ?? string.Empty, "[A-Z]", " $0", RegexOptions.None,
                    TimeSpan.FromSeconds(1)).Trim();
        }

        /// <summary>
        /// Converts a string to sentence case, ignoring acronyms.
        /// </summary>
        /// <param name="input">The string to convert.</param>
        /// <returns>A string</returns>
        public static string ToSentenceCase(this string input)
        {
            if (string.IsNullOrEmpty(input)) return input;

            string[] words = input.Split(' ');
            bool firstNonAcronymCapitalized = false;

            for (int i = 0; i < words.Length; i++)
            {
                // Not an acronym
                if (IsAcronym(words[i]) is false)
                {
                    words[i] = words[i].ToLowerInvariant();

                    if (firstNonAcronymCapitalized is false)
                    {
                        words[i] = char.ToUpperInvariant(words[i][0]) + words[i].Substring(1);
                        firstNonAcronymCapitalized = true;
                    }
                }
            }

            return string.Join(' ', words);
        }

        /// <summary>
        /// Extension method that converts "Yes" and "No" strings to bool values.
        /// "Yes" is converted to true and "No" is converted to false.
        /// The comparison is case-insensitive.
        /// If the input string does not match "Yes" or "No", an ArgumentException will be thrown.
        /// </summary>
        public static bool ToBool(this string str)
        {
            return str.ToLower() switch
            {
                "yes" => true,
                "no" => false,
                _ => throw new ArgumentException("The string must be either 'Yes' or 'No'.")
            };
        }

        /// <summary>
        /// Returns true/false if the word is detected as being an acronym
        /// </summary>
        /// <param name="word"></param>
        /// <returns></returns>
        public static bool IsAcronym(string word)
        {
            if (string.IsNullOrEmpty(word) || word.Length < 2)
            {
                return false;
            }

            return char.IsUpper(word[0]) && char.IsUpper(word[^1]);
        }


        /// <summary>
        ///  Checks a string to see if it contains exclusively capital letters
        /// </summary>
        /// <param name="word">The string to check.</param>
        /// <returns>A string</returns>
        public static bool IsAllCaps(string word)
        {
            if (string.IsNullOrEmpty(word)) return false;
            return word.All(char.IsUpper);
        }

        /// <summary>
        /// Applies title casing to a string
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string ToTitleCase(this string str)
        {
            TextInfo textInfo = CultureInfo.CurrentCulture.TextInfo;
            return textInfo.ToTitleCase(str);
        }

        /// <summary>
        /// Returns true if IsNullOrWhiteSpace == true
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static bool IsEmpty(this string input)
        {
            return string.IsNullOrWhiteSpace(input);
        }

        /// <summary>
        /// Returns true if IsEmpty == false.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static bool IsPresent(this string input)
        {
            return input.IsEmpty() is false;
        }

        /// <summary>
        /// Removes spaces throughout a string and returns ToLowerInvariant
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string Squish(this string input)
        {
            return input.Replace(" ", "").ToLowerInvariant();
        }
    }
}