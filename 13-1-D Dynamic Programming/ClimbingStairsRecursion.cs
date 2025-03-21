public partial class Solution {
    // This method initiates the recursive depth-first search (DFS) function.
    // It starts at step 0 and attempts to reach step 'n'.
    public int RClimbStairs(int n) {     
        return CSRDfs(n, 0);
    }

    // Recursive DFS function to count the number of ways to reach the nth step.
    // 'i' represents the current step.
    public int CSRDfs(int n, int i) {
        // Base case: If we have reached or exceeded the nth step,
        // return 1 if exactly at step 'n' (valid path), otherwise return 0.
        if (i >= n) return i == n ? 1 : 0;

        // Recursive case: Sum up the ways by taking one step and two steps.
        return CSRDfs(n, i + 1) + CSRDfs(n, i + 2);
    }
}
/*
CSRDfs(5, 0)
├── CSRDfs(5, 1)
│   ├── CSRDfs(5, 2)
│   │   ├── CSRDfs(5, 3)
│   │   │   ├── CSRDfs(5, 4)
│   │   │   │   ├── CSRDfs(5, 5) → 1  (Valid)
│   │   │   │   ├── CSRDfs(5, 6) → 0  (Invalid)
│   │   │   ├── CSRDfs(5, 5) → 1  (Valid)
│   │   ├── CSRDfs(5, 4)
│   │       ├── CSRDfs(5, 5) → 1  (Valid)
│   │       ├── CSRDfs(5, 6) → 0  (Invalid)
│   ├── CSRDfs(5, 3)
│       ├── CSRDfs(5, 4)
│       │   ├── CSRDfs(5, 5) → 1  (Valid)
│       │   ├── CSRDfs(5, 6) → 0  (Invalid)
│       ├── CSRDfs(5, 5) → 1  (Valid)
├── CSRDfs(5, 2)
    ├── CSRDfs(5, 3)
    │   ├── CSRDfs(5, 4)
    │   │   ├── CSRDfs(5, 5) → 1  (Valid)
    │   │   ├── CSRDfs(5, 6) → 0  (Invalid)
    │   ├── CSRDfs(5, 5) → 1  (Valid)
    ├── CSRDfs(5, 4)
        ├── CSRDfs(5, 5) → 1  (Valid)
        ├── CSRDfs(5, 6) → 0  (Invalid)

The total ways to climb n=5 is the sum of all valid paths. So 8.
*/
/*
Explanation:

The function RClimbStairs(n) is a wrapper that calls the recursive function 
CSRDfs(n, 0), starting at step 0.

The function CSRDfs(n, i) explores all possible paths to reach step n:
    If i reaches exactly n, it counts as a valid way (1).
    If i exceeds n, it returns 0 (invalid path).
Otherwise, it recursively calls itself to explore two possibilities:
    Climbing 1 step (i + 1)
    Climbing 2 steps (i + 2)
The total number of ways is the sum of these two recursive calls.
*/
/*
Climbing Stairs

You are given an integer n representing the number of steps to reach the top of a staircase. 
You can climb with either 1 or 2 steps at a time.

Return the number of distinct ways to climb to the top of the staircase.

Example 1:
Input: n = 2
Output: 2

Explanation:
1 + 1 = 2
2 = 2

Example 2:
Input: n = 3
Output: 3

Explanation:
1 + 1 + 1 = 3
1 + 2 = 3
2 + 1 = 3

Constraints:
1 <= n <= 30
*/