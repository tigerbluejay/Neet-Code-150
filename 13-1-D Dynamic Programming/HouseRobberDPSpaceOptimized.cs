public partial class Solution {
    public int DPSORob(int[] nums) {
        // rob1 stores the max loot up to two houses before
        // rob2 stores the max loot up to the last house
        int rob1 = 0, rob2 = 0;

        // Iterate through each house in the array
        foreach (int num in nums) {
            // Compute the new maximum loot possible at this step
            int temp = Math.Max(num + rob1, rob2);

            // Shift values forward for the next iteration
            rob1 = rob2;  // The previous max becomes the "two houses ago" max
            rob2 = temp;  // The new max becomes the current max
        }

        // The final answer is stored in rob2 (the max loot possible)
        return rob2;
    }
}

/*
This version of House Robber optimizes the Bottom-Up DP approach by reducing space 
complexity from O(n) to O(1). Instead of using a dp array, it only keeps track of the 
last two computed values.
*/

/*
Initialization:
rob1 = 0, rob2 = 0

Step-by-step:

House[0] = 2
    temp = max(2 + rob1, rob2) = max(2 + 0, 0) = 2
    rob1 = 0, rob2 = 2

House[1] = 9
    temp = max(9 + rob1, rob2) = max(9 + 0, 2) = 9
    rob1 = 2, rob2 = 9

House[2] = 8
    temp = max(8 + rob1, rob2) = max(8 + 2, 9) = 10
    rob1 = 9, rob2 = 10

House[3] = 3
    temp = max(3 + rob1, rob2) = max(3 + 9, 10) = 12
    rob1 = 10, rob2 = 12

House[4] = 6
    temp = max(6 + rob1, rob2) = max(6 + 10, 12) = 16
    rob1 = 12, rob2 = 16

Final Answer = 16
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