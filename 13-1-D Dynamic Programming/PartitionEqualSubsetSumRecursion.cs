public partial class Solution {
    public bool RCanPartition(int[] nums) {
        int sum = 0;

        // Step 1: Calculate total sum of array
        for (int i = 0; i < nums.Length; i++) {
            sum += nums[i];
        }

        // Step 2: If total sum is odd, it cannot be split into two equal parts
        if (sum % 2 != 0) {
            return false;
        }

        // Step 3: Call DFS to check if there exists a subset with sum = sum / 2
        return PESSRDfs(nums, 0, sum / 2);
    }

    // Recursive DFS function
    // i: current index in nums array
    // target: remaining target sum to achieve
    public bool PESSRDfs(int[] nums, int i, int target) {
        // Base case: reached end of array
        if (i == nums.Length) {
            return target == 0; // True if target is exactly 0
        }

        // If target becomes negative, no point in continuing
        if (target < 0) {
            return false;
        }

        // Recursive step:
        // 1. Skip current element
        // 2. Include current element in the subset and subtract it from target
        return PESSRDfs(nums, i + 1, target) ||
               PESSRDfs(nums, i + 1, target - nums[i]);
    }
}

/*
🌲 Recursive Call Tree (for nums = [1, 2, 3, 4])
Total sum = 10 → target = 5

The tree shows:

(i, target) as the state of the function call
Branches for including and excluding the current element

(0,5)
├── (1,5)  // Exclude nums[0]=1
│   ├── (2,5)
│   │   ├── (3,5)
│   │   │   ├── (4,5) ❌
│   │   │   └── (4,1) ❌
│   │   └── (3,2)
│   │       ├── (4,2) ❌
│   │       └── (4,-2) ❌
│   └── (2,3)
│       ├── (3,3)
│       │   ├── (4,3) ❌
│       │   └── (4,0) ✅  ← solution found
│       └── (3,0) ✅  ← solution found
└── (1,4)  // Include nums[0]=1
    ├── (2,4)
    │   ├── (3,4)
    │   │   ├── (4,4) ❌
    │   │   └── (4,1) ❌
    │   └── (3,1)
    │       ├── (4,1) ❌
    │       └── (4,-2) ❌
    └── (2,2)
        ├── (3,2)
        │   ├── (4,2) ❌
        │   └── (4,-1) ❌
        └── (3,-1) ❌

✅ paths reach (4,0), meaning we found a subset sum that adds up to 5.
DFS returns true the moment it finds any such path.
Note that reaching a subarray that adds up to 5 is sufficient because
it means that the remaining elements not included in that subarray will
also sum to 5, since 5 is exactly half of total sum of the elements in the
original array.
*/

/*
The DFS traversal explores all possible ways to select a subset of numbers 
that add up to exactly half of the total sum. Starting from the first index, 
the function considers two choices at each step: either exclude the current 
number from the subset (keeping the target sum unchanged) or include it 
(subtracting the current number's value from the target). This branching 
continues recursively until one of two conditions is met: either the target 
reaches zero, indicating a valid subset has been found, or the index reaches 
the end of the array without achieving the target. If at any point the target 
becomes negative, the function returns false early since continuing further 
cannot yield a valid result. The recursion effectively builds a decision tree 
of inclusion and exclusion, and the function returns true as soon as any branch 
reaches a valid partition.
*/


/*
Partition Equal Subset Sum

You are given an array of positive integers nums.
Return true if you can partition the array into two subsets, 
subset1 and subset2 where sum(subset1) == sum(subset2). Otherwise, return false.

Example 1:
Input: nums = [1,2,3,4]
Output: true
Explanation: The array can be partitioned as [1, 4] and [2, 3].

Example 2:
Input: nums = [1,2,3,4,5]
Output: false

Constraints:
1 <= nums.length <= 100
1 <= nums[i] <= 50
*/