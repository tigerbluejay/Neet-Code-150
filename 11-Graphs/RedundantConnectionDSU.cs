public partial class Solution {
    
    // Main function to find the redundant connection.
    public int[] RCDSUFindRedundantConnection(int[][] edges) {
        // Create arrays for the parent and rank of each node in the union-find structure.
        int[] par = new int[edges.Length + 1]; // 'par' stores the parent of each node.
        int[] rank = new int[edges.Length + 1]; // 'rank' stores the rank (or depth) of each tree for optimization.

        // Initialize each node as its own parent (disjoint sets), and set rank to 1.
        for (int i = 0; i < par.Length; i++) {
            par[i] = i; // Initially, each node is its own parent.
            rank[i] = 1; // Initialize rank of each node to 1 (all sets are flat at the beginning).
        }

        // Loop through all the edges to process them.
        foreach (var edge in edges) {
            // Try to union the two nodes of the current edge.
            // If the two nodes are already in the same set, that means the edge is redundant (cycle detected).
            if (!RCDSUUnion(par, rank, edge[0], edge[1]))
                return new int[]{ edge[0], edge[1] }; // Return the redundant edge as it forms a cycle.
        }
        // If no redundant connection is found, return an empty array (though this case shouldn't happen in the context of the problem).
        return new int[0];
    }

    // Helper function to find the parent of a node using path compression (for efficiency).
    private int RCDSUFind(int[] par, int n) {
        int p = par[n]; // Start with the parent of the node.
        
        // Keep traversing up the tree until we reach the root (node whose parent is itself).
        while (p != par[p]) {
            // Path compression: Make the parent of the node point directly to the root.
            par[p] = par[par[p]]; 
            p = par[p]; // Move up the tree.
        }
        return p; // Return the root of the set.
    }

    // Helper function to perform union of two sets, if they are not already in the same set.
    private bool RCDSUUnion(int[] par, int[] rank, int n1, int n2) {
        // Find the roots of the sets to which n1 and n2 belong.
        int p1 = RCDSUFind(par, n1); 
        int p2 = RCDSUFind(par, n2);

        // If both nodes are already in the same set, they form a cycle, so return false (no union).
        if (p1 == p2)
            return false;

        // Union by rank: attach the smaller tree (the one with lower rank) to the root of the larger tree.
        if (rank[p1] > rank[p2]) {
            par[p2] = p1; // Make p1 the parent of p2.
            rank[p1] += rank[p2]; // Increase the rank of the new root (p1).
        } else {
            par[p1] = p2; // Make p2 the parent of p1.
            rank[p2] += rank[p1]; // Increase the rank of the new root (p2).
        }
        return true; // Return true if the union was successful (no cycle detected).
    }
}
/*

Input: [[1, 2], [1, 3], [3, 4], [2, 4]]

Initialization:
par = [0, 1, 2, 3, 4]  // Parent array where each node is its own parent initially.
rank = [0, 1, 1, 1, 1] // Rank array to track the depth of each set.

Processing edge [1, 2]:
Find root of 1: RCDSUFind(par, 1) → root is 1.
Find root of 2: RCDSUFind(par, 2) → root is 2.
Union by rank: Union the sets of 1 and 2, making 2 the parent of 1 (or vice versa), as ranks are equal.
par = [0, 2, 2, 3, 4]
rank = [0, 1, 2, 1, 1]

Processing edge [1, 3]:
Find root of 1: RCDSUFind(par, 1) → find 2 as root (after path compression, par[1] = 2).
Find root of 3: RCDSUFind(par, 3) → root is 3.
Union the sets of 2 and 3.
par = [0, 2, 2, 2, 4]
rank = [0, 1, 2, 1, 1]

Processing edge [3, 4]:
Find root of 3: RCDSUFind(par, 3) → find 2 as root (after path compression, par[3] = 2).
Find root of 4: RCDSUFind(par, 4) → root is 4.
Union the sets of 2 and 4.
par = [0, 2, 2, 2, 2]
rank = [0, 1, 2, 1, 1]

Processing edge [2, 4]:
Find root of 2: RCDSUFind(par, 2) → root is 2.
Find root of 4: RCDSUFind(par, 4) → find 2 as root (after path compression, par[4] = 2).
Since both nodes have the same root, this edge forms a cycle (redundant edge).
Output: [2, 4]
*/

/*
We need to understand that a graph with n nodes and n edges is necessarily in a cycle.
*/

/*
Redundant Connection

You are given a connected undirected graph with n nodes labeled from 1 to n. 
Initially, it contained no cycles and consisted of n-1 edges.

We have now added one additional edge to the graph. The edge has two different vertices chosen from 1 to n, 
and was not an edge that previously existed in the graph.

The graph is represented as an array edges of length n where edges[i] = [ai, bi] represents an edge between nodes ai
 and bi in the graph.

Return an edge that can be removed so that the graph is still a connected non-cyclical graph. 
If there are multiple answers, return the edge that appears last in the input edges.

Example 1:
Input: edges = [[1,2],[1,3],[3,4],[2,4]]
Output: [2,4]

Example 2:
Input: edges = [[1,2],[1,3],[1,4],[3,4],[4,5]]
Output: [3,4]

Constraints:
n == edges.length
3 <= n <= 100
1 <= edges[i][0] < edges[i][1] <= edges.length
There are no repeated edges and no self-loops in the input.
*/