public partial class Solution {
    public int MCCPPIMinCostConnectPoints(int[][] points) {
        int N = points.Length;

        // Step 1: Construct the adjacency list (Graph representation)
        var adj = new Dictionary<int, List<int[]>>();
        for (int i = 0; i < N; i++) {
            int x1 = points[i][0];
            int y1 = points[i][1];

            for (int j = i + 1; j < N; j++) { // Avoid duplicate edges
                int x2 = points[j][0];
                int y2 = points[j][1];

                // Calculate Manhattan distance between points i and j
                int dist = Math.Abs(x1 - x2) + Math.Abs(y1 - y2);

                // Add edge to adjacency list for both points
                // {
                // 0: [(1, 4), (2, 6), (3, 6), (4, 6)],  
                // 1: [(0, 4), (2, 2), (3, 2), (4, 2)],  
                // 2: [(0, 6), (1, 2), (3, 2), (4, 2)],  
                // 3: [(0, 6), (1, 2), (2, 2), (4, 4)],  
                // 4: [(0, 6), (1, 2), (2, 2), (3, 4)]
                // }
                if (!adj.ContainsKey(i)) 
                    adj[i] = new List<int[]>();
                adj[i].Add(new int[] { j, dist });

                if (!adj.ContainsKey(j)) 
                    adj[j] = new List<int[]>();
                adj[j].Add(new int[] { i, dist });
            }
            /*
            Step-by-Step Execution
            We'll iterate through all pairs (i, j) and compute the Manhattan distance:

            1st Iteration (i=0)
            (0,1) → |0 - 2| + |0 - 2| = 4
            adj[0] = [(1, 4)]
            adj[1] = [(0, 4)]
            (0,2) → |0 - 3| + |0 - 3| = 6
            adj[0] = [(1, 4), (2, 6)]
            adj[2] = [(0, 6)]
            (0,3) → |0 - 2| + |0 - 4| = 6
            adj[0] = [(1, 4), (2, 6), (3, 6)]
            adj[3] = [(0, 6)]
            (0,4) → |0 - 4| + |0 - 2| = 6
            adj[0] = [(1, 4), (2, 6), (3, 6), (4, 6)]
            adj[4] = [(0, 6)]

            2nd Iteration (i=1)
            (1,2) → |2 - 3| + |2 - 3| = 2
            adj[1] = [(0, 4), (2, 2)]
            adj[2] = [(0, 6), (1, 2)]
            (1,3) → |2 - 2| + |2 - 4| = 2
            adj[1] = [(0, 4), (2, 2), (3, 2)]
            adj[3] = [(0, 6), (1, 2)]
            (1,4) → |2 - 4| + |2 - 2| = 2
            adj[1] = [(0, 4), (2, 2), (3, 2), (4, 2)]
            adj[4] = [(0, 6), (1, 2)]

            3rd Iteration (i=2)
            (2,3) → |3 - 2| + |3 - 4| = 2
            adj[2] = [(0, 6), (1, 2), (3, 2)]
            adj[3] = [(0, 6), (1, 2), (2, 2)]
            (2,4) → |3 - 4| + |3 - 2| = 2
            adj[2] = [(0, 6), (1, 2), (3, 2), (4, 2)]
            adj[4] = [(0, 6), (1, 2), (2, 2)]

            4th Iteration (i=3)
            (3,4) → |2 - 4| + |4 - 2| = 4
            adj[3] = [(0, 6), (1, 2), (2, 2), (4, 4)]
            adj[4] = [(0, 6), (1, 2), (2, 2), (3, 4)]
            */

        }

        // Step 2: Prim's Algorithm Initialization
        int res = 0; // Stores the total minimum cost
        var visit = new HashSet<int>(); // Tracks visited nodes
        var pq = new PriorityQueue<int, int>(); // Min-heap (priority queue)
        
        pq.Enqueue(0, 0); // Start from point 0 with cost 0

        // Step 3: Process nodes until all are connected
        while (visit.Count < N && pq.Count > 0) {
            if (pq.TryPeek(out int i, out int cost)) {
                pq.Dequeue(); // Extract the minimum-cost edge

                if (visit.Contains(i)) {
                    continue; // Skip if already visited
                }

                res += cost; // Add edge cost to total
                visit.Add(i); // Mark node as visited

                // Step 4: Add adjacent edges to priority queue
                if (adj.ContainsKey(i)) {
                    foreach (var edge in adj[i]) {
                        var nei = edge[0];
                        var neiCost = edge[1];

                        if (!visit.Contains(nei)) {
                            pq.Enqueue(nei, neiCost); // Add neighbor to heap
                        }
                    }
                }
            }
        }

        // If all points are visited, return total cost, otherwise return -1
        return visit.Count == N ? res : -1;
    }
}
/*
Prim’s Algorithm solves the Minimum Cost to Connect Points problem by incrementally building a 
Minimum Spanning Tree (MST), starting from an arbitrary point and growing the tree by always 
adding the cheapest edge that connects a visited point to an unvisited one. First, it constructs 
an adjacency list representing the Manhattan distances between all pairs of points. Then, it uses 
a priority queue (min-heap) to repeatedly extract the smallest edge connecting the MST to an 
unvisited point. Each selected point is marked as visited, and its adjacent edges are pushed 
into the priority queue. This process continues until all points are connected, ensuring that 
the total cost is minimized efficiently.
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