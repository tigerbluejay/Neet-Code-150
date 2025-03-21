public partial class Solution {
    int[] cache; // Array to store results for previously computed steps

    // This function initializes the cache and calls the recursive DFS function
    public int DPTDClimbStairs(int n) { 
        cache = new int[n]; // Create an array of size 'n' to store computed values
        for (int i = 0; i < n; i++) {
            cache[i] = -1; // Initialize cache with -1 (indicating uncomputed values)
        }    
        return CSDPTDDfs(n, 0); // Start recursion from step 0
    }

    // Recursive DFS function with memoization
    public int CSDPTDDfs(int n, int i) {
        // Base case: If we reach or exceed 'n', return 1 if exactly at 'n', else 0
        if (i >= n) return i == n ? 1 : 0;

        // If the result for this step is already computed, return it
        if (cache[i] != -1) return cache[i];

        // Compute and store the result in the cache before returning
        return cache[i] = CSDPTDDfs(n, i + 1) + CSDPTDDfs(n, i + 2);
    }
}

/*
Tree Representation for n = 5 (Memoization Applied)
CSDPTDDfs(5, 0)
├── CSDPTDDfs(5, 1)
│   ├── CSDPTDDfs(5, 2)
│   │   ├── CSDPTDDfs(5, 3)
│   │   │   ├── CSDPTDDfs(5, 4)
│   │   │   │   ├── CSDPTDDfs(5, 5) → 1  (Valid)
│   │   │   │   ├── CSDPTDDfs(5, 6) → 0  (Invalid)
│   │   │   ├── CSDPTDDfs(5, 5) → 1  (Valid) **(Cached)**
│   │   ├── CSDPTDDfs(5, 4) → 2  **(Cached)**
│   ├── CSDPTDDfs(5, 3) → 3  **(Cached)**
├── CSDPTDDfs(5, 2) → 5  **(Cached)**

So the answer is 8.
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