public partial class Solution {
    public int DPBUILengthOfLIS(int[] nums) {
        int n = nums.Length;
        // dp[i, j+1] stores the length of LIS starting at index i, 
        // with the previous number in the sequence being at index j
        // We use j + 1 because j can be -1 (no previous element), and 
        // arrays can’t use -1 as index
        int[,] dp = new int[n + 1, n + 1];

        // Fill the DP table in reverse order (bottom-up)
        for (int i = n - 1; i >= 0; i--) {
            for (int j = i - 1; j >= -1; j--) {
                // Case 1: skip nums[i], LIS length remains as it was from 
                // i+1 with same j
                int LIS = dp[i + 1, j + 1];

                // Case 2: include nums[i] if valid (either first element or increasing)
                if (j == -1 || nums[j] < nums[i]) {
                    LIS = Math.Max(LIS, 1 + dp[i + 1, i + 1]);
                }

                // Save result
                dp[i, j + 1] = LIS;
            }
        }

        // Result is LIS starting at index 0 with no previous element
        return dp[0, 0];
    }
}
/*

🌳 Tree-like Structure (Conceptual Translation)

Since this is bottom-up, it's not a recursive tree, but you can imagine it as a 
reversed recursion tree being filled from the leaves up.

Think of it like this:

dp[i, j+1] = max(
    dp[i+1, j+1],                   // don't include nums[i]
    if (j == -1 || nums[j] < nums[i])
        1 + dp[i+1, i+1]            // include nums[i]
)
For nums = [9, 1, 4, 2, 3, 3, 7] the table will be filled starting from the end:

Start with i = 6 (value 7), and j = -1 to 5.
Then i = 5 (value 3), compare with j = -1 to 4.
...
Finally, i = 0 (value 9), compare with all previous values (none in this case).

So the computation flows bottom-up, calculating for every possible pair of current 
index i and previous index j.

This version builds the solution from the ground up, avoiding recursion.
We use a 2D DP table where:
dp[i][j+1] represents the length of the LIS starting at index i,
assuming that the previous element in the subsequence is at index j.
We iterate from the last index of the array backwards, trying for each pair (i, j) to:
either skip nums[i], and keep the LIS value from dp[i+1][j+1],
or include nums[i], if it forms an increasing sequence with nums[j], and add 1 + dp[i+1][i+1].
We always store the maximum of these two in dp[i][j+1].
At the end, dp[0][0] contains the result: the longest increasing subsequence length 
starting from index 0 with no previous element selected.
*/
/*
i\j	-1	0	1	2	3	4	5	6
0	4	0	0	0	0	0	0	0
1	4	0	0	0	0	0	0	0
2	3	0	3	0	0	0	0	0
3	3	0	3	1	0	0	0	0
4	2	0	2	1	2	0	0	0
5	2	0	2	1	2	1	0	0
6	1	0	1	1	1	1	1	0
7	0	0	0	0	0	0	0	0

dp[i][j+1] stores the length of the Longest Increasing Subsequence starting at i with the 
previous index being j.

The final result is found at dp[0][0] = 4, which is the length of the longest increasing 
subsequence. 
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