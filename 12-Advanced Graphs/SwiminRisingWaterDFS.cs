public partial class Solution {
    public int DFSSwimInWater(int[][] grid) {
        int n = grid.Length;
        
        // Create a 'visit' matrix to track visited cells during DFS.
        bool[][] visit = new bool[n][];
        for (int i = 0; i < n; i++) {
            visit[i] = new bool[n];
        }

        // Determine the minimum and maximum heights in the grid.
        int minH = grid[0][0], maxH = grid[0][0];
        for (int row = 0; row < n; row++) {
            for (int col = 0; col < n; col++) {
                maxH = Math.Max(maxH, grid[row][col]); // Track highest water level.
                minH = Math.Min(minH, grid[row][col]); // Track lowest water level.
            }
        }

        // Try different threshold values (water levels) from minH to maxH.
        for (int t = minH; t < maxH; t++) {
            // If a path exists with water level <= t, return t.
            if (SRWDFSdfs(grid, visit, 0, 0, t)) {
                return t;
            }
            
            // Reset 'visit' array for the next threshold attempt.
            for (int r = 0; r < n; r++) {
                Array.Fill(visit[r], false);
            }
        }
        
        // If no threshold works before maxH, return maxH as the worst-case scenario.
        return maxH;
    }

    private bool SRWDFSdfs(int[][] grid, bool[][] visit, int r, int c, int t) {
        // Out of bounds check, already visited cell, or cell with a height greater than threshold t.
        if (r < 0 || c < 0 || r >= grid.Length || 
            c >= grid.Length || visit[r][c] || grid[r][c] > t) {
            return false;
        }

        // If we reached the bottom-right corner, return true (valid path found).
        if (r == grid.Length - 1 && c == grid.Length - 1) {
            return true;
        }

        // Mark current cell as visited.
        visit[r][c] = true;

        // Explore all four directions (down, up, right, left).
        return SRWDFSdfs(grid, visit, r + 1, c, t) || 
               SRWDFSdfs(grid, visit, r - 1, c, t) || 
               SRWDFSdfs(grid, visit, r, c + 1, t) || 
               SRWDFSdfs(grid, visit, r, c - 1, t);
    }
}

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