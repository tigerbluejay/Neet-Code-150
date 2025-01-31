public partial class Solution {
    private static readonly int[][] NOIdirections = new int[][] {
        new int[] {1, 0}, new int[] {-1, 0}, 
        new int[] {0, 1}, new int[] {0, -1}
    };

    public int NumIslandsBFS(char[][] grid) {
        int ROWS = grid.Length, COLS = grid[0].Length;
        int islands = 0;

        for (int r = 0; r < ROWS; r++) {
            for (int c = 0; c < COLS; c++) {
                if (grid[r][c] == '1') {
                    Bfs(grid, r, c);
                    islands++;
                }
            }
        }

        return islands;
    }

    private void Bfs(char[][] grid, int r, int c) {
        Queue<int[]> q = new Queue<int[]>();
        grid[r][c] = '0';
        q.Enqueue(new int[] { r, c });

        while (q.Count > 0) {
            var node = q.Dequeue();
            int row = node[0], col = node[1];

            foreach (var dir in NOIdirections) {
                int nr = row + dir[0], nc = col + dir[1];
                if (nr >= 0 && nc >= 0 && nr < grid.Length && 
                    nc < grid[0].Length && grid[nr][nc] == '1') {
                    q.Enqueue(new int[] { nr, nc });
                    grid[nr][nc] = '0'; // mark it as visited on original grid
                }
            }
        }
    }
}
/*
Initial State:
q: [(0, 1)]  --> Start BFS from the first '1'

Step 1: Dequeue (0, 1)
Dequeue: (row, col) = (0, 1)
Queue before processing: []
Processing neighbors of (0, 1):
  Neighbor 1: (nr, nc) = (1, 1) --> Enqueued
  Neighbor 2: (nr, nc) = (-1, 1) --> Out of bounds
  Neighbor 3: (nr, nc) = (0, 2) --> Enqueued
  Neighbor 4: (nr, nc) = (0, 0) --> Value = '0'
Queue after processing: [(1, 1), (0, 2)]

Step 2: Dequeue (1, 1)
Dequeue: (row, col) = (1, 1)
Queue before processing: [(0, 2)]
Processing neighbors of (1, 1):
  Neighbor 1: (nr, nc) = (2, 1) --> Enqueued
  Neighbor 2: (nr, nc) = (0, 1) --> Already visited
  Neighbor 3: (nr, nc) = (1, 2) --> Value = '0'
  Neighbor 4: (nr, nc) = (1, 0) --> Value = '0'
Queue after processing: [(0, 2), (2, 1)]

Step 3: Dequeue (0, 2)
Dequeue: (row, col) = (0, 2)
Queue before processing: [(2, 1)]
Processing neighbors of (0, 2):
  Neighbor 1: (nr, nc) = (1, 2) --> Value = '0'
  Neighbor 2: (nr, nc) = (-1, 2) --> Out of bounds
  Neighbor 3: (nr, nc) = (0, 3) --> Enqueued
  Neighbor 4: (nr, nc) = (0, 1) --> Already visited
Queue after processing: [(2, 1), (0, 3)]

Step 4: Dequeue (2, 1)
Dequeue: (row, col) = (2, 1)
Queue before processing: [(0, 3)]
Processing neighbors of (2, 1):
  Neighbor 1: (nr, nc) = (3, 1) --> Out of bounds
  Neighbor 2: (nr, nc) = (1, 1) --> Already visited
  Neighbor 3: (nr, nc) = (2, 2) --> Value = '0'
  Neighbor 4: (nr, nc) = (2, 0) --> Enqueued
Queue after processing: [(0, 3), (2, 0)]

Step 5: Dequeue (0, 3)
Dequeue: (row, col) = (0, 3)
Queue before processing: [(2, 0)]
Processing neighbors of (0, 3):
  Neighbor 1: (nr, nc) = (1, 3) --> Enqueued
  Neighbor 2: (nr, nc) = (-1, 3) --> Out of bounds
  Neighbor 3: (nr, nc) = (0, 4) --> Value = '0'
  Neighbor 4: (nr, nc) = (0, 2) --> Already visited
Queue after processing: [(2, 0), (1, 3)]

Step 6: Dequeue (2, 0)
Dequeue: (row, col) = (2, 0)
Queue before processing: [(1, 3)]
Processing neighbors of (2, 0):
  Neighbor 1: (nr, nc) = (3, 0) --> Out of bounds
  Neighbor 2: (nr, nc) = (1, 0) --> Value = '0'
  Neighbor 3: (nr, nc) = (2, 1) --> Already visited
  Neighbor 4: (nr, nc) = (2, -1) --> Out of bounds
Queue after processing: [(1, 3)]

Step 7: Dequeue (1, 3)
Dequeue: (row, col) = (1, 3)
Queue before processing: []
Processing neighbors of (1, 3):
  Neighbor 1: (nr, nc) = (2, 3) --> Value = '0'
  Neighbor 2: (nr, nc) = (0, 3) --> Already visited
  Neighbor 3: (nr, nc) = (1, 4) --> Value = '0'
  Neighbor 4: (nr, nc) = (1, 2) --> Value = '0'
Queue after processing: []

Final State:
Queue is empty. BFS for this island is complete.
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