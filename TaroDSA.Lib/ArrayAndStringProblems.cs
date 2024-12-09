namespace TaroDSA.Lib;

public class ArrayAndStringProblems
{
    /// <summary>
    /// Represents a character frequency counter for a given string.
    /// </summary>
    public class Counter
    {
        public IReadOnlyDictionary<char, int> Counts { get; }
        private readonly string _s;

        /// <summary>
        /// Initializes a new instance of the <see cref="Counter"/> class with the specified string.
        /// </summary>
        /// <param name="s">The string to count character frequencies for.</param>
        /// <exception cref="ArgumentNullException">Thrown when the input string is null.</exception>
        public Counter(string s)
        {
            ArgumentNullException.ThrowIfNull(s);
            Counts = CreateFrequencyMap(s);
            _s = s;
        }

        /// <summary>
        /// Finds the most frequent character in the string. In the case of ties, the character
        /// appearing first is returned.
        /// Time complexity: O(n)
        /// Space complexity: O(1)
        /// </summary>
        /// <returns>The character that appears most frequently in the string.</returns>
        /// <exception cref="InvalidOperationException">Thrown when the string is empty.</exception>
        public char MostFrequentCharacter()
        {
            var mostFrequent = _s[0];

            for (var i = 1; i < _s.Length - 1; i++)
            {
                var mostFrequentCount = Counts[mostFrequent];
                var thisChar = _s[i];
                var thisCount = Counts[thisChar];

                if (thisCount > mostFrequentCount)
                {
                    mostFrequent = thisChar;
                }
            }

            return mostFrequent;
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// Time complexity: O(n) because each key value pair needs to be compared.
        /// Space complexity: O(1)
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

            return FrequenciesMapsAreEqual(Counts, that.Counts);
        }

        /// <summary>
        /// Returns a hash code for the current object.
        /// Time complexity: O(n log n) because the keys are ordered prior to iterating the dictionary to calculate
        /// the hash codes of the key value pairs.
        /// Space complexity: O(1) 
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
    /// Time complexity: O(n)
    /// Space complexity: O(n)
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

    public static char GetMostFrequentCharacter(string a)
    {
        ArgumentNullException.ThrowIfNull(a);

        return new Counter(a).MostFrequentCharacter();
    }

    /// <summary>
    /// Finds a pair of numbers in the given array that sum up to the target value.
    /// Time complexity: O(n)
    /// Space complexity: O(n)
    /// </summary>
    /// <param name="arr">The array of numbers.</param>
    /// <param name="target">The target sum.</param>
    /// <returns>An array containing the indices of the pair of numbers that sum up to the target value.</returns>
    /// <exception cref="ArgumentNullException">Thrown when the input array is null.</exception>
    public static int[] PairSum(int[] arr, int target)
    {
        ArgumentNullException.ThrowIfNull(arr);

        if (arr.Length == 0)
        {
            return [];
        }

        var map = new Dictionary<int, int>();

        for (var i = 0; i < arr.Length; i++)
        {
            var current = arr[i];
            var complement = target - current;

            if (map.TryGetValue(complement, out var value))
            {
                return [value, i];
            }

            map.Add(current, i);
        }

        return [];
    }

    /// <summary>
    /// Finds a pair of numbers in the given array that sum up to the target value using a
    /// brute-force approach.
    /// Time complexity: O(n^2)
    /// Space complexity: O(1)
    /// </summary>
    /// <param name="arr">The array of numbers.</param>
    /// <param name="target">The target sum.</param>
    /// <returns>An array containing the indices of the pair of numbers that sum up to the target value.</returns>
    /// <exception cref="ArgumentNullException">Thrown when the input array is null.</exception>
    public static int[] PairSumBruteForce(int[] arr, int target)
    {
        ArgumentNullException.ThrowIfNull(arr);

        if (arr.Length == 0)
        {
            return [];
        }

        for (var i = 0; i < arr.Length; i++)
        {
            for (var j = i + 1; j < arr.Length; j++)
            {
                if (arr[j] + arr[i] == target)
                {
                    return [i, j];
                }
            }
        }

        return [];
    }

    /// <summary>
    /// Finds a pair of numbers in the given array that multiply to the target value using a
    /// brute-force approach.
    /// Time complexity: O(n^2)
    /// Space complexity: O(1)
    /// </summary>
    /// <param name="arr">The array of numbers.</param>
    /// <param name="target">The target product.</param>
    /// <returns>An array containing the indices of the pair of numbers that multiply to the target value.</returns>
    /// <exception cref="ArgumentNullException">Thrown when the input array is null.</exception>
    public static int[] PairProductBruteForce(int[] arr, int target)
    {
        ArgumentNullException.ThrowIfNull(arr);

        if (arr.Length == 0)
        {
            return [];
        }

        for (var i = 0; i < arr.Length; i++)
        {
            for (var j = 0; j < arr.Length; j++)
            {
                if (arr[i] * arr[j] == target)
                {
                    return [i, j];
                }
            }
        }

        return [];
    }

