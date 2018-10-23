import java.util.*;


public class Main {

    // <summary>
    // Find the value appeared most frequently in the list.
    // </summary>
    // <param name="list">List of integers to be searched.</param>
    // <returns>The value appeared most frequently in the list.
    //          If more than one value have the same highest frequency,
    //          then the first array value which reaches the the highest
    //          frequency will be returned.
    // </returns>
    static int findMostFrequentNumber(List<Integer> list)
    {
        if (list == null || list.size() == 0)
            throw new NullPointerException("The passed list can not be null or empty");

        // Create a dictionary to hold the values and their frequency
        HashMap<Integer, Integer> hashMap = new HashMap<Integer, Integer>();

        // Remember the highest frequency and the corresponding value
        int maxFrequency = 0;
        int maxValue = 0;

        for(int key:  list)
        {
            if (hashMap.containsKey(key))
            {
                // If the key (array value) is in the dictionary, then add 1 to the value (frequency)
                int frequency = hashMap.get(key) + 1;
                hashMap.replace(key, frequency);

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
                hashMap.put(key, 1);

                if (maxFrequency == 0)
                {
                    maxFrequency = 1;
                    maxValue = key;
                }
            }
        }

        return maxValue;
    }

    public static void main(String args[] ) throws Exception {
        /* Enter your code here. Read input from STDIN. Print output to STDOUT */
        // Both 3 and 5 appear 8 times. 5 appears 8 time before 3 in list1 while 3 appears 8 time before 5 in list2
        List<Integer> list1 = new ArrayList<>(
                Arrays.asList(5,3,5,6,4,3,3,5,5,6,4,3,6,7,2,6,5,8,9,7,5,3,4,3,2,5,6,4,7,3,5,3));
        List<Integer> list2 = new ArrayList<>(
                Arrays.asList(5,3,5,6,4,3,3,5,5,6,4,3,6,7,2,6,5,8,9,7,5,3,4,3,2,5,6,4,7,3,3,5));

        int max1 = findMostFrequentNumber(list1);    // max1 = 5
        int max2 = findMostFrequentNumber(list2);    // max2 = 3

        // Output the results to the screen
        System.out.println("Most frequently appeared number in the following list1 is " + max1);
        System.out.println(Arrays.toString(list1.toArray()));
        System.out.println();

        System.out.println("Most frequently appeared number in the list2 is " + max2);
        System.out.println(Arrays.toString(list2.toArray()));

        //  Hit a key to close the window.
        System.out.println();
        System.out.println("Enter any key to continue.");
        System.out.println();
    }
}