// Definition for a Node.
public class MAINode {
    public int val;
    public IList<MAINode> neighbors;

    public MAINode() {
        val = 0;
        neighbors = new List<MAINode>();
    }

    public MAINode(int _val) {
        val = _val;
        neighbors = new List<MAINode>();
    }

    public MAINode(int _val, List<MAINode> _neighbors) {
        val = _val;
        neighbors = _neighbors;
    }
}

public partial class Solution {
    public MAINode CloneGraphDFS(MAINode node) {
        Dictionary<MAINode, MAINode> oldToNew = new Dictionary<MAINode, MAINode>();
        return Dfs(node, oldToNew);
    }

    private MAINode Dfs(MAINode node, Dictionary<MAINode, MAINode> oldToNew) {
        if (node == null)
            return null;

        if (oldToNew.ContainsKey(node))
            return oldToNew[node];

        // if node doesnt exist in dictionary, create a copy
        // and add it to it
        MAINode copy = new MAINode(node.val);
        oldToNew[node] = copy;

        foreach (MAINode nei in node.neighbors)
            copy.neighbors.Add(Dfs(nei, oldToNew));

        return copy;
    }
}
/*
Dfs(Node1)
├── Create Copy1 (Node1)
│   └── Call Dfs(Node2)
│       ├── Create Copy2 (Node2)
│       │   ├── Call Dfs(Node1) -> Copy1
│       │   ├── Add Copy1 to Copy2.neighbors
│       │   └── Call Dfs(Node3)
│       │       ├── Create Copy3 (Node3)
│       │       │   ├── Call Dfs(Node2) -> Copy2
│       │       │   └── Add Copy2 to Copy3.neighbors
│       │       └── Return Copy3
│       └── Add Copy3 to Copy2.neighbors
│       └── Return Copy2
└── Add Copy2 to Copy1.neighbors
└── Return Copy1
Final oldToNew Mapping
Node1 -> Copy1
Node2 -> Copy2
Node3 -> Copy3
Result Graph
Copy1.neighbors = [Copy2]
Copy2.neighbors = [Copy1, Copy3]
Copy3.neighbors = [Copy2]
Original Graph
(1) <--> (2) <--> (3)
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