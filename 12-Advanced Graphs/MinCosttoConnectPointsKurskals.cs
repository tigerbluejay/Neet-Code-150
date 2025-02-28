public partial class MCCPKDSU {
    public int[] Parent, Size; // Arrays to store parent references and size of each set
        
    public MCCPKDSU(int n) {
        Parent = new int[n + 1]; // Initialize parent array to store representatives
        Size = new int[n + 1]; // Initialize size array to keep track of set sizes
        for (int i = 0; i <= n; i++) Parent[i] = i; // Initially, each node is its own parent (self-loop)
        Array.Fill(Size, 1); // Each set starts with size 1
    }

    public int Find(int node) {
        if (Parent[node] != node) { // If node is not its own parent, apply path compression
            Parent[node] = Find(Parent[node]); // Recursively find and update the parent to root
        }
        return Parent[node]; // Return the root representative of the set
    }

    public bool Union(int u, int v) {
        int pu = Find(u), pv = Find(v); // Find the roots of both nodes
        if (pu == pv) return false; // If they are already in the same set, do nothing
        
        // Union by size: attach smaller tree to larger tree
        if (Size[pu] < Size[pv]) {
            int temp = pu;
            pu = pv;
            pv = temp;
        }
        Size[pu] += Size[pv]; // Update size of the new root
        Parent[pv] = pu; // Merge sets by updating the parent
        return true; // Return true as a successful union operation
    }
}

public partial class Solution {

    // points = [[0,0],[2,2],[3,3],[2,4],[4,2]]
    public int MCCPKMinCostConnectPoints(int[][] points) {
        int n = points.Length;
        MCCPKDSU dsu = new MCCPKDSU(n); // Initialize Disjoint Set Union (DSU) for 'n' points
        List<(int, int, int)> edges = new List<(int, int, int)>(); // Store edges as (distance, point1, point2)

        // Generate all possible edges with their Manhattan distance
        // edges = [ (4,0,1), (6,0,2), (6,0,3), (6,0,4), (2,1,2), 
        // (2,1,3), (2,1,4), (2,2,3), (2,2,4), (4,3,4) ];
        for (int i = 0; i < n; i++) {
            for (int j = i + 1; j < n; j++) {
                int dist = Math.Abs(points[i][0] - points[j][0]) +  
                           Math.Abs(points[i][1] - points[j][1]);
                edges.Add((dist, i, j)); // Store edge with distance and endpoints
            }
        }

        // Sort edges based on their distance in ascending order (Kruskal’s algorithm)
        // edges = [ (2,1,2), (2,1,3), (2,1,4), (2,2,3), (2,2,4),
        // (4,0,1), (4,3,4), (6,0,2), (6,0,3), (6,0,4) ]
        edges.Sort((a, b) => a.Item1.CompareTo(b.Item1));
        int res = 0; // Variable to store the total minimum cost

        // Iterate through sorted edges and use DSU to determine MST
        foreach (var edge in edges) {
            if (dsu.Union(edge.Item2, edge.Item3)) { // If adding this edge does not create a cycle
            // The Union() method only succeeds when two nodes are in separate components.
            // If it fails (returns false), it means adding the edge would form a cycle.
            // This makes it a simple cycle detection mechanism for Kruskal’s algorithm.
                res += edge.Item1; // Add the edge weight to the total cost
            }
        }
        return res; // Return the minimum cost to connect all points
    }
}
/*
Kruskal’s Algorithm solves the Minimum Cost to Connect Points problem by treating the points as nodes in a 
graph and connecting them with weighted edges representing their Manhattan distances. 
It first generates all possible edges between points, then sorts the edges by weight in ascending order. 
Using a Disjoint Set Union (DSU) data structure, it processes each edge in order, adding it to the solution 
only if it connects two previously unconnected components (i.e., no cycle is formed). This ensures that the 
algorithm constructs a Minimum Spanning Tree (MST) efficiently, resulting in the minimum cost to connect all points.
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