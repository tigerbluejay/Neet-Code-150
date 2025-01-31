public partial class Solution {
    private static readonly int[][] NOIdirectionsDFS = new int[][] {
        new int[] {1, 0},  // Move down (increment row)
        new int[] {-1, 0}, // Move up (decrement row)
        new int[] {0, 1},  // Move right (increment column)
        new int[] {0, -1}  // Move left (decrement column)
    };
    
    public int NumIslandsDFS(char[][] grid) {
        int ROWS = grid.Length, COLS = grid[0].Length;
        int islands = 0;

        for (int r = 0; r < ROWS; r++) {
            for (int c = 0; c < COLS; c++) {
                if (grid[r][c] == '1') {
                    Dfs(grid, r, c);
                    islands++;
                }
            }
        }

        return islands;
    }

    // nodes keep being visited only if there is land, if there is water, is out of
    // bounds the Dfs stops and continues to explore down, up, right, left for the
    // current spot in that order.
    private void Dfs(char[][] grid, int r, int c) {
        if (r < 0 || c < 0 || r >= grid.Length || 
            c >= grid[0].Length || grid[r][c] == '0') {
            return;
        }

        grid[r][c] = '0';
        // this would be the same as doing four separate Dfs calls
        // with different dir elements. down, up , right, left
        foreach (var dir in NOIdirectionsDFS) {
            Dfs(grid, r + dir[0], c + dir[1]);
        }
    }
}

/*
Dfs(0, 1)  --> Start at the first '1'
    Dfs(1, 1)  --> Move Down
        Dfs(2, 1)  --> Move Down
            Dfs(3, 1)  --> Move Down (Out of bounds, return)
            Dfs(1, 1)  --> Move Up (Already visited, return)
            Dfs(2, 2)  --> Move Right (Value = '0', return)
            Dfs(2, 0)  --> Move Left
                Dfs(3, 0)  --> Move Down (Out of bounds, return)
                Dfs(1, 0)  --> Move Up (Value = '0', return)
                Dfs(2, 1)  --> Move Right (Already visited, return)
                Dfs(2, -1) --> Move Left (Out of bounds, return)
        Dfs(0, 1)  --> Move Up (Already visited, return)
        Dfs(1, 2)  --> Move Right (Value = '0', return)
        Dfs(1, 0)  --> Move Left (Value = '0', return)
    Dfs(-1, 1)  --> Move Up (Out of bounds, return)
    Dfs(0, 2)  --> Move Right
        Dfs(1, 2)  --> Move Down (Value = '0', return)
        Dfs(-1, 2)  --> Move Up (Out of bounds, return)
        Dfs(0, 3)  --> Move Right
            Dfs(1, 3)  --> Move Down
                Dfs(2, 3)  --> Move Down (Value = '0', return)
                Dfs(0, 3)  --> Move Up (Already visited, return)
                Dfs(1, 4)  --> Move Right (Value = '0', return)
                Dfs(1, 2)  --> Move Left (Value = '0', return)
            Dfs(-1, 3)  --> Move Up (Out of bounds, return)
            Dfs(0, 4)  --> Move Right (Value = '0', return)
            Dfs(0, 2)  --> Move Left (Already visited, return)
        Dfs(0, 1)  --> Move Left (Already visited, return)
    Dfs(0, 0)  --> Move Left (Value = '0', return)
*/

/*
Number of Islands

Given a 2D grid grid where '1' represents land and '0' represents water, 
count and return the number of islands.

An island is formed by connecting adjacent lands horizontally or vertically 
and is surrounded by water. You may assume water is surrounding the grid 
(i.e., all the edges are water).

Example 1:
Input: grid = [
    ["0","1","1","1","0"],
    ["0","1","0","1","0"],
    ["1","1","0","0","0"],
    ["0","0","0","0","0"]
  ]
Output: 1

Example 2:
Input: grid = [
    ["1","1","0","0","1"],
    ["1","1","0","0","1"],
    ["0","0","1","0","0"],
    ["0","0","0","1","1"]
  ]
Output: 4

Constraints:
1 <= grid.length, grid[i].length <= 100
grid[i][j] is '0' or '1'.
*/