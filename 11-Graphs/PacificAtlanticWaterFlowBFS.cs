public partial class Solution {
    private int[][] PAWFBFSdirections = new int[][] { 
        new int[] { 1, 0 }, new int[] { -1, 0 }, 
        new int[] { 0, 1 }, new int[] { 0, -1 } 
    };
    public List<List<int>> PacificAtlanticBFS(int[][] heights) {
        int ROWS = heights.Length, COLS = heights[0].Length;
        bool[,] pac = new bool[ROWS, COLS];
        bool[,] atl = new bool[ROWS, COLS];

        Queue<int[]> pacQueue = new Queue<int[]>();
        Queue<int[]> atlQueue = new Queue<int[]>();

        for (int c = 0; c < COLS; c++) {
            pacQueue.Enqueue(new int[] { 0, c });
            atlQueue.Enqueue(new int[] { ROWS - 1, c });
        }
        for (int r = 0; r < ROWS; r++) {
            pacQueue.Enqueue(new int[] { r, 0 });
            atlQueue.Enqueue(new int[] { r, COLS - 1 });
        }

        PAWFBfs(pacQueue, pac, heights);
        PAWFBfs(atlQueue, atl, heights);

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

    private void PAWFBfs(Queue<int[]> q, bool[,] ocean, int[][] heights) {
        while (q.Count > 0) {
            int[] cur = q.Dequeue();
            int r = cur[0], c = cur[1];
            ocean[r, c] = true;
            foreach (var dir in PAWFBFSdirections) {
                int nr = r + dir[0], nc = c + dir[1];
                // iF next row is within bounds, and if next column is within bounds
                // and if the next cell is marked as false (not been visited)
                // and 
                // the condition heights[nr][nc] >= heights[r][c] is correct for this problem. 
                // Instead of water "falling" from a cell to its neighbors, 
                // imagine tracing the path water could have taken to get there.
                if (nr >= 0 && nr < heights.Length && nc >= 0 && 
                    nc < heights[0].Length && !ocean[nr, nc] && 
                    heights[nr][nc] >= heights[r][c]) {
                    q.Enqueue(new int[] { nr, nc });
                }
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