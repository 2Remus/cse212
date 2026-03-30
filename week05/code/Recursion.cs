using System.Collections;
using System.Diagnostics;

public static class Recursion
{
    /// <summary>
    /// Problem 1: Sum of Squares
    /// </summary>
    public static int SumSquaresRecursive(int n)
    {
        // Base Case: If n <= 0, the sum is 0
        if (n <= 0)
            return 0;

        // Recursive Step: n^2 + sum of squares of (n-1)
        return (n * n) + SumSquaresRecursive(n - 1);
    }

    /// <summary>
    /// Problem 2: Permutations Choose
    /// </summary>
    public static void PermutationsChoose(List<string> results, string letters, int size, string word = "")
    {
        // Base Case: If the current word reached the target size, we found a permutation
        if (word.Length == size)
        {
            results.Add(word);
            return;
        }

        // Recursive Step: Try adding each letter to the current word
        foreach (char letter in letters)
        {
            // Since we assume letters are unique, we check if the current word contains this letter
            if (!word.Contains(letter))
            {
                PermutationsChoose(results, letters, size, word + letter);
            }
        }
    }

    /// <summary>
    /// Problem 3: Climbing Stairs with Memoization
    /// </summary>
    public static decimal CountWaysToClimb(int s, Dictionary<int, decimal>? remember = null)
    {
        // Initialize the dictionary if it's the first call
        if (remember == null)
            remember = new Dictionary<int, decimal>();

        // Base Cases
        if (s < 0) return 0;
        if (s == 0) return 1; // 1 way to be at the top (reached the goal)

        // Check Memoization
        if (remember.ContainsKey(s))
            return remember[s];

        // Solve using recursion and store in memo
        decimal ways = CountWaysToClimb(s - 1, remember) +
                       CountWaysToClimb(s - 2, remember) +
                       CountWaysToClimb(s - 3, remember);

        remember[s] = ways;
        return ways;
    }

    /// <summary>
    /// Problem 4: Wildcard Binary Patterns
    /// </summary>
    public static void WildcardBinary(string pattern, List<string> results)
    {
        // Find the first wildcard
        int index = pattern.IndexOf('*');

        // Base Case: No wildcards left, add the string to results
        if (index == -1)
        {
            results.Add(pattern);
            return;
        }

        // Recursive Step: Replace '*' with '0' and '1' and recurse
        // Using C# range operators [..index] and [(index+1)..]
        WildcardBinary(pattern[..index] + '0' + pattern[(index + 1)..], results);
        WildcardBinary(pattern[..index] + '1' + pattern[(index + 1)..], results);
    }

    /// <summary>
    /// Problem 5: Maze Solver
    /// </summary>
    public static void SolveMaze(List<string> results, Maze maze, int x = 0, int y = 0, List<ValueTuple<int, int>>? currPath = null)
    {
        if (currPath == null)
        {
            currPath = new List<ValueTuple<int, int>>();
        }

        // 1. Add current position to path
        currPath.Add((x, y));

        // 2. Base Case: Are we at the end?
        if (maze.IsEnd(x, y))
        {
            // FIX: Trying the parameterless version of AsString based on your error
            results.Add(currPath.AsString());
        }
        else
        {
            // 3. Recursive Step: Try all 4 directions
            var moves = new (int dx, int dy)[] { (0, 1), (0, -1), (1, 0), (-1, 0) };

            foreach (var move in moves)
            {
                int nextX = x + move.dx;
                int nextY = y + move.dy;

                // FIX: Swap arguments based on Error CS1503
                // It wants the List first, then the X and Y ints.
                if (maze.IsValidMove(currPath, nextX, nextY))
                {
                    SolveMaze(results, maze, nextX, nextY, currPath);
                }
            }
        }

        // 4. Backtrack
        currPath.RemoveAt(currPath.Count - 1);
    }
}
