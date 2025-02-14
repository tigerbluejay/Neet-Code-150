public partial class Solution {
    public bool GVTDFSValidTree(int n, int[][] edges) {
        
        // A valid tree must have exactly n-1 edges (a connected acyclic graph with n nodes).
        // If there are more edges than n-1, it means there is a cycle or redundancy, making it invalid.
        if (edges.Length > n - 1) {
            return false;
        }

        // Initialize an adjacency list to represent the graph.
        List<List<int>> adj = new List<List<int>>();
        for (int i = 0; i < n; i++) {
            adj.Add(new List<int>());
        }

        // Populate the adjacency list with bidirectional edges (since the graph is undirected).
        foreach (var edge in edges) {
            adj[edge[0]].Add(edge[1]);
            adj[edge[1]].Add(edge[0]);
        }

        // Use a HashSet to track visited nodes.
        HashSet<int> visit = new HashSet<int>();

        // Perform DFS starting from node 0.
        // If a cycle is detected, return false.
        if (!GVTDfs(0, -1, visit, adj)) {
            return false;
        }

        // After DFS, check if all nodes have been visited.
        // If some nodes are unvisited, it means the graph is disconnected, so it's not a valid tree.
        return visit.Count == n;
    }

    private bool GVTDfs(int node, int parent, HashSet<int> visit, List<List<int>> adj) {
        
        // If the node is already visited, it means we've found a cycle.
        if (visit.Contains(node)) {
            return false;
        }

        // Mark the node as visited.
        visit.Add(node);

        // Explore all neighbors.
        foreach (var nei in adj[node]) {
            // Skip the edge leading back to the parent (to avoid falsely detecting a cycle).
            if (nei == parent) {
                continue;
            }
            // If DFS finds a cycle in any other path, return false.
            if (!GVTDfs(nei, node, visit, adj)) {
                return false;
            }
        }
        
        // If no cycles were found, return true.
        return true;
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