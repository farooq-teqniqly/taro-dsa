namespace TaroDSA.Lib
{
    public class ArrayAndStringProblems
    {
        /// <summary>
        /// Represents a character frequency counter for a given string.
        /// </summary>
        public class Counter
        {
            public IReadOnlyDictionary<char, int> Counts { get; }

            /// <summary>
            /// Initializes a new instance of the <see cref="Counter"/> class with the specified string.
            /// </summary>
            /// <param name="s">The string to count character frequencies for.</param>
            /// <exception cref="ArgumentNullException">Thrown when the input string is null.</exception>
            public Counter(string s)
            {
                ArgumentNullException.ThrowIfNull(s);
                Counts = CreateFrequencyMap(s);
            }

            /// <summary>
            /// Determines whether the specified object is equal to the current object.
            /// Time complexity: O(n) because each key value pair needs to be compared.  
            /// </summary>
            /// <param name="obj">The object to compare with the current object.</param>
            /// <returns>True if the specified object is equal to the current object; otherwise, false.</returns>
            public override bool Equals(object? obj)
            {
                if (obj == null)
                {
                    return false;
                }

                if (obj.GetType() != this.GetType())
                {
                    return false;
                }

                var that = (Counter)obj;

                return FrequenciesMapsAreEqual(this.Counts, that.Counts);
            }

            /// <summary>
            /// Returns a hash code for the current object.
            /// Time complexity: O(n log n + n) because the keys are ordered prior to iterating the dictionary to calculate
            /// the hash codes of the key value pairs.  
            /// </summary>
            /// <returns>A hash code for the current object.</returns>
            public override int GetHashCode()
            {
                var hash = new HashCode();

                foreach (var keyValuePair in Counts.OrderBy(kvp => kvp.Key))
                {
                    hash.Add(HashCode.Combine(keyValuePair.Key, keyValuePair.Value));
                }

                return hash.ToHashCode();
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

            private static bool FrequenciesMapsAreEqual(IReadOnlyDictionary<char, int> a, IReadOnlyDictionary<char, int> b)
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
        /// <summary>
        /// Determines whether two strings are anagrams of each other.
        /// Time complexity: O(a + b + c) where a and b represent building the two Counters and c represents
        /// comparing the Counters.
        /// Space complexity: O(a + b) for the two Counters.
        /// </summary>
        /// <param name="a">The first string to compare.</param>
        /// <param name="b">The second string to compare.</param>
        /// <returns>True if the strings are anagrams; otherwise, false.</returns>
        /// <exception cref="ArgumentNullException">Thrown when either of the input strings is null.</exception>
        public static bool IsAnagram(string a, string b)
        {
            ArgumentNullException.ThrowIfNull(a);
            ArgumentNullException.ThrowIfNull(b);

            var aFrequencies = new Counter(a);
            var bFrequencies = new Counter(b);

            return aFrequencies.Equals(bFrequencies);
        }




    }
}
