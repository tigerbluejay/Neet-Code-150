public partial class Solution {
    public int BFFindCheapestPrice(int n, int[][] flights, int src, int dst, int k) {
        // Initialize an array to store the minimum prices to reach each node.
        int[] prices = new int[n];
        Array.Fill(prices, int.MaxValue); // Set all prices to "infinity" initially.
        prices[src] = 0; // The cost to reach the source node is always 0.

        // Perform Bellman-Ford relaxation for at most k+1 times (k stops mean k+1 edges).
        for (int i = 0; i <= k; i++) {
            // Create a temporary array to store updated prices for this iteration.
            int[] tmpPrices = (int[])prices.Clone();

            // Iterate through all flights (edges in the graph).
            foreach (var flight in flights) {
                int s = flight[0]; // Source airport
                int d = flight[1]; // Destination airport
                int p = flight[2]; // Cost of the flight

                // If the current source airport is unreachable, skip it.
                if (prices[s] == int.MaxValue)
                    continue;

                // Relaxation step: If taking this flight results in a cheaper price, update tmpPrices.
                if (prices[s] + p < tmpPrices[d])
                    tmpPrices[d] = prices[s] + p;
            }

            // Update the main prices array with the latest computed costs.
            prices = tmpPrices;
        }

        // If the destination is still unreachable, return -1; otherwise, return the minimum cost.
        return prices[dst] == int.MaxValue ? -1 : prices[dst];
    }
}

/*

Start at node 0 with cost 0
|
|-- [0 -> 1] Cost: 200
|    |
|    |-- [1 -> 2] Cost: 200 + 100 = 300
|    |    |
|    |    |-- [2 -> 3] Cost: 300 + 100 = 400  (Not valid, exceeds k=1 stops)
|    |
|    |-- [1 -> 3] Cost: 200 + 300 = 500  (Valid, reaches dst)
|
End: Cheapest cost to reach node 3 within 1 stop = 500

Explanation:
The algorithm starts at node 0 with cost 0.
It considers the first stop:
Takes flight (0 → 1) with cost 200.
Now at node 1, the algorithm explores its outgoing flights:
Takes flight (1 → 2) with cost 100, reaching node 2 with total cost 300.
Takes flight (1 → 3) with cost 300, reaching node 3 with total cost 500.

Since k = 1, we are allowed only 1 stop, meaning we cannot use (2 → 3) because it requires 2 stops.
The only valid route to destination (3) within 1 stop is 0 → 1 → 3 with total cost 500.
*/
/*
Initialization:
prices = [0, ∞, ∞, ∞]  // Set all prices to infinity except the source (0)

Iteration 1 (i = 0):
  Processing flight [0,1,200]: 
    prices[0] + 200 < tmpPrices[1]      → 0 + 200 < ∞ → 
    Update tmpPrices[1] = 200
  tmpPrices = [0, 200, ∞, ∞]

Iteration 2 (i = 1):
  Cloning prices → prices = [0, 200, ∞, ∞]
  
  Processing flight [1,2,100]: 
    prices[1] + 100 < tmpPrices[2]      → 200 + 100 < ∞ → 
    Update tmpPrices[2] = 300
  
  Processing flight [1,3,300]: 
    prices[1] + 300 < tmpPrices[3]      → 200 + 300 < ∞ → 
    Update tmpPrices[3] = 500
  
  tmpPrices = [0, 200, 300, 500]

Final prices array: [0, 200, 300, 500]
Answer: prices[3] = 500
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