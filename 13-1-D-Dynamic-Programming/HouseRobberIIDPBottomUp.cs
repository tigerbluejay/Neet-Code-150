public partial class Solution {
    public int HRIIDPBURob(int[] nums) {
        // Edge case: no houses
        if (nums.Length == 0) return 0;
        // Edge case: only one house
        if (nums.Length == 1) return nums[0];

        // House Robber II:
        // Because the first and last houses are adjacent (circular),
        // we split the problem into two cases:
        // 1. Rob houses from index 1 to end (excluding first)
        // 2. Rob houses from index 0 to second-to-last (excluding last)
        return Math.Max(
            HRIIDPBUHelper(nums[1..]),    // Rob from index 1 to end
            HRIIDPBUHelper(nums[..^1])    // Rob from start to second-last
        );
    }

    // Standard House Robber I bottom-up DP
    private int HRIIDPBUHelper(int[] nums) {
        if (nums.Length == 0) return 0;
        if (nums.Length == 1) return nums[0];

        int[] dp = new int[nums.Length];
        dp[0] = nums[0];                         // Only one house
        dp[1] = Math.Max(nums[0], nums[1]);      // Choose max between first two

        for (int i = 2; i < nums.Length; i++) {
            // At each house: either skip it or rob it and add the value from two steps back
            dp[i] = Math.Max(dp[i - 1], nums[i] + dp[i - 2]);
        }

        return dp[^1]; // Last element has the max profit
    }
}

/*
🌲 2. Step-by-Step Notepad-Friendly Execution
Input: [2, 9, 8, 3, 6]

We consider two scenarios:

🟦 Case A: Rob from index 1 to end → input = [9, 8, 3, 6]
i	House	dp[i] Calculation	dp[i]
0	9	    dp[0] = 9	        9
1	8	    max(9, 8)	        9
2	3	    max(9, 3 + 9)	    12
3	6	    max(12, 6 + 9)	    15
✅ Max for Case A = 15

🟩 Case B: Rob from index 0 to second-last → input = [2, 9, 8, 3]
i	House	dp[i] Calculation	dp[i]
0	2	dp[0] = 2	2
1	9	max(2, 9)	9
2	8	max(9, 8 + 2)	10
3	3	max(10, 3 + 9)	12
✅ Max for Case B = 12

✅ Final Result
return Math.Max(15, 12); // => 15
*/

/*
House Robber II

You are given an integer array nums where nums[i] represents the amount of money 
the ith house has. The houses are arranged in a circle, i.e. the first house and the 
last house are neighbors.

You are planning to rob money from the houses, but you cannot rob two adjacent houses 
because the security system will automatically alert the police if two adjacent houses 
were both broken into.

Return the maximum amount of money you can rob without alerting the police.

Example 1:
Input: nums = [3,4,3]
Output: 4
Explanation: You cannot rob nums[0] + nums[2] = 6 because nums[0] and nums[2] are 
adjacent houses. The maximum you can rob is nums[1] = 4.

Example 2:
Input: nums = [2,9,8,3,6]
Output: 15
Explanation: You cannot rob nums[0] + nums[2] + nums[4] = 16 because nums[0] and 
nums[4] are adjacent houses. The maximum you can rob is nums[1] + nums[4] = 15.

Constraints:
1 <= nums.length <= 100
0 <= nums[i] <= 100
*/