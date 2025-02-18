public partial class Solution {
    public int[] RCDFS2FindRedundantConnection(int[][] edges) {
        int n = edges.Length; // Number of edges in the graph
        List<int>[] adj = new List<int>[n + 1]; // Adjacency list representation

        // Initialize adjacency list for nodes from 0 to n
        for (int i = 0; i <= n; i++) adj[i] = new List<int>();

        // Build the adjacency list representation of the graph
        foreach (var edge in edges) {
            int u = edge[0], v = edge[1]; // Extract the two nodes that form the edge
            adj[u].Add(v);
            adj[v].Add(u);
        }

        bool[] visit = new bool[n + 1]; // Tracks visited nodes in DFS
        HashSet<int> cycle = new HashSet<int>(); // Stores nodes that form the cycle
        int cycleStart = -1; // Stores the first node in the detected cycle

        // Depth-First Search (DFS) function to detect a cycle
        bool Dfs(int node, int par) {
            if (visit[node]) { // If the node is already visited, we found a cycle
                cycleStart = node; // Mark the starting node of the cycle
                return true;
            }

            visit[node] = true; // Mark the current node as visited

            // Traverse all adjacent nodes (neighbors)
            foreach (int nei in adj[node]) {
                if (nei == par) continue; // Skip the parent node to avoid backtracking
                if (Dfs(nei, node)) { // Recursively call DFS
                    if (cycleStart != -1) cycle.Add(node); // Add nodes to cycle set
                    if (node == cycleStart) {
                        cycleStart = -1; // Reset cycle start when the cycle is fully traced
                    }
                    return true; // Return true if a cycle is found
                }
            }

            return false; // No cycle detected
        }

        // Start DFS from node 1 (since nodes are 1-based)
        Dfs(1, -1);

        // Find the last edge in the input that is part of the cycle
        for (int i = edges.Length - 1; i >= 0; i--) { // Traverse edges in reverse order
            int u = edges[i][0], v = edges[i][1];
            if (cycle.Contains(u) && cycle.Contains(v)) { // Check if both nodes are in the cycle
                return new int[] { u, v }; // Return the redundant edge
            }
        }

        return new int[0]; // If no redundant edge is found (should not happen per problem constraints)
    }
}

/*
Before starting DFS, the graph looks like this:
    1
   / \
  2   3
       \
        4

Edges: [[1,2],[1,3],[3,4],[2,4]]

We are trying to detect a cycle in this graph and ultimately find the redundant edge.

DFS Recursive Call Tree:

We'll start DFS from node 1 (as it is commonly the starting point) and traverse its neighbors.

DFS Call Tree for Edge [2,4] (to detect the cycle):

Dfs(1, -1)          // Start DFS from node 1, no parent (-1)
│
├── Dfs(2, 1)       // Move to node 2 (parent 1)
│   ├── Dfs(1, 2)   // Move back to node 1 (parent 2) -> Already visited (Cycle detected here)
│   │   └── Found cycle at node 1. Set cycleStart = 1
│   └── Return true // Backtrack after detecting cycle
│
├── Dfs(3, 1)       // Move to node 3 (parent 1)
│   ├── Dfs(4, 3)   // Move to node 4 (parent 3)
│   │   ├── Dfs(2, 4)   // Move to node 2 (parent 4)
│   │   │   └── Found cycle at node 2 (since node 2 is already in the cycle)
│   │   └── Backtrack and continue
│   └── Return true  // Continue after detecting cycle
│
└── Dfs(4, 3)       // DFS finished with a cycle detected and added to cycle HashSet

Key Values during Traversal:

Cycle detection starts when we visit node 1, which is already visited.

The cycle start node is set as 1 and later is reset as we finish exploring the cycle.

Visualization of the DFS Call Tree:
This is a simple tree structure showing the recursive DFS calls and the cycle detection flow:

Dfs(1, -1)
├── Dfs(2, 1)      // Visit node 2
│   ├── Dfs(1, 2)  // Back to node 1 (Cycle detected)
│   └── Backtrack
├── Dfs(3, 1)      // Visit node 3
│   ├── Dfs(4, 3)  // Visit node 4
│   │   ├── Dfs(2, 4) // Back to node 2 (Cycle detected)
│   │   └── Backtrack

└── Finished DFS with detected cycle nodes: {1, 2, 4}
Final Output:

The cycle nodes are {1, 2, 4}. The redundant edge is found by checking which of the edges form a cycle.

Next Steps (After DFS)
Cycle Nodes Identified: {1, 2, 4}

Check edges in reverse order to find the last edge contributing to the cycle:

In this case, edge [2,4] forms the cycle and is the redundant one.
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