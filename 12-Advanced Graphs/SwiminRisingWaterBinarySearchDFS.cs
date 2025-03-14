public partial class Solution {
    public int BSDFSSwimInWater(int[][] grid) {
        int n = grid.Length;
        
        // Create a 2D boolean array to track visited cells
        bool[][] visit = new bool[n][];
        for (int i = 0; i < n; i++) {
            visit[i] = new bool[n];
        }

        // Find the minimum and maximum height values in the grid
        int minH = grid[0][0], maxH = grid[0][0];
        for (int row = 0; row < n; row++) {
            for (int col = 0; col < n; col++) {
                maxH = Math.Max(maxH, grid[row][col]);
                minH = Math.Min(minH, grid[row][col]);
            }
        }

        // Perform binary search to find the minimum possible time to cross
        int l = minH, r = maxH;
        while (l < r) {
            int m = (l + r) >> 1; // Midpoint for binary search
            
            // If it's possible to reach the bottom-right cell with water level 'm'
            if (SRWBSDFSdfs(grid, visit, 0, 0, m)) {
                r = m; // Try a lower water level
            } else {
                l = m + 1; // Increase the water level
            }
            
            // Reset the visited array for the next iteration
            for (int row = 0; row < n; row++) {
                Array.Fill(visit[row], false);
            }
        }
        return r; // The minimum time required to cross
    }

    // Depth-first search (DFS) function to check if reaching bottom-right is possible
    private bool SRWBSDFSdfs(int[][] grid, bool[][] visit, int r, int c, int t) {
        // Check boundaries, already visited cells, or if the water level is too high
        if (r < 0 || c < 0 || r >= grid.Length || 
            c >= grid.Length || visit[r][c] || grid[r][c] > t) {
            return false;
        }

        // If we reach the bottom-right cell, return true
        if (r == grid.Length - 1 && c == grid.Length - 1) {
            return true;
        }

        // Mark the current cell as visited
        visit[r][c] = true;

        // Explore all four possible movement directions (down, up, right, left)
        return SRWBSDFSdfs(grid, visit, r + 1, c, t) || 
               SRWBSDFSdfs(grid, visit, r - 1, c, t) || 
               SRWBSDFSdfs(grid, visit, r, c + 1, t) || 
               SRWBSDFSdfs(grid, visit, r, c - 1, t);
    }
}
/*
Input Grid
0  2  4
1  3  5
2  6  7

Tree Representation of Recursive Calls for t = 4
For t = 4, the DFS will only traverse cells where grid[r][c] ≤ 4. The valid traversal is:

0  2  4
1  3  .
2  .  .
. represents cells blocked because their value is greater than 4.
Recursive Calls Tree (DFS Traversal Starting from (0,0))
(0,0)
 ├── (1,0)
 │    ├── (2,0)
 │    │    ├── (1,1)
 │    │    │    ├── (0,1)
 │    │    │    │    ├── (0,2)  ✅ (Goal not reached, backtracks)
 │    │    │    ├── (1,2) ❌ (Blocked)
 │    │    │    ├── (2,1) ❌ (Blocked)

then tries 5 and fails
then tries 6 and fails
then tries 7 and succeeds:

Recursive Calls Tree for t = 7
scss
Copy
Edit
(0,0)
 ├── (1,0)
 │    ├── (2,0)
 │    │    ├── (1,1)
 │    │    │    ├── (0,1)
 │    │    │    │    ├── (0,2)
 │    │    │    │    │    ├── (1,2)  
 │    │    │    │    │    │    ├── (2,2) ✅ (Goal reached!)
 │    │    │    ├── (2,1)
 │    │    │    │    ├── (2,2) ✅ (Goal reached!)
Once t = 7, (2,2) is finally accessible.
DFS finds two possible paths to (2,2), either through (1,2) or (2,1).
Binary search terminates here, as this is the minimum t where DFS succeeds.
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