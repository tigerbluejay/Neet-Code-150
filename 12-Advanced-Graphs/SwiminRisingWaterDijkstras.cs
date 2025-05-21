public partial class Solution {
    public int DASwimInWater(int[][] grid) {
        int N = grid.Length;  // Get the size of the grid (N x N)
        
        // A hash set to keep track of visited cells to avoid redundant processing
        var visit = new HashSet<(int, int)>();

        // Min-heap (priority queue) to always explore the lowest elevation path first
        var minHeap = new PriorityQueue<(int t, int r, int c), int>();

        // Possible movement directions: right, left, down, up
        int[][] directions = { 
            new int[]{0, 1}, new int[]{0, -1}, 
            new int[]{1, 0}, new int[]{-1, 0} 
        };

        // Initialize the priority queue with the starting position (0,0)
        // Priority is determined by grid[0][0], the starting elevation
        minHeap.Enqueue((grid[0][0], 0, 0), grid[0][0]);
        visit.Add((0, 0));  // Mark (0,0) as visited

        // Process nodes in the priority queue
        while (minHeap.Count > 0) {
            var curr = minHeap.Dequeue();  // Get the cell with the minimum elevation encountered so far
            int t = curr.t, r = curr.r, c = curr.c;

            // If we reach the bottom-right corner, return the minimum time required
            if (r == N - 1 && c == N - 1) {
                return t;
            }

            // Explore the 4 possible directions
            foreach (var dir in directions) {
                int neiR = r + dir[0], neiC = c + dir[1];

                // Ensure the next cell is within bounds and hasn't been visited
                if (neiR < 0 || neiC < 0 || neiR >= N || 
                    neiC >= N || visit.Contains((neiR, neiC))) {
                    continue;
                }

                visit.Add((neiR, neiC));  // Mark the new cell as visited
                
                // Calculate the maximum elevation encountered in the path so far
                int newT = Math.Max(t, grid[neiR][neiC]);

                // Push the new cell into the priority queue, prioritizing the smallest elevation
                minHeap.Enqueue((newT, neiR, neiC), newT);
            }
        }

        return N * N;  // This line should never be reached; added for safety
    }
}

/*
Given Grid:
0  2  4
1  3  5
2  6  7

-------------------------------------------------------
Step 1: Initial State
Enqueue: (0, 0,0)   // Start at (0,0) with elevation 0

-------------------------------------------------------
Step 2: Dequeue (0,0,0)
Dequeue: (0, 0,0)
Enqueue: (2, 0,1)   // Right to (0,1) with elevation 2
Enqueue: (1, 1,0)   // Down to (1,0) with elevation 1

Min-Heap:
(1, 1,0)
(2, 0,1)

-------------------------------------------------------
Step 3: Dequeue (1,1,0)
Dequeue: (1, 1,0)
Enqueue: (3, 1,1)   // Right to (1,1) with elevation 3
Enqueue: (2, 2,0)   // Down to (2,0) with elevation 2

Min-Heap:
(2, 0,1)
(2, 2,0)
(3, 1,1)

-------------------------------------------------------
Step 4: Dequeue (2,0,1)
Dequeue: (2, 0,1)
Enqueue: (4, 0,2)   // Right to (0,2) with elevation 4

Min-Heap:
(2, 2,0)
(3, 1,1)
(4, 0,2)

-------------------------------------------------------
Step 5: Dequeue (2,2,0)
Dequeue: (2, 2,0)
Enqueue: (6, 2,1)   // Right to (2,1) with elevation 6

Min-Heap:
(3, 1,1)
(4, 0,2)
(6, 2,1)

-------------------------------------------------------
Step 6: Dequeue (3,1,1)
Dequeue: (3, 1,1)
Enqueue: (5, 1,2)   // Right to (1,2) with elevation 5

Min-Heap:
(4, 0,2)
(5, 1,2)
(6, 2,1)

-------------------------------------------------------
Step 7: Dequeue (4,0,2)
Dequeue: (4, 0,2)

Min-Heap:
(5, 1,2)
(6, 2,1)

-------------------------------------------------------
Step 8: Dequeue (5,1,2)
Dequeue: (5, 1,2)
Enqueue: (7, 2,2)   // Down to (2,2) with elevation 7

Min-Heap:
(6, 2,1)
(7, 2,2)

-------------------------------------------------------
Step 9: Dequeue (6,2,1)
Dequeue: (6, 2,1)

Min-Heap:
(7, 2,2)

-------------------------------------------------------
Step 10: Dequeue (7,2,2)
Dequeue: (7, 2,2)
REACHED END! Return 7

-------------------------------------------------------
Final Answer: 7
-------------------------------------------------------

Final Tree Representation

(0,0)
 ├── (1,0)
 └── (0,1)

 (0,0)
 ├── (1,0)
 │    ├── (2,0)
 │    └── (1,1)
 └── (0,1)

 (0,0)
 ├── (1,0)
 │    ├── (2,0)
 │    │    └── (2,1)
 │    │         └── (2,2) ✅
 │    └── (1,1)
 └── (0,1)


(0,0)
 ├── (1,0)
 │    ├── (2,0)
 │    │    └── (2,1)
 │    │         └── (2,2) ✅
 │    └── (1,1)
 │         └── (1,2)
 └── (0,1)
      └── (0,2)
How to Read This?
The depth-first order shows how each cell is expanded in the algorithm.
The branches represent new expansions when a cell is dequeued.
The path to (2,2) represents the shortest path found.
*/

/*
Swim in Rising Water

You are given a square 2-D matrix of distinct integers grid where each integer grid[i][j] represents the 
elevation at position (i, j).

Rain starts to fall at time = 0, which causes the water level to rise. At time t, the water level across the 
entire grid is t.

You may swim either horizontally or vertically in the grid between two adjacent squares if the original 
elevation of both squares is less than or equal to the water level at time t.

Starting from the top left square (0, 0), return the minimum amount of time it will take until it is possible 
to reach the bottom right square (n - 1, n - 1).

Example 1:
Input: grid = [[0,1],[2,3]]

Output: 3
Explanation: For a path to exist to the bottom right square grid[1][1] the water elevation must be at least 3. 
At time t = 3, the water level is 3.
*/