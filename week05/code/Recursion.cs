
using System.Collections;

public static class Recursion
{
    /// <summary>
    /// #############
    /// # Problem 1 #
    /// #############
    /// Using recursion, find the sum of 1^2 + 2^2 + 3^2 + ... + n^2
    /// and return it.
    /// </summary>
    public static int SumSquaresRecursive(int n)
    {
        // Base case
        if (n <= 0)
            return 0;

        // Add n squared to the recursive result for n - 1
        return (n * n) + SumSquaresRecursive(n - 1);
    }

    /// <summary>
    /// #############
    /// # Problem 2 #
    /// #############
    /// Using recursion, insert permutations of length
    /// 'size' from a list of 'letters' into the results list.
    /// </summary>
    public static void PermutationsChoose(
        List<string> results,
        string letters,
        int size,
        string word = "")
    {
        // Base case: requested word length has been reached
        if (word.Length == size)
        {
            results.Add(word);
            return;
        }

        // Choose each available letter
        for (int i = 0; i < letters.Length; i++)
        {
            string letter = letters[i].ToString();

            // Remove the chosen letter from remaining letters
            string remainingLetters =
                letters.Remove(i, 1);

            // Recursively build the next word
            PermutationsChoose(
                results,
                remainingLetters,
                size,
                word + letter);
        }
    }

    /// <summary>
    /// #############
    /// # Problem 3 #
    /// #############
    /// Count the number of ways to climb stairs using
    /// one, two, or three steps at a time.
    /// </summary>
    public static decimal CountWaysToClimb(
        int s,
        Dictionary<int, decimal>? remember = null)
    {
        // Base Cases
        if (s == 0)
            return 0;
        if (s == 1)
            return 1;
        if (s == 2)
            return 2;
        if (s == 3)
            return 4;

        // Initialize dictionary if it is null
        if (remember == null)
        {
            remember = new Dictionary<int, decimal>();
        }

        // Return previously calculated result
        if (remember.ContainsKey(s))
        {
            return remember[s];
        }

        // Solve using recursion and pass the same dictionary
        decimal ways =
            CountWaysToClimb(s - 1, remember) +
            CountWaysToClimb(s - 2, remember) +
            CountWaysToClimb(s - 3, remember);

        // Store calculated result
        remember[s] = ways;

        return ways;
    }

    /// <summary>
    /// #############
    /// # Problem 4 #
    /// #############
    /// Generate all possible binary strings from a pattern
    /// containing wildcard characters (*).
    /// </summary>
    public static void WildcardBinary(
        string pattern,
        List<string> results)
    {
        // Find the first wildcard
        int index = pattern.IndexOf('*');

        // Base case: no wildcard remains
        if (index == -1)
        {
            results.Add(pattern);
            return;
        }

        // Replace the first wildcard with 0
        string pattern0 =
            pattern.Substring(0, index) +
            "0" +
            pattern.Substring(index + 1);

        // Replace the first wildcard with 1
        string pattern1 =
            pattern.Substring(0, index) +
            "1" +
            pattern.Substring(index + 1);

        // Recursively explore both possibilities
        WildcardBinary(pattern0, results);
        WildcardBinary(pattern1, results);
    }

    /// <summary>
    /// Use recursion to insert all paths that start at (0,0)
    /// and end at the 'end' square into the results list.
    /// </summary>
    public static void SolveMaze(
        List<string> results,
        Maze maze,
        int x = 0,
        int y = 0,
        List<ValueTuple<int, int>>? currPath = null)
    {
        // Initialize current path if necessary
        if (currPath == null)
        {
            currPath = new List<ValueTuple<int, int>>();
        }

        // Add current position to path
        currPath.Add((x, y));

        // Check whether the current position is the maze end
        if (maze.IsEnd(x, y))
        {
            results.Add(currPath.AsString());

            // Remove current position when backtracking
            currPath.RemoveAt(currPath.Count - 1);
            return;
        }

        // Explore neighboring positions
        // Right
        if (maze.IsValidMove(currPath, x + 1, y))
        {
            SolveMaze(results, maze, x + 1, y, currPath);
        }

        // Down
        if (maze.IsValidMove(currPath, x, y + 1))
        {
            SolveMaze(results, maze, x, y + 1, currPath);
        }

        // Left
        if (maze.IsValidMove(currPath, x - 1, y))
        {
            SolveMaze(results, maze, x - 1, y, currPath);
        }

        // Up
        if (maze.IsValidMove(currPath, x, y - 1))
        {
            SolveMaze(results, maze, x, y - 1, currPath);
        }

        // Backtrack: remove current position
        currPath.RemoveAt(currPath.Count - 1);
    }
}
