public partial class Solution {
    public int NDTFWNetworkDelayTime(int[][] times, int n, int k) {
        int inf = int.MaxValue / 2; // A large value to represent infinity (avoid overflow)
        int[,] dist = new int[n, n]; // Distance matrix to store shortest paths
        
        // Initialize the distance matrix 
        /*
                1      2      3      4
            1   0    inf    inf    inf
            2  inf     0    inf    inf
            3  inf   inf      0    inf
            4  inf   inf    inf      0 
            
        */
        for (int i = 0; i < n; i++) {
            for (int j = 0; j < n; j++) {
                dist[i, j] = i == j ? 0 : inf; // Distance to itself is 0, others are infinite initially
            }
        }
        /*
                1      2      3      4
            1   0      1    inf      4
            2  inf     0      1    inf
            3  inf   inf      0      1
            4  inf   inf    inf      0
        */
        // Fill in the given edge weights from input `times`
        // note that the time array holds in time[0] the origin node, in time[1] the destination node
        // and in time[2] the time.
        foreach (var time in times) {
            int u = time[0] - 1, v = time[1] - 1, w = time[2]; // Convert to 0-based indexing
            dist[u, v] = w; // Direct edge weight between u and v
        }
        
        // Floyd-Warshall Algorithm: Update shortest distances between all pairs
        for (int mid = 0; mid < n; mid++) { // Consider each node as an intermediate point
            for (int i = 0; i < n; i++) { // Iterate over all source nodes
                for (int j = 0; j < n; j++) { // Iterate over all destination nodes
                    // Update the shortest distance from `i` to `j` using `mid` as an intermediate node
                    // in other words, if we included mid node as an intermediate between source and destination
                    // nodes, would the path shorten?
                    // this is answered by the formula below:
                    // dist[i][j]=min(dist[i][j],dist[i][mid]+dist[mid][j])
                    dist[i, j] = Math.Min(dist[i, j], dist[i, mid] + dist[mid, j]);
                }
            }
        }
        // and the table is updated 4 times, considering each iteration of mid, in its final form
        // the table looks like this:
        /*
                1      2      3      4
            1   0      1      2      3
            2  inf     0      1      2
            3  inf   inf      0      1
            4  inf   inf    inf      0
        */
        
        // Extract the maximum time needed to reach any node from the source `k-1` (0-based)
        int res = Enumerable.Range(0, n).Select(i => dist[k-1, i]).Max();
        
        // If any node is unreachable (still has `inf` distance), return -1
        return res == inf ? -1 : res;
    }
}

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