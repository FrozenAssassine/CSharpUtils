using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CSharpHelper.Extensions
{
    public static class SafeString
    {
        /// <summary>
        /// Returns a substring from the given string.
        /// </summary>
        /// <param name="str">The string to substring</param>
        /// <param name="start">The index to start from</param>
        /// <param name="length">The number of characters to substring</param>
        /// <returns>A new string from the given start and length. When the string is null or start and length are negative values it returns an emty string. When start and length are higher than the length of the string it returns the string without modifications.</returns>
        public static string SafeSubstring(this string str, int start, int length)
        {
            if (str == null || start < 0 || length < 0)
                return "";

            if (start >= str.Length)
                return str;

            if (start + length >= str.Length)
                return str.Substring(start, str.Length - start);

            return str.Substring(start, length);
        }
        /// <summary>
        /// Returns a substring from the given string.
        /// </summary>
        /// <param name="str">The string to substring</param>
        /// <param name="start">The index to start from</param>
        /// <returns>A new string from the given start to the end of the string. When the string is null or start is negative, it returns an emty string. When start is greater than the length of the string it returns the string without modifications.</returns>
        public static string SafeSubstring(this string str, int start)
        {
            return SafeSubstring(str, start, str.Length - start);
        }

        /// <summary>
        /// Returns a new string from the given string.
        /// </summary>
        /// <param name="str">The string to remove</param>
        /// <param name="start">The index to start from</param>
        /// <param name="length">The number of characters to remove</param>
        /// <returns>A new string from the given start to the end of the string. When the string is null or start is negative, it returns an emty string. When start is greater than the length of the string it returns the string without modifications.</returns>
        public static string SafeRemove(this string str, int start, int length)
        {
            if (str == null || start < 0 || length < 0)
                return "";

            if (start >= str.Length)
                return str;

            if (start + length >= str.Length)
                return str.Remove(start, str.Length - start);

            return str.Remove(start, length);
        }
        /// <summary>
        /// Returns a new string from the given string.
        /// </summary>
        /// <param name="str">The string to remove from</param>
        /// <param name="start">The index to start from</param>
        /// <returns>A new string from the given start to the end of the string. When the string is null or start is negative, it returns an emty string. When start is greater than the length of the string it returns the string without modifications.</returns>
        public static string SafeRemove(this string str, int start)
        {
            return SafeRemove(str, start, str.Length - start);
        }

        /// <summary>
        /// Get the index of the given regex pattern
        /// </summary>
        /// <param name="str">The string to search in</param>
        /// <param name="pattern">The regex pattern to search for</param>
        /// <param name="start">The index after it starts searching</param>
        /// <param name="options">The options for the regex pattern</param>
        /// <returns>The index of the found regex or -1 when nothing was found</returns>
        public static int IndexOfRegex(this string str, string pattern, int start, RegexOptions options)
        {
            var match = Regex.Match(start < 0 || start >= str.Length ? str : str.Substring(start), pattern, options);
            return match.Success ? match.Index : -1;
        }
        /// <summary>
        /// Get the index of the given regex pattern
        /// </summary>
        /// <param name="str">The string to search in</param>
        /// <param name="pattern">The regex pattern to search for</param>
        /// <param name="start">The index after it starts searching</param>
        /// <returns>The index of the found regex or -1 when nothing was found</returns>
        public static int IndexOfRegex(this string str, string pattern, int start)
        {
            return IndexOfRegex(str, pattern, start, RegexOptions.None);
        }
        /// <summary>
        /// Get the index of the given regex pattern
        /// </summary>
        /// <param name="str">The string to search in</param>
        /// <param name="pattern">The regex pattern to search for</param>
        /// <returns>The index of the found regex or -1 when nothing was found</returns>
        public static int IndexOfRegex(this string str, string pattern)
        {
            return IndexOfRegex(str, pattern, -1, RegexOptions.None);
        }
        /// <summary>
        /// Get the index of the given regex pattern
        /// </summary>
        /// <param name="str">The string to search in</param>
        /// <param name="pattern">The regex pattern to search for</param>
        /// <param name="options">The options for the regex pattern</param>
        /// <returns>The index of the found regex or -1 when nothing was found</returns>
        public static int IndexOfRegex(this string str, string pattern, RegexOptions options)
        {
            return IndexOfRegex(str, pattern, -1, options);
        }

        /// <summary>
        /// Get the a list of indices of the given regex pattern
        /// </summary>
        /// <param name="str">The string to search in</param>
        /// <param name="pattern">The regex pattern to search for</param>
        /// <param name="start">The index after it starts searching</param>
        /// <param name="options">The options for the regex pattern</param>
        /// <returns>The indices of the found regex or -1 when nothing was found</returns>
        public static int[] AllIndexOfRegex(this string str, string pattern, int start, RegexOptions options)
        {
            int MatchToIndex(Match m)
            {
                return m.Index;
            }

            MatchCollection matches = Regex.Matches(start < 0 || start >= str.Length ? str : str.Substring(start), pattern, options);
            return matches.Count > 0 ? Array.ConvertAll(matches.Where(x => x.Success).ToArray(), new Converter<Match, int>(MatchToIndex)) : Array.Empty<int>();
        }
        /// <summary>
        /// Get the a list of indices of the given regex pattern
        /// </summary>
        /// <param name="str">The string to search in</param>
        /// <param name="pattern">The regex pattern to search for</param>
        /// <param name="start">The index after it starts searching</param>
        /// <returns>The indices of the found regex or -1 when nothing was found</returns>
        public static int[] AllIndexOfRegex(this string str, string pattern, int start)
        {
            return AllIndexOfRegex(str, pattern, start, RegexOptions.None);
        }
        /// <summary>
        /// Get the a list of indices of the given regex pattern
        /// </summary>
        /// <param name="str">The string to search in</param>
        /// <param name="pattern">The regex pattern to search for</param>
        /// <returns>The indices of the found regex or -1 when nothing was found</returns>
        public static int[] AllIndexOfRegex(this string str, string pattern)
        {
            return AllIndexOfRegex(str, pattern, -1, RegexOptions.None);
        }
        /// <summary>
        /// Get the a list of indices of the given regex pattern
        /// </summary>
        /// <param name="str">The string to search in</param>
        /// <param name="pattern">The regex pattern to search for</param>
        /// <param name="options">The options for the regex pattern</param>
        /// <returns>The indices of the found regex or -1 when nothing was found</returns>
        public static int[] AllIndexOfRegex(this string str, string pattern, RegexOptions options)
        {
            return AllIndexOfRegex(str, pattern, -1, options);
        }

        /// <summary>
        /// Get the the last index of the given regex pattern
        /// </summary>
        /// <param name="str">The string to search in</param>
        /// <param name="pattern">The regex pattern to search for</param>
        /// <param name="start">The index after it starts searching</param>
        /// <param name="options">The options for the regex pattern</param>
        /// <returns>The indices of the found regex or -1 when nothing was found</returns>
        public static int LastIndexOfRegex(this string str, string pattern, int start, RegexOptions options)
        {
            MatchCollection matches = Regex.Matches(start < 0 || start >= str.Length ? str : str.Substring(start), pattern, options);
            if(matches.Count > 0)
                return matches[matches.Count - 1].Index;
            return -1;
        }
        /// <summary>
        /// Get the the last index of the given regex pattern
        /// </summary>
        /// <param name="str">The string to search in</param>
        /// <param name="pattern">The regex pattern to search for</param>
        /// <param name="start">The index after it starts searching</param>
        /// <returns>The indices of the found regex or -1 when nothing was found</returns>
        public static int LastIndexOfRegex(this string str, string pattern, int start)
        {
            return LastIndexOfRegex(str, pattern, start, RegexOptions.None);
        }
        /// <summary>
        /// Get the the last index of the given regex pattern
        /// </summary>
        /// <param name="str">The string to search in</param>
        /// <param name="pattern">The regex pattern to search for</param>
        /// <returns>The indices of the found regex or -1 when nothing was found</returns>
        public static int LastIndexOfRegex(this string str, string pattern)
        {
            return LastIndexOfRegex(str, pattern, -1, RegexOptions.None);
        }
        /// <summary>
        /// Get the the last index of the given regex pattern
        /// </summary>
        /// <param name="str">The string to search in</param>
        /// <param name="pattern">The regex pattern to search for</param>
        /// <param name="options">The options for the regex pattern</param>
        /// <returns>The indices of the found regex or -1 when nothing was found</returns>
        public static int LastIndexOfRegex(this string str, string pattern, RegexOptions options)
        {
            return LastIndexOfRegex(str, pattern, -1, options);
        }

        /// <summary>
        /// Inserts the given string at the specified position in the input string.
        /// </summary>
        /// <param name="str">The input string to insert into.</param>
        /// <param name="startIndex">The zero-based position at which to insert the string.</param>
        /// <param name="value">The string to insert at the specified position.</param>
        /// <returns>A new string with the specified string inserted at the specified position.</returns>
        public static string SafeInsert(this string str, int startIndex, string value)
        {
            if (str == null)
                return "";

            if (startIndex >= str.Length)
                return str += str;
            
            return str.Insert(startIndex < 0 ? 0 : startIndex, value);
        }
        /// <summary>
        /// Replaces a specified range of characters in the input string with the given string.
        /// </summary>
        /// <param name="str">The input string to perform the replacement on.</param>
        /// <param name="startIndex">The zero-based start position of the range to replace.</param>
        /// <param name="length">The length of the range of characters to replace.</param>
        /// <param name="value">The string to replace the removed range with.</param>
        /// <returns>A new string where the specified range is replaced with the given string.</returns>
        public static string ReplaceRange(this string str, int startIndex, int length, string value)
        {
            return str.SafeRemove(startIndex, length).SafeInsert(startIndex, value);
        }
    
    }
}
