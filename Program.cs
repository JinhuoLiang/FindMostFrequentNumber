using System;
using System.Collections.Generic;

namespace FindMostFrequentNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            // Both 3 and 5 appear 8 times. 5 appears 8 time before 3 in list1 while 3 appears 8 time before 5 in list2
            List<int> list1 = new List<int>() { 5, 3, 5, 6, 4, 3, 3, 5, 5, 6, 4, 3, 6, 7, 2, 6, 5, 8, 9, 7, 5, 3, 4, 3, 2, 5, 6, 4, 7, 3, 5, 3 };
            List<int> list2 = new List<int>() { 5, 3, 5, 6, 4, 3, 3, 5, 5, 6, 4, 3, 6, 7, 2, 6, 5, 8, 9, 7, 5, 3, 4, 3, 2, 5, 6, 4, 7, 3, 3, 5 };

            int max1 = FindMostFrequentNumber(list1);    // max1 = 5 
            int max2 = FindMostFrequentNumber(list2);    // max2 = 3

            // Output the results to the screen
            Console.WriteLine("Most frequently appeared number in the following list1 is {0}", max1);
            Console.WriteLine(string.Join(",", list1.ToArray()));
            Console.WriteLine();

            Console.WriteLine("Most frequently appeared number in the list2 is {0}", max2);
            Console.WriteLine(string.Join(",", list2.ToArray()));

            //  Hit a key to close the window.
            Console.WriteLine();
            Console.WriteLine("Enter any key to continue.");
            Console.ReadLine();
        }


        /// <summary>
        /// Find the value appeared most frequently in the list.
        /// </summary>
        /// <param name="list">List of integers to be searched.</param>
        /// <returns>The value appeared most frequently in the list.
        ///          If more than one value have the same highest frequency,
        ///          then the first array value which reaches the the highest
        ///          frequency will be returned.
        /// </returns>
        public static int FindMostFrequentNumber(List<int> list)
        {
            if (list == null || list.Count == 0)
                throw new ArgumentNullException("The passed list can not be null or empty");

            // Create a dictionary to hold the values and their frequency
            Dictionary<int, int> dictionary = new Dictionary<int, int>();

            // Remember the highest frequency and the corresponding value
            int maxFrequency = 0;
            int maxValue = 0;

            foreach (int key in list)
            {
                if (dictionary.ContainsKey(key))
                {
                    // If the key (array value) is in the dictionary, then add 1 to the value (frequency)
                    int frequency = dictionary[key] + 1;
                    dictionary[key] = frequency;

                    // Update the highest frequency and the corresponding value
                    // Use the first value if more than 1 number have the same frequency
                    if (frequency > maxFrequency)
                    {
                        maxFrequency = frequency;
                        maxValue = key;
                    }
                }
                else
                {
                    // Add the array value as the key and 1 as the value as (key, value) pair to the dictionary
                    dictionary.Add(key, 1);

                    if (maxFrequency == 0)
                    {
                        maxFrequency = 1;
                        maxValue = key;
                    }
                }
            }

            return maxValue;
        }
    }
}
