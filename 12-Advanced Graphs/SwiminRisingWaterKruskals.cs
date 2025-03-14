// Disjoint Set Union (DSU) or Union-Find data structure with path compression and union by size
public class SRWKADSU {
    private int[] Parent, Size;

    // Constructor initializes DSU for 'n' elements
    public SRWKADSU(int n) {
        Parent = new int[n + 1]; // Parent array to track the root of each set
        Size = new int[n + 1];   // Size array to track the size of each set

        // Initialize each node as its own parent (self-loop)
        for (int i = 0; i <= n; i++) Parent[i] = i;

        // Initially, each set has size 1
        Array.Fill(Size, 1);
    }

    // Find operation with path compression: recursively finds root and flattens the tree
    public int Find(int node) {
        if (Parent[node] != node)
            Parent[node] = Find(Parent[node]); // Path compression
        return Parent[node];
    }

    // Union operation with union by size: attaches smaller tree under larger tree
    public bool Union(int u, int v) {
        int pu = Find(u), pv = Find(v); // Find root parents
        if (pu == pv) return false; // Already in the same set, no need to merge

        // Always attach the smaller tree to the larger tree
        if (Size[pu] < Size[pv]) {
            int temp = pu;
            pu = pv;
            pv = temp;
        }
        Size[pu] += Size[pv]; // Increase the size of the new root set
        Parent[pv] = pu; // Merge pv into pu
        return true;
    }

    // Checks if two nodes belong to the same set
    public bool Connected(int u, int v) {
        return Find(u) == Find(v);
    }
}

public partial class Solution {
    public int KASwimInWater(int[][] grid) {
        int N = grid.Length; // Size of the grid (NxN)
        SRWKADSU dsu = new SRWKADSU(N * N); // DSU structure to track connectivity

        List<int[]> positions = new List<int[]>(); // List to store cell positions along with their water levels

        // Flatten the grid into a list where each cell is represented as {height, row, col}
        for (int r = 0; r < N; r++)
            for (int c = 0; c < N; c++)
                positions.Add(new int[] {grid[r][c], r, c});

        // Sort the list in ascending order based on water height (greedy approach)
        positions.Sort((a, b) => a[0] - b[0]);

        // Define the possible four movement directions (right, down, left, up)
        int[][] directions = new int[][] { 
            new int[] {0, 1}, new int[] {1, 0}, 
            new int[] {0, -1}, new int[] {-1, 0} 
        };

        // Process each cell in order of increasing height
        foreach (var pos in positions) {
            int t = pos[0], r = pos[1], c = pos[2]; // Extract time, row, and column

            // Try to connect the current cell with its adjacent cells that have already been processed
            foreach (var dir in directions) {
                int nr = r + dir[0], nc = c + dir[1]; // New row and column

                // Ensure within grid bounds and only union with cells that have been processed (height <= t)
                if (nr >= 0 && nr < N && nc >= 0 && nc < N && grid[nr][nc] <= t) {
                    dsu.Union(r * N + c, nr * N + nc);
                }
            }

            // If the start (0,0) and end (N-1,N-1) are connected, return the current time
            if (dsu.Connected(0, N * N - 1)) return t;
        }

        return N * N; // Should never reach here
    }
}
/*
Explanation of Algorithm:
Flatten Grid & Sort by Water Level:

We store each cell along with its water level and sort them in ascending order.
This ensures we process the lowest water levels first (greedy approach).
Union-Find (DSU) for Connectivity:

Each cell is treated as a node in a graph.
Initially, no cells are connected.
As we process cells, we attempt to union them with already processed neighbors.
Checking Connectivity:

At each step, if (0,0) is connected to (N-1,N-1), we return the current time (height).
The first time this happens gives the minimum possible time to swim across.
*/

/*
Given grid:

0  2  4
1  3  5
2  6  7

Step-by-Step DSU Operations Tree

Start processing cells sorted by height:
(0,0) height=0

  (0,0) connects to (1,0) [1]
    (1,0) connects to (2,0) [2]
      (2,0) connects to (2,1) [6]
        (2,1) connects to (2,2) [7]
        
  (0,0) connects to (0,1) [2]
    (0,1) connects to (1,1) [3]
      (1,1) connects to (1,2) [5]
      (1,1) connects to (2,1) [6] (already connected)

    (0,1) connects to (0,2) [4]
      (0,2) connects to (1,2) [5] (already connected)

Final step:
  - Check if (0,0) is connected to (2,2)
  - Yes! Minimum time required: **7**

Explanation of the Corrected Representation:
The minimum time is determined by the highest water height encountered along the path from (0,0) to (2,2).
The path followed in this case is from (0,0) -> (1,0) -> (2,0) -> (2,1) -> (2,2), and the highest height 
along this path is 7 (at position (2,2)).
This means the minimum time required to swim across the grid is 7.
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