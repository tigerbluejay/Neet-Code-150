public partial class Solution {
    public bool CSKACanFinish(int numCourses, int[][] prerequisites) {

        // indegree[i]: Stores the number of prerequisites for course i.
        int[] indegree = new int[numCourses];

        // adj[i]: Stores the list of courses that depend on course i.
        List<List<int>> adj = new List<List<int>>();

        //We initialize an adjacency list where each course has an empty list of dependent courses.
        for (int i = 0; i < numCourses; i++) {
            adj.Add(new List<int>());
        }
        // For each prerequisite (A, B), we:
        // Increase indegree[B] because course B has an additional dependency (A must be taken first).
        // Add B to the adjacency list of A (A → B).
        foreach (var pre in prerequisites) {
            indegree[pre[1]]++;
            adj[pre[0]].Add(pre[1]);
        }

        // All courses with no prerequisites (indegree[i] == 0) are added to the queue 
        // since they can be taken immediately.
        Queue<int> q = new Queue<int>();
        for (int i = 0; i < numCourses; i++) {
            if (indegree[i] == 0) {
                q.Enqueue(i);
            }
        }

        int finish = 0;
        // We process courses one by one, removing them from the queue.
        while (q.Count > 0) {
            int node = q.Dequeue(); // Take a course with no prerequisites
            finish++;  // Increment the count of completed courses

            // For each dependent course (nei of node):
            // Decrease its in-degree (since its prerequisite is now taken).
            // If in-degree becomes 0, enqueue it (ready to be taken).
            foreach (var nei in adj[node]) {
                indegree[nei]--;
                if (indegree[nei] == 0) {
                    q.Enqueue(nei);
                }
            }
        }
        // If we processed all courses (finish == numCourses), return true.
        // Otherwise, return false, meaning there is a cycle.
        return finish == numCourses;
        /*
        If the total number of processed courses (finish) is equal to numCourses, 
        it means we could take all courses without getting stuck in a cycle.
        If there was a cycle, some courses would remain with a nonzero indegree, 
        preventing finish from reaching numCourses.
        */
    }
}
/*
Example Walkthrough

Input: numCourses = 4
prerequisites = [[1,0], [2,1], [3,2]]

Graph Representation:
  0 → 1 → 2 → 3

Execution:
indegree = [0, 1, 1, 1]
Start with q = [0] (only 0 has indegree = 0).
Process 0, decrease indegree[1], add 1 to q.
Process 1, decrease indegree[2], add 2 to q.
Process 2, decrease indegree[3], add 3 to q.
Process 3, all courses are done! Return true.
*/

/*
Course Schedule

You are given an array prerequisites where prerequisites[i] = [a, b] 
indicates that you must take course b first if you want to take course a.

The pair [0, 1], indicates that must take course 1 before taking course 0.

There are a total of numCourses courses you are required to take, labeled from 0 to numCourses - 1.

Return true if it is possible to finish all courses, otherwise return false.

Example 1:
Input: numCourses = 2, prerequisites = [[0,1]]
Output: true
Explanation: First take course 1 (no prerequisites) and then take course 0.

Example 2:
Input: numCourses = 2, prerequisites = [[0,1],[1,0]]
Output: false
Explanation: In order to take course 1 you must take course 0, 
and to take course 0 you must take course 1. So it is impossible.

Constraints:
1 <= numCourses <= 1000
0 <= prerequisites.length <= 1000
All prerequisite pairs are unique.
*/