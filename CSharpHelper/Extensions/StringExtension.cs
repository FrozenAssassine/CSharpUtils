namespace CSharpHelper.Extensions
{
    public static class StringExtension
    {
        /// <summary>
        /// Counts the total number of words in the provided string.
        /// </summary>
        /// <param name="text">The string to count the words from.</param>
        /// <returns>The total number of words in the string.</returns>
        public static int CountWords(this string text)
        {
            if (text.Contains("\r") || text.Contains("\r\n"))
                return text.Count(x => x == ' ' || x == '\r') + 1;
            return text.Count(x => x == ' ' || x == '\n') + 1;
        }

        /// <summary>
        /// Repeats the provided string a specified number of times.
        /// </summary>
        /// <param name="text">The string to repeat.</param>
        /// <param name="count">The number of times to repeat the string.</param>
        /// <returns>A new string consisting of the input string repeated the specified number of times.</returns>
        public static string Repeat(this string text, int count)
        {
            return string.Join("", Enumerable.Repeat(text, count));
        }
    }
}
