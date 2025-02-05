public partial class Solution {
    public int OrangesRotting(int[][] grid) {
        Queue<int[]> q = new Queue<int[]>();
        int fresh = 0;
        int time = 0;

        for (int r = 0; r < grid.Length; r++) {
            for (int c = 0; c < grid[0].Length; c++) {
                if (grid[r][c] == 1) {
                    fresh++;
                }
                if (grid[r][c] == 2) {
                    q.Enqueue(new int[] { r, c });
                }
            }
        }

        int[][] directions = { new int[] { 0, 1 }, new int[] { 0, -1 }, new int[] { 1, 0 }, new int[] { -1, 0 } };
        while (fresh > 0 && q.Count > 0) {
            int length = q.Count;
            for (int i = 0; i < length; i++) {
                int[] curr = q.Dequeue();
                int r = curr[0];
                int c = curr[1];

                // try all four directions and if clause executes whenever there's a 1
                foreach (int[] dir in directions) {
                    int row = r + dir[0];
                    int col = c + dir[1];

                    if (row >= 0 && row < grid.Length && 
                        col >= 0 && col < grid[0].Length &&
                        grid[row][col] == 1) {
                        grid[row][col] = 2;
                        q.Enqueue(new int[] { row, col });
                        fresh--;
                    }
                }
            }
            time++;
        }
        return fresh == 0 ? time : -1;
    }
}

/*
Initial State:
grid = [[1,1,0],
        [0,1,1],
        [0,1,2]]
fresh = 5
queue = [(2,2)]  # Initial rotten orange
time = 0

Step 1 (time = 1):
- Process (2,2), infects:
    - (2,1) → Now rotten
    - (1,2) → Now rotten
- New queue: [(2,1), (1,2)]
- fresh = 3

Step 2 (time = 2):
- Process (2,1), infects:
    - (1,1) → Now rotten
- Process (1,2), infects nothing new
- New queue: [(1,1)]
- fresh = 2

Step 3 (time = 3):
- Process (1,1), infects:
    - (0,1) → Now rotten
- New queue: [(0,1)]
- fresh = 1

Step 4 (time = 4):
- Process (0,1), infects:
    - (0,0) → Now rotten
- New queue: [(0,0)]
- fresh = 0

Final State:
grid = [[2,2,0],
        [0,2,2],
        [0,2,2]]
fresh = 0
time = 4
Output: 4

*/

/*
Rotting Fruit

You are given a 2-D matrix grid. Each cell can have one of three possible values:

0 representing an empty cell
1 representing a fresh fruit
2 representing a rotten fruit

Every minute, if a fresh fruit is horizontally or vertically adjacent to a rotten fruit, then the fresh fruit also 
becomes rotten.

Return the minimum number of minutes that must elapse until there are zero fresh fruits remaining. If this state is 
impossible within the grid, return -1.

Example 1:
[1,1,0]
[0,1,1]
[0,1,2]

Input: grid = [[1,1,0],[0,1,1],[0,1,2]]
Output: 4

Example 2:
Input: grid = [[1,0,1],[0,2,0],[1,0,1]]
Output: -1

Constraints:
1 <= grid.length, grid[i].length <= 10
*/