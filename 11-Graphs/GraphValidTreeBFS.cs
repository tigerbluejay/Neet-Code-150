public partial class Solution {
    public bool GVTBFSValidTree(int n, int[][] edges) {
        
        // A valid tree must have exactly n-1 edges.
        // If there are more edges than n-1, then either there's a cycle or redundancy, making it invalid.
        if (edges.Length > n - 1) {
            return false;
        }

        // Initialize an adjacency list to represent the undirected graph.
        List<List<int>> adj = new List<List<int>>();
        for (int i = 0; i < n; i++) {
            adj.Add(new List<int>());
        }

        // Populate the adjacency list with bidirectional edges.
        foreach (var edge in edges) {
            adj[edge[0]].Add(edge[1]);
            adj[edge[1]].Add(edge[0]);
        }

        // Use a HashSet to track visited nodes.
        HashSet<int> visit = new HashSet<int>();

        // Use a queue for BFS traversal. Each entry stores (current node, parent node).
        Queue<(int, int)> q = new Queue<(int, int)>();
        q.Enqueue((0, -1));  // Start BFS from node 0, with parent set as -1 (null parent).
        visit.Add(0);

        while (q.Count > 0) {
            var (node, parent) = q.Dequeue();

            // Explore all neighbors of the current node.
            foreach (var nei in adj[node]) {
                // Ignore the edge that leads back to the parent (to avoid falsely detecting a cycle).
                if (nei == parent) {
                    continue;
                }
                // If the neighbor has already been visited, a cycle is detected, so it's not a valid tree.
                if (visit.Contains(nei)) {
                    return false;
                }
                // Mark the neighbor as visited and enqueue it for further exploration.
                visit.Add(nei);
                q.Enqueue((nei, node));
            }
        }

        // After BFS, check if all nodes were visited.
        // If not, the graph is disconnected, meaning it's not a valid tree.
        return visit.Count == n;
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