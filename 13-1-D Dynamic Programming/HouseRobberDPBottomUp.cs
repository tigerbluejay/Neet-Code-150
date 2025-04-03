public partial class Solution {
    public int DPBURob(int[] nums) {
        // Edge case: No houses
        if (nums.Length == 0) return 0;
        // Edge case: Only one house
        if (nums.Length == 1) return nums[0];

        // DP array to store max loot at each house
        int[] dp = new int[nums.Length];
        dp[0] = nums[0]; // Base case: First house
        dp[1] = Math.Max(nums[0], nums[1]); // Base case: Max of first two houses

        // Fill DP array iteratively
        for (int i = 2; i < nums.Length; i++) {
            dp[i] = Math.Max(dp[i - 1], nums[i] + dp[i - 2]);
        }

        // Final answer is the last element in dp array
        return dp[nums.Length - 1];
    }
}

/*
For nums = [2, 9, 8, 3, 6]:

i	nums[i]	dp[i] (Max loot)	    Decision
0	2	    2	                    Base case (first house)
1	9	    max(2, 9) = 9	        Choose max of first two houses
2	8	    max(9, 2 + 8) = 10	    Either skip or rob
3	3	    max(10, 9 + 3) = 12	    Either skip or rob
4	6	    max(12, 10 + 6) = 16	Either skip or rob


DP[0] = 2        → Base case: First house only
DP[1] = max(2, 9) = 9  → Max of first two houses

DP[2] = max(DP[1], nums[2] + DP[0]) 
       = max(9, 8 + 2) 
       = 10

DP[3] = max(DP[2], nums[3] + DP[1]) 
       = max(10, 3 + 9) 
       = 12

DP[4] = max(DP[3], nums[4] + DP[2]) 
       = max(12, 6 + 10) 
       = 16
*/

/*
House Robber

You are given an integer array nums where nums[i] represents the amount of money 
the ith house has. The houses are arranged in a straight line, i.e. the ith house 
is the neighbor of the (i-1)th and (i+1)th house.

You are planning to rob money from the houses, but you cannot rob two adjacent 
houses because the security system will automatically alert the police if two 
adjacent houses were both broken into.

Return the maximum amount of money you can rob without alerting the police.

Example 1:
Input: nums = [1,1,3,3]
Output: 4
Explanation: nums[0] + nums[2] = 1 + 3 = 4.

Example 2:
Input: nums = [2,9,8,3,6]
Output: 16
Explanation: nums[0] + nums[2] + nums[4] = 2 + 8 + 6 = 16.

Constraints:
1 <= nums.length <= 100
0 <= nums[i] <= 100
*/