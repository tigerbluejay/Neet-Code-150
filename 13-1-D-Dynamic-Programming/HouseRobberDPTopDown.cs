public partial class Solution {
    private int[] memo;

    public int DPTDRob(int[] nums) {
        // Initialize memoization array with -1 (indicating uncomputed values)
        memo = new int[nums.Length];
        for (int i = 0; i < nums.Length; i++) {
            memo[i] = -1;
        }
        // Start recursive function from the first house
        return HRDPTDDfs(nums, 0);
    }

    private int HRDPTDDfs(int[] nums, int i) {
        // Base case: If we go beyond the last house, return 0
        if (i >= nums.Length) {
            return 0;
        }

        // If already computed, return the stored result
        if (memo[i] != -1) {
            return memo[i];
        }

        // Compute and store the result in the memo array
        memo[i] = Math.Max(HRDPTDDfs(nums, i + 1), // Skip the current house
                           nums[i] + HRDPTDDfs(nums, i + 2)); // Rob the current house
        return memo[i];
    }
}

/*
Recursion Tree with Memoization
For nums = [2, 9, 8, 3, 6]:

HRDPTDDfs(0)   → Max(HRDPTDDfs(1), 2 + HRDPTDDfs(2))
 ├── HRDPTDDfs(1)   → Max(HRDPTDDfs(2), 9 + HRDPTDDfs(3))
 │    ├── HRDPTDDfs(2)   → Max(HRDPTDDfs(3), 8 + HRDPTDDfs(4))
 │    │    ├── HRDPTDDfs(3)   → Max(HRDPTDDfs(4), 3 + HRDPTDDfs(5))
 │    │    │    ├── HRDPTDDfs(4)   → Max(HRDPTDDfs(5), 6 + HRDPTDDfs(6))
 │    │    │    │    ├── HRDPTDDfs(5) → 0 (out of bounds)
 │    │    │    │    ├── HRDPTDDfs(6) → 0 (out of bounds)
 │    │    │    │    └── Max(0, 6) = 6
 │    │    │    ├── HRDPTDDfs(5) → 0 (out of bounds)
 │    │    │    └── Max(6, 3 + 0) = 6
 │    │    ├── HRDPTDDfs(4) → 6 (memoized)
 │    │    └── Max(6, 8 + 6) = 14
 │    ├── HRDPTDDfs(3) → 6 (memoized)
 │    └── Max(14, 9 + 6) = 15
 ├── HRDPTDDfs(2) → 14 (memoized)
 └── Max(15, 2 + 14) = 16

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