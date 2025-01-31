public partial class Solution {
    private static readonly int[][] MAIdirections = new int[][] {
        new int[] {1, 0},  // Move down (increment row)
        new int[] {-1, 0}, // Move up (decrement row)
        new int[] {0, 1},  // Move right (increment column)
        new int[] {0, -1}  // Move left (decrement column)
    };
    
    public int MaxAreaOfIslandDFS(int[][] grid) {
        int ROWS = grid.Length, COLS = grid[0].Length;
        int area = 0;

        for (int r = 0; r < ROWS; r++) {
            for (int c = 0; c < COLS; c++) {
                if (grid[r][c] == 1) {
                    area = Math.Max(area, MAIDfs(grid, r, c));
                }
            }
        }

        return area;
    }

    private int MAIDfs(int[][] grid, int r, int c) {
        if (r < 0 || c < 0 || r >= grid.Length || 
            c >= grid[0].Length || grid[r][c] == 0) {
            return 0; // the recursion stps if water is found
            // if it is not, then the piece of code below is called
            // further activating the recursion (when land is found within an island)
        }

        grid[r][c] = 0;
        int res = 1;
        foreach (var dir in MAIdirections) {
            res += Dfs(grid, r + dir[0], c + dir[1]);
        }
        return res;
    }
}

/*
[
  [0,1,1,0,1],
  [1,0,1,0,1],
  [0,1,1,0,1],
  [0,1,0,0,1]
]

Dfs(0,1)  --> Start of island
 ├── Dfs(1,1) --> Water (grid[1][1] == 0) → Return 0
 ├── Dfs(-1,1) --> Out of bounds → Return 0
 ├── Dfs(0,2)  --> Land (grid[0][2] == 1)
 │    ├── Dfs(1,2) --> Land (grid[1][2] == 1)
 │    │    ├── Dfs(2,2) --> Land (grid[2][2] == 1)
 │    │    │    ├── Dfs(3,2) --> Water (grid[3][2] == 0) → Return 0
 │    │    │    ├── Dfs(1,2) --> Already visited (grid[1][2] == 0) → Return 0
 │    │    │    ├── Dfs(2,3) --> Water (grid[2][3] == 0) → Return 0
 │    │    │    ├── Dfs(2,1) --> Land (grid[2][1] == 1)
 │    │    │         ├── Dfs(3,1) --> Land (grid[3][1] == 1)
 │    │    │         │    ├── Dfs(4,1) --> Out of bounds → Return 0
 │    │    │         │    ├── Dfs(2,1) --> Already visited (grid[2][1] == 0) → Return 0
 │    │    │         │    ├── Dfs(3,2) --> Already visited (grid[3][2] == 0) → Return 0
 │    │    │         │    ├── Dfs(3,0) --> Water (grid[3][0] == 0) → Return 0
 │    │    │         ├── Dfs(1,1) --> Already visited (grid[1][1] == 0) → Return 0
 │    │    │         ├── Dfs(2,2) --> Already visited (grid[2][2] == 0) → Return 0
 │    │    │         ├── Dfs(2,0) --> Water (grid[2][0] == 0) → Return 0
 │    │    ├── Dfs(0,2) --> Already visited (grid[0][2] == 0) → Return 0
 │    │    ├── Dfs(1,3) --> Water (grid[1][3] == 0) → Return 0
 │    │    ├── Dfs(1,1) --> Already visited (grid[1][1] == 0) → Return 0
 │    ├── Dfs(0,3) --> Water (grid[0][3] == 0) → Return 0
 │    ├── Dfs(0,1) --> Already visited (grid[0][1] == 0) → Return 0
 ├── Dfs(0,0) --> Water (grid[0][0] == 0) → Return 0
 */
/*
Once land is found, the algorithm recursively explores its neighbors in all four 
directions (up, down, left, right). Every time a neighboring cell contains land 
(grid[r][c] == 1), a recursive Dfs is triggered to visit it and its neighbors.
*/
/*
Max Area of Island

You are given a matrix grid where grid[i] is either a 0 (representing water) or 1 
(representing land).

An island is defined as a group of 1's connected horizontally or vertically.
You may assume all four edges of the grid are surrounded by water.

The area of an island is defined as the number of cells within the island.

Return the maximum area of an island in grid. If no island exists, return 0.

Example 1:
Input: grid = [
  [0,1,1,0,1],
  [1,0,1,0,1],
  [0,1,1,0,1],
  [0,1,0,0,1]
]
Output: 6
Explanation: 1's cannot be connected diagonally, so the maximum area of the island 
is 6.

Constraints:
1 <= grid.length, grid[i].length <= 50
*/
