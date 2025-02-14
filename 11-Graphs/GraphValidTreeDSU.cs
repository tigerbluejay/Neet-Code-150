// Disjoint Set Union (DSU) with path compression and union by size
public partial class GVTDSU {
    private int[] GVTParent, GVTSize;
    private int GVTcomps; // Number of connected components

    public GVTDSU(int n) {
        GVTcomps = n; // Initially, each node is its own component
        GVTParent = new int[n + 1];
        GVTSize = new int[n + 1];

        // Each node is its own parent (self loop), and size is initialized to 1.
        for (int i = 0; i <= n; i++) {
            GVTParent[i] = i;
            GVTSize[i] = 1;
        }
    }

    // Find function with path compression to optimize lookup time.
    public int GVTFind(int node) {
        if (GVTParent[node] != node) {
            // Path compression: Make every node in the path point directly to the root.
            GVTParent[node] = GVTFind(GVTParent[node]);
        }
        return GVTParent[node];
    }

    // Union function using union by size.
    public bool GVTUnion(int u, int v) {
        int pu = GVTFind(u), pv = GVTFind(v);

        // If both nodes already belong to the same component, there's a cycle.
        if (pu == pv) return false;

        // Attach the smaller tree under the larger tree to keep depth small.
        if (GVTSize[pu] < GVTSize[pv]) {
            int temp = pu;
            pu = pv;
            pv = temp;
        }

        // Merge the two components.
        GVTcomps--;
        GVTSize[pu] += GVTSize[pv];
        GVTParent[pv] = pu;

        return true;
    }

    // Returns the number of connected components in the graph.
    public int Components() {
        return GVTcomps;
    }
}

// Solution class that uses DSU to check if the graph is a valid tree.
public partial class Solution {
    public bool GVTDSUValidTree(int n, int[][] edges) {
        
        // A valid tree must have exactly n-1 edges.
        if (edges.Length > n - 1) {
            return false;
        }

        GVTDSU dsu = new GVTDSU(n);

        // Try to union each edge, if any union fails, it means there’s a cycle.
        foreach (var edge in edges) {
            if (!dsu.GVTUnion(edge[0], edge[1])) {
                return false;
            }
        }

        // A valid tree must be fully connected (exactly 1 component).
        return dsu.Components() == 1;
    }
}

/*
Note:
A graph will be a valid tree if all nodes are connected (no island nodes in the graph)
And if there are no cycles or loops, for instance 3 is a child of 2, 2 is a child of 1, and 3 is also a child of 1
*/

/*
Graph Valid Tree

Given n nodes labeled from 0 to n - 1 and a list of undirected edges (each edge is a pair of nodes), write a function 
to check whether these edges make up a valid tree.

Example 1:
Input:
n = 5
edges = [[0, 1], [0, 2], [0, 3], [1, 4]]
Output:
true

//          0
//      1   2   3
//    4

Example 2:
Input:
n = 5
edges = [[0, 1], [1, 2], [2, 3], [1, 3], [1, 4]]

//          0
//      1
//    2   4
/// 3   // 1 connects to 3 also, so there's a loop, it's not a tree
Output:
false

Note:
You can assume that no duplicate edges will appear in edges. 
Since all edges are undirected, [0, 1] is the same as [1, 0] and thus will not appear together in edges.

Constraints:
1 <= n <= 100
0 <= edges.length <= n * (n - 1) / 2
*/