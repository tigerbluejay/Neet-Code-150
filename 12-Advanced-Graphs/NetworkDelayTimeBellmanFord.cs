public partial class Solution {
    public int NDTBFNetworkDelayTime(int[][] times, int n, int k) {
        // Step 1: Initialize the distance array
        // `dist[i]` represents the shortest known distance from the source node `k` to node `i + 1`
        // Initially, all nodes are set to `int.MaxValue` (infinity) to signify they are unreachable
        int[] dist = Enumerable.Repeat(int.MaxValue, n).ToArray();
        
        // Set the distance to the starting node `k` to 0
        dist[k - 1] = 0;

        // Step 2: Relax all edges up to (n - 1) times
        // Bellman-Ford runs (n - 1) iterations, since the shortest path in a graph with `n` nodes
        // can be at most `n - 1` edges long.
        for (int i = 0; i < n - 1; i++) {
            bool updated = false; // Optimization: track if any update is made
            
            // Iterate through all edges and attempt to relax them
            foreach (var time in times) {
                int u = time[0] - 1, // Convert 1-based to 0-based index for `u`
                    v = time[1] - 1, // Convert 1-based to 0-based index for `v`
                    w = time[2];     // Weight of the edge (time delay)

                // If node `u` has been reached (`dist[u]` is not infinity) and 
                // the path through `u` offers a shorter route to `v`, update `dist[v]`
                if (dist[u] != int.MaxValue && dist[u] + w < dist[v]) {
                    dist[v] = dist[u] + w;
                    updated = true; // Track that at least one distance was updated
                }
            }
            
            // Optimization: If no update was made in an entire pass, we can terminate early
            if (!updated) break;
        }

        // Step 3: Find the longest shortest path from the source node `k`
        int maxDist = dist.Max();

        // If any node is still at `int.MaxValue`, it means it was never reached, return -1
        return maxDist == int.MaxValue ? -1 : maxDist;
    }
}

/*
Explanation of the Algorithm:

Initialization:
Create a dist array initialized to int.MaxValue (infinity), except for dist[k-1] = 0 (starting node).

Relaxation Process:
Iterate n-1 times, where n is the number of nodes.
For each edge (u, v, w), update dist[v] if dist[u] + w < dist[v].

Optimization:
If in an iteration, no dist[v] is updated, stop early (as further iterations will not change results).

Result Calculation:
Find the longest shortest path from k (i.e., the maximum value in dist).
If any node remains unreachable (int.MaxValue), return -1.

This implementation efficiently determines the minimum time required for all nodes to receive 
the signal using Bellman-Ford, which works well when edge weights can be negative 
(though this problem only has non-negative weights).
*/