    /// <summary>
    /// Finds a pair of numbers in the given array that multiply to the target value.
    /// Time complexity: O(n)
    /// Space complexity: O(n)
    /// </summary>
    /// <param name="arr">The array of numbers.</param>
    /// <param name="target">The target product.</param>
    /// <returns>An array containing the indices of the pair of numbers that multiply to the target value.</returns>
    /// <exception cref="ArgumentNullException">Thrown when the input array is null.</exception>
    public static int[] PairProduct(int[] arr, int target)
    {
        ArgumentNullException.ThrowIfNull(arr);

        if (arr.Length == 0)
        {
            return [];
        }

        var map = new Dictionary<int, int>();


        for (var i = 0; i < arr.Length; i++)
        {
            var current = arr[i];

            if (current == 0)
            {
                continue;
            }

            var remainder = target % current;

            if (remainder != 0)
            {
                continue;
            }

            var complement = target / current;

            if (map.TryGetValue(complement, out var value))
            {
                return [value, i];
            }

            map.Add(current, i);
        }

        return [];
    }

    /// <summary>
    /// Finds the intersection of two arrays using a brute-force approach.
    /// Time complexity: O(a * b)
    /// Space complexity: O(min(a, b)))
    /// </summary>
    /// <param name="a">The first array.</param>
    /// <param name="b">The second array.</param>
    /// <returns>An IEnumerable containing the intersection of the two arrays.</returns>
    /// <exception cref="ArgumentNullException">Thrown when either input array is null.</exception>
    public static IEnumerable<int> IntersectionBruteForce(int[] a, int[] b)
    {
        ArgumentNullException.ThrowIfNull(a);
        ArgumentNullException.ThrowIfNull(b);

        if (a.Length == 0 || b.Length == 0)
        {
            return [];
        }

        var intersection = new List<int>();

        for (var i = 0; i < a.Length; i++)
        {
            for (var j = 0; j < b.Length; j++)
            {
                if (a[i] == b[j])
                {
                    intersection.Add(a[i]);
                }
            }
        }

        return intersection;
    }

    /// <summary>
    /// Finds the intersection of two arrays.
    /// Time complexity: O(a + b)
    /// Space complexity: O(b)
    /// </summary>
    /// <param name="a">The first array.</param>
    /// <param name="b">The second array.</param>
    /// <returns>An IEnumerable containing the intersection of the two arrays.</returns>
    /// <exception cref="ArgumentNullException">Thrown when either input array is null.</exception>
    public static IEnumerable<int> Intersection(int[] a, int[] b)
    {
        ArgumentNullException.ThrowIfNull(a);
        ArgumentNullException.ThrowIfNull(b);

        if (a.Length == 0 || b.Length == 0)
        {
            return [];
        }

        var intersection = new List<int>();
        HashSet<int> set = [.. b];

        for (var i = 0; i < a.Length; i++)
        {
            if (set.Contains(a[i]))
            {
                intersection.Add(a[i]);
            }
        }

        return intersection;
    }

    /// <summary>
    /// Finds a pair of numbers in the given array that sum up to the target value.
    /// Time complexity: O(n)
    /// Space complexity: O(1)
    /// </summary>
    /// <param name="arr">The array of numbers.</param>
    /// <param name="target">The target sum.</param>
    /// <returns>An array containing the indices of the pair of numbers that sum up to the target value.</returns>
    /// <exception cref="ArgumentNullException">Thrown when the input array is null.</exception>
    public static int[] PairSumSorted(int[] arr, int target)
    {
        ArgumentNullException.ThrowIfNull(arr);

        var arrLength = arr.Length;
        var leftIndex = 0;
        var rightIndex = arrLength - 1;

        for (var i = 0; i < arrLength; i++)
        {
            var sum = arr[leftIndex] + arr[rightIndex];

            if (sum == target)
            {
                return [leftIndex, rightIndex];
            }

            if (sum < target)
            {
                leftIndex++;
            }
            else
            {
                rightIndex--;
            }
        }

        return [];
    }

    /// <summary>
    /// Finds triplets in the given array that sum up to zero.
    /// Time complexity: O(n^2): O(n log n) for the sort + O(n^2) for the array traversals.
    /// Space complexity: O(n) for the sort.
    /// </summary>
    /// <param name="arr">The array of numbers.</param>
    /// <returns>A list of arrays containing the triplets that sum up to zero.</returns>
    public static List<int[]> TripletSum(int[] arr)
    {
        var triplets = new List<int[]>();
        Array.Sort(arr);

        for (var i = 0; i < arr.Length; i++)
        {
            // Positive numbers can't add up to zero. Since it's a sorted array, exit.
            if (arr[i] > 0)
            {
                break;
            }

            // Prevents duplicates resulting from arr[i].
            if (i > 0 && arr[i] == arr[i - 1])
            {
                continue;
            }

            var leftIndex = i + 1;
            var rightIndex = arr.Length - 1;

            while (leftIndex < rightIndex)
            {
                // Prevents duplicates resulting from arr[left].
                if (arr[leftIndex] == arr[leftIndex - 1])
                {
                    leftIndex++;
                }

                var target = -arr[i];
                var sum = arr[leftIndex] + arr[rightIndex];

                if (sum == target)
                {
                    triplets.Add([arr[i], arr[leftIndex], arr[rightIndex]]);
                    leftIndex++;
                }
                else if (sum < target)
                {
                    leftIndex++;
                }
                else
                {
                    rightIndex--;
                }
            }
        }

        return triplets;
    }
}
