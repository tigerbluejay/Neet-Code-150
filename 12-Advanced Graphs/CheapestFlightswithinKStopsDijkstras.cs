public partial class Solution {
    public int DAFindCheapestPrice(int n, int[][] flights, int src, int dst, int k) {
        int INF = int.MaxValue;  // Define an "infinity" value for unvisited nodes
        
        // Create an adjacency list representation of the graph
        List<int[]>[] adj = new List<int[]>[n];
        
        // Distance table: dist[i][j] represents the min cost to reach node i with j stops
        int[][] dist = new int[n][];

        for (int i = 0; i < n; i++) {
            adj[i] = new List<int[]>();  // Initialize adjacency list for each node
            dist[i] = new int[k + 2];  // We track up to (k + 1) stops
            Array.Fill(dist[i], INF);  // Initialize all distances to "infinity"
        }

        // Populate adjacency list with flight data
        foreach (var flight in flights) {
            adj[flight[0]].Add(new int[] { flight[1], flight[2] });  // (destination, price)
        }

        // Start from the source with cost 0 and 0 stops
        dist[src][0] = 0;
        
        // Priority queue (MinHeap) to always expand the lowest-cost path first
        var minHeap = new PriorityQueue<(int cst, int node, int stops), int>();
        minHeap.Enqueue((0, src, 0), 0);  // Enqueue (cost, source node, stops) with priority = cost

        // Dijkstra-like traversal with stop constraints
        while (minHeap.Count > 0) {
            var (cst, node, stops) = minHeap.Dequeue();  // Get the node with the lowest cost

            // If we reached the destination, return the cost
            if (node == dst) return cst;

            // If we exceeded the allowed stops (k), skip further processing
            if (stops > k) continue;

            // Explore neighbors (adjacent nodes)
            foreach (var neighbor in adj[node]) {
                int nei = neighbor[0], w = neighbor[1];  // Destination and weight of the edge
                int nextCst = cst + w;  // Calculate the new cost
                int nextStops = stops + 1;  // Increment the stop count

                // If we found a cheaper way to reach 'nei' within 'nextStops', update and enqueue
                if (dist[nei][nextStops] > nextCst) {
                    dist[nei][nextStops] = nextCst;
                    minHeap.Enqueue((nextCst, nei, nextStops), nextCst);  // Push into the heap
                }
            }
        }

        // If we exhaust all paths without reaching the destination, return -1
        return -1;
    }
}

/*
Key Points:
Graph Representation:

Uses an adjacency list (adj) where each node stores (neighbor, price) pairs.
Example for flights = [[0,1,200],[1,2,100],[1,3,300],[2,3,100]]:
adj[0] → [(1, 200)]
adj[1] → [(2, 100), (3, 300)]
adj[2] → [(3, 100)]

Priority Queue (MinHeap) for Efficient Processing:
Always expands the cheapest path first.
Stores (cost, node, stops) and sorts by cost.

Tracking Costs with Stops:
dist[node][stops] keeps the minimum cost to reach node using stops stops.

If a cheaper route is found within allowed stops, it gets updated and pushed into the heap.

Early Termination:

If we dequeue a node and it’s the destination, return immediately (greedy approach).
If we exceed k stops, we skip further exploration.
*/
/*
Input:
n = 4, 
flights = [[0,1,200],[1,2,100],[1,3,300],[2,3,100]], 
src = 0, dst = 3, k = 1

Graph Representation (adj List)
adj[0] → [(1, 200)]
adj[1] → [(2, 100), (3, 300)]
adj[2] → [(3, 100)]

This means:
0 → 1 with cost 200
1 → 2 with cost 100
1 → 3 with cost 300
2 → 3 with cost 100

Priority Queue (minHeap) Evolution
Initial State:
minHeap = [(0, src=0, stops=0)]  // Start from node 0 with cost 0
dist[0][0] = 0

Step 1: Dequeue (0, 0, 0) → Explore neighbors of 0
Processing node 0 with cost=0, stops=0
  - 0 → 1 (cost=200)
    - Push (200, 1, 1) into minHeap
    - Update dist[1][1] = 200
Queue after Step 1:
minHeap = [(200, 1, 1)]

Step 2: Dequeue (200, 1, 1) → Explore neighbors of 1
Processing node 1 with cost=200, stops=1
  - 1 → 2 (cost=100)
    - Total cost = 200 + 100 = 300
    - Push (300, 2, 2) into minHeap
    - Update dist[2][2] = 300
  - 1 → 3 (cost=300)
    - Total cost = 200 + 300 = 500
    - Push (500, 3, 2) into minHeap
    - Update dist[3][2] = 500
Queue after Step 2:
minHeap = [(300, 2, 2), (500, 3, 2)]

Step 3: Dequeue (300, 2, 2) → Explore neighbors of 2
Processing node 2 with cost=300, stops=2
  - 2 → 3 (cost=100)
    - Total cost = 300 + 100 = 400
    - But stops = 3 (exceeds k=1), so we ignore it
Queue after Step 3:
minHeap = [(500, 3, 2)]

Step 4: Dequeue (500, 3, 2) → Destination reached
Processing node 3 with cost=500, stops=2
  - Destination reached → return 500
Final Answer:
Output: 500
*/


/*
Cheapest Flights Within K Stops
There are n airports, labeled from 0 to n - 1, which are connected by some flights. 
You are given an array flights where flights[i] = [from_i, to_i, price_i] represents a 
one-way flight from airport from_i to airport to_i with cost price_i. You may assume there are no 
duplicate flights and no flights from an airport to itself.

You are also given three integers src, dst, and k where:

src is the starting airport
dst is the destination airport
src != dst
k is the maximum number of stops you can make (not including src and dst)
Return the cheapest price from src to dst with at most k stops, or return -1 if it is impossible.

Example 1:
Input: n = 4, flights = [[0,1,200],[1,2,100],[1,3,300],[2,3,100]], src = 0, dst = 3, k = 1
Output: 500
Explanation:
The optimal path with at most 1 stop from airport 0 to 3 is shown in red, with total cost 200 + 300 = 500.
Note that the path [0 -> 1 -> 2 -> 3] costs only 400, and thus is cheaper, but it requires 2 stops, 
which is more than k.

Example 2:
Input: n = 3, flights = [[1,0,100],[1,2,200],[0,2,100]], src = 1, dst = 2, k = 1
Output: 200
Explanation:
The optimal path with at most 1 stop from airport 1 to 2 is shown in red and has cost 200.

Constraints:
1 <= n <= 100
fromi != toi
1 <= pricei <= 1000
0 <= src, dst, k < n
*/