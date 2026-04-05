public static class Trees
{
    /// <summary>
    /// Given a sorted list (sorted_list), create a balanced BST.
    /// </summary>
    public static BinarySearchTree CreateTreeFromSortedList(int[] sortedNumbers)
    {
        var bst = new BinarySearchTree();
        InsertMiddle(sortedNumbers, 0, sortedNumbers.Length - 1, bst);
        return bst;
    }

    /// <summary>
    /// Problem 5: Insert the middle item to ensure a balanced tree.
    /// </summary>
    private static void InsertMiddle(int[] sortedNumbers, int first, int last, BinarySearchTree bst)
    {
        // Base case: if range is invalid
        if (first > last)
        {
            return;
        }

        // Find the middle index of the current range
        int mid = first + (last - first) / 2;

        // Insert the middle value into the BST
        bst.Insert(sortedNumbers[mid]);

        // Recursively handle the left half (values smaller than mid)
        InsertMiddle(sortedNumbers, first, mid - 1, bst);

        // Recursively handle the right half (values larger than mid)
        InsertMiddle(sortedNumbers, mid + 1, last, bst);
    }
}
