public partial class Solution {
    public int SPFindCheapestPrice(int n, int[][] flights, int src, int dst, int k) {
        // Array to store the minimum cost to reach each node
        int[] prices = new int[n];
        Array.Fill(prices, int.MaxValue); // Initialize all prices to "infinity"
        prices[src] = 0; // Cost to reach the source node is always 0

        // Adjacency list to store flight connections and costs
        List<int[]>[] adj = new List<int[]>[n];
        for (int i = 0; i < n; i++) {
            adj[i] = new List<int[]>();
        }

        // Build the adjacency list from the given flight data
        foreach (var flight in flights) {
            adj[flight[0]].Add(new int[] { flight[1], flight[2] });
        }

        // Queue to perform a modified BFS: (current cost, current node, stops used)
        var q = new Queue<(int cst, int node, int stops)>();
        q.Enqueue((0, src, 0)); // Start from the source with cost 0 and 0 stops

        while (q.Count > 0) {
            var (cst, node, stops) = q.Dequeue(); // Dequeue an element

            // If the number of stops exceeds k, ignore this path
            if (stops > k) continue;

            // Explore all neighboring nodes (direct flights from the current node)
            foreach (var neighbor in adj[node]) {
                int nei = neighbor[0], w = neighbor[1]; // Destination and cost of the flight
                int nextCost = cst + w; // Compute the cost of reaching the neighbor

                // If this new cost is cheaper than the previously known cost, update and continue
                if (nextCost < prices[nei]) {
                    prices[nei] = nextCost; // Update the price for this node
                    q.Enqueue((nextCost, nei, stops + 1)); // Enqueue with updated cost and stops
                }
            }
        }

        // If the destination remains at int.MaxValue, there was no valid path within k stops
        return prices[dst] == int.MaxValue ? -1 : prices[dst];
    }
}
/*
Explanation:
Graph Representation: Uses an adjacency list to store flight routes and their costs.
Breadth-First Search (BFS): Modified to track stops and minimize costs.
Queue Processing: Stores (cost, node, stops) to process nodes level-by-level.
Early Termination: Stops processing a node’s neighbors if exceeding k stops.
*/

/*
Input:
n = 4
flights = [[0,1,200],[1,2,100],[1,3,300],[2,3,100]]
src = 0, dst = 3, k = 1

--------------------------------------------------
Step 1: Initialization
--------------------------------------------------
prices[] = [0, ∞, ∞, ∞]   // Cost to reach each node (0 means source node)
q = [(0, 0, 0)]           // Start BFS from (cost=0, node=0, stops=0)

--------------------------------------------------
Step 2: Dequeue (0, 0, 0)
--------------------------------------------------
Processing node 0 with cost 0 and stops 0

  - Exploring neighbor: (0 → 1, cost = 200)
    * Updated price[1] = 200
    * Enqueue (200, 1, 1)

q = [(200, 1, 1)]
prices[] = [0, 200, ∞, ∞]

--------------------------------------------------
Step 3: Dequeue (200, 1, 1)
--------------------------------------------------
Processing node 1 with cost 200 and stops 1

  - Exploring neighbor: (1 → 2, cost = 100)
    * Updated price[2] = 300
    * Enqueue (300, 2, 2)

  - Exploring neighbor: (1 → 3, cost = 300)
    * Updated price[3] = 500
    * Enqueue (500, 3, 2)

q = [(300, 2, 2), (500, 3, 2)]
prices[] = [0, 200, 300, 500]

--------------------------------------------------
Step 4: Dequeue (300, 2, 2)
--------------------------------------------------
Processing node 2 with cost 300 and stops 2

  - Stops exceeded (k=1), ignoring further processing

q = [(500, 3, 2)]

--------------------------------------------------
Step 5: Dequeue (500, 3, 2)
--------------------------------------------------
Processing node 3 with cost 500 and stops 2

  - Stops exceeded (k=1), ignoring further processing

q = []

--------------------------------------------------
Final Check:
--------------------------------------------------
prices[3] = 500 (valid)
Return 500

--------------------------------------------------
Final Output:
--------------------------------------------------
Output = 500

--------------------------------------------------
Tree Structure Representation:
--------------------------------------------------
(0, cost=0, stops=0)
  └── (1, cost=200, stops=1)
       ├── (2, cost=300, stops=2)  // Stops exceeded (ignored)
       └── (3, cost=500, stops=2)  // Stops exceeded (ignored)
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