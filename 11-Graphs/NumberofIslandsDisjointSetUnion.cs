public class NOIDSU {
    private int[] Parent, Size;

    // Constructor: Initialize Parent and Size arrays.
    public NOIDSU(int n) {
        Parent = new int[n + 1];
        Size = new int[n + 1];
        for (int i = 0; i <= n; i++) {
            Parent[i] = i; // Each node starts as its own parent.
            Size[i] = 1;   // Each set initially has size 1.
        }
    }

    // Find with path compression: Efficiently find the root of the set.
    public int Find(int node) {
        if (node != Parent[node]) {
            Parent[node] = Find(Parent[node]);
        }
        return Parent[node];
    }

// Union by size: Merge two sets, keeping the larger tree as the root.
    public bool Union(int u, int v) {
        int pu = Find(u); // Find the root of u.
        int pv = Find(v); // Find the root of v.
        if (pu == pv) return false; // Already in the same set.

        // Merge smaller tree into larger tree.
        if (Size[pu] >= Size[pv]) {
            Size[pu] += Size[pv];
            Parent[pv] = pu; // Make pu the parent of pv.
        } else {
            Size[pv] += Size[pu];
            Parent[pu] = pv; // Make pv the parent of pu.
        }
        return true;
    }
}
public partial class Solution {
    public int NumIslandsDSU(char[][] grid) {
        int ROWS = grid.Length;
        int COLS = grid[0].Length;

        // Initialize DSU with one node per cell.
        NOIDSU dsu = new NOIDSU(ROWS * COLS);

        int[][] directions = new int[][] {
            new int[] { 1, 0 }, new int[] { -1, 0 }, 
            new int[] { 0, 1 }, new int[] { 0, -1 }
        };
        int islands = 0;

        // Iterate over the grid.
        for (int r = 0; r < ROWS; r++) {
            for (int c = 0; c < COLS; c++) {
                if (grid[r][c] == '1') { // Land cell found.
                    islands++; // Assume it's a new island.
                    foreach (var d in directions) { // Check all neighbors.
                        int nr = r + d[0];
                        int nc = c + d[1];
                        // If neighbor is within bounds and is land.
                        if (nr >= 0 && nc >= 0 && nr < ROWS && nc < COLS && grid[nr][nc] == '1') {
                            // Attempt to union the current cell with the neighbor.
                            if (dsu.Union(r * COLS + c, nr * COLS + nc)) {
                                islands--; // Merge two islands, reduce count.
                            }
                        }
                    }
                }
            }
        }

        return islands; // Return the total number of islands.
    }
}

/*
This implementation uses Disjoint Set Union (DSU) (also known as Union-Find) to 
solve the problem of counting the number of islands in a grid. DSU is a powerful 
data structure for efficiently managing a collection of disjoint sets, supporting 
two main operations:

Union: Merge two sets into one.
Find: Identify the representative (root) of the set containing a given element.
The grid is treated as a graph where each cell is a node, 
and adjacent land cells ('1') are connected by edges. The algorithm:

Initializes a DSU to represent the nodes in the grid.
Iterates through the grid, marking cells that are '1' (land) as part of a set.
For each land cell, attempts to merge it with its adjacent land cells.
Decreases the count of islands whenever a union operation successfully merges 
two distinct sets.
*/

/*
Example Grid:
0 1 1 1 0
0 1 0 1 0
1 1 0 0 0
0 0 0 0 0

Index Mapping:
[0, 1, 2, 3, 4]
[5, 6, 7, 8, 9]
[10,11,12,13,14]
[15,16,17,18,19]

Initial Parent Array:
[0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, ...]

Union Operations:
1. Union(1, 2):
   Parent: [0, 1, 1, 3, 4, 5, 6, 7, 8, 9, ...]
   Tree: 1 → 2

2. Union(2, 3):
   Parent: [0, 1, 1, 1, 4, 5, 6, 7, 8, 9, ...]
   Tree: 1 → 2, 3

3. Union(1, 6):
   Parent: [0, 1, 1, 1, 4, 5, 1, 7, 8, 9, ...]
   Tree: 1 → 2, 3, 6

4. Union(6, 8):
   Parent: [0, 1, 1, 1, 4, 5, 1, 7, 1, 9, ...]
   Tree: 1 → 2, 3, 6, 8

5. Union(8, 9):
   Parent: [0, 1, 1, 1, 4, 5, 1, 7, 1, 1, ...]
   Tree: 1 → 2, 3, 6, 8, 9

6. Union(3, 7):
   Parent: [0, 1, 1, 1, 4, 5, 1, 1, 1, 1, ...]
   Tree: 1 → 2, 3 → 7, 6, 8, 9

Final Tree:
1 → 2, 3 → 7, 6, 8, 9

Final Parent Array:
[0, 1, 1, 1, 4, 5, 1, 1, 1, 1, ...]

Final Size Array:
[1, 7, 1, 1, 1, 1, 1, 1, 1, 1, ...]

Yes, these correspond directly to the variables maintained by the DSU 
(Disjoint Set Union) structure in the algorithm:

Final Tree:
This represents the structure implied by the Parent array, 
which tracks the parent of each node. For example:
1 → 2 means that the parent of node 2 is node 1.
3 → 7 means node 7 is connected to node 3, and so on.

Final Parent Array:
The Parent array in the DSU tracks the representative (or parent) for each node.
Example: [0, 1, 1, 1, 4, 5, 1, 1, 1, 1, ...]
Parent[2] = 1, meaning node 2's parent is node 1.
Parent[6] = 1, meaning node 6's parent is node 1.

Final Size Array:
The Size array tracks the size of the set (number of connected nodes) 
for each root node.
Example: [1, 7, 1, 1, 1, 1, 1, 1, 1, 1, ...]
Size[1] = 7 means that the set represented by node 1 contains 7 nodes.

All other sizes are 1 because their respective nodes are either isolated or 
have not been joined into larger sets.
These variables are updated during Union and Find operations to efficiently 
merge and find connected components in the grid.

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