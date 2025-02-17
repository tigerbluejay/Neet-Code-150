public class NCCDSU {
    private int[] NCCparent; // Stores the parent of each node
    private int[] NCCrank;   // Stores the rank (size) of each tree in the DSU

    public NCCDSU(int n) {
        NCCparent = new int[n];
        NCCrank = new int[n];

        // Initialize each node as its own parent (self-loop) and rank as 1
        for (int i = 0; i < n; i++) {
            NCCparent[i] = i;
            NCCrank[i] = 1;
        }
    }

    // Find function with path compression
    public int NCCFind(int node) {
        int cur = node;

        // Traverse up the parent chain until the root is found
        while (cur != NCCparent[cur]) {
            NCCparent[cur] = NCCparent[NCCparent[cur]]; // Path compression for efficiency
            cur = NCCparent[cur];
        }
        return cur; // Return the root representative of the set
    }

    // Union function with rank-based merging
    public bool NCCUnion(int u, int v) {
        int pu = NCCFind(u); // Find root of u
        int pv = NCCFind(v); // Find root of v

        // If both nodes are already in the same set, return false (no merge needed)
        if (pu == pv) {
            return false;
        }

        // Union by rank: attach the smaller tree to the larger one
        if (NCCrank[pv] > NCCrank[pu]) {
            int temp = pu;
            pu = pv;
            pv = temp;
        }

        NCCparent[pv] = pu; // Attach smaller tree to larger tree
        NCCrank[pu] += NCCrank[pv]; // Update rank

        return true; // Return true since a merge was performed
    }
}

public partial class Solution {
    public int NCCDSUCountComponents(int n, int[][] edges) {
        NCCDSU dsu = new NCCDSU(n); // Initialize DSU for n nodes
        int res = n; // Start with n separate components

        // Process each edge and perform union operations
        foreach (var edge in edges) {
            if (dsu.NCCUnion(edge[0], edge[1])) {
                res--; // Reduce the component count when a union is successful
            }
        }
        return res; // Return the number of connected components
    }
}

/*
DSU (Disjoint Set Union) Tree Representation
For the given input:
n = 6
edges = [[0,1], [1,2], [2,3], [4,5]]

The DSU algorithm follows these steps:

Initialize NCCparent[] and NCCrank[]:
NCCparent = [0, 1, 2, 3, 4, 5]  (each node is its own parent initially)
NCCrank   = [1, 1, 1, 1, 1, 1]  (each set starts with rank 1)

Process each edge and perform NCCUnion calls:

Step-by-step DSU Execution
Processing Edge (0,1):
Find(0): Root is 0
Find(1): Root is 1

Union(0,1): Merge trees, making 0 the root (since both have the same rank)
NCCparent = [0, 0, 2, 3, 4, 5]
NCCrank   = [2, 1, 1, 1, 1, 1]

Processing Edge (1,2):
Find(1): Root is 0 (via path compression)
Find(2): Root is 2

Union(0,2): Merge, making 0 the root
NCCparent = [0, 0, 0, 3, 4, 5]
NCCrank   = [3, 1, 1, 1, 1, 1]

Processing Edge (2,3):
Find(2): Root is 0 (via path compression)
Find(3): Root is 3
Union(0,3): Merge, making 0 the root

NCCparent = [0, 0, 0, 0, 4, 5]
NCCrank   = [4, 1, 1, 1, 1, 1]

Processing Edge (4,5):
Find(4): Root is 4
Find(5): Root is 5
Union(4,5): Merge, making 4 the root

NCCparent = [0, 0, 0, 0, 4, 4]
NCCrank   = [4, 1, 1, 1, 2, 1]

Final Tree Representation of DSU
Component 1:
     0
    /|\
   1 2 3

Component 2:
   4
   |
   5

Summary of res Evolution:
Step	Edge	Union Success?	res (Component Count)
Start	  -	     -                   6
1	    (0,1)	 ✅     Yes	        5
2	    (1,2)	 ✅     Yes	        4
3	    (2,3)	 ✅     Yes	        3
4	    (4,5) 	 ✅     Yes	        2

Each successful union reduces res by 1. If an edge connects two nodes already in the same component, 
res remains unchanged.
*/


/*
Number of Connected Components in an Undirected Graph

There is an undirected graph with n nodes. 
There is also an edges array, where edges[i] = [a, b] means that 
there is an edge between node a and node b in the graph.

The nodes are numbered from 0 to n - 1.

Return the total number of connected components in that graph.

Example 1:
Input:
n=3
edges=[[0,1], [0,2]]
Output:
1

Example 2:
Input:
n=6
edges=[[0,1], [1,2], [2,3], [4,5]]
Output:
2

Constraints:
1 <= n <= 100
0 <= edges.length <= n * (n - 1) / 2
*/