public partial class Solution {
    private static readonly int[][] MAIdirectionsBFS = new int[][] {
        new int[] {1, 0}, new int[] {-1, 0}, 
        new int[] {0, 1}, new int[] {0, -1}
    };

    public int MaxAreaOfIslandBFS(int[][] grid) {
        int ROWS = grid.Length, COLS = grid[0].Length;
        int area = 0;

        for (int r = 0; r < ROWS; r++) {
            for (int c = 0; c < COLS; c++) {
                if (grid[r][c] == 1) {
                    area = Math.Max(area, MAIBfs(grid, r, c));
                }
            }
        }

        return area;
    }

    private int MAIBfs(int[][] grid, int r, int c) {
        Queue<int[]> q = new Queue<int[]>();
        grid[r][c] = 0;
        q.Enqueue(new int[] { r, c });
        int res = 1;

        while (q.Count > 0) {
            var node = q.Dequeue();
            int row = node[0], col = node[1];

            // search in all four directions and enqueue land if found
            foreach (var dir in MAIdirectionsBFS) {
                int nr = row + dir[0], nc = col + dir[1];
                if (nr >= 0 && nc >= 0 && nr < grid.Length && 
                    nc < grid[0].Length && grid[nr][nc] == 1) {
                    q.Enqueue(new int[] { nr, nc });
                    grid[nr][nc] = 0;
                    res++; // increment area if land is found
                }
            }
        }
        return res;
    }
}
/*

grid = [  
  [0, 1, 1, 0, 1],
  [1, 0, 1, 0, 1],
  [0, 1, 1, 0, 1],
  [0, 1, 0, 0, 1]
]

Start BFS at (0,1):
BFS(0,1)
    - Mark (0,1) as visited (grid[0][1] = 0)
    - res = 1
    - Enqueue neighbors:
        * Add (1,1) (down) -> Water (0) -> Skip
        * Add (-1,1) (up) -> Out of bounds -> Skip
        * Add (0,2) (right) -> Land (1) -> Enqueue
        * Add (0,0) (left) -> Water (0) -> Skip
    - Queue after processing: [(0,2)]

Process (0,2):
BFS(0,2)
    - Dequeue (0,2)
    - Mark (0,2) as visited (grid[0][2] = 0)
    - res = 2
    - Enqueue neighbors:
        * Add (1,2) (down) -> Land (1) -> Enqueue
        * Add (-1,2) (up) -> Out of bounds -> Skip
        * Add (0,3) (right) -> Water (0) -> Skip
        * Add (0,1) (left) -> Already visited -> Skip
    - Queue after processing: [(1,2)]

Process (1,2):
BFS(1,2)
    - Dequeue (1,2)
    - Mark (1,2) as visited (grid[1][2] = 0)
    - res = 3
    - Enqueue neighbors:
        * Add (2,2) (down) -> Land (1) -> Enqueue
        * Add (0,2) (up) -> Already visited -> Skip
        * Add (1,3) (right) -> Water (0) -> Skip
        * Add (1,1) (left) -> Water (0) -> Skip
    - Queue after processing: [(2,2)]

Process (2,2):
BFS(2,2)
    - Dequeue (2,2)
    - Mark (2,2) as visited (grid[2][2] = 0)
    - res = 4
    - Enqueue neighbors:
        * Add (3,2) (down) -> Water (0) -> Skip
        * Add (1,2) (up) -> Already visited -> Skip
        * Add (2,3) (right) -> Water (0) -> Skip
        * Add (2,1) (left) -> Land (1) -> Enqueue
    - Queue after processing: [(2,1)]

Process (2,1):
BFS(2,1)
    - Dequeue (2,1)
    - Mark (2,1) as visited (grid[2][1] = 0)
    - res = 5
    - Enqueue neighbors:
        * Add (3,1) (down) -> Land (1) -> Enqueue
        * Add (1,1) (up) -> Water (0) -> Skip
        * Add (2,2) (right) -> Already visited -> Skip
        * Add (2,0) (left) -> Water (0) -> Skip
    - Queue after processing: [(3,1)]

Process (3,1):
BFS(3,1)
    - Dequeue (3,1)
    - Mark (3,1) as visited (grid[3][1] = 0)
    - res = 6
    - Enqueue neighbors:
        * Add (4,1) (down) -> Out of bounds -> Skip
        * Add (2,1) (up) -> Already visited -> Skip
        * Add (3,2) (right) -> Water (0) -> Skip
        * Add (3,0) (left) -> Water (0) -> Skip
    - Queue after processing: []
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
