
using System.Collections.Generic;

public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // TODO Problem 1 Start

        // Step 1: Create an array with the specified length.
        // Step 2: Use a loop to go through each position in the array.
        // Step 3: Multiply the given number by the current position plus one.
        // Step 4: Store each calculated multiple in the array.
        // Step 5: Return the completed array.

        double[] multiples = new double[length];

        for (int i = 0; i < length; i++)
        {
            multiples[i] = number * (i + 1);
        }

        return multiples;
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // TODO Problem 2 Start

        // Step 1: Find the total number of elements in the list.
        // Step 2: Calculate the starting index of the elements
        // that need to move to the beginning.
        // Step 3: Copy the last 'amount' elements into a new list.
        // Step 4: Copy the remaining elements into another list.
        // Step 5: Clear the original list.
        // Step 6: Add the last elements to the beginning.
        // Step 7: Add the remaining elements after them.

        int count = data.Count;
        int startIndex = count - amount;

        List<int> lastElements = data.GetRange(startIndex, amount);
        List<int> firstElements = data.GetRange(0, startIndex);

        data.Clear();

        data.AddRange(lastElements);
        data.AddRange(firstElements);
    }
}
