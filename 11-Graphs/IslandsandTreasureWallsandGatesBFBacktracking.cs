public partial class Solution {
    private int[][] IATdirectionsBFB = new int[][] {
        new int[] {1, 0}, new int[] {-1, 0}, 
        new int[] {0, 1}, new int[] {0, -1}
    };
    private int IATBFBINF = 2147483647;
    private bool[,] IATBFBvisit;
    private int IATBFBROWS, IATBFBCOLS;

    private int Dfs(int[][] grid, int r, int c) {
        if (r < 0 || c < 0 || r >= IATBFBROWS || 
            c >= IATBFBCOLS || grid[r][c] == -1 || IATBFBvisit[r, c]) {
            return IATBFBINF;
        }
        if (grid[r][c] == 0) {
            return 0;
        }
        IATBFBvisit[r, c] = true;
        int res = IATBFBINF;
        foreach (var dir in IATdirectionsBFB) {
            int cur = Dfs(grid, r + dir[0], c + dir[1]);
            if (cur != IATBFBINF) {
                res = Math.Min(res, 1 + cur);
            }
        }
        IATBFBvisit[r, c] = false;
        return res;
    }

    public void islandsAndTreasureBruteForce(int[][] grid) {
        IATBFBROWS = grid.Length;
        IATBFBCOLS = grid[0].Length;
        IATBFBvisit = new bool[IATBFBROWS, IATBFBCOLS];

        for (int r = 0; r < IATBFBROWS; r++) {
            for (int c = 0; c < IATBFBCOLS; c++) {
                if (grid[r][c] == IATBFBINF) {
                    grid[r][c] = Dfs(grid, r, c);
                }
            }
        }
    }
}
/*
Output: [
  [3,-1,0,1],
  [2,2,1,-1],
  [1,-1,2,-1],
  [0,-1,3,4]
]
Dfs(grid, 0, 0)
|
|-- Direction: Down (r=1, c=0)  --> Dfs(grid, 1, 0)
|   |
|   |-- Direction: Down (r=2, c=0)  --> Dfs(grid, 2, 0)
|   |   |
|   |   |-- Direction: Down (r=3, c=0) --> Dfs(grid, 3, 0) [0] --> Return 0
|   |   |-- Direction: Up (r=1, c=0) --> Already computed, Return 2
|   |   |-- Direction: Right (r=2, c=1) --> Blocked (-1), Return INF
|   |   |-- Direction: Left (r=2, c=-1) --> Out of bounds, Return INF
|   |
|   |-- Return 1
|   |
|   |-- Direction: Up (r=0, c=0) --> Already computed, Return 3
|   |-- Direction: Right (r=1, c=1) --> Blocked (-1), Return INF
|   |-- Direction: Left (r=1, c=-1) --> Out of bounds, Return INF
|   |
|   --> Return 2
|
|-- Direction: Up (r=-1, c=0) --> Out of bounds, Return INF
|-- Direction: Right (r=0, c=1) --> Blocked (-1), Return INF
|-- Direction: Left (r=0, c=-1) --> Out of bounds, Return INF
|
|-- Return 3

Dfs(grid, 0, 1)
|
|-- Direction: Down (r=1, c=1) --> Blocked (-1), Return INF
|-- Direction: Up (r=-1, c=1) --> Out of bounds, Return INF
|-- Direction: Right (r=0, c=2) --> Dfs(grid, 0, 2) [0] --> Return 0
|-- Direction: Left (r=0, c=0) --> Already computed, Return 3
|
|-- Return 1

Dfs(grid, 0, 2) [Already a 0] --> Return 0

Dfs(grid, 0, 3)
|
|-- Direction: Down (r=1, c=3) --> Blocked (-1), Return INF
|-- Direction: Up (r=-1, c=3) --> Out of bounds, Return INF
|-- Direction: Right (r=0, c=4) --> Out of bounds, Return INF
|-- Direction: Left (r=0, c=2) --> Already computed, Return 0
|
|-- Return 1

Dfs(grid, 1, 0) [Already computed] --> Return 2

Dfs(grid, 1, 1) [Blocked by -1] --> Return INF

Dfs(grid, 1, 2)
|
|-- Direction: Down (r=2, c=2) --> Dfs(grid, 2, 2)
|   |
|   |-- Direction: Down (r=3, c=2) --> Dfs(grid, 3, 2)
|   |   |
|   |   |-- Direction: Down (r=4, c=2) --> Out of bounds, Return INF
|   |   |-- Direction: Up (r=2, c=2) --> Already computed, Return 2
|   |   |-- Direction: Right (r=3, c=3) --> Dfs(grid, 3, 3) [0] --> Return 0
|   |   |-- Direction: Left (r=3, c=1) --> Blocked (-1), Return INF
|   |
|   |-- Return 1
|   |
|   |-- Direction: Up (r=1, c=2) --> Already computed, Return 1
|   |-- Direction: Right (r=2, c=3) --> Blocked (-1), Return INF
|   |-- Direction: Left (r=2, c=1) --> Blocked (-1), Return INF
|
|-- Return 2

Dfs(grid, 1, 3) [Blocked by -1] --> Return INF

Dfs(grid, 2, 0) [Already computed] --> Return 1
*/

/*
Islands and Treasure / Walls and Gates

You are given a 
m×n 2D grid initialized with these three possible values:

-1  - A water cell that can not be traversed.
0   - A treasure chest.
INF - A land cell that can be traversed. We use the integer 2^31 - 1 
= 2147483647 to represent INF.

Fill each land cell with the distance to its nearest treasure chest. 
If a land cell cannot reach a treasure chest than the value should remain INF.

Assume the grid can only be traversed up, down, left, or right.

Modify the grid in-place.

Example 1:
Input: [
  [2147483647,-1,0,2147483647],
  [2147483647,2147483647,2147483647,-1],
  [2147483647,-1,2147483647,-1],
  [0,-1,2147483647,2147483647]
  ]
Output: [
  [3,-1,0,1],
  [2,2,1,-1],
  [1,-1,2,-1],
  [0,-1,3,4]
]
Example 2:
Input: [
  [0,-1],
  [2147483647,2147483647]
]
Output: [
  [0,-1],
  [1,2]
]

Constraints:
m == grid.length
n == grid[i].length
1 <= m, n <= 100
grid[i][j] is one of {-1, 0, 2147483647}
*/