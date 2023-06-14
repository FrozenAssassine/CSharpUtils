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
    
        public static int IndexOfRegex(this string str, string pattern, int start, RegexOptions options)
        {
            var match = Regex.Match(start < 0 || start >= str.Length ? str : str.Substring(start), pattern);
            return match.Success ? match.Index : -1;
        }
        public static int IndexOfRegex(this string str, string pattern, int start)
        {
            return IndexOfRegex(str, pattern, start, RegexOptions.None);
        }
        public static int IndexOfRegex(this string str, string pattern)
        {
            return IndexOfRegex(str, pattern, -1, RegexOptions.None);
        }
        public static int IndexOfRegex(this string str, string pattern, RegexOptions options)
        {
            return IndexOfRegex(str, pattern, -1, options);
        }

        public static int[] AllIndexOfRegex(this string str, string pattern, int start, RegexOptions options)
        {
            int MatchToIndex(Match m)
            {
                return m.Index;
            }

            MatchCollection matches = Regex.Matches(start < 0 || start >= str.Length ? str : str.Substring(start), pattern);
            return matches.Count > 0 ? Array.ConvertAll(matches.Where(x => x.Success).ToArray(), new Converter<Match, int>(MatchToIndex)) : Array.Empty<int>();
        }
        public static int[] AllIndexOfRegex(this string str, string pattern, int start)
        {
            return AllIndexOfRegex(str, pattern, start, RegexOptions.None);
        }
        public static int[] AllIndexOfRegex(this string str, string pattern)
        {
            return AllIndexOfRegex(str, pattern, -1, RegexOptions.None);
        }
        public static int[] AllIndexOfRegex(this string str, string pattern, RegexOptions options)
        {
            return AllIndexOfRegex(str, pattern, -1, options);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="str"></param>
        /// <param name="pattern"></param>
        /// <param name="start"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public static int LastIndexOfRegex(this string str, string pattern, int start, RegexOptions options)
        {
            string stR = "";
            MatchCollection matches = Regex.Matches(start < 0 || start >= str.Length ? str : str.Substring(start), pattern, options);
            if(matches.Count > 0)
                return matches[matches.Count - 1].Index;
            return -1;
        }
        public static int LastIndexOfRegex(this string str, string pattern, int start)
        {
            return LastIndexOfRegex(str, pattern, start, RegexOptions.None);
        }
        public static int LastIndexOfRegex(this string str, string pattern)
        {
            return LastIndexOfRegex(str, pattern, -1, RegexOptions.None);
        }
        public static int LastIndexOfRegex(this string str, string pattern, RegexOptions options)
        {
            return LastIndexOfRegex(str, pattern, -1, options);
        }
    
        /// <summary>
        /// Insert a given string at a given position
        /// </summary>
        /// <param name="str">The string to insert to</param>
        /// <param name="startIndex">The zero based position to insert at</param>
        /// <param name="value">The string to insert at the position</param>
        /// <returns>A new string with the given word inserted at the given position</returns>
        public static string SafeInsert(this string str, int startIndex, string value)
        {
            if (str == null)
                return "";

            if (startIndex >= str.Length)
                return str += str;
            
            return str.Insert(startIndex < 0 ? 0 : startIndex, value);
        }
        /// <summary>
        /// Replace the given range with the given string
        /// </summary>
        /// <param name="str">The string to replace at</param>
        /// <param name="startIndex">The zero based start position to replace with</param>
        /// <param name="length">The length of the characters to replace</param>
        /// <param name="value">The string to replace the removed with</param>
        /// <returns>A new string where the given string is added</returns>
        public static string ReplaceRange(this string str, int startIndex, int length, string value)
        {
            return str.SafeRemove(startIndex, length).SafeInsert(startIndex, value);
        }
    
    }
}
