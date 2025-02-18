public partial class Solution {
    public int[] RCKAFindRedundantConnection(int[][] edges) {
        int n = edges.Length;  // Number of edges in the graph
        int[] indegree = new int[n + 1];  // Array to store the degree (number of neighbors) of each node
        List<int>[] adj = new List<int>[n + 1];  // Adjacency list to represent the graph
        
        // Initialize the adjacency list for each node
        for (int i = 0; i <= n; i++) adj[i] = new List<int>();

        // Loop through each edge and build the graph
        foreach (var edge in edges) {
            int u = edge[0], v = edge[1];  // Extract the two nodes connected by the edge
            adj[u].Add(v);  // Add node v to the adjacency list of node u
            adj[v].Add(u);  // Add node u to the adjacency list of node v
            indegree[u]++;  // Increment the degree (neighbor count) for node u
            indegree[v]++;  // Increment the degree (neighbor count) for node v
        }

        // Initialize a queue to perform the process of pruning leaves (nodes with degree 1)
        Queue<int> q = new Queue<int>();
        
        // Add all nodes with degree 1 (leaf nodes) to the queue
        for (int i = 1; i <= n; i++) {
            if (indegree[i] == 1) q.Enqueue(i);
        }

        // Start the pruning process
        while (q.Count > 0) {
            int node = q.Dequeue();  // Remove a node from the queue (starting from leaves)
            indegree[node]--;  // Decrease the degree of the current node (it’s being removed)

            // For each neighbor of the current node
            foreach (int nei in adj[node]) {
                indegree[nei]--;  // Decrease the degree of the neighbor (since we're "removing" node from graph)

                // If a neighbor becomes a leaf node (degree 1), add it to the queue
                if (indegree[nei] == 1) q.Enqueue(nei);
            }
        }

        // After pruning leaves, check the edges to find the redundant connection
        // The last edge that connects two nodes where both have degree 2 will be the redundant edge
        for (int i = edges.Length - 1; i >= 0; i--) {
            int u = edges[i][0], v = edges[i][1];
            if (indegree[u] == 2 && indegree[v] > 0)  // We found the redundant edge
                return new int[] {u, v};  // Return the redundant edge
        }

        return new int[0];  // Return an empty array if no redundant connection is found
    }
}
/*
Input:
edges = [[1,2],[1,3],[3,4],[2,4]]

Initial Graph Construction:
Adjacency List:
1 -> [2, 3]
2 -> [1, 4]
3 -> [1, 4]
4 -> [2, 3]

Indegree Array:
1: 2, 2: 2, 3: 2, 4: 2

Initial Queue (Nodes with Degree 1):
Queue is empty (no node with degree 1)

Finding Redundant Edge

Now that the pruning process is skipped, the algorithm moves on to the second part, which checks the edges in 
reverse order to identify the redundant edge.

It starts from the last edge and works backwards, checking if both nodes of the edge still have an indegree of 2, 
which would mean the edge is redundant.

The algorithm does this with the following loop:

for (int i = edges.Length - 1; i >= 0; i--) {
    int u = edges[i][0], v = edges[i][1];
    if (indegree[u] == 2 && indegree[v] > 0) 
        return new int[] {u, v};
}
The first edge to be checked in reverse order is [2, 4].
Indegree of 2 and 4 is 2 after pruning.

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