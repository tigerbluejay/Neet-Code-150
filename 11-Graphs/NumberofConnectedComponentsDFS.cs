public partial class Solution {
    public int NCCDFSCountComponents(int n, int[][] edges) {

        // Initialize an adjacency list representation of the graph
        List<List<int>> adj = new List<List<int>>();

        // Array to keep track of visited nodes
        bool[] visit = new bool[n];

        // Create empty adjacency lists for each node
        for (int i = 0; i < n; i++) {
            adj.Add(new List<int>());
        }

        // Populate the adjacency list with the given edges (undirected graph)
        foreach (var edge in edges) {
            adj[edge[0]].Add(edge[1]);
            adj[edge[1]].Add(edge[0]);
        }

        int res = 0; // Counter for the number of connected components

        // Iterate over each node in the graph
        for (int node = 0; node < n; node++) {
            // If the node has not been visited, perform DFS to explore its component
            if (!visit[node]) {
                NCCDfs(adj, visit, node);
                res++; // Increment the component count after a full DFS traversal
            }
        }
        return res;
    }

    // Performs DFS to mark all nodes in the same connected component as visited
    private void NCCDfs(List<List<int>> adj, bool[] visit, int node) {
        visit[node] = true; // Mark the current node as visited

        // Recursively visit all unvisited neighbors
        foreach (var nei in adj[node]) {
            if (!visit[nei]) {
                NCCDfs(adj, visit, nei);
            }
        }
    }
}
/*
Input:
n = 6
edges = [[0,1], [1,2], [2,3], [4,5]]

Adjacency List Construction:
0 -> [1]
1 -> [0, 2]
2 -> [1, 3]
3 -> [2]
4 -> [5]
5 -> [4]

Recursive DFS Calls (Tracking node and visit[] updates)

NCCDFSCountComponents(n=6, edges)

Start DFS at node 0 (not visited) → Increment component count: res = 1
└── NCCDfs(node=0)
    ├── Mark visit[0] = true
    ├── Visit neighbor: 1 (not visited)
    │   └── NCCDfs(node=1)
    │       ├── Mark visit[1] = true
    │       ├── Visit neighbor: 0 (already visited, skip)
    │       ├── Visit neighbor: 2 (not visited)
    │       │   └── NCCDfs(node=2)
    │       │       ├── Mark visit[2] = true
    │       │       ├── Visit neighbor: 1 (already visited, skip)
    │       │       ├── Visit neighbor: 3 (not visited)
    │       │       │   └── NCCDfs(node=3)
    │       │       │       ├── Mark visit[3] = true
    │       │       │       ├── Visit neighbor: 2 (already visited, skip)
    │       │       │       └── Return to node 2
    │       │       └── Return to node 1
    │       └── Return to node 0
    └── Return to NCCDFSCountComponents

Start DFS at node 1 (already visited, skip)
Start DFS at node 2 (already visited, skip)
Start DFS at node 3 (already visited, skip)

Start DFS at node 4 (not visited) → Increment component count: res = 2
└── NCCDfs(node=4)
    ├── Mark visit[4] = true
    ├── Visit neighbor: 5 (not visited)
    │   └── NCCDfs(node=5)
    │       ├── Mark visit[5] = true
    │       ├── Visit neighbor: 4 (already visited, skip)
    │       └── Return to node 4
    └── Return to NCCDFSCountComponents

Start DFS at node 5 (already visited, skip)

Final result: 2 connected components
*/

/*
Number of Connected Components in an Undirected Graph

There is an undirected graph with n nodes. 
There is also an edges array, where edges[i] = [a, b] means that 
there is an edge between node a and node b in the graph.

The nodes are numbered from 0 to n - 1.

Return the total number of connected components in that graph.

Example 1:
Input:
n=3
edges=[[0,1], [0,2]]
Output:
1

Example 2:
Input:
n=6
edges=[[0,1], [1,2], [2,3], [4,5]]
Output:
2

Constraints:
1 <= n <= 100
0 <= edges.length <= n * (n - 1) / 2
*/