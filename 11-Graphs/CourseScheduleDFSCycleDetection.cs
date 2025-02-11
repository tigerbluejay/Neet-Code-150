public partial class Solution {

    // Map each course to its prerequisites
    private Dictionary<int, List<int>> CSDFSpreMap = new Dictionary<int, List<int>>();
    
    // Store all courses along the current DFS path to detect cycles
    private HashSet<int> CSDFSvisiting = new HashSet<int>();

    public bool CSDFSCanFinish(int numCourses, int[][] prerequisites) {
        // Initialize prerequisite map with empty lists for each course
        for (int i = 0; i < numCourses; i++) {
            CSDFSpreMap[i] = new List<int>();
        }
        
        // Populate the prerequisite map where each course points to its required courses
        foreach (var prereq in prerequisites) {
            CSDFSpreMap[prereq[0]].Add(prereq[1]);
        }

        // Perform DFS for each course to detect cycles
        for (int c = 0; c < numCourses; c++) {
            if (!CSDFSDfs(c)) {
                return false; // Cycle detected, courses cannot be completed
            }
        }
        return true; // No cycles detected, courses can be completed
    }

    private bool CSDFSDfs(int crs) {
        if (CSDFSvisiting.Contains(crs)) {
            // Cycle detected - the course is already in the current DFS path
            return false;
        }
        if (CSDFSpreMap[crs].Count == 0) {
            // No prerequisites for this course, it can be completed
            return true;
        }

        // Mark the course as being visited in the current DFS path
        CSDFSvisiting.Add(crs);
        
        // Recursively check prerequisites
        foreach (int pre in CSDFSpreMap[crs]) {
            if (!CSDFSDfs(pre)) {
                return false; // Cycle detected in the prerequisite chain
            }
        }
        
        // Remove course from the visiting set after processing
        CSDFSvisiting.Remove(crs);
        
        // Mark course as completed by clearing its prerequisite list
        CSDFSpreMap[crs].Clear();
        return true;
    }
}
/*
Example Walkthrough

Input: numCourses = 4
prerequisites = [[1,0], [2,1], [3,2]]


CSDFSDfs(0) ✅  // No prerequisites
CSDFSDfs(1)
 ├── CSDFSDfs(0) ✅  // Already processed, no prerequisites
 ✅  // Course 1 completed

CSDFSDfs(2)
 ├── CSDFSDfs(1)
 │    ├── CSDFSDfs(0) ✅  // Already processed
 │    ✅  // Course 1 completed
 ✅  // Course 2 completed

CSDFSDfs(3)
 ├── CSDFSDfs(2)
 │    ├── CSDFSDfs(1)
 │    │    ├── CSDFSDfs(0) ✅  // Already processed
 │    │    ✅  // Course 1 completed
 │    ✅  // Course 2 completed
 ✅  // Course 3 completed

Output: true // All courses can be completed
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