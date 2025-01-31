public partial class Solution {
      /*
      The multi-source BFS version of the algorithm starts by enqueuing all the 
      treasure cells (0), effectively treating them as sources of exploration. 
      The BFS spreads out simultaneously from all treasure cells, assigning the 
      shortest distance to each reachable cell.
      */  
      public void islandsAndTreasureMultiSourceBFS(int[][] grid) {
        Queue<int[]> q = new Queue<int[]>();
        int m = grid.Length;
        int n = grid[0].Length;
        for (int i = 0; i < m; i++) {
            for (int j = 0; j < n; j++) {
                if (grid[i][j] == 0) q.Enqueue(new int[] { i, j });
            }
        }

        if (q.Count == 0) return;
        
        int[][] dirs = { 
            new int[] { -1, 0 }, new int[] { 0, -1 }, 
            new int[] { 1, 0 }, new int[] { 0, 1 } 
        };
        while (q.Count > 0) {
            int[] cur = q.Dequeue();
            int row = cur[0];
            int col = cur[1];
            foreach (int[] dir in dirs) {
                int r = row + dir[0];
                int c = col + dir[1];
                if (r >= m || c >= n || r < 0 ||
                    c < 0 || grid[r][c] != int.MaxValue) {
                    continue;   
                }
                q.Enqueue(new int[] { r, c });

                grid[r][c] = grid[row][col] + 1;
            }
        }
    }
}

/*
The starting queue is initialized with all treasure cells (0):
Initial Queue: [(0, 2), (3, 0)]

Step 1: Processing (0, 2)
Process (0, 2) --> Current Distance: 0
|
|-- Direction: Up    (r=-1, c=2) --> Out of bounds, Skip
|-- Direction: Down  (r=1, c=2) --> Enqueue (1, 2), Set grid[1][2] = 1
|-- Direction: Left  (r=0, c=1) --> Blocked (-1), Skip
|-- Direction: Right (r=0, c=3) --> Enqueue (0, 3), Set grid[0][3] = 1
|
Queue After Processing (0, 2): [(3, 0), (1, 2), (0, 3)]

Step 2: Processing (3, 0)
Process (3, 0) --> Current Distance: 0
|
|-- Direction: Up    (r=2, c=0) --> Enqueue (2, 0), Set grid[2][0] = 1
|-- Direction: Down  (r=4, c=0) --> Out of bounds, Skip
|-- Direction: Left  (r=3, c=-1) --> Out of bounds, Skip
|-- Direction: Right (r=3, c=1) --> Blocked (-1), Skip
|
Queue After Processing (3, 0): [(1, 2), (0, 3), (2, 0)]

Step 3: Processing (1, 2)
Process (1, 2) --> Current Distance: 1
|
|-- Direction: Up    (r=0, c=2) --> Already 0, Skip
|-- Direction: Down  (r=2, c=2) --> Enqueue (2, 2), Set grid[2][2] = 2
|-- Direction: Left  (r=1, c=1) --> Enqueue (1, 1), Set grid[1][1] = 2
|-- Direction: Right (r=1, c=3) --> Blocked (-1), Skip
|
Queue After Processing (1, 2): [(0, 3), (2, 0), (2, 2), (1, 1)]

Step 4: Processing (0, 3)
Process (0, 3) --> Current Distance: 1
|
|-- Direction: Up    (r=-1, c=3) --> Out of bounds, Skip
|-- Direction: Down  (r=1, c=3) --> Blocked (-1), Skip
|-- Direction: Left  (r=0, c=2) --> Already 0, Skip
|-- Direction: Right (r=0, c=4) --> Out of bounds, Skip
|
Queue After Processing (0, 3): [(2, 0), (2, 2), (1, 1)]

Step 5: Processing (2, 0)
Process (2, 0) --> Current Distance: 1
|
|-- Direction: Up    (r=1, c=0) --> Enqueue (1, 0), Set grid[1][0] = 2
|-- Direction: Down  (r=3, c=0) --> Already 0, Skip
|-- Direction: Left  (r=2, c=-1) --> Out of bounds, Skip
|-- Direction: Right (r=2, c=1) --> Blocked (-1), Skip
|
Queue After Processing (2, 0): [(2, 2), (1, 1), (1, 0)]

Step 6: Processing (2, 2)

Process (2, 2) --> Current Distance: 2
|
|-- Direction: Up    (r=1, c=2) --> Already 1, Skip
|-- Direction: Down  (r=3, c=2) --> Enqueue (3, 2), Set grid[3][2] = 3
|-- Direction: Left  (r=2, c=1) --> Blocked (-1), Skip
|-- Direction: Right (r=2, c=3) --> Blocked (-1), Skip
|
Queue After Processing (2, 2): [(1, 1), (1, 0), (3, 2)]

Step 7: Processing (1, 1)
Process (1, 1) --> Current Distance: 2
|
|-- Direction: Up    (r=0, c=1) --> Blocked (-1), Skip
|-- Direction: Down  (r=2, c=1) --> Blocked (-1), Skip
|-- Direction: Left  (r=1, c=0) --> Already 2, Skip
|-- Direction: Right (r=1, c=2) --> Already 1, Skip
|
Queue After Processing (1, 1): [(1, 0), (3, 2)]

Step 8: Processing (1, 0)
Process (1, 0) --> Current Distance: 2
|
|-- Direction: Up    (r=0, c=0) --> Enqueue (0, 0), Set grid[0][0] = 3
|-- Direction: Down  (r=2, c=0) --> Already 1, Skip
|-- Direction: Left  (r=1, c=-1) --> Out of bounds, Skip
|-- Direction: Right (r=1, c=1) --> Already 2, Skip
|
Queue After Processing (1, 0): [(3, 2), (0, 0)]

Step 9: Processing (3, 2)
Process (3, 2) --> Current Distance: 3
|
|-- Direction: Up    (r=2, c=2) --> Already 2, Skip
|-- Direction: Down  (r=4, c=2) --> Out of bounds, Skip
|-- Direction: Left  (r=3, c=1) --> Blocked (-1), Skip
|-- Direction: Right (r=3, c=3) --> Enqueue (3, 3), Set grid[3][3] = 4
|
Queue After Processing (3, 2): [(0, 0), (3, 3)]

Step 10: Processing (0, 0)
Process (0, 0) --> Current Distance: 3
|
|-- Direction: Up    (r=-1, c=0) --> Out of bounds, Skip
|-- Direction: Down  (r=1, c=0) --> Already 2, Skip
|-- Direction: Left  (r=0, c=-1) --> Out of bounds, Skip
|-- Direction: Right (r=0, c=1) --> Blocked (-1), Skip
|
Queue After Processing (0, 0): [(3, 3)]

Step 11: Processing (3, 3)
Process (3, 3) --> Current Distance: 4
|
|-- Direction: Up    (r=2, c=3) --> Blocked (-1), Skip
|-- Direction: Down  (r=4, c=3) --> Out of bounds, Skip
|-- Direction: Left  (r=3, c=2) --> Already 3, Skip
|-- Direction: Right (r=3, c=4) --> Out of bounds, Skip
|
Queue After Processing (3, 3): []
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