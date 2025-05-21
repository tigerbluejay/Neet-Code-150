public partial class Solution
{
    public int DPBUUniquePaths(int m, int n)
    {
        // Create a DP table with one extra row and column to avoid bounds checking
        int[,] dp = new int[m + 1, n + 1];

        // Base case: there's 1 way to reach the destination from itself
        dp[m - 1, n - 1] = 1;

        // Traverse the grid in reverse: from bottom-right to top-left
        for (int i = m - 1; i >= 0; i--)
        {
            for (int j = n - 1; j >= 0; j--)
            {
                // Add paths from the cell below and the cell to the right
                // (except the destination cell which was set directly)
                dp[i, j] += dp[i + 1, j] + dp[i, j + 1];
            }
        }

        // The top-left corner now holds the total number of unique paths
        return dp[0, 0];
    }
}

/*

This algorithm uses bottom-up dynamic programming to count the number of unique paths 
from the top-left to the bottom-right of an m × n grid, moving only right or down. 
It initializes a 2D array dp with dimensions (m+1) x (n+1) to store the number of paths 
from each cell to the goal.

The key insight is that the number of paths from a cell (i, j) equals the sum of the 
paths from the cell directly below it (i+1, j) and the cell directly to its right (i, j+1). 
The base case is that there is exactly 1 path from the destination cell (m-1, n-1) 
to itself.

The algorithm iterates the grid backward, filling each cell with the sum of its right 
and bottom neighbors. By the time it reaches the top-left cell (0,0), this cell contains 
the total number of unique paths from the start to the finish.

✅ 3) Grid of Computed Paths for Input m = 3, n = 6:
Below is the final dp table that the algorithm builds (same grid as before, just 
calculated bottom-up instead of top-down):


[ 21][ 15][ 10][  6][  3][ 1]
[  6][  5][  4][  3][  2][ 1]
[  1][  1][  1][  1][  1][ 1]

This grid shows the number of unique paths from each position to the bottom-right corner 
(2,5). As expected, dp[0][0] = 21, which is the answer.

*/

/*
for (int i = m - 1; i >= 0; i--)
    for (int j = n - 1; j >= 0; j--)
        dp[i, j] += dp[i + 1, j] + dp[i, j + 1];

We’ll show each cell update as a tree node, including:

The current cell being processed: dp[i,j]
Its value after the update
The values of the bottom and right neighbors used in the calculation

🌳 Tree-like Simulation of Bottom-Up DP for m = 3, n = 6

Start: set dp[2,5] = 1

i = 2
 ├─ j = 5 → dp[2,5] = 1 (already set)
 ├─ j = 4 → dp  = 1
 ├─ j = 3 → dp  = 1
 ├─ j = 2 → dp  = 1
 ├─ j = 1 → dp  = 1
 └─ j = 0 → dp  = 1

i = 1
 ├─ j = 5 → dp  + 0 = 1
 ├─ j = 4 → dp  + dp  = 2
 ├─ j = 3 → dp  + dp  = 3
 ├─ j = 2 → dp  + dp  = 4
 ├─ j = 1 → dp  + dp  = 5
 └─ j = 0 → dp  + dp  = 6

i = 0
 ├─ j = 5 → dp  + 0 = 1
 ├─ j = 4 → dp  + dp  = 3
 ├─ j = 3 → dp  + dp  = 6
 ├─ j = 2 → dp  + dp  = 10
 ├─ j = 1 → dp  + dp  = 15
 └─ j = 0 → dp  + dp  = ✅ 21 total unique paths
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