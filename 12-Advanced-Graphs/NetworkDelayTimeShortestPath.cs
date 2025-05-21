public partial class Solution {
    public int NDTSPNetworkDelayTime(int[][] times, int n, int k) {
        // Adjacency list representation of the graph.
        // Each node maps to a list of {destination, weight} pairs.
        var adj = new Dictionary<int, List<int[]>>();
        for (int i = 1; i <= n; i++) adj[i] = new List<int[]>();

        // Populate adjacency list with given directed edges.
        /*
        adj = {
            1: [[2, 1], [4, 4]],  // Node 1 connects to 2 (weight=1), 4 (weight=4)
            2: [[3, 1]],          // Node 2 connects to 3 (weight=1)
            3: [[4, 1]],          // Node 3 connects to 4 (weight=1)
            4: []                 // Node 4 has no outgoing edges
        }
        */
        foreach (var time in times) {
            adj[time[0]].Add(new int[] {time[1], time[2]});
        }
        
        // Dictionary to store the shortest known distance to each node.
        var dist = new Dictionary<int, int>();
        for (int i = 1; i <= n; i++) dist[i] = int.MaxValue; // Initialize all distances to infinity.
        dist[k] = 0; // Starting node has a distance of 0.

        // Queue for processing nodes in a BFS-like manner.
        var q = new Queue<int[]>();
        q.Enqueue(new int[] {k, 0}); // Start from node k with time 0.

        while (q.Count > 0) {
            var curr = q.Dequeue();
            int node = curr[0], time = curr[1];

            // If we already found a shorter path to this node, skip processing.
            if (dist[node] < time) continue;

            // Explore neighbors of the current node.
            foreach (var nei in adj[node]) {
                int nextNode = nei[0], weight = nei[1];

                // If a shorter path to nextNode is found, update the distance and enqueue it.
                if (time + weight < dist[nextNode]) {
                    dist[nextNode] = time + weight;
                    q.Enqueue(new int[] {nextNode, time + weight});
                }
            }
        }

        // Find the maximum shortest time to reach any node.
        int res = 0;
        foreach (var time in dist.Values) { 
            res = Math.Max(res, time);
        }

        // If any node is still unreachable (int.MaxValue), return -1.
        return res == int.MaxValue ? -1 : res;
    }
}
/*
Start BFS from node 1 (k = 1, time = 0)

1 (time=0)
│
├──> 2 (time=1)  [from edge (1 -> 2) with weight 1]
│    │
│    └──> 3 (time=2)  [from edge (2 -> 3) with weight 1]
│         │
│         └──> 4 (time=3)  [from edge (3 -> 4) with weight 1]
│
└──> 4 (time=4)  [from edge (1 -> 4) with weight 4, ignored since 3 is shorter]

BFS step-by-step processing:

Start at node 1 (k=1), with dist[1] = 0.

Process node 1, explore its neighbors:
Visit 2, update dist[2] = 1, enqueue (2, 1).
Visit 4 via (1 → 4, weight=4), update dist[4] = 4, enqueue (4, 4).

Process node 2:
Visit 3, update dist[3] = 2, enqueue (3, 2).

Process node 3:
Visit 4, update dist[4] = 3 (shorter than 4), enqueue (4, 3).

Process node 4 (time=3).
Process node 4 again (time=4), but ignore it since a shorter time (3) was already found.
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