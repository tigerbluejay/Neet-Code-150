public partial class Solution
{
    public int DPSOUniquePaths(int m, int n)
    {
        // Initialize a row array of size n, all filled with 1.
        // This represents the bottom row where there's only one way to reach the destination (all the way to the right).
        var row = new int[n];
        Array.Fill(row, 1);

        // Loop over the number of rows, excluding the last one which is the base case already initialized.
        for (int i = 0; i < m - 1; i++)
        {
            // Create a new row array for the current iteration, initialized with 1s.
            // The rightmost cell is always 1 since only one way exists (going right).
            var newRow = new int[n];
            Array.Fill(newRow, 1);

            // Fill the new row from right to left, skipping the last column (already 1).
            for (int j = n - 2; j >= 0; j--)
            {
                // The number of ways to reach (i, j) is:
                // ways to the right (newRow[j + 1]) + ways from below (row[j]).
                newRow[j] = newRow[j + 1] + row[j];
            }

            // Move to the next row upwards by replacing 'row' with 'newRow'.
            row = newRow;
        }

        // The top-left cell (row[0]) contains the total number of unique paths.
        return row[0];
    }
}

/*
This algorithm solves the Unique Paths problem using a Dynamic Programming approach 
with space optimization (DP-SO). Instead of building a full m x n DP grid, it uses a 
single row that gets updated iteratively to save space. The idea is that at any cell 
in the grid, the number of unique paths to the destination is the sum of the paths from 
the cell directly to the right and the cell directly below. The algorithm starts by 
initializing the bottom row (or a single row) with all 1s, since from any position in the
 last row there is exactly one way to reach the bottom-right corner (by moving only right). It then works its way upward row by row, updating the row in place by computing each cell from right to left. Each cell's value becomes the sum of its right neighbor (moving right) and its counterpart in the row below (moving down). After completing m-1 iterations (to simulate moving up m-1 rows), the top-left cell of this compressed row holds the total number of unique paths, which is returned as the result.
*/

/*
Initial row (bottom row, all 1s):
[1, 1, 1, 1, 1, 1]

First iteration (building second-to-last row):
Start from right:
j=4: newRow[4] = 1 (right) + 1 (below) = 2
j=3: newRow[3] = 2 (right) + 1 (below) = 3
j=2: newRow[2] = 3 (right) + 1 (below) = 4
j=1: newRow[1] = 4 (right) + 1 (below) = 5
j=0: newRow[0] = 5 (right) + 1 (below) = 6

Row after first iteration:
[6, 5, 4, 3, 2, 1]

Second iteration (building top row):
Start from right:
j=4: newRow[4] = 1 (right) + 2 (below) = 3
j=3: newRow[3] = 3 (right) + 3 (below) = 6
j=2: newRow[2] = 6 (right) + 4 (below) = 10
j=1: newRow[1] = 10 (right) + 5 (below) = 15
j=0: newRow[0] = 15 (right) + 6 (below) = 21

Row after second iteration (final):
[21, 15, 10, 6, 3, 1]

Result:
row[0] = 21

21 15 10  6  3  1   <-- Top row (final result)
 6  5  4  3  2  1   <-- Middle row (after first iteration)
 1  1  1  1  1  1   <-- Bottom row (initial)

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