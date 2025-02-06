public partial class Solution {
    private int[][] PAWFDFSdirections = new int[][] { 
        new int[] { 1, 0 }, new int[] { -1, 0 }, 
        new int[] { 0, 1 }, new int[] { 0, -1 } 
    };
    public List<List<int>> PacificAtlantic(int[][] heights) {
        int ROWS = heights.Length, COLS = heights[0].Length;
        bool[,] pac = new bool[ROWS, COLS]; //  A boolean matrix to track which cells can flow into the Pacific Ocean.
        bool[,] atl = new bool[ROWS, COLS]; //  A boolean matrix to track which cells can flow into the Atlantic Ocean.

        // Runs DFS from the first row (Pacific Ocean) downward.
        // Runs DFS from the last row (Atlantic Ocean) upward.
        for (int c = 0; c < COLS; c++) {
            PAWFDFSDfs(0, c, pac, heights);
            PAWFDFSDfs(ROWS - 1, c, atl, heights);
        }

        // Runs DFS from the first column (Pacific Ocean) rightward.
        // Runs DFS from the last column (Atlantic Ocean) leftward.
        for (int r = 0; r < ROWS; r++) {
            PAWFDFSDfs(r, 0, pac, heights);
            PAWFDFSDfs(r, COLS - 1, atl, heights);
        }

        // If a cell is marked true in both pac and atl, it can reach both oceans.
        // Those cells are added to the result list.
        List<List<int>> res = new List<List<int>>();
        for (int r = 0; r < ROWS; r++) {
            for (int c = 0; c < COLS; c++) {
                if (pac[r, c] && atl[r, c]) {
                    res.Add(new List<int> { r, c });
                }
            }
        }
        return res;
    }

/*
The DFS function (PAWFDFSDfs) operates on each individual cell and explores in all four directions 
(up, down, left, right) recursively.

When PAWFDFSDfs(r, c, ocean, heights) is called:
  It marks the current cell as reachable (ocean[r, c] = true).
  It then iterates over the four possible directions (stored in PAWFDFSdirections).
  For each direction (nr, nc), it checks if the next cell:
    Is within bounds.
    Has not been visited (ocean[nr, nc] == false).
    Has a height greater than or equal to the current cell (to allow water to "flow" uphill).
    If the conditions are met, recursively calls DFS on the next cell.
*/
      private void PAWFDFSDfs(int r, int c, bool[,] ocean, int[][] heights) {
        ocean[r, c] = true;
        foreach (var dir in PAWFDFSdirections) {
            int nr = r + dir[0], nc = c + dir[1];
            if (nr >= 0 && nr < heights.Length && nc >= 0 && 
                nc < heights[0].Length && !ocean[nr, nc] && 
                heights[nr][nc] >= heights[r][c]) {
                PAWFDFSDfs(nr, nc, ocean, heights);
            }
        }
    }
}

/*
Pacific Atlantic Water Flow

You are given a rectangular island heights where heights[r][c] represents the height above sea level of the cell at 
coordinate (r, c).

The islands borders the Pacific Ocean from the top and left sides, 
and borders the Atlantic Ocean from the bottom and right sides.

Water can flow in four directions (up, down, left, or right) from a cell to a neighboring cell with height equal or lower. 
Water can also flow into the ocean from cells adjacent to the ocean.

Find all cells where water can flow from that cell to both the Pacific and Atlantic oceans. 
Return it as a 2D list where each element is a list [r, c] representing the row and column of the cell. 
You may return the answer in any order.

Example 1:

Input: heights = [
  [4,2,7,3,4],
  [7,4,6,4,7],
  [6,3,5,3,6]
]Output: [[0,2],[0,4],[1,0],[1,1],[1,2],[1,3],[1,4],[2,0]]

Example 2:
Input: heights = [[1],[1]]
Output: [[0,0],[0,1]]

Constraints:
1 <= heights.length, heights[r].length <= 100
0 <= heights[r][c] <= 1000
*/