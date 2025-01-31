public class DSU {
    private int[] Parent, Size;

    public DSU(int n) {
        Parent = new int[n + 1];
        Size = new int[n + 1];
        for (int i = 0; i <= n; i++) {
            Parent[i] = i;
            Size[i] = 1;
        }
    }

    public int Find(int node) {
        if (node != Parent[node]) {
            Parent[node] = Find(Parent[node]);
        }
        return Parent[node];
    }

    public bool Union(int u, int v) {
        int pu = Find(u);
        int pv = Find(v);
        if (pu == pv) return false;
        if (Size[pu] >= Size[pv]) {
            Size[pu] += Size[pv];
            Parent[pv] = pu;
        } else {
            Size[pv] += Size[pu];
            Parent[pu] = pv;
        }
        return true;
    }

    public int GetSize(int node) {
        return Size[Find(node)];
    }
}

public partial class Solution {
    public int MaxAreaOfIslandDSU(int[][] grid) {
        int ROWS = grid.Length;
        int COLS = grid[0].Length;
        DSU dsu = new DSU(ROWS * COLS);

        int[][] directions = new int[][] {
            new int[] { 1, 0 }, new int[] { -1, 0 }, 
            new int[] { 0, 1 }, new int[] { 0, -1 }
        };
        int area = 0;

        for (int r = 0; r < ROWS; r++) {
            for (int c = 0; c < COLS; c++) {
                if (grid[r][c] == 1) {
                    foreach (var d in directions) {
                        int nr = r + d[0];
                        int nc = c + d[1];
                        if (nr >= 0 && nc >= 0 && nr < ROWS && 
                            nc < COLS && grid[nr][nc] == 1) {
                            dsu.Union(r * COLS + c, nr * COLS + nc);
                        }
                    }
                    area = Math.Max(area, dsu.GetSize(r * COLS + c));
                }
            }
        }

        return area;
    }
}
/*

Let’s break down Find and Union in the context of Disjoint Set Union (DSU), 
and then explain how they work with the looping in your algorithm:

Key Concepts of DSU
Purpose of DSU:

DSU helps efficiently group elements into disjoint sets (or islands, in this 
problem).
It supports two main operations:
Find: Identify the "representative" (or "parent") of the set that an element 
belongs to.
Union: Combine two sets into one, ensuring that all elements in the combined 
set share the same "representative."

DSU Representation:
Parent array: Tracks the "leader" or "parent" of each node. Initially, each 
node is its own leader (self-loop).
Size array: Tracks the size of each set to optimize merging.

Find Function
public int Find(int node) {
    if (node != Parent[node]) {
        Parent[node] = Find(Parent[node]);
    }
    return Parent[node];
}

How it works:
If node is not its own parent, it means it’s part of a larger set, and we 
follow the chain of parents recursively until we find the ultimate parent 
(or root).
Along the way, we perform path compression, which makes the tree flatter 
by directly linking all visited nodes to the root. This optimizes future 
calls to Find.

Example:
Suppose Parent = [0, 0, 1, 2] and you call Find(3).

Initially, Parent[3] = 2.
Parent[2] = 1.
Parent[1] = 0.
So, Find(3) returns 0 as the representative of the set containing 3.
After path compression, Parent becomes [0, 0, 0, 0].
 Now, all nodes point directly to 0.

Union Function
public bool Union(int u, int v) {
    int pu = Find(u); // Find the representative of u
    int pv = Find(v); // Find the representative of v
    if (pu == pv) return false; // Already in the same set

    // Union by size: Attach the smaller tree under the larger tree
    if (Size[pu] >= Size[pv]) {
        Size[pu] += Size[pv];
        Parent[pv] = pu;
    } else {
        Size[pv] += Size[pu];
        Parent[pu] = pv;
    }
    return true; // Successful union
}

How it works:
Find the parents of both nodes (pu for u and pv for v).
If both nodes are already in the same set (pu == pv), there’s no need to merge.
Otherwise, merge the smaller set into the larger set for efficiency 
(minimizing tree height).
Update the Parent and Size arrays to reflect the merged set.

Example:
Initial state: Parent = [0, 1, 2, 3], Size = [1, 1, 1, 1].
Union(0, 1):
Find(0) = 0, Find(1) = 1.
Merge 1 into 0: Parent = [0, 0, 2, 3], Size = [2, 1, 1, 1].
Union(1, 2):
Find(1) = 0 (via path compression), Find(2) = 2.
Merge 2 into 0: Parent = [0, 0, 0, 3], Size = [3, 1, 1, 1].

How DSU Affects the Looping in the Algorithm

Connecting Neighbors with DSU:
For each land cell (r, c) in the grid, you calculate its 1D index: 
index = r * COLS + c.
Check all four directions (up, down, left, right). If a neighboring cell 
(nr, nc) is also land, you use Union(index, neighborIndex) to connect the 
two cells into the same set.
Over time, all connected land cells will belong to the same set, 
represented by a single "parent."

Tracking Maximum Area:
After processing the neighbors, call dsu.GetSize(index) to get the size of 
the set that the current cell belongs to.
Update the maximum area using Math.Max(area, dsu.GetSize(index)).

Example Walkthrough:
Grid:
[0, 1, 1, 0]
[1, 1, 0, 0]
[0, 1, 1, 1]

Step-by-Step with DSU:

Initialization:
Parent = [0, 1, 2, ..., 11] (for a 3x4 grid flattened into indices 0-11).
Size = [1, 1, 1, ..., 1].

Processing Cell (0,1):
index = 1.
Union with (0,2): Union(1, 2).
Find(1) = 1, Find(2) = 2. Merge 2 into 1.
Parent = [0, 1, 1, ..., 11], Size = [1, 2, 1, ..., 1].
No other neighbors to connect.
Processing Cell (1,1):

index = 5.
Union with (0,1): Union(5, 1).
Find(5) = 5, Find(1) = 1. Merge 5 into 1.
Parent = [0, 1, 1, ..., 11], Size = [1, 3, 1, ..., 1].
Processing Continues...

As you loop, all connected land cells merge into a single set. 
The Size array tracks the size of each connected component, 
so you can find the largest one.

Summary:
Find connects cells to their root parent, ensuring all connected land cells
belong to the same set.
Union merges two sets of cells, efficiently keeping the DSU structure 
balanced with union by size.
During the loop, every land cell either connects to neighbors (via Union) 
or retrieves the size of its island (via GetSize). This ensures that the 
largest connected land mass is tracked efficiently.
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
