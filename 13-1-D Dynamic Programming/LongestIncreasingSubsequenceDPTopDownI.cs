public partial class Solution {
    public int DPTDILengthOfLIS(int[] nums) {
        int n = nums.Length;

        // memo[i, j+1] stores the LIS starting at index i, with previous index being j 
        // (-1 is shifted to index 0)
        int[,] memo = new int[n, n + 1];  // n+1 to safely handle j = -1 via offset j+1

        // Initialize memo with -1 (meaning "not computed")
        for (int i = 0; i < n; i++)
            for (int j = 0; j <= n; j++)
                memo[i, j] = -1;

        // Start recursion at index 0, with no previous element included (j = -1)
        return LISDPTDIDFS(nums, 0, -1, memo);
    }

    private int LISDPTDIDFS(int[] nums, int i, int j, int[,] memo) {
        if (i == nums.Length) return 0; // Base case: no more elements

        // Check memo table to avoid recomputing subproblems
        if (memo[i, j + 1] != -1) {
            return memo[i, j + 1]; // Already solved
        }

        // Option 1: skip current element
        int LIS = LISDPTDIDFS(nums, i + 1, j, memo);

        // Option 2: include current element if it maintains increasing order
        if (j == -1 || nums[j] < nums[i]) {
            LIS = Math.Max(LIS, 1 + LISDPTDIDFS(nums, i + 1, i, memo));
        }

        // Store the result before returning it
        memo[i, j + 1] = LIS;
        return LIS;
    }
}

/*
We'll now revisit nums = [9, 1, 4, 2, 3, 3, 7].

Call: LIS(0, -1)
├── skip 9 → LIS(1, -1)
│   ├── skip 1 → LIS(2, -1)
│   │   ├── skip 4 → LIS(3, -1)
│   │   │   ├── skip 2 → LIS(4, -1)
│   │   │   │   ├── skip 3 → LIS(5, -1)
│   │   │   │   │   ├── skip 3 → LIS(6, -1)
│   │   │   │   │   │   ├── skip 7 → LIS(7, -1) = 0
│   │   │   │   │   │   └── include 7 → LIS(7, 6) = 0 → return 1
│   │   │   │   │   └── memo[6, 0] = 1
│   │   │   │   └── include 3 → LIS(6, 4) → memo[6, 5] filled next
│   │   │   └── include 2 → LIS(4, 3) → memo[4, 4]
│   │   └── include 4 → LIS(3, 2) → memo[3, 3]
│   └── include 1 → LIS(2, 1) → memo[2, 2]
└── include 9 → LIS(1, 0)
    ├── skip 1 (not valid, 1 < 9)
    └── skip 4 → ...

Once a call like LIS(6, -1) is computed, future calls with those exact indices are 
retrieved instantly from memo[6, 0].

This version works just like the brute-force one — exploring each position with the 
choice of "include or skip." But here, we store the result of each unique state 
defined by (i, j) in a 2D array (memo[i][j+1]). This way, if a state is revisited 
later (which happens a lot), we just return the saved result instead of recomputing it.

This optimization drastically improves efficiency. For nums = [9, 1, 4, 2, 3, 3, 7], 
there are many repeated (i, j) states, so memoization cuts down the time from exponential
to quadratic.
*/

/*
Here is the final memo table after running the top-down DP LIS algorithm on:

ini
Copy
Edit
nums = [9, 1, 4, 2, 3, 3, 7]
Each entry memo[i][j+1] stores the length of the longest increasing subsequence 
starting at index i, given that the last picked index was j (j = -1 means no previous 
element).

     j = -1    0   1   2   3   4   5   6
        -------------------------------
i = 0 |   4   -1  -1  -1  -1  -1  -1  -1
i = 1 |   4    0  -1  -1  -1  -1  -1  -1
i = 2 |   3    0   3  -1  -1  -1  -1  -1
i = 3 |   3    0   3   1  -1  -1  -1  -1
i = 4 |   2    0   2   1   2  -1  -1  -1
i = 5 |   2    0   2   1   2   1  -1  -1
i = 6 |   1    0   1   1   1   1   1  -1
*/


/*
Longest Increasing Subsequence

Given an integer array nums, return the length of the longest strictly increasing 
subsequence.

A subsequence is a sequence that can be derived from the given sequence by deleting 
some or no elements without changing the relative order of the remaining characters.

For example, "cat" is a subsequence of "crabt".

Example 1:
Input: nums = [9,1,4,2,3,3,7]
Output: 4
Explanation: The longest increasing subsequence is [1,2,3,7], which has a length of 4.

Example 2:
Input: nums = [0,3,1,3,2,3]
Output: 4

Constraints:
1 <= nums.length <= 1000
-1000 <= nums[i] <= 1000
*/