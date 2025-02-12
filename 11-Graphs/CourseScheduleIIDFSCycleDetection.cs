public partial class Solution {
    public int[] CSIICDFindOrder(int numCourses, int[][] prerequisites) {
        Dictionary<int, List<int>> prereq = new Dictionary<int, List<int>>();
        foreach (var pair in prerequisites) {
            if (!prereq.ContainsKey(pair[0])) {
                prereq[pair[0]] = new List<int>();
            }
            prereq[pair[0]].Add(pair[1]);
        }

        List<int> output = new List<int>();
        HashSet<int> visit = new HashSet<int>();
        HashSet<int> cycle = new HashSet<int>();

        for (int course = 0; course < numCourses; course++) {
            if (!CSIICDDfs(course, prereq, visit, cycle, output)) {
                return new int[0];
            }
        }

        return output.ToArray();
    }

    /*
    The CSIICDDfs function is a Depth-First Search (DFS) implementation used to determine the order in which courses 
    should be taken while ensuring there are no cyclic dependencies (which would make it impossible to complete all courses).
    */
    /*
    course: The current course being checked.
    prereq: A dictionary where each key is a course and its value is a list of prerequisite courses.
    visit: A set that stores courses that have been fully processed.
    cycle: A set that helps detect cycles (courses currently being visited in the current recursion stack).
    output: A list where the valid course order will be stored.
    */
    private bool CSIICDDfs(int course, Dictionary<int, List<int>> prereq,
                 HashSet<int> visit, HashSet<int> cycle, 
                 List<int> output) {
                    
    // If the course is already in the cycle set, a cycle is detected
    // and it's impossible to finish all courses.
    if (cycle.Contains(course)) {
        return false;
    }

    // If the course is already visited, it means we've already determined 
    // its order and don't need to process it again.
    if (visit.Contains(course)) {
        return true;
    }

    // Mark this course as being visited in the current DFS path (for cycle detection).
    cycle.Add(course);

    // Recursively visit all prerequisites of this course.
    if (prereq.ContainsKey(course)) {
        foreach (int pre in prereq[course]) {
            // If any prerequisite leads to a cycle, return false immediately.
            if (!CSIICDDfs(pre, prereq, visit, cycle, output)) {
                return false;
            }
        }
    }

    // After processing all prerequisites, remove the course from the cycle set
    // since we are done exploring it.
    cycle.Remove(course);

    // Mark this course as fully processed.
    visit.Add(course);

    // Add this course to the output list (this ensures courses appear after their prerequisites).
    output.Add(course);

    // Return true, indicating that this course can be completed successfully.
    return true;
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