public partial class Solution {
    private int[] LISDPTDIImemo; // Memoization array, stores LIS starting at each index

    public int DPTDIILengthOfLIS(int[] nums) {
        int n = nums.Length;
        LISDPTDIImemo = new int[n];
        Array.Fill(LISDPTDIImemo, -1); // Initialize all memo values to -1 (uncomputed)

        int maxLIS = 1; // At least one element is always an increasing subsequence
        for (int i = 0; i < n; i++) {
            // Compute LIS starting at index i and track the global max
            maxLIS = Math.Max(maxLIS, LISDPTDIIDfs(nums, i));
        }
        return maxLIS;
    }

    private int LISDPTDIIDfs(int[] nums, int i) {
        if (LISDPTDIImemo[i] != -1) {
            return LISDPTDIImemo[i]; // Already computed
        }

        int LIS = 1; // The element at index i itself is a valid subsequence
        for (int j = i + 1; j < nums.Length; j++) {
            if (nums[i] < nums[j]) {
                // Can extend the subsequence to nums[j]
                LIS = Math.Max(LIS, 1 + LISDPTDIIDfs(nums, j));
            }
        }

        LISDPTDIImemo[i] = LIS; // Save the result in memo
        return LIS;
    }
}

/*
🌳 Recursion Tree for nums = [9, 1, 4, 2, 3, 3, 7]

Each node represents LISDPTDIIDfs(nums, i):

DPTDIILengthOfLIS:
  i=0 -> LIS(0) = 1                  // 9 can't grow, as all later numbers are smaller
  i=1 -> LIS(1) = 4
    ├─ j=2 (4) -> LIS(2) = 3
    │   ├─ j=4 (3) -> LIS(4) = 2
    │   │   └─ j=6 (7) -> LIS(6) = 1
    │   └─ j=6 (7)
    └─ j=6 (7)
  i=2 -> LIS(2) = 3
    ├─ j=4 (3) -> LIS(4) = 2
    │   └─ j=6 (7)
    └─ j=6 (7)
  i=3 -> LIS(3) = 2
    └─ j=4 (3)
        └─ j=6 (7)
  i=4 -> LIS(4) = 2
    └─ j=6 (7)
  i=5 -> LIS(5) = 2
    └─ j=6 (7)
  i=6 -> LIS(6) = 1

This approach treats each index as the potential start of an increasing subsequence. 
It uses recursion to explore how long a subsequence can grow from that index by comparing 
to every element ahead of it.

Here’s the process for nums = [9, 1, 4, 2, 3, 3, 7]:

Start from index 0 (value 9). No future values are larger, so the LIS from here is just 1.

At index 1 (value 1), you can go to:
4 → 2 → 3 → 7: a chain of 4 elements → LIS = 4.

From index 2 (value 4), you can go to 7, or to 3 and then 7 → LIS = 3.
Index 3 (2) can go to 3 → 7, or directly to 7 → LIS = 2.

Index 4 and 5 (3s) can go to 7 → LIS = 2.

Index 6 (7) has no valid continuation → LIS = 1.

The maximum among all these gives the final result: 4.
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