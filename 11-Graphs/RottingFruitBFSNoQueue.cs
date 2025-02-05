public partial class Solution {
    public int OrangesRottingNoQueue(int[][] grid) {
        int ROWS = grid.Length, COLS = grid[0].Length;
        int fresh = 0, time = 0;

        for (int r = 0; r < ROWS; r++) {
            for (int c = 0; c < COLS; c++) {
                if (grid[r][c] == 1) fresh++;
            }
        }

        int[][] directions = new int[][] {
            new int[] {0, 1}, new int[] {0, -1}, 
            new int[] {1, 0}, new int[] {-1, 0}
        };

        while (fresh > 0) {
            bool flag = false;
            for (int r = 0; r < ROWS; r++) {
                for (int c = 0; c < COLS; c++) {
                    if (grid[r][c] == 2) {
                        // process adjacent cells in all four directions
                        foreach (var d in directions) {
                            int row = r + d[0], col = c + d[1];
                            if (row >= 0 && col >= 0 && 
                                row < ROWS && col < COLS && 
                                grid[row][col] == 1) { // if fruit is fresh
                                grid[row][col] = 3; // turn it to infected
                                fresh--;    // decrease fresh count
                                flag = true;
                            }
                        }
                    }
                }
            }

            if (!flag) return -1; // only if not possible to process all fruit

            for (int r = 0; r < ROWS; r++) {
                for (int c = 0; c < COLS; c++) {
                    if (grid[r][c] == 3) grid[r][c] = 2;
                }
            }

            time++;
        }

        return time;
    }
}

/*
Time = 1 | Fresh = 5
 ├── Process (2,2) → Infects (2,1) → Becomes 3
 ├── Process (2,2) → Infects (1,2) → Becomes 3
 ├── Grid after infection:
 │   [[1,1,0],
 │    [0,1,3],
 │    [0,3,2]]
 ├── Convert all 3 → 2
 │   [[1,1,0],
 │    [0,1,2],
 │    [0,2,2]]
 ├── Time Increases → 1
 ├── Fresh count → 3

Time = 2 | Fresh = 3
 ├── Process (2,1) → Infects (1,1) → Becomes 3
 ├── Process (1,2) → No new infections
 ├── Grid after infection:
 │   [[1,1,0],
 │    [0,3,2],
 │    [0,2,2]]
 ├── Convert all 3 → 2
 │   [[1,1,0],
 │    [0,2,2],
 │    [0,2,2]]
 ├── Time Increases → 2
 ├── Fresh count → 2

Time = 3 | Fresh = 2
 ├── Process (1,1) → Infects (0,1) → Becomes 3
 ├── Grid after infection:
 │   [[1,3,0],
 │    [0,2,2],
 │    [0,2,2]]
 ├── Convert all 3 → 2
 │   [[1,2,0],
 │    [0,2,2],
 │    [0,2,2]]
 ├── Time Increases → 3
 ├── Fresh count → 1

Time = 4 | Fresh = 1
 ├── Process (0,1) → Infects (0,0) → Becomes 3
 ├── Grid after infection:
 │   [[3,2,0],
 │    [0,2,2],
 │    [0,2,2]]
 ├── Convert all 3 → 2
 │   [[2,2,0],
 │    [0,2,2],
 │    [0,2,2]]
 ├── Time Increases → 4
 ├── Fresh count → 0
Final Output:
All fresh oranges are rotten.
Output = 4
*/

/*
How It Differs From the Queue-Based Version
✅ Saves memory since it doesn't store a queue of rotting oranges.
✅ More brute-force—rechecks the entire grid on each time step, making it less efficient than the queue-based approach.
✅ Same logic applies—counts time steps and fresh oranges.
✅ Still BFS but implemented in-place without an explicit queue.



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