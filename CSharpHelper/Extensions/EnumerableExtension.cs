namespace CSharpHelper.Extensions
{
    public static class EnumerableExtension
    {
        /// <summary>
        /// Counts the total number of words in the collection of strings.
        /// </summary>
        /// <param name="items">The collection of strings to count the words from.</param>
        /// <returns>The total number of words in the collection.</returns>

        public static int CountWords(this IEnumerable<string> items)
        {
            int words = 0;
            var separator = new[] { ' ', '\n', '\r' };
            foreach (string line in items)
            {
                words += line.Split(separator, StringSplitOptions.RemoveEmptyEntries).Length;
            }
            return words;
        }

        /// <summary>
        /// Counts the total number of characters in the collection of strings.
        /// </summary>
        /// <param name="items">The collection of strings to count the characters from.</param>
        /// <returns>The total number of characters in the collection.</returns>
        public static int CountCharacters(this IEnumerable<string> items)
        {
            int characters = 0;
            foreach (string line in items)
            {
                characters += line.Length;
            }
            return characters;
        }

        /// <summary>
        /// Returns the index of the string with the longest length in the provided collection.
        /// </summary>
        /// <param name="items">The collection of strings to search.</param>
        /// <returns>The index of the string with the longest length. If the collection is empty, returns 0.</returns>
        public static int LongestStringIndex(IEnumerable<string> items)
        {
            int longestIndex = 0;
            int oldLenght = 0;
            int i = 0;
            foreach(var item in items)
            {
                i++;
                var lenght = item.Length;
                if (lenght > oldLenght)
                {
                    longestIndex = i;
                    oldLenght = lenght;
                }
            }
            return longestIndex;
        }

        /// <summary>
        /// Concatenates the strings in the collection using the specified separator and returns the resulting string.
        /// </summary>
        /// <param name="items">The collection of strings to concatenate.</param>
        /// <param name="separator">The string used to separate each element in the resulting concatenated string.</param>
        /// <returns>A string that consists of the elements in the collection concatenated using the specified separator.</returns>
        public static string ToString(this IEnumerable<string> items, string separator)
        {
            return string.Join(separator, items);
        }
    }
}
