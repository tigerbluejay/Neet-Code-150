public partial class Solution {
    // This function initiates the search for the minimum time required 
    // to swim from the top-left (0,0) to the bottom-right (n-1, n-1).
    public int BFSwimInWater(int[][] grid) {
        int n = grid.Length; // Get the size of the grid (n x n)
        
        // Create a boolean 2D array to track visited cells
        bool[][] visit = new bool[n][];
        for (int i = 0; i < n; i++) {
            visit[i] = new bool[n]; // Initialize each row of the visit array
        }
        
        // Start the Depth-First Search (DFS) from (0,0) with initial time t=0
        return SRWBFDfs(grid, visit, 0, 0, 0);
    }

    // DFS function to find the minimum time required to reach (n-1, n-1)
    private int SRWBFDfs(int[][] grid, bool[][] visit, 
                    int r, int c, int t) {
        int n = grid.Length; // Get the grid size
        
        // Base case: Check if we are out of bounds or already visited
        if (r < 0 || c < 0 || r >= n || c >= n || visit[r][c]) {
            return 1000000; // Return a large number to indicate an invalid path
        }
        
        // If we've reached the bottom-right corner, return the maximum depth encountered
        if (r == n - 1 && c == n - 1) {
            return Math.Max(t, grid[r][c]); // Ensure we consider the max depth at (r, c)
        }
        
        // Mark the current cell as visited
        visit[r][c] = true;
        
        // Update the maximum water level encountered so far
        t = Math.Max(t, grid[r][c]);

        // Recursively explore all four possible directions (down, up, right, left)
        int res = Math.Min(
            Math.Min(SRWBFDfs(grid, visit, r + 1, c, t), // Move Down
                     SRWBFDfs(grid, visit, r - 1, c, t)), // Move Up
            Math.Min(SRWBFDfs(grid, visit, r, c + 1, t), // Move Right
                     SRWBFDfs(grid, visit, r, c - 1, t))  // Move Left
        );

        // Backtrack: Unmark the cell as visited for other recursive paths
        visit[r][c] = false;
        
        // Return the minimum time required to reach (n-1, n-1)
        return res;
    }
}
/*
The marking of visit[r][c] = true and later setting it back to false (backtracking) is a crucial aspect of 
Depth-First Search (DFS) algorithms.

Why Mark as true?
When we visit a cell (r, c), we mark it as true to prevent revisiting it within the same DFS path. 
This avoids infinite loops or redundant work.

Example:

If we move down from (0,0) to (1,0), we don’t want to go back up to (0,0), creating an unnecessary loop.
Why Mark as false (Undoing the Marking)?
After exploring all possible paths from a cell (r, c), we mark it back as false to allow other DFS paths 
to visit it.

Key Concept: Backtracking
DFS explores one path at a time.
Once a path is fully explored, we revert changes to allow alternative paths to be tested.
Example Walkthrough:
Consider this 3×3 grid:

0  2  4
1  3  5
2  6  7
The DFS call flow:

Start at (0,0), mark it true.
Move to (1,0), mark it true.
Move to (2,0), mark it true.
No more valid moves → backtrack (mark (2,0) = false).
Try a different path from (1,0).
Backtrack (1,0) = false, allowing (0,0) to try another direction.
If we don’t mark false (backtrack), the algorithm will think the cell is permanently visited and will 
block valid paths from using it later.

What Happens if We Don’t Mark false?
The DFS would get "stuck" because once a cell is visited, no other path can use it.
It would lead to an incomplete search, missing valid paths.

Summary:
✅ Mark true → Prevent revisiting the same cell within the same path.
✅ Mark false → Allow other DFS paths to explore the cell.
⚠️ If we don’t mark false, the algorithm will not explore all valid paths.

This technique is a core part of DFS with backtracking, commonly used in pathfinding problems like mazes, 
Sudoku solving, and combinatorial problems. 🚀
*/
/*
Consider this 3×3 grid:

0  2  4
1  3  5
2  6  7

(0,0) - 0
 ├── (1,0) - 1
 │   ├── (2,0) - 2
 │   │   ├── (2,1) - 6
 │   │   │   ├── (2,2) - 7  [GOAL REACHED]
 │   │   │   ├── (1,1) - 3  [BACKTRACK]
 │   │   │   ├── (2,0) - 2  [ALREADY VISITED]
 │   │   ├── (1,0) - 1  [ALREADY VISITED]
 │   │   ├── (2,1) - 6  [ALREADY VISITED]
 │   ├── (1,1) - 3
 │   │   ├── (2,1) - 6
 │   │   │   ├── (2,2) - 7  [GOAL REACHED]
 │   │   ├── (1,2) - 5
 │   │   │   ├── (2,2) - 7  [GOAL REACHED]
 │   │   ├── (1,0) - 1  [ALREADY VISITED]
 │   ├── (0,1) - 2
 │       ├── (1,1) - 3
 │       │   ├── (2,1) - 6
 │       │   │   ├── (2,2) - 7  [GOAL REACHED]
 │       │   ├── (1,2) - 5
 │       │   │   ├── (2,2) - 7  [GOAL REACHED]
 │       ├── (0,2) - 4
 │           ├── (1,2) - 5
 │           │   ├── (2,2) - 7  [GOAL REACHED]
 */
/*
Swim in Rising Water

You are given a square 2-D matrix of distinct integers grid where each integer grid[i][j] represents the 
elevation at position (i, j).

Rain starts to fall at time = 0, which causes the water level to rise. At time t, the water level across the 
entire grid is t.

You may swim either horizontally or vertically in the grid between two adjacent squares if the original 
elevation of both squares is less than or equal to the water level at time t.

Starting from the top left square (0, 0), return the minimum amount of time it will take until it is possible 
to reach the bottom right square (n - 1, n - 1).

Example 1:
Input: grid = [[0,1],[2,3]]

Output: 3
Explanation: For a path to exist to the bottom right square grid[1][1] the water elevation must be at least 3. 
At time t = 3, the water level is 3.
*/