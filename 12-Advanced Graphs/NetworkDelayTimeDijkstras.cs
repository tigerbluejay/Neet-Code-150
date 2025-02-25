public partial class Solution {
    public int NDTDNetworkDelayTime(int[][] times, int n, int k) {
        // Step 1: Build the adjacency list representation of the graph.
        // Each node maps to a list of {destination, weight} pairs.
        /*
        edges = {
         1: [[2,1], [4,4]],
         2: [[3,1]],
         3: [[4,1]]
        }
        */
        var edges = new Dictionary<int, List<int[]>>();
        foreach (var time in times) {
            if (!edges.ContainsKey(time[0])) {
                edges[time[0]] = new List<int[]>();
            }
            edges[time[0]].Add(new int[] { time[1], time[2] });
        }

        // Step 2: Priority queue (Min-Heap) for Dijkstra's Algorithm.
        // The queue stores {node, distance} pairs, ordered by the shortest distance.
        var pq = new PriorityQueue<int, int>();
        pq.Enqueue(k, 0); // Start from node k with time 0.

        // Step 3: Distance dictionary to store the shortest known distance to each node.
        /*
        dist = new Dictionary<int, int> {
          {1, 0},
          {2, int.MaxValue},
          {3, int.MaxValue},
          {4, int.MaxValue}
        };
        */
        var dist = new Dictionary<int, int>();
        for (int i = 1; i <= n; i++) {
            dist[i] = int.MaxValue; // Initialize all distances to infinity.
        }
        dist[k] = 0; // The starting node k has a distance of 0.

        // Step 4: Process the priority queue (Dijkstra's algorithm).
        while (pq.Count > 0) {
            // Extract the node with the minimum known distance.
            if (pq.TryDequeue(out int node, out int minDist)) {
                // Skip if a shorter distance has already been recorded.
                if (minDist > dist[node]) {
                    continue;
                }

                // Step 5: Relaxation process - update the distances of adjacent nodes.
                if (edges.ContainsKey(node)) {
                    foreach (var edge in edges[node]) {
                        var next = edge[0];   // Neighboring node
                        var weight = edge[1]; // Edge weight
                        var newDist = minDist + weight; // Calculate new possible distance

                        // If a shorter path to 'next' is found, update the distance and enqueue.
                        if (newDist < dist[next]) {
                            dist[next] = newDist;
                            pq.Enqueue(next, newDist);
                        }
                    }
                }
            }
        }

        // Step 6: Find the maximum shortest path to determine the network delay time.
        int result = 0;
        for (int i = 1; i <= n; i++) {
            if (dist[i] == int.MaxValue) return -1; // If any node is unreachable, return -1.
            result = Math.Max(result, dist[i]); // Track the longest shortest path.
        }

        return result;
    }
}
/*
Start: Node 1 (Source) with time 0  
Queue: [(1, 0)]  
dist = { 1: 0, 2: ∞, 3: ∞, 4: ∞ }
------------------------------------------------
Processing Node 1 (Time 0)
 ├──> Reaches Node 2 in Time 1 (Updated: dist[2] = 1)
 ├──> Reaches Node 4 in Time 4 (Updated: dist[4] = 4)
Queue: [(2, 1), (4, 4)]  
dist = { 1: 0, 2: 1, 3: ∞, 4: 4 }
------------------------------------------------
Processing Node 2 (Time 1)
 ├──> Reaches Node 3 in Time 2 (Updated: dist[3] = 2)
Queue: [(3, 2), (4, 4)]  
dist = { 1: 0, 2: 1, 3: 2, 4: 4 }
------------------------------------------------
Processing Node 3 (Time 2)
 ├──> Reaches Node 4 in Time 3 (Updated: dist[4] = 3, as 3 < 4)
Queue: [(4, 3)]  
dist = { 1: 0, 2: 1, 3: 2, 4: 3 }
------------------------------------------------
Processing Node 4 (Time 3)
 ├──> No new updates (All neighbors already visited with shorter time)
Queue: [] (Empty)  
------------------------------------------------
Final Distances:
dist = { 1: 0, 2: 1, 3: 2, 4: 3 }
Answer: 3 (Maximum time needed to reach all nodes)
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