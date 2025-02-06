public partial class Solution {
    int PAWFROWS, PAWFCOLS;
    bool pacific, atlantic;
    int[][] PAWFdirections = new int[][] {
        new int[] {1, 0}, new int[] {-1, 0}, new int[] {0, 1}, new int[] {0, -1}
    };

    public List<List<int>> PacificAtlanticBFBacktracking(int[][] heights) {
        PAWFROWS = heights.Length;
        PAWFCOLS = heights[0].Length;
        List<List<int>> res = new List<List<int>>();

        for (int r = 0; r < PAWFROWS; r++) {
            for (int c = 0; c < PAWFCOLS; c++) {
                pacific = false;
                atlantic = false;
                PAWFDfs(heights, r, c, int.MaxValue);
                if (pacific && atlantic) {
                    res.Add(new List<int>{r, c});
                }
            }
        }
        return res;
    }

    private void PAWFDfs(int[][] heights, int r, int c, int prevVal) {
        if (r < 0 || c < 0) {
            pacific = true;
            return;
        }
        if (r >= PAWFROWS || c >= PAWFCOLS) {
            atlantic = true;
            return;
        }
        if (heights[r][c] > prevVal) {
            return;
        }

        int tmp = heights[r][c];
        heights[r][c] = int.MaxValue;
        foreach (var dir in PAWFdirections) {
            PAWFDfs(heights, r + dir[0], c + dir[1], tmp);
            if (pacific && atlantic) {
                break;
            }
        }
        heights[r][c] = tmp;
    }
}
/*
How It Works:
Iterate through every cell in the grid.
For each cell (r, c), start a DFS traversal to check whether water can flow to:
    The Pacific Ocean (top/left border).
    The Atlantic Ocean (bottom/right border).
The DFS follows height constraints: water can only flow downhill or at the same height.
    If the DFS reaches both oceans, store (r, c) in the result.
Return the list of all such cells.

Key Mechanisms:
Recursive DFS moves in four directions (up, down, left, right).
    Uses a temporary modification of the grid (int.MaxValue) to track visited cells.
    If water escapes the grid from the top/left → Pacific = true,
    If water escapes from the bottom/right → Atlantic = true.
If both Pacific and Atlantic are true, store the cell.
*/
// For this input
// [9, 9, 3]
// [8, 9, 4]
// [7, 6, 5]
// Let's examine the case of cell (2,1) (6)
/*
DFS Process for Cell (2, 1) [Height: 6]:

- Start DFS at (2, 1) [Height: 6]
    ├── Downward to (3, 1): Out of bounds → **Atlantic = true**
    ├── Upward to (1, 1) [Height: 9]: 9 > 6 → No DFS
    ├── Right to (2, 2) [Height: 5]: 5 < 6 → DFS continues
        └── DFS at (2, 2) [Height: 5]
            ├── Downward to (3, 2): Out of bounds → **Atlantic = true**
            ├── Upward to (1, 2) [Height: 4]: 4 < 5 → DFS continues
                └── DFS at (1, 2) [Height: 4]
                    ├── Downward to (2, 2) [Height: 5]: 5 > 4 → No DFS
                    ├── Upward to (0, 2) [Height: 3]: 3 < 4 → DFS continues
                        └── DFS at (0, 2) [Height: 3]
                            ├── Downward to (1, 2) [Height: 4]: 4 > 3 → No DFS
                            ├── Upward to (-1, 2): Out of bounds → **Pacific = true**
                            ├── Right to (0, 3): Out of bounds → No further DFS
                            └── Left to (0, 1) [Height: 9]: 9 > 3 → No DFS
                        └── **Pacific = true** for (0, 2)
                    └── **Pacific = true** for (1, 2)
                └── **Pacific = true** for (2, 2)
    └── **Atlantic = true** for (2, 1)

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