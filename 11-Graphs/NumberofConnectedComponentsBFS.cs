public partial class Solution {
    public int NCCBFSCountComponents(int n, int[][] edges) {

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
            // If the node has not been visited, perform BFS to explore its component
            if (!visit[node]) {
                NCCBfs(adj, visit, node);
                res++; // Increment the component count after a full BFS traversal
            }
        }
        return res;
    }

    // Performs BFS to mark all nodes in the same connected component as visited
    private void NCCBfs(List<List<int>> adj, bool[] visit, int node) {
        Queue<int> q = new Queue<int>(); // Initialize a queue for BFS
        q.Enqueue(node); // Start BFS from the given node
        visit[node] = true; // Mark the starting node as visited

        // Process nodes in the queue
        while (q.Count > 0) {
            int cur = q.Dequeue(); // Remove a node from the queue

            // Visit all unvisited neighbors
            foreach (var nei in adj[cur]) {
                if (!visit[nei]) {
                    visit[nei] = true; // Mark neighbor as visited
                    q.Enqueue(nei); // Add neighbor to the queue for further processing
                }
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

BFS Traversal Steps (Tracking queue and visit[] updates)

NCCBFSCountComponents(n=6, edges)

Start BFS at node 0 (not visited) → Increment component count: res = 1
└── NCCBfs(node=0)
    ├── Enqueue 0, Mark visit[0] = true, Queue: [0]
    ├── Dequeue 0, Visit neighbors:
    │   ├── Visit neighbor: 1 (not visited)
    │   │   ├── Enqueue 1, Mark visit[1] = true, Queue: [1]
    ├── Dequeue 1, Visit neighbors:
    │   ├── Visit neighbor: 0 (already visited, skip)
    │   ├── Visit neighbor: 2 (not visited)
    │   │   ├── Enqueue 2, Mark visit[2] = true, Queue: [2]
    ├── Dequeue 2, Visit neighbors:
    │   ├── Visit neighbor: 1 (already visited, skip)
    │   ├── Visit neighbor: 3 (not visited)
    │   │   ├── Enqueue 3, Mark visit[3] = true, Queue: [3]
    ├── Dequeue 3, Visit neighbors:
    │   ├── Visit neighbor: 2 (already visited, skip)
    ├── Queue empty → Return to NCCBFSCountComponents

Start BFS at node 1 (already visited, skip)
Start BFS at node 2 (already visited, skip)
Start BFS at node 3 (already visited, skip)

Start BFS at node 4 (not visited) → Increment component count: res = 2
└── NCCBfs(node=4)
    ├── Enqueue 4, Mark visit[4] = true, Queue: [4]
    ├── Dequeue 4, Visit neighbors:
    │   ├── Visit neighbor: 5 (not visited)
    │   │   ├── Enqueue 5, Mark visit[5] = true, Queue: [5]
    ├── Dequeue 5, Visit neighbors:
    │   ├── Visit neighbor: 4 (already visited, skip)
    ├── Queue empty → Return to NCCBFSCountComponents

Start BFS at node 5 (already visited, skip)

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