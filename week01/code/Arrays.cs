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
        // PLAN:
        // 1. Initialize a new  array called 'multiples' that has the size of 'length'.
        // 2. Create a for loop that starts at index 0 and runs until it reaches 'length'.
        // 3. Inside the loop calculate the multiple: (current index + 1) * number.
        // 4. Assign that value to the current index in the 'multiples' array.
        // 5. Return the multiples array once the loop is finished.

        double[] multiples = new double[length];
        for (int i = 0; i < length; i++)
        {
            multiples[i] = (i + 1) * number;
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
        // PLAN:
        // 1. Determine the split point by subtracting 'amount' from the total count of the list.
        // 2. Use GetRange to capture the elements from that split point to the end of the list.
        //    These are the numbers that will move to the front.
        // 3. Use RemoveRange to delete those same elements from their original positions at the end of the list.
        // 4. Use InsertRange to place those captured elements at the very beginning (index 0) of the list.

        if (data.Count == 0 || amount == 0) return;

        // Calculate how many items to pull from the back
        int splitIndex = data.Count - amount;

        // Get the part that needs to move to the front
        List<int> movedPart = data.GetRange(splitIndex, amount);

        // Remove it from the back
        data.RemoveRange(splitIndex, amount);

        // Put it at the front
        data.InsertRange(0, movedPart);
    }
}
