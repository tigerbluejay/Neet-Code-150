public partial class Solution
{
    // Memoization table to store computed subproblem results
    int[,]? UniquePDPTDDmemo;

    public int DPTDUniquePaths(int m, int n)
    {
        // Initialize memo table with -1 to signify uncomputed states
        UniquePDPTDDmemo = new int[m, n];
        for (int i = 0; i < m; i++)
            for (int j = 0; j < n; j++)
                UniquePDPTDDmemo[i, j] = -1;

        // Start DFS traversal from the top-left corner (0,0)
        return UniquePDPTDDfs(0, 0, m, n);
    }

    int UniquePDPTDDfs(int i, int j, int m, int n)
    {
        // Base case: reached the bottom-right cell, count 1 path
        if (i == (m - 1) && j == (n - 1))
        {
            return 1;
        }

        // Out of bounds — invalid path
        if (i >= m || j >= n) return 0;

        // If already computed, return memoized result
        if (UniquePDPTDDmemo[i, j] != -1)
        {
            return UniquePDPTDDmemo[i, j];
        }

        // Otherwise, compute the result recursively by moving right and down,
        // then memoize the result before returning it
        return UniquePDPTDDmemo[i, j] = UniquePDPTDDfs(i, j + 1, m, n) +
                                  UniquePDPTDDfs(i + 1, j, m, n);
    }
}

/*
This algorithm computes how many unique paths exist from the top-left to the bottom-right 
corner in an m x n grid, where you can only move right or down.

It uses top-down dynamic programming with memoization to optimize recursive exploration. 
It starts at cell (0,0) and explores all possible paths to the bottom-right cell 
(m-1, n-1), but stores the result of each subproblem (i.e., number of paths from a given 
cell) in a 2D array UPDPTDmemo.

Each time the function reaches a previously visited cell, it skips redundant computation 
by returning the stored value. This drastically improves efficiency compared to the naive 
recursive version, reducing time complexity from exponential to O(m * n).
*/

/*

UniquePDPTDDfs(0,0) = 21
├─ UniquePDPTDDfs(0,1) = 15
│  ├─ UniquePDPTDDfs(0,2) = 10
│  │  ├─ UniquePDPTDDfs(0,3) = 6
│  │  │  ├─ UniquePDPTDDfs(0,4) = 3
│  │  │  │  ├─ UniquePDPTDDfs(0,5) = 1 (base case)
│  │  │  │  └─ UniquePDPTDDfs(1,4) = 2
│  │  │  │      ├─ UniquePDPTDDfs(1,5) = 1 (base case)
│  │  │  │      └─ UniquePDPTDDfs(2,4) = 1 (base case)
│  │  │  └─ UniquePDPTDDfs(1,3) = 3
│  │  │      ├─ [memo hit] UniquePDPTDDfs(1,4) = 2
│  │  │      └─ UniquePDPTDDfs(2,3) = 1 (base case)
│  │  └─ UniquePDPTDDfs(1,2) = 4
│  │      ├─ [memo hit] UniquePDPTDDfs(1,3) = 3
│  │      └─ UniquePDPTDDfs(2,2) = 1 (base case)
│  └─ UniquePDPTDDfs(1,1) = 5
│      ├─ [memo hit] UniquePDPTDDfs(1,2) = 4
│      └─ UniquePDPTDDfs(2,1) = 1 (base case)
└─ UniquePDPTDDfs(1,0) = 6
   ├─ [memo hit] UniquePDPTDDfs(1,1) = 5
   └─ UniquePDPTDDfs(2,0) = 1 (base case)

more detailed tree:

Dfs(0,0)
├── Dfs(0,1)
│   ├── Dfs(0,2)
│   │   ├── Dfs(0,3)
│   │   │   ├── Dfs(0,4)
│   │   │   │   ├── Dfs(0,5)
│   │   │   │   │   ├── Dfs(0,6) = 0
│   │   │   │   │   └── Dfs(1,5)
│   │   │   │   │       ├── Dfs(1,6) = 0
│   │   │   │   │       └── Dfs(2,5)
│   │   │   │   │           ├── Dfs(2,6) = 0
│   │   │   │   │           └── Dfs(3,5) ❌ = 0 (out of bounds)
│   │   │   │   │       => Dfs(2,5) = 1
│   │   │   │   │   => Dfs(1,5) = 1
│   │   │   │   └── Dfs(0,5) = 1
│   │   │   └── Dfs(1,4)
│   │   │       ├── Dfs(1,5) = 1 (memo)
│   │   │       └── Dfs(2,4)
│   │   │           ├── Dfs(2,5) = 1 (memo)
│   │   │           └── Dfs(3,4) = 0
│   │   │       => Dfs(2,4) = 1
│   │   │   => Dfs(1,4) = 2
│   │   │ => Dfs(0,4) = 3
│   │   └── Dfs(1,3)
│   │       ├── Dfs(1,4) = 2 (memo)
│   │       └── Dfs(2,3)
│   │           ├── Dfs(2,4) = 1 (memo)
│   │           └── Dfs(3,3) = 0
│   │       => Dfs(2,3) = 1
│   │   => Dfs(1,3) = 3
│   │ => Dfs(0,3) = 6
│   └── Dfs(1,2)
│       ├── Dfs(1,3) = 3 (memo)
│       └── Dfs(2,2)
│           ├── Dfs(2,3) = 1 (memo)
│           └── Dfs(3,2) = 0
│       => Dfs(2,2) = 1
│   => Dfs(1,2) = 4
│ => Dfs(0,2) = 10
└── Dfs(1,0)
    ├── Dfs(1,1)
    │   ├── Dfs(1,2) = 4 (memo)
    │   └── Dfs(2,1)
    │       ├── Dfs(2,2) = 1 (memo)
    │       └── Dfs(3,1) = 0
    │   => Dfs(2,1) = 1
    │ => Dfs(1,1) = 5
    └── Dfs(2,0)
        ├── Dfs(2,1) = 1 (memo)
        └── Dfs(3,0) = 0
    => Dfs(2,0) = 1
=> Dfs(1,0) = 6

Final at root:
Dfs(0,0) = Dfs(0,1) + Dfs(1,0)
         = 15       + 6
         = ✅ **21 total unique paths**
*/

/*
Grid of Unique Paths from Each Cell (3 rows × 6 columns)
[ 21][ 15][ 10][  6][  3][ 1]
[  6][  5][  4][  3][  2][ 1]
[  1][  1][  1][  1][  1][ 1]
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