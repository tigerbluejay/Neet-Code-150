public partial class Solution {
    public List<string> RFPHIFindItinerary(List<List<string>> tickets) {
        // Adjacency list to store directed graph of flights
        var adj = new Dictionary<string, List<string>>();

        // Sort tickets in reverse lexicographical order to ensure correct order when popping from the end
        foreach (var ticket in tickets.OrderByDescending(t => t[1])) {
            if (!adj.ContainsKey(ticket[0])) {
                adj[ticket[0]] = new List<string>();
            }
            adj[ticket[0]].Add(ticket[1]);
        }
        
        // Result list to store final itinerary in reversed order
        var res = new List<string>();

        // Stack for iterative DFS traversal
        var stack = new Stack<string>();

        // Start traversal from "JFK"
        stack.Push("JFK");

        // Hierholzer's Algorithm main loop
        while (stack.Count > 0) {
            var curr = stack.Peek();  // Look at the current airport without removing it

            // If curr has no outgoing flights or all have been used
            if (!adj.ContainsKey(curr) || adj[curr].Count == 0) {
                // No more flights from curr, add it to the result as part of the Eulerian path
                res.Insert(0, stack.Pop()); // Insert at the beginning to reverse later
            } else {
                // There are remaining flights, take the lexicographically smallest (last in sorted list)
                var next = adj[curr][adj[curr].Count - 1];
                
                // Remove the flight from the adjacency list (marking it as used)
                adj[curr].RemoveAt(adj[curr].Count - 1);

                // Push the next airport onto the stack to continue traversal
                stack.Push(next);
            }
        }

        // Return the reconstructed itinerary
        return res;
    }
}
/*
Initial Stack: [JFK]
----------------------------------------
Step 1:
  Current top of stack: JFK
  JFK has outgoing flight to HOU
  Stack after push: [JFK, HOU]
  Updated adjacency list:
    JFK -> [SEA]    (HOU removed)
    SEA -> [JFK]
    HOU -> [JFK]

----------------------------------------
Step 2:
  Current top of stack: HOU
  HOU has outgoing flight to JFK
  Stack after push: [JFK, HOU, JFK]
  Updated adjacency list:
    JFK -> [SEA]
    SEA -> [JFK]
    HOU -> []       (JFK removed)

----------------------------------------
Step 3:
  Current top of stack: JFK
  JFK has outgoing flight to SEA
  Stack after push: [JFK, HOU, JFK, SEA]
  Updated adjacency list:
    JFK -> []       (SEA removed)
    SEA -> [JFK]
    HOU -> []

----------------------------------------
Step 4:
  Current top of stack: SEA
  SEA has outgoing flight to JFK
  Stack after push: [JFK, HOU, JFK, SEA, JFK]
  Updated adjacency list:
    JFK -> []
    SEA -> []       (JFK removed)
    HOU -> []

----------------------------------------
Step 5:
  Current top of stack: JFK
  JFK has no more outgoing flights
  Popping JFK and inserting at beginning of result
  Stack after pop: [JFK, HOU, JFK, SEA]
  Result: ["JFK"]

----------------------------------------
Step 6:
  Current top of stack: SEA
  SEA has no more outgoing flights
  Popping SEA and inserting at beginning of result
  Stack after pop: [JFK, HOU, JFK]
  Result: ["SEA", "JFK"]

----------------------------------------
Step 7:
  Current top of stack: JFK
  JFK has no more outgoing flights
  Popping JFK and inserting at beginning of result
  Stack after pop: [JFK, HOU]
  Result: ["JFK", "SEA", "JFK"]

----------------------------------------
Step 8:
  Current top of stack: HOU
  HOU has no more outgoing flights
  Popping HOU and inserting at beginning of result
  Stack after pop: [JFK]
  Result: ["HOU", "JFK", "SEA", "JFK"]

----------------------------------------
Step 9:
  Current top of stack: JFK
  JFK has no more outgoing flights
  Popping JFK and inserting at beginning of result
  Stack after pop: []
  Result: ["JFK", "HOU", "JFK", "SEA", "JFK"]

----------------------------------------
Final Itinerary Output:
["JFK", "HOU", "JFK", "SEA", "JFK"]
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