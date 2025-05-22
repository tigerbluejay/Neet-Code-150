public partial class Solution
{
    public int DPOUniquePaths(int m, int n)
    {
        // Initialize the DP array for the bottom row, all set to 1.
        // Represents the last row where there's only one path (all moves to the right).
        int[] dp = new int[n];
        Array.Fill(dp, 1);

        // Loop from the second-to-last row up to the top row.
        for (int i = m - 2; i >= 0; i--)
        {
            // Loop from the second-to-last column to the first column.
            for (int j = n - 2; j >= 0; j--)
            {
                // Update the current cell:
                // dp[j] = dp[j] (down) + dp[j + 1] (right)
                dp[j] += dp[j + 1];
            }
        }

        // dp[0] holds the number of unique paths from the top-left corner.
        return dp[0];
    }
}

/*

This solution is a space-optimized dynamic programming approach that further simplifies 
the previous algorithm by using only a single one-dimensional array (dp) instead of two 
rows. It starts by initializing the array with all 1s, representing the bottom row of the
 grid where there's only one path to the destination from any cell (by moving right). 
 The algorithm then iterates from the second-to-last row upwards, updating the dp array 
 in place. For each cell from right to left, it updates the value as the sum of the 
 current value (dp[j], representing the path coming from below) and the value to the right 
 (dp[j + 1], representing the path coming from moving right). After processing all rows, 
 the first element dp[0] contains the total number of unique paths from the top-left to 
 the bottom-right corner.

21 15 10  6  3  1   <-- After processing top row (final result)
 6  5  4  3  2  1   <-- After processing middle row
 1  1  1  1  1  1   <-- Initial bottom row
*/

/*
Unique Paths

There is an m x n grid where you are allowed to move either down or to the right at 
any point in time.

Given the two integers m and n, return the number of possible unique paths that can 
be taken from the top-left corner of the grid (grid[0][0]) to the bottom-right corner 
(grid[m - 1][n - 1]).

You may assume the output will fit in a 32-bit integer.

Example 1:
Input: m = 3, n = 6
Output: 21

Example 2:
Input: m = 3, n = 3
Output: 6

Constraints:
1 <= m, n <= 100
*/