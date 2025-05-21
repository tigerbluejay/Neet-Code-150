public partial class Solution {
    // Entry point method that starts the DFS from cell (0, 0)
    public int RUniquePaths(int m, int n) {
        return UPRDfs(0, 0, m, n);
    }

    // Recursive DFS method that explores all possible paths from (i, j) to (m-1, n-1)
    int UPRDfs(int i, int j, int m, int n) {
        // Base case: reached bottom-right corner → one valid path found
        if (i == (m - 1) && j == (n - 1)) {
            return 1;
        }
        // Base case: out of bounds → not a valid path
        if (i >= m || j >= n) return 0;

        // Recursive case:
        // Sum of all paths moving right (j + 1) and down (i + 1)
        return UPRDfs(i, j + 1, m, n) +  // move right
               UPRDfs(i + 1, j, m, n);   // move down
    }
}

/*

This algorithm solves the Unique Paths problem using a depth-first search (DFS) 
strategy with recursion. The robot starts at the top-left cell (0, 0) in an m x n grid 
and can move only right or down. The goal is to reach the bottom-right cell (m - 1, n - 1).

The function UPRDfs(i, j, m, n) recursively explores all valid paths from the current 
position (i, j) to the destination:

If the current position is the bottom-right cell, the function returns 1 to count a 
successful path.

If the current position is outside the grid (either i >= m or j >= n), it returns 0, 
as this path is invalid.

Otherwise, it recursively explores the two possible directions:

Moving right to (i, j + 1)
Moving down to (i + 1, j)

By summing the results of these two recursive calls, it aggregates the number of unique 
paths from the current position to the destination. The initial call starts at (0, 0), 
so the total number of unique paths from the start to the end of the grid is returned.
*/

/*

UPRDfs(0,0) = 21
├─ UPRDfs(0,1) = 15
│  ├─ UPRDfs(0,2) = 10
│  │  ├─ UPRDfs(0,3) = 6
│  │  │  ├─ UPRDfs(0,4) = 3
│  │  │  │  ├─ UPRDfs(0,5) = 1
│  │  │  │  └─ UPRDfs(1,4) = 2
│  │  │  │      ├─ UPRDfs(1,5) = 1
│  │  │  │      └─ UPRDfs(2,4) = 1
│  │  │  └─ UPRDfs(1,3) = 3
│  │  │      ├─ UPRDfs(1,4) = 2
│  │  │      └─ UPRDfs(2,3) = 1
│  │  └─ UPRDfs(1,2) = 4
│  │      ├─ UPRDfs(1,3) = 3
│  │      └─ UPRDfs(2,2) = 1
│  └─ UPRDfs(1,1) = 5
│      ├─ UPRDfs(1,2) = 4
│      └─ UPRDfs(2,1) = 1
└─ UPRDfs(1,0) = 6
   ├─ UPRDfs(1,1) = 5
   └─ UPRDfs(2,0) = 1

Legend:
Each node shows the recursive call position (i, j)

Arrows -> show terminal cases: either hitting the edge (returns 0) or reaching (2, 5) 
and going down to (3, 5) (returns 1)

Many subtrees collapse into ... due to repetition and depth, but they follow the same 
pattern: try going right and down from each cell.

This structure grows exponentially, which is why adding memoization or switching to 
dynamic programming is often used to optimize this brute-force recursive approach.
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