namespace TaroDSA.Lib
{
    public class ArrayAndStringProblems
    {
        /// <summary>
        /// Determines whether two strings are anagrams of each other.
        /// Time complexity: O(a + b + c) where a and b represent building the frequency maps and c represents
        /// comparing the maps.
        /// Space complexity: O(a + b) for the two frequency maps. 
        /// </summary>
        /// <param name="a">The first string to compare.</param>
        /// <param name="b">The second string to compare.</param>
        /// <returns>True if the strings are anagrams; otherwise, false.</returns>
        /// <exception cref="ArgumentNullException">Thrown when either of the input strings is null.</exception>
        public static bool IsAnagram(string a, string b)
        {
            ArgumentNullException.ThrowIfNull(a);
            ArgumentNullException.ThrowIfNull(b);

            var aFrequencies = CreateFrequencyMap(a);
            var bFrequencies = CreateFrequencyMap(b);

            return FrequenciesMapsAreEqual(aFrequencies, bFrequencies);
        }

        private static Dictionary<char, int> CreateFrequencyMap(string s)
        {
            var frequencies = new Dictionary<char, int>();

            foreach (var c in s)
            {
                if (!char.IsLetter(c))
                {
                    continue;
                }

                if (!frequencies.TryAdd(c, 1))
                {
                    frequencies[c] += 1;
                }
            }

            return frequencies;
        }

        private static bool FrequenciesMapsAreEqual(Dictionary<char, int> a, Dictionary<char, int> b)
        {
            foreach (var keyValuePair in a)
            {
                var key = keyValuePair.Key;

                if (!b.TryGetValue(key, out var value))
                {
                    return false;
                }

                if (value != a[key])
                {
                    return false;
                }
            }

            return true;
        }
    }
}
