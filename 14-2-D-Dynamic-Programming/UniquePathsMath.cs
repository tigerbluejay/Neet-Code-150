public partial class Solution
{
    public int MathUniquePaths(int m, int n)
    {
        // Base case: if either row or column is 1, there's only one path.
        if (m == 1 || n == 1)
        {
            return 1;
        }

        // Optimization: swap so that n is the smaller number to minimize loop iterations.
        if (m < n)
        {
            int temp = m;
            m = n;
            n = temp;
        }

        long res = 1; // Use long to avoid integer overflow during calculations.
        int j = 1;

        // Calculate the combination (m + n - 2) choose (n - 1)
        // Equivalent to (m + n - 2)! / ((m - 1)! * (n - 1)!)
        for (int i = m; i < m + n - 1; i++)
        {
            res *= i;   // Multiply by the current numerator
            res /= j;   // Divide by the current denominator
            j++;        // Increment denominator
        }

        return (int)res; // Cast back to int since the result fits within int bounds
    }
}

/*

This algorithm solves the Unique Paths problem using a combinatorial mathematics approach 
rather than dynamic programming. The core idea is that moving from the top-left corner to 
the bottom-right corner requires a fixed number of moves: (m - 1) moves down and (n - 1) 
moves right, in any order. The total number of unique sequences of these moves is given by 
the binomial coefficient formula:

(m + n - 2) choose (n - 1),
which is mathematically calculated as:
(m + n - 2)! / ((m - 1)! * (n - 1)!).

The algorithm optimizes this computation by only performing the minimal necessary 
multiplications and divisions in a single loop to avoid overflow and inefficiency that 
would come from calculating large factorials directly. It swaps m and n if needed so that 
the smaller number is used in the denominator, minimizing the number of iterations. 
This is the most time and space-efficient of the three approaches, with constant space and 
O(min(m, n)) time.

Correct formula: (m + n - 2) choose (n - 1)
→ (3 + 6 - 2) choose (6 - 1)
→ (7 choose 5) or (7 choose 2) (because choose(k) = choose(n - k))

So: (7 * 6) / (1 * 2) = 42 / 2 = 21 ✔️ Correct.

Step-by-step tree:

i=3, j=1 --> res *= 3 --> res = 3 --> res /= 1 --> res = 3
i=4, j=2 --> res *= 4 --> res = 12 --> res /= 2 --> res = 6
i=5, j=3 --> res *= 5 --> res = 30 --> res /= 3 --> res = 10
i=6, j=4 --> res *= 6 --> res = 60 --> res /= 4 --> res = 15
i=7, j=5 --> res *= 7 --> res = 105 --> res /= 5 --> res = 21

Result: 21

res = 1
res = (1 * 3) / 1  = 3
res = (3 * 4) / 2  = 6
res = (6 * 5) / 3  = 10
res = (10 * 6) / 4 = 15
res = (15 * 7) / 5 = 21

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