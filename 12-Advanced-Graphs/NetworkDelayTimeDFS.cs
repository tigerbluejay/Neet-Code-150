public partial class Solution {
    // Method to compute the time for all nodes to receive the signal from node k using DFS.
    public int NDTDFSNetworkDelayTime(int[][] times, int n, int k) {
        // Adjacency list to store the directed graph (node -> list of (neighbor, travel time))
        var adj = new Dictionary<int, List<int[]>>();
        foreach (var time in times) {
            if (!adj.ContainsKey(time[0])) {
                adj[time[0]] = new List<int[]>();
            }
            adj[time[0]].Add(new int[] { time[1], time[2] }); // Add edge (destination, time)
        }

        // Dictionary to track the minimum time required to reach each node
        var dist = new Dictionary<int, int>();
        for (int i = 1; i <= n; i++) 
            dist[i] = int.MaxValue; // Initialize all distances to infinity (unreachable)

        // Start DFS traversal from node k with initial time 0
        NDTDfs(k, 0, adj, dist);

        // The result is the maximum time taken to reach any node
        int res = dist.Values.Max();
        return res == int.MaxValue ? -1 : res; // If any node is unreachable, return -1
    }

    // Depth-First Search (DFS) helper function
    private void NDTDfs(int node, int time, 
                     Dictionary<int, List<int[]>> adj, 
                     Dictionary<int, int> dist) {
        // If the current path takes longer than an already found shorter path, stop
        if (time >= dist[node]) return;

        // Update the shortest time to reach this node
        dist[node] = time;

        // If there are no outgoing edges from this node, stop
        if (!adj.ContainsKey(node)) return;

        // Explore all neighboring nodes (DFS traversal)
        foreach (var edge in adj[node]) {
            NDTDfs(edge[0], time + edge[1], adj, dist); // Recursive DFS call
        }
    }
}
/*
Input:
times = [[1,2,1], [2,3,1], [1,4,4], [3,4,1]]
n = 4
k = 1

Graph Representation (Adjacency List):
1 -> [(2,1), (4,4)]
2 -> [(3,1)]
3 -> [(4,1)]
4 -> []

Recursive DFS Calls (Tree-Like Structure)
NDTDfs(1, 0)   // Start at node 1 with time 0
│
├── NDTDfs(2, 1)   // Move to node 2 with time 1
│   │
│   ├── NDTDfs(3, 2)   // Move to node 3 with time 2
│   │   │
│   │   ├── NDTDfs(4, 3)   // Move to node 4 with time 3
│   │   │   ├── No more children, return
│   │   │
│   │   └── Return to NDTDfs(3, 2)
│   │
│   └── Return to NDTDfs(2, 1)
│
├── NDTDfs(4, 4)   // Move to node 4 directly from node 1 with time 4
│   ├── Already reached node 4 with a shorter time (3), so return
│
└── Return to NDTDfs(1, 0)

Final Distance Dictionary (dist):
{
    1: 0,
    2: 1,
    3: 2,
    4: 3
}
*/


/*
Network Delay Time

You are given a network of n directed nodes, labeled from 1 to n. 
You are also given times, a list of directed edges where times[i] = (ui, vi, ti).

ui is the source node (an integer from 1 to n)
vi is the target node (an integer from 1 to n)
ti is the time it takes for a signal to travel from the source to the target node 
(an integer greater than or equal to 0).
You are also given an integer k, representing the node that we will send a signal from.

Return the minimum time it takes for all of the n nodes to receive the signal. 
If it is impossible for all the nodes to receive the signal, return -1 instead.

Example 1:
Input: times = [[1,2,1],[2,3,1],[1,4,4],[3,4,1]], n = 4, k = 1
Output: 3

Example 2:
Input: times = [[1,2,1],[2,3,1]], n = 3, k = 2
Output: -1

Constraints:
1 <= k <= n <= 100
1 <= times.length <= 1000
*/