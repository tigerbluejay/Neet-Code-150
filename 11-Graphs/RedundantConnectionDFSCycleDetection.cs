
public partial class Solution {
    public int[] RCDFS1FindRedundantConnection(int[][] edges) {
        int n = edges.Length; // The number of edges in the graph
        List<List<int>> adj = new List<List<int>>(); // Adjacency list representation of the graph

        // Initialize adjacency list for nodes from 0 to n
        for (int i = 0; i <= n; i++) {
            adj.Add(new List<int>());
        }

        // Process each edge
        foreach (var edge in edges) {
            int u = edge[0], v = edge[1]; // Extract the two nodes that form the edge

            // Add the edge to the adjacency list (undirected graph)
            adj[u].Add(v);
            adj[v].Add(u);

            // Create a visited array for DFS traversal
            bool[] visit = new bool[n + 1];

            // Check if adding this edge creates a cycle using DFS // every edge added is checked *foreach above
            if (RCDFS1Dfs(u, -1, adj, visit)) {
                // If a cycle is detected, return this edge as the redundant connection
                return new int[] { u, v };
            }
        }

        // If no redundant edge is found (though the problem guarantees one exists), return an empty array
        return new int[0];
    }

    private bool RCDFS1Dfs(int node, int parent, 
                           List<List<int>> adj, bool[] visit) {
        if (visit[node]) return true; // If the node is already visited, a cycle is detected
        visit[node] = true; // Mark the current node as visited

        // Traverse all adjacent nodes (neighbors)
        foreach (int nei in adj[node]) {
            if (nei == parent) continue; // Skip the parent node to avoid counting the back edge
            if (RCDFS1Dfs(nei, node, adj, visit)) return true; // If DFS finds a cycle, return true
        }

        return false; // No cycle detected
    }
}

/*
Edges Processed in Order:
[1,2]
[1,3]
[3,4]
[2,4] (Causes a cycle, triggering DFS cycle detection)

Graph Before Adding Edge [2,4]:
    1
   / \
  2   3
       \
        4

DFS Call Tree for Edge [2,4]

When adding edge [2,4], the adjacency list becomes:
1 → [2, 3]
2 → [1, 4]
3 → [1, 4]
4 → [3, 2]

DFS starts from 2, trying to detect if 4 is already reachable.
Recursive Calls:

RCDFS1Dfs(2, -1)
│
├── RCDFS1Dfs(1, 2)
│   ├── RCDFS1Dfs(3, 1)
│   │   ├── RCDFS1Dfs(4, 3)
│   │   │   ├── RCDFS1Dfs(2, 4)  <-- Cycle Detected! (2 already visited)
│   │   │   └── Return true
│   │   └── Return true
│   └── Return true
└── Return true (Cycle found)

Explanation of DFS Calls:

RCDFS1Dfs(2, -1): Start DFS from 2 (newly connected node).
RCDFS1Dfs(1, 2): Visit 1 (neighbor of 2).
RCDFS1Dfs(3, 1): Visit 3 (neighbor of 1).
RCDFS1Dfs(4, 3): Visit 4 (neighbor of 3).
RCDFS1Dfs(2, 4): Cycle detected! (2 is already visited).
Since we find a cycle, edge [2,4] is the redundant connection.
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