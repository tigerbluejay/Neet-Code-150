public partial class Solution {
    // Main function to start the recursion from the first house (index 0)
    public int RRob(int[] nums) {
        return HRRDfs(nums, 0);
    }

    // Recursive function to explore the maximum amount that can be robbed
    private int HRRDfs(int[] nums, int i) {
        // Base case: If the index exceeds the length of the array, return 0
        if (i >= nums.Length) {
            return 0;
        }

        // Recursive case: Choose between skipping the current house or robbing it
        // - If we skip: Call HRRDfs on the next house (i+1)
        // - If we rob: Add the value of the current house to the result of HRRDfs(i+2)
        return Math.Max(HRRDfs(nums, i + 1),  // Skip the current house
                        nums[i] + HRRDfs(nums, i + 2)); // Rob the current house
    }
}

/*
Recursive Tree Representation

For the input nums = [2, 9, 8, 3, 6], we want to see the recursion tree that leads to 
the maximum loot of 16.

HRRDfs(0)   → Max(HRRDfs(1), 2 + HRRDfs(2))
 ├── HRRDfs(1)   → Max(HRRDfs(2), 9 + HRRDfs(3))
 │    ├── HRRDfs(2)   → Max(HRRDfs(3), 8 + HRRDfs(4))
 │    │    ├── HRRDfs(3)   → Max(HRRDfs(4), 3 + HRRDfs(5))
 │    │    │    ├── HRRDfs(4)   → Max(HRRDfs(5), 6 + HRRDfs(6))
 │    │    │    │    ├── HRRDfs(5) → 0 (out of bounds)
 │    │    │    │    ├── HRRDfs(6) → 0 (out of bounds)
 │    │    │    │    └── Max(0, 6) = 6
 │    │    │    ├── HRRDfs(5) → 0 (out of bounds)
 │    │    │    └── Max(6, 3 + 0) = 6
 │    │    ├── HRRDfs(4) → 6 (already computed)
 │    │    └── Max(6, 8 + 6) = 14
 │    ├── HRRDfs(3) → 6 (already computed)
 │    └── Max(14, 9 + 6) = 15
 ├── HRRDfs(2) → 14 (already computed)
 └── Max(15, 2 + 14) = 16

The recursion works by trying to either rob the current house or skip it, and it 
explores all possibilities before selecting the maximum amount possible.
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