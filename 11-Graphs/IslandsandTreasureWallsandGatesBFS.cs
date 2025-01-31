public partial class Solution {
    private int[][] IATdirectionsBFS = new int[][] {
        new int[] { 1, 0 }, new int[] { -1, 0 },
        new int[] { 0, 1 }, new int[] { 0, -1 }
    };
    private int IATBFSINF = int.MaxValue;
    private int IATBFSROWS, IATBFSCOLS;

    private int Bfs(int[][] grid, int r, int c) {
        var q = new Queue<int[]>();
        q.Enqueue(new int[] { r, c });
        bool[][] visit = new bool[IATBFSROWS][];
        for (int i = 0; i < IATBFSROWS; i++) visit[i] = new bool[IATBFSCOLS];
        visit[r][c] = true;
        int steps = 0;

        while (q.Count > 0) {
            int size = q.Count;
            for (int i = 0; i < size; i++) {
                var curr = q.Dequeue();
                int row = curr[0], col = curr[1];
                if (grid[row][col] == 0) return steps;
                foreach (var dir in IATdirectionsBFS) {
                    int nr = row + dir[0], nc = col + dir[1];
                    if (nr >= 0 && nr < IATBFSROWS && nc >= 0 && nc < IATBFSCOLS && 
                        !visit[nr][nc] && grid[nr][nc] != -1) {
                        visit[nr][nc] = true;
                        q.Enqueue(new int[] { nr, nc });
                    }
                }
            }
            steps++;
        }
        return IATBFSINF;
    }

    public void islandsAndTreasureBFS(int[][] grid) {
        IATBFSROWS = grid.Length;
        IATBFSCOLS = grid[0].Length;

        for (int r = 0; r < IATBFSROWS; r++) {
            for (int c = 0; c < IATBFSCOLS; c++) {
                if (grid[r][c] == IATBFSINF) {
                    grid[r][c] = Bfs(grid, r, c);
                }
            }
        }
    }
}
/*
Bfs(grid, 0, 0) --> Queue: [(0, 0)] (steps = 0)
|
|-- Dequeue (0, 0)
|   |
|   |-- Direction: Down (r=1, c=0) --> Valid, Enqueue (1, 0)
|   |-- Direction: Up (r=-1, c=0) --> Out of bounds, Skip
|   |-- Direction: Right (r=0, c=1) --> Blocked (-1), Skip
|   |-- Direction: Left (r=0, c=-1) --> Out of bounds, Skip
|
|-- Queue: [(1, 0)] (steps = 1)
|
|-- Dequeue (1, 0)
|   |
|   |-- Direction: Down (r=2, c=0) --> Valid, Enqueue (2, 0)
|   |-- Direction: Up (r=0, c=0) --> Already visited, Skip
|   |-- Direction: Right (r=1, c=1) --> Valid, Enqueue (1, 1)
|   |-- Direction: Left (r=1, c=-1) --> Out of bounds, Skip
|
|-- Queue: [(2, 0), (1, 1)] (steps = 2)
|
|-- Dequeue (2, 0)
|   |
|   |-- Direction: Down (r=3, c=0) --> Valid, Enqueue (3, 0)
|   |-- Direction: Up (r=1, c=0) --> Already visited, Skip
|   |-- Direction: Right (r=2, c=1) --> Blocked (-1), Skip
|   |-- Direction: Left (r=2, c=-1) --> Out of bounds, Skip
|
|-- Queue: [(1, 1), (3, 0)] (steps = 3)
|
|-- Dequeue (1, 1)
|   |
|   |-- Direction: Down (r=2, c=1) --> Blocked (-1), Skip
|   |-- Direction: Up (r=0, c=1) --> Blocked (-1), Skip
|   |-- Direction: Right (r=1, c=2) --> Valid, Enqueue (1, 2)
|   |-- Direction: Left (r=1, c=0) --> Already visited, Skip
|
|-- Queue: [(3, 0), (1, 2)] (steps = 4)
|
|-- Dequeue (3, 0)
|   |
|   |-- Direction: Down (r=4, c=0) --> Out of bounds, Skip
|   |-- Direction: Up (r=2, c=0) --> Already visited, Skip
|   |-- Direction: Right (r=3, c=1) --> Blocked (-1), Skip
|   |-- Direction: Left (r=3, c=-1) --> Out of bounds, Skip
|
|-- Queue: [(1, 2)] (steps = 5)
|
|-- Dequeue (1, 2)
|   |
|   |-- Direction: Down (r=2, c=2) --> Valid, Enqueue (2, 2)
|   |-- Direction: Up (r=0, c=2) --> Already visited, Skip
|   |-- Direction: Right (r=1, c=3) --> Blocked (-1), Skip
|   |-- Direction: Left (r=1, c=1) --> Already visited, Skip
|
|-- Queue: [(2, 2)] (steps = 6)
|
|-- Dequeue (2, 2)
|   |
|   |-- Direction: Down (r=3, c=2) --> Valid, Enqueue (3, 2)
|   |-- Direction: Up (r=1, c=2) --> Already visited, Skip
|   |-- Direction: Right (r=2, c=3) --> Blocked (-1), Skip
|   |-- Direction: Left (r=2, c=1) --> Blocked (-1), Skip
|
|-- Queue: [(3, 2)] (steps = 7)
|
|-- Dequeue (3, 2)
|   |
|   |-- Direction: Down (r=4, c=2) --> Out of bounds, Skip
|   |-- Direction: Up (r=2, c=2) --> Already visited, Skip
|   |-- Direction: Right (r=3, c=3) --> Valid, Enqueue (3, 3)
|   |-- Direction: Left (r=3, c=1) --> Blocked (-1), Skip
|
|-- Queue: [(3, 3)] (steps = 8)
|
|-- Dequeue (3, 3) --> Found treasure (0)
|
|-- Return 4
*/
/*
(0,3) does get processed in a later iteration, but it gets assigned its shortest 
distance (1) immediately since it's adjacent to (0,2) (a treasure).
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