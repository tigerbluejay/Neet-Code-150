/*
// Definition for a Node.
public class Node {
    public int val;
    public IList<Node> neighbors;

    public Node() {
        val = 0;
        neighbors = new List<Node>();
    }

    public Node(int _val) {
        val = _val;
        neighbors = new List<Node>();
    }

    public Node(int _val, List<Node> _neighbors) {
        val = _val;
        neighbors = _neighbors;
    }
}
*/

public partial class Solution {
    public MAINode CloneGraphBFS(MAINode node) {
        if (node == null) return null;
        var oldToNew = new Dictionary<MAINode, MAINode>();
        var q = new Queue<MAINode>();
        oldToNew[node] = new MAINode(node.val);
        q.Enqueue(node);

        while (q.Count > 0) {
            var cur = q.Dequeue();
            // For every neighbor of the current node
            foreach (var nei in cur.neighbors) {
                // If the neighbor is not yet cloned (not in the dictionary)
                if (!oldToNew.ContainsKey(nei)) {
                    // Create a copy of the neighbor and add it to the dictionary
                    oldToNew[nei] = new MAINode(nei.val);
                    // Enqueue the neighbor for further processing
                    q.Enqueue(nei);
                }
                // Add the cloned neighbor to the list of neighbors
                // of the cloned current node
                oldToNew[cur].neighbors.Add(oldToNew[nei]);
            }
        }
        
        return oldToNew[node];
    }
}

/*
Start BFS with Node(1)
├── Create Copy1 (Node(1))
│   └── Enqueue Node(1)
│
├── Dequeue Node(1)
│   ├── Process Neighbor Node(2)
│   │   ├── Create Copy2 (Node(2))
│   │   ├── Add Copy2 to Copy1.neighbors
│   │   └── Enqueue Node(2)
│
├── Dequeue Node(2)
│   ├── Process Neighbor Node(1)
│   │   ├── Node(1) already cloned -> Add Copy1 to Copy2.neighbors
│   ├── Process Neighbor Node(3)
│   │   ├── Create Copy3 (Node(3))
│   │   ├── Add Copy3 to Copy2.neighbors
│   │   └── Enqueue Node(3)
│
├── Dequeue Node(3)
│   ├── Process Neighbor Node(2)
│   │   ├── Node(2) already cloned -> Add Copy2 to Copy3.neighbors
│
Return Copy1 (start of cloned graph)
*/

/*

Clone Graph

Given a node in a connected undirected graph, return a deep copy of the graph.

Each node in the graph contains an integer value and a list of its neighbors.

class Node {
    public int val;
    public List<Node> neighbors;
}

The graph is shown in the test cases as an adjacency list. An adjacency list is 
a mapping of nodes to lists, used to represent a finite graph. Each list 
describes the set of neighbors of a node in the graph.

For simplicity, nodes values are numbered from 1 to n, where n is the total 
number of nodes in the graph. The index of each node within the adjacency list 
is the same as the node's value (1-indexed).

The input node will always be the first node in the graph and have 1 as the 
value.

Example 1:
Original Graph
(1) <--> (2) <--> (3)
Input: adjList = [[2],[1,3],[2]]
Output: [[2],[1,3],[2]]
Explanation: There are 3 nodes in the graph.
Node 1: val = 1 and neighbors = [2].
Node 2: val = 2 and neighbors = [1, 3].
Node 3: val = 3 and neighbors = [2].

Example 2:
Input: adjList = [[]]
Output: [[]]
Explanation: The graph has one node with no neighbors.

Example 3:
Input: adjList = []
Output: []
Explanation: The graph is empty.

Constraints:
0 <= The number of nodes in the graph <= 100.
1 <= Node.val <= 100
There are no duplicate edges and no self-loops in the graph.
*/