public class Node
{
    public int Data { get; set; }
    public Node? Right { get; private set; }
    public Node? Left { get; private set; }

    public Node(int data)
    {
        this.Data = data;
    }

    public void Insert(int value)
    {
        // Problem 1: Only allow unique values (Sorted Set behavior)
        if (value == Data)
        {
            return; // Value already exists, do nothing
        }

        if (value < Data)
        {
            // Insert to the left
            if (Left is null)
                Left = new Node(value);
            else
                Left.Insert(value);
        }
        else
        {
            // Insert to the right
            if (Right is null)
                Right = new Node(value);
            else
                Right.Insert(value);
        }
    }

    public bool Contains(int value)
    {
        // Problem 2: Recursive search
        if (value == Data)
        {
            return true;
        }

        if (value < Data)
        {
            // Search left subtree if it exists
            return Left != null && Left.Contains(value);
        }
        else
        {
            // Search right subtree if it exists
            return Right != null && Right.Contains(value);
        }
    }

    public int GetHeight()
    {
        // Problem 4: Recursive height calculation
        // Height = 1 + Max(LeftHeight, RightHeight)

        int leftHeight = Left?.GetHeight() ?? 0;
        int rightHeight = Right?.GetHeight() ?? 0;

        return 1 + Math.Max(leftHeight, rightHeight);
    }
}
