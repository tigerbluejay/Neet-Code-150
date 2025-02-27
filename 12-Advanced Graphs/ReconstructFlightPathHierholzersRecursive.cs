public partial class Solution {
    private Dictionary<string, List<string>> RFPHRadj; // Adjacency list representation of the graph
    private List<string> RFPHRres = new List<string>(); // List to store the Eulerian path (itinerary)

    // This method constructs an itinerary using Hierholzer’s algorithm
    public List<string> RFPHRFindItinerary(List<List<string>> tickets) {
        RFPHRadj = new Dictionary<string, List<string>>(); // Initialize adjacency list

        // Sort tickets in descending order by destination to enable efficient removal (stack-like processing)
        var sortedTickets = tickets.OrderByDescending(t => t[1]).ToList();

        // Populate adjacency list with destinations sorted in reverse lexicographical order
        foreach (var ticket in sortedTickets) {
            if (!RFPHRadj.ContainsKey(ticket[0])) {
                RFPHRadj[ticket[0]] = new List<string>();
            }
            RFPHRadj[ticket[0]].Add(ticket[1]); // Add destination to adjacency list
        }

        RFPHRDfs("JFK"); // Start the DFS traversal from "JFK" (required starting point)
        RFPHRres.Reverse(); // Reverse the final list since we construct the path in reverse order
        return RFPHRres; // Return the reconstructed itinerary
    }

    // Hierholzer’s DFS function to construct the Eulerian path
    private void RFPHRDfs(string src) {
        // While there are unvisited edges from the current airport
        while (RFPHRadj.ContainsKey(src) && RFPHRadj[src].Count > 0) {
            // Select the last destination (smallest lexicographically due to sorting in reverse order)
            var dst = RFPHRadj[src][RFPHRadj[src].Count - 1];
            
            // Remove the last ticket from the adjacency list (simulating using the ticket)
            RFPHRadj[src].RemoveAt(RFPHRadj[src].Count - 1);

            // Recursively visit the next airport
            RFPHRDfs(dst);
        }

        // Once all flights from `src` are exhausted, add `src` to the result list
        // This ensures the path is built in reverse order (post-order DFS)
        RFPHRres.Add(src);
    }
}
/*
Hierholzer's algorithm is used to find an Eulerian path or circuit, which is a path that visits 
every edge exactly once in a directed or undirected graph. In the context of this problem, the 
flight tickets represent directed edges in a graph where airports (nodes) are connected by flights 
(edges). The algorithm ensures that we construct a valid itinerary by always consuming edges while 
maintaining the ability to complete the full route. It works by recursively visiting destinations in 
lexicographically smallest order (via sorting in reverse) and backtracking to add nodes to the itinerary 
once all outgoing edges are used. This guarantees that we reconstruct the itinerary in correct order 
when we reverse the result at the end. In this example, the algorithm efficiently finds a path covering 
all given flights, ensuring the correct sequence: ["JFK", "HOU", "JFK", "SEA", "JFK"].
*/
/*
Input: [["HOU","JFK"],["SEA","JFK"],["JFK","SEA"],["JFK","HOU"]]
Sorted in reverse order:
  "HOU" -> ["JFK"]
  "SEA" -> ["JFK"]
  "JFK" -> ["SEA", "HOU"]

Starting DFS from "JFK":

JFK
├── HOU  (Removed "HOU" from JFK)
│   ├── JFK  (Removed "JFK" from HOU)
│   │   └── Backtrack, add JFK to result
│   └── Backtrack, add HOU to result
├── SEA  (Removed "SEA" from JFK)
│   ├── JFK  (Removed "JFK" from SEA)
│   │   └── Backtrack, add JFK to result
│   └── Backtrack, add SEA to result
└── Backtrack, add JFK to result

Final reversed result: ["JFK", "HOU", "JFK", "SEA", "JFK"]

*/


/*
Reconstruct Flight Path

You are given a list of flight tickets tickets where tickets[i] = [from_i, to_i] represent 
the source airport and the destination airport.

Each from_i and to_i consists of three uppercase English letters.

Reconstruct the itinerary in order and return it.

All of the tickets belong to someone who originally departed from "JFK".
Your objective is to reconstruct the flight path that this person took, assuming each ticket was used exactly once.

If there are multiple valid flight paths, return the lexicographically smallest one.

For example, the itinerary ["JFK", "SEA"] has a smaller lexical order than ["JFK", "SFO"].
You may assume all the tickets form at least one valid flight path.

Example 1:
Input: tickets = [["BUF","HOU"],["HOU","SEA"],["JFK","BUF"]]
Output: ["JFK","BUF","HOU","SEA"]

Example 2:
Input: tickets = [["HOU","JFK"],["SEA","JFK"],["JFK","SEA"],["JFK","HOU"]]
Output: ["JFK","HOU","JFK","SEA","JFK"]
Explanation: Another possible reconstruction is ["JFK","SEA","JFK","HOU","JFK"] but it is lexicographically larger.

Constraints:
1 <= tickets.length <= 300
from_i != to_i
*/