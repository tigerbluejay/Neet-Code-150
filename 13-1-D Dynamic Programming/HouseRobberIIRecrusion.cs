public partial class Solution {
    public int HRIIRRob(int[] nums) {
        // Edge case: Only one house, rob it
        if (nums.Length == 1) return nums[0];

        // Option 1: Rob from index 0 to n-2 (exclude last house)
        // Option 2: Rob from index 1 to n-1 (exclude first house)
        // Take the max of both strategies
        return Math.Max(HRIIRDfs(0, true, nums), HRIIRDfs(1, false, nums));
    }

    private int HRIIRDfs(int i, bool flag, int[] nums) {
        // Base case: out of bounds
        // OR if we started at index 0 and now reached the last house (i == n-1), we can't rob it
        if (i >= nums.Length || (flag && i == nums.Length - 1)) 
            return 0;

        // Choice:
        // - Skip current house (move to i+1)
        // - Rob current house (add nums[i] and move to i+2)
        // When robbing the first house (i == 0), set flag to true to mark circular constraint
        return Math.Max(
            HRIIRDfs(i + 1, flag, nums),
            nums[i] + HRIIRDfs(i + 2, flag || i == 0, nums)
        );
    }
}
/*

Recursive Tree for HRIIRDfs(0, true, nums)
(This excludes last house)

HRIIRDfs(0, true)
├─ skip → HRIIRDfs(1, true)
│  ├─ skip → HRIIRDfs(2, true)
│  │  ├─ skip → HRIIRDfs(3, true)
│  │  │  ├─ skip → HRIIRDfs(4, true) = 0  ❌ (flag==true && i==4)
│  │  │  └─ rob  → HRIIRDfs(5, true) = 0
│  │  │     return max(0, 3 + 0) = 3
│  │  └─ rob → HRIIRDfs(4, true) = 0  ❌
│  │     return max(3, 8 + 0) = 8
│  └─ rob → HRIIRDfs(3, true)
│     (already computed = 3)
│     return max(8, 9 + 3) = 12
└─ rob → HRIIRDfs(2, true)
   (already computed = 8)
   return max(12, 2 + 8) = 12

Result from path 1 = 12

🌲 Recursive Tree for HRIIRDfs(1, false, nums)
(This excludes first house)

HRIIRDfs(1, false)
├─ skip → HRIIRDfs(2, false)
│  ├─ skip → HRIIRDfs(3, false)
│  │  ├─ skip → HRIIRDfs(4, false)
│  │  │  ├─ skip → HRIIRDfs(5, false) = 0
│  │  │  └─ rob → HRIIRDfs(6, true) = 0
│  │  │     return max(0, 6 + 0) = 6
│  │  └─ rob → HRIIRDfs(5, true) = 0
│  │     return max(6, 3 + 0) = 6
│  └─ rob → HRIIRDfs(4, true)
│     ├─ skip → HRIIRDfs(5, true) = 0
│     └─ rob → HRIIRDfs(6, true) = 0
│        return max(0, 6 + 0) = 6
│     return max(6, 8 + 6) = 14
└─ rob → HRIIRDfs(3, false)
   (already computed = 6)
   return max(14, 9 + 6) = 15 ✅

Result from path 2 = 15

✅ Final Answer
return Math.Max(12, 15); // → 15
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