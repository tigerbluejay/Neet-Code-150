public partial class Solution {
    public int DPBSLengthOfLIS(int[] nums) {
        // dp[i] will hold the smallest possible tail value for an increasing 
        // subsequence of length i+1
        List<int> dp = new List<int>();
        dp.Add(nums[0]);

        int LIS = 1; // start with first element as base subsequence
        for (int i = 1; i < nums.Length; i++) {
            // If current number is greater than the last number in dp, 
            // it extends the LIS
            if (dp[dp.Count - 1] < nums[i]) {
                dp.Add(nums[i]); // add new larger value
                LIS++;
                continue;
            }

            // Otherwise, find the smallest number in dp >= nums[i] to 
            // replace it (binary search)
            int idx = dp.BinarySearch(nums[i]);

            // If not found, BinarySearch returns negative complement of 
            // insertion index (~idx)
            if (idx < 0) idx = ~idx;

            // Replace the value at the found index — this doesn't change LIS length
            // but improves the potential for future longer sequences
            dp[idx] = nums[i];
        }

        return LIS;
    }
}

/*
🌲 Tree-Like Trace (Copy-Paste Friendly)
For nums = [9,1,4,2,3,3,7]

i = 0, nums[i] = 9
dp: [9]

i = 1, nums[i] = 1
BinarySearch(1) = ~0 → replace dp[0] = 1
dp: [1]

i = 2, nums[i] = 4
dp[dp.Count-1] < 4 → append
dp: [1, 4]

i = 3, nums[i] = 2
BinarySearch(2) = ~1 → replace dp[1] = 2
dp: [1, 2]

i = 4, nums[i] = 3
BinarySearch(3) = ~2 → replace dp[2] = 3
dp: [1, 2, 3]

i = 5, nums[i] = 3
BinarySearch(3) = 2 → replace dp[2] = 3 (unchanged)
dp: [1, 2, 3]

i = 6, nums[i] = 7
dp[dp.Count-1] < 7 → append
dp: [1, 2, 3, 7]

Final LIS: 4
*/

/*
What's Happening?

We're not actually building the LIS sequence itself.

We're maintaining a greedy front: the dp list has the smallest possible end 
values for subsequences of various lengths.

If a number extends the longest subsequence → append.
If not → replace a value to keep the subsequences optimally low.

This method achieves O(n log n) time due to binary search.
*/

/*
Purpose of BinarySearch in LIS
It finds the position in the dp list where the current number should be placed or 
replaced to maintain a growing list of optimal "tails" for increasing subsequences.

📦 What is dp holding?
dp[i] = the smallest possible tail value of any increasing subsequence of length i + 1.

So dp is always sorted in ascending order, which is why binary search works.
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