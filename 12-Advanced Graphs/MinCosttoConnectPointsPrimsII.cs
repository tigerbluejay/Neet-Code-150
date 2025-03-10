public partial class Solution {
    public int MCCPPIIMinCostConnectPoints(int[][] points) {
        int n = points.Length; // Number of points
        int node = 0; // Start with the first node
        int[] dist = new int[n]; // Array to store minimum distances to MST (Minimum Spanning Tree)
        bool[] visit = new bool[n]; // Boolean array to keep track of visited nodes
        
        // Initialize distance array with a large value (effectively infinity)
        Array.Fill(dist, 100000000);
        
        int edges = 0; // Count of edges added to the MST
        int res = 0; // Variable to store the final cost of connecting all points

        while (edges < n - 1) { // Since MST for n nodes has (n - 1) edges
            visit[node] = true; // Mark the current node as visited
            int nextNode = -1; // Variable to track the next node to be added to MST
            
            for (int i = 0; i < n; i++) { // Iterate over all points
                if (visit[i]) continue; // Skip already visited nodes
                
                // Calculate Manhattan distance between the current node and node 'i'
                int curDist = Math.Abs(points[i][0] - points[node][0]) + 
                               Math.Abs(points[i][1] - points[node][1]);
                
                // Update the minimum distance for node 'i'
                dist[i] = Math.Min(dist[i], curDist);
                
                // Find the node with the smallest distance to MST
                if (nextNode == -1 || dist[i] < dist[nextNode]) {
                    nextNode = i;
                }
            }
            
            // Add the minimum edge to the result (cost of MST)
            res += dist[nextNode];
            
            // Move to the next node
            node = nextNode;
            edges++; // Increment the count of edges added to the MST
        }
        
        return res; // Return the total minimum cost to connect all points
    }
}
/*
Prim's algorithm never forms a cycle (unlike Dijkstra’s, which finds shortest paths to all nodes from a 
single source).
It always picks the globally best edge, meaning that no unnecessary longer edge can sneak in.
Because we always take the best option at every step, we never have to "backtrack" to replace a longer 
edge with a shorter one.
4. Why It’s Different from Dijkstra’s Algorithm
Dijkstra’s Algorithm and Prim’s Algorithm look similar, but their goals are different:

Algorithm	Goal
Prim’s Algorithm	Finds the cheapest way to connect all nodes (MST)
Dijkstra’s Algorithm	Finds the shortest path from one node to all others

Prim's Algorithm doesn’t care about the path between two specific points—it just builds the 
minimum-cost way to connect everything.
Dijkstra’s Algorithm finds the shortest distance from a single starting node to all others.
*/

/*
Iteration 1:
Current node: 0 [0,0]
Visit: [true, false, false, false, false]
Distances: [INF, 4, 6, 6, 6]
Next node: 1
Total cost: 4

Iteration 2:
Current node: 1 [2,2]
Visit: [true, true, false, false, false]
Distances: [INF, 4, 2, 2, 2]
Next node: 2
Total cost: 6

Iteration 3:
Current node: 2 [3,3]
Visit: [true, true, true, false, false]
Distances: [INF, 4, 2, 2, 2]
Next node: 3
Total cost: 8

Iteration 4:
Current node: 3 [2,4]
Visit: [true, true, true, true, false]
Distances: [INF, 4, 2, 2, 2]
Next node: 4
Total cost: 10

Final Output: 10
*/

/*
Min Cost to Connect Points

You are given a 2-D integer array points, where points[i] = [xi, yi]. 
Each points[i] represents a distinct point on a 2-D plane.

The cost of connecting two points [xi, yi] and [xj, yj] is the manhattan distance between the two points, 
i.e. |xi - xj| + |yi - yj|.

Return the minimum cost to connect all points together, such that there exists exactly one path between 
each pair of points.

Example 1:
Input: points = [[0,0],[2,2],[3,3],[2,4],[4,2]]
Output: 10

Constraints:
1 <= points.length <= 1000
-1000 <= xi, yi <= 1000
*/