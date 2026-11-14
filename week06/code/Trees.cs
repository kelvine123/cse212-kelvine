
public static class Trees
{
    /// <summary>
    /// Given a sorted list, create a balanced BST.
    /// </summary>
    public static BinarySearchTree CreateTreeFromSortedList(
        int[] sortedNumbers)
    {
        var bst = new BinarySearchTree();

        InsertMiddle(
            sortedNumbers,
            0,
            sortedNumbers.Length - 1,
            bst);

        return bst;
    }

    /// <summary>
    /// Insert the middle value recursively to create
    /// a balanced binary search tree.
    /// </summary>
    private static void InsertMiddle(
        int[] sortedNumbers,
        int first,
        int last,
        BinarySearchTree bst)
    {
        // Problem 5: Base case
        if (first > last)
            return;

        // Find the middle index
        int middle = (first + last) / 2;

        // Insert the middle value
        bst.Insert(sortedNumbers[middle]);

        // Recursively insert the left half
        InsertMiddle(
            sortedNumbers,
            first,
            middle - 1,
            bst);

        // Recursively insert the right half
        InsertMiddle(
            sortedNumbers,
            middle + 1,
            last,
            bst);
    }
}
