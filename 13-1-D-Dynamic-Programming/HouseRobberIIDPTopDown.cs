public partial class Solution {
    private int[][] HRIIDPTDmemo;

    public int HRIIDPTDRob(int[] nums) {
        // Special case: only one house
        if (nums.Length == 1) return nums[0];

        // Memo table: HRIIDPTPmemo[i][flag]
        // flag = 1 if first house is robbed, else 0
        HRIIDPTDmemo = new int[nums.Length][];
        for (int i = 0; i < nums.Length; i++) {
            HRIIDPTDmemo[i] = new int[] { -1, -1 }; // -1 = uncomputed
        }

        // Try robbing starting at index 0 (set flag = 1) or at index 1 (flag = 0)
        return Math.Max(HRIIDPTDDfs(0, 1, nums), HRIIDPTDDfs(1, 0, nums));
    }

    private int HRIIDPTDDfs(int i, int flag, int[] nums) {
        // Base case:
        // if we've passed the end of array, return 0
        // if we robbed first house (flag == 1) and now are at last house, we skip it
        if (i >= nums.Length || (flag == 1 && i == nums.Length - 1)) 
            return 0;

        // Check memoized result
        if (HRIIDPTDmemo[i][flag] != -1) 
            return HRIIDPTDmemo[i][flag];

        // Option 1: skip this house → go to next
        int skip = HRIIDPTDDfs(i + 1, flag, nums);

        // Option 2: rob this house
        // If i == 0, we set flag = 1 (indicating first house was robbed)
        int newFlag = flag | (i == 0 ? 1 : 0);
        int rob = nums[i] + HRIIDPTDDfs(i + 2, newFlag, nums);

        // Memoize and return max of both options
        return HRIIDPTDmemo[i][flag] = Math.Max(skip, rob);
    }
}

/*
🌲 2. Notepad-Friendly Tree Style Execution (Input: [2,9,8,3,6])
We'll show two paths, one starting at index 0 (robs house 0, flag = 1) and the 
other at index 1 (skips house 0, flag = 0).

🟦 Path 1: Start at index 0, flag = 1
(Can’t rob house 4 if house 0 is robbed)

HRIIDPTPDfs(0, 1)
├─ skip → HRIIDPTPDfs(1, 1)
│  ├─ skip → HRIIDPTPDfs(2, 1)
│  │  ├─ skip → HRIIDPTPDfs(3, 1)
│  │  │  ├─ skip → HRIIDPTPDfs(4, 1) = 0 ❌ (can’t rob last if first was robbed)
│  │  │  └─ rob → HRIIDPTPDfs(5, 1) = 0
│  │  │     return max(0, 3 + 0) = 3
│  │  └─ rob → HRIIDPTPDfs(4, 1) = 0 ❌
│  │     return max(3, 8 + 0) = 8
│  └─ rob → HRIIDPTPDfs(3, 1) = 3
│     return max(8, 9 + 3) = 12
└─ rob → HRIIDPTPDfs(2, 1) = 8
   return max(12, 2 + 8) = 12
📘 Path 1 total = 12

🟩 Path 2: Start at index 1, flag = 0
(House 0 skipped → we can rob last house)

HRIIDPTPDfs(1, 0)
├─ skip → HRIIDPTPDfs(2, 0)
│  ├─ skip → HRIIDPTPDfs(3, 0)
│  │  ├─ skip → HRIIDPTPDfs(4, 0)
│  │  │  ├─ skip → HRIIDPTPDfs(5, 0) = 0
│  │  │  └─ rob → HRIIDPTPDfs(6, 1) = 0
│  │  │     return max(0, 6 + 0) = 6
│  │  └─ rob → HRIIDPTPDfs(5, 1) = 0
│  │     return max(6, 3 + 0) = 6
│  └─ rob → HRIIDPTPDfs(4, 1)
│     ├─ skip → HRIIDPTPDfs(5, 1) = 0
│     └─ rob → HRIIDPTPDfs(6, 1) = 0
│     return max(0, 6 + 0) = 6
│     return max(6, 8 + 6) = 14
└─ rob → HRIIDPTPDfs(3, 0) = 6
   return max(14, 9 + 6) = 15 ✅
📗 Path 2 total = 15

✅ Final Result
return Math.Max(12, 15); // => 15

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