public partial class Solution {
    public int[] CSIIKAFindOrder(int numCourses, int[][] prerequisites) {
        // Step 1: Initialize in-degree array and adjacency list.
        int[] indegree = new int[numCourses]; // Stores the number of incoming edges for each course.
        List<List<int>> adj = new List<List<int>>(); // Adjacency list representation of the graph.

        // Create an adjacency list with empty lists for each course.
        for (int i = 0; i < numCourses; i++) {
            adj.Add(new List<int>());
        }

        // Step 2: Build the graph.
        foreach (var pre in prerequisites) {
            // pre[1] → pre[0] means pre[0] depends on pre[1].
            indegree[pre[1]]++; // Increase in-degree of course pre[1].
            adj[pre[0]].Add(pre[1]); // Add dependency to adjacency list.
        }

        // Step 3: Add courses with in-degree 0 to the queue (those with no prerequisites).
        Queue<int> q = new Queue<int>();
        for (int i = 0; i < numCourses; i++) {
            if (indegree[i] == 0) {
                q.Enqueue(i);
            }
        }

        // Step 4: Process nodes in the queue using BFS.
        int finish = 0; // Counts how many courses have been processed.
        int[] output = new int[numCourses]; // Stores the topological order.

        while (q.Count > 0) {
            int node = q.Dequeue(); // Remove course with no dependencies.
            output[numCourses - finish - 1] = node; // Store it in the result array.
            finish++;

            // Reduce the in-degree of all its neighboring courses.
            foreach (var nei in adj[node]) {
                indegree[nei]--; // Remove dependency.
                if (indegree[nei] == 0) { // If in-degree becomes 0, enqueue the course.
                    q.Enqueue(nei);
                }
            }
        }

        // Step 5: Check if all courses were processed.
        if (finish != numCourses) {
            return new int[0]; // If not all courses are processed, a cycle exists.
        }
        return output;
    }
}
/*
Overview of Topological Sort & Kahn’s Algorithm
What is Topological Sort?
Topological sorting is a linear ordering of vertices in a Directed Acyclic Graph (DAG) such that for every directed 
edge u → v, vertex u comes before v in the ordering.
It is mainly used in dependency resolution problems, such as:
    Course scheduling
    Task scheduling in dependency graphs
    Compilation order in a build system

There are two common algorithms to perform topological sorting:
DFS-based method (used in your previous code)
Kahn’s Algorithm (BFS-based) → Used in the code below.

What is Kahn’s Algorithm?
Kahn’s Algorithm is a BFS-based topological sorting approach that relies on in-degree counts to process nodes in the 
correct order.

How Kahn’s Algorithm Works:

Compute in-degrees:
The in-degree of a node is the number of incoming edges to it.
If a node has an in-degree of 0, it means it has no dependencies and can be processed immediately.
Initialize the queue with nodes having in-degree 0.

These are the starting points (nodes with no prerequisites).
Process nodes in the queue (BFS traversal).

Remove a node from the queue, add it to the result list.
Reduce the in-degree of all its neighbors.
If any neighbor’s in-degree becomes 0, enqueue it.

Check if all nodes are processed.

If the number of processed nodes is less than numCourses, it means there's a cycle and no valid order exists.
*/
/*
Course Schedule II

You are given an array prerequisites where prerequisites[i] = [a, b] indicates that you must take course b 
first if you want to take course a.

For example, the pair [0, 1], indicates that to take course 0 you have to first take course 1.
There are a total of numCourses courses you are required to take, labeled from 0 to numCourses - 1.

Return a valid ordering of courses you can take to finish all courses. If there are many valid answers, 
return any of them. If it's not possible to finish all courses, return an empty array.

Example 1:
Input: numCourses = 3, prerequisites = [[1,0]]
Output: [0,1,2]
Explanation: We must ensure that course 0 is taken before course 1.

Example 2:
Input: numCourses = 3, prerequisites = [[0,1],[1,2],[2,0]]
Output: []
Explanation: It's impossible to finish all courses.

Constraints:
1 <= numCourses <= 1000
0 <= prerequisites.length <= 1000
All prerequisite pairs are unique.

*/