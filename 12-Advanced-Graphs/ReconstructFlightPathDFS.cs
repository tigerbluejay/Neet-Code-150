public partial class Solution {
    // This method reconstructs an itinerary given a list of flight tickets.
    // It uses a recursive DFS approach to ensure the itinerary is lexicographically smallest.
    public List<string> RFPDFSFindItinerary(List<List<string>> tickets) {
        var adj = new Dictionary<string, List<string>>(); // Adjacency list representation of the graph
        
        // Populate adjacency list with unique departure locations
        foreach (var ticket in tickets) {
            if (!adj.ContainsKey(ticket[0])) {
                adj[ticket[0]] = new List<string>();
            }
        }

        // Sort tickets by destination lexicographically to ensure smallest order is chosen first
        tickets.Sort((a, b) => string.Compare(a[1], b[1]));
        
        // Populate adjacency list with destinations sorted in lexicographical order
        foreach (var ticket in tickets) {
            adj[ticket[0]].Add(ticket[1]);
        }

        var res = new List<string> { "JFK" }; // Start the itinerary with "JFK" as per problem constraints
        RFPDfs("JFK", res, adj, tickets.Count + 1); // Call DFS to find a valid itinerary
        return res; // Return the reconstructed itinerary
    }

    // Recursive DFS function to construct the itinerary
    private bool RFPDfs(string src, List<string> res, 
                     Dictionary<string, List<string>> adj, int targetLen) {
        if (res.Count == targetLen) return true; // If itinerary reaches required length, return success
        if (!adj.ContainsKey(src)) return false; // If no more destinations from current source, return failure

        var temp = new List<string>(adj[src]); // Create a temporary copy to allow modifications during iteration

        // Iterate over all possible destinations from the current source
        for (int i = 0; i < temp.Count; i++) {
            var v = temp[i]; // Select the i-th destination from the adjacency list

            adj[src].RemoveAt(i); // Remove this destination from the adjacency list to simulate "using" the ticket
            res.Add(v); // Add the destination to the itinerary
            
            // Recursively attempt to construct the remaining itinerary from the selected destination
            if (RFPDfs(v, res, adj, targetLen)) return true; // If a valid itinerary is found, return true
            
            // Backtrack: If the recursive call failed, revert the changes
            res.RemoveAt(res.Count - 1); // Remove the last added destination
            adj[src].Insert(i, v); // Restore the destination at its original index to maintain ordering
        }
        return false; // Return false if no valid itinerary could be constructed
    }
}

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