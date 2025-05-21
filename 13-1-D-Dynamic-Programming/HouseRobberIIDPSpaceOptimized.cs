public partial class Solution {
    
    public int HRIIDPSORob(int[] nums) {
        // Edge case: only one house
        if (nums.Length == 1) 
            return nums[0];

        // House Robber II: we can't rob both first and last houses
        // So we split into two cases:
        // Case 1: rob from 1 to end
        // Case 2: rob from 0 to second-last
        return Math.Max(HRIIDPSOHelper(nums[1..]),     // Exclude first
                        HRIIDPSOHelper(nums[..^1]));   // Exclude last
    }

    private int HRIIDPSOHelper(int[] nums) {
        // rob1: max amount robbed up to two houses ago
        // rob2: max amount robbed up to previous house
        int rob1 = 0, rob2 = 0;

        foreach (int num in nums) {
            // Either rob this house and add rob1,
            // or skip it and carry rob2
            int newRob = Math.Max(rob1 + num, rob2);
            rob1 = rob2;
            rob2 = newRob;
        }

        return rob2; // The final max
    }
}

/*
🌲 2. Visual Step-by-Step Execution with Arrows
Input: nums = [2, 9, 8, 3, 6]
We compute the max between two cases:

🟦 Case A: Exclude first → [9, 8, 3, 6]

Start: rob1 = 0, rob2 = 0

House: 9
→ newRob = max(0 + 9, 0) = 9
→ rob1 = 0, rob2 = 9

House: 8
→ newRob = max(0 + 8, 9) = 9
→ rob1 = 9, rob2 = 9

House: 3
→ newRob = max(9 + 3, 9) = 12
→ rob1 = 9, rob2 = 12

House: 6
→ newRob = max(9 + 6, 12) = 15
→ rob1 = 12, rob2 = 15
✅ Max for Case A = 15

🟩 Case B: Exclude last → [2, 9, 8, 3]
Start: rob1 = 0, rob2 = 0

House: 2
→ newRob = max(0 + 2, 0) = 2
→ rob1 = 0, rob2 = 2

House: 9
→ newRob = max(0 + 9, 2) = 9
→ rob1 = 2, rob2 = 9

House: 8
→ newRob = max(2 + 8, 9) = 10
→ rob1 = 9, rob2 = 10

House: 3
→ newRob = max(9 + 3, 10) = 12
→ rob1 = 10, rob2 = 12

✅ Max for Case B = 12

✅ Final Answer:
return Math.Max(15, 12); // → 15
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