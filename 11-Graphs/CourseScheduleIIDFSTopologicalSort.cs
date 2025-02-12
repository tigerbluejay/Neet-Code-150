public partial class Solution {
    // List to store the topological ordering of courses.
    private List<int> CSIITSoutput = new List<int>();

    // Array to store the in-degree (number of prerequisites) for each course.
    private int[] CSIITSindegree;

    // Adjacency list representation of the graph.
    private List<List<int>> CSIITSadj;

    // Recursive DFS function for processing nodes with in-degree 0.
    private void CSIITSDfs(int node) {
        // Add the current course to the output list since it can now be taken.
        CSIITSoutput.Add(node);

        // Reduce its in-degree (mark it as processed).
        CSIITSindegree[node]--;

        // Traverse all dependent courses.
        foreach (var nei in CSIITSadj[node]) {
            // Reduce the in-degree of the dependent course.
            CSIITSindegree[nei]--;

            // If the in-degree becomes 0, it means all prerequisites are done → process it.
            if (CSIITSindegree[nei] == 0) {
                CSIITSDfs(nei);
            }
        }
    }

    public int[] CSIITSFindOrder(int numCourses, int[][] prerequisites) {
        
        // Step 1: Initialize adjacency list.
        CSIITSadj = new List<List<int>>();
        for (int i = 0; i < numCourses; i++) {
            CSIITSadj.Add(new List<int>());
        }

        // Step 2: Initialize in-degree array.
        CSIITSindegree = new int[numCourses];

        // Step 3: Build the graph.
        foreach (var pre in prerequisites) {
            // pre[1] → pre[0] means pre[0] depends on pre[1].
            CSIITSindegree[pre[0]]++;  // Increase in-degree of course pre[0].
            CSIITSadj[pre[1]].Add(pre[0]);  // Add edge to adjacency list.
        }

        // Step 4: Start DFS from nodes with in-degree 0 (no prerequisites).
        for (int i = 0; i < numCourses; i++) {
            if (CSIITSindegree[i] == 0) {
                CSIITSDfs(i);
            }
        }

        // Step 5: If all courses were processed, return the output order.
        if (CSIITSoutput.Count != numCourses) return new int[0]; // Cycle detected, return empty array.
        return CSIITSoutput.ToArray();
    }
}

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