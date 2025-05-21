public partial class Solution
{
    private bool?[,] PESSDPTDmemo;

    public bool DPTDCanPartition(int[] nums)
    {
        int sum = 0;

        // Step 1: Calculate total sum
        for (int i = 0; i < nums.Length; i++)
        {
            sum += nums[i];
        }

        // Step 2: If sum is odd, can't divide into equal subsets
        if (sum % 2 != 0)
        {
            return false;
        }

        // Step 3: Initialize 2D memoization array (index, target)
        PESSDPTDmemo = new bool?[nums.Length + 1, sum / 2 + 1];

        // Step 4: Start DFS with memoization to find target = sum / 2
        return PESSDPTDDfs(nums, 0, sum / 2);
    }

    public bool PESSDPTDDfs(int[] nums, int i, int target)
    {
        // Base case: we hit the exact target
        if (target == 0)
        {
            return true;
        }

        // Base case: out of bounds or invalid path
        if (i == nums.Length || target < 0)
        {
            return false;
        }

        // Return cached result if already computed
        if (PESSDPTDmemo[i, target] != null)
        {
            return PESSDPTDmemo[i, target] == true;
        }

        // Recursive step: explore including or skipping current element
        bool result = PESSDPTDDfs(nums, i + 1, target) ||
                      PESSDPTDDfs(nums, i + 1, target - nums[i]);

        // Store result in memo table
        PESSDPTDmemo[i, target] = result;
        return result;
    }
}

/*
This top-down dynamic programming approach builds on the recursive solution by adding 
memoization to eliminate redundant computations. As before, the algorithm attempts to 
find a subset of elements that sum to half the total. At each step, it considers two 
options: skip the current number or include it in the running total, reducing the target 
accordingly. To optimize, the function stores previously computed results for each 
combination of index and target in a memoization table. If a state is revisited, it simply 
returns the stored result instead of recomputing the entire subtree. This avoids 
exponential recomputation, reducing the overall time complexity from exponential to 
pseudo-polynomial.
*/

/*
🌲 Recursive Call Tree for nums = [1,2,3,4]

Just like in the raw recursive version, but memoization prunes some repeated branches.

Input sum = 10 → target = 5

(0,5)
├── (1,5)  // skip 1
│   ├── (2,5)  // skip 2
│   │   ├── (3,5)  // skip 3
│   │   │   ├── (4,5) ❌
│   │   │   └── (4,2) ❌
│   │   └── (3,2)  // include 3
│   │       ├── (4,2) ❌ (memo hit)
│   │       └── (4,-1) ❌
│   └── (2,3)  // include 2
│       ├── (3,3)
│       │   ├── (4,3) ❌
│       │   └── (4,0) ✅ ← solution
│       └── (3,0) ✅ ← solution
└── (1,4)  // include 1
    ├── (2,4)
    │   ├── (3,4)
    │   │   ├── (4,4) ❌
    │   │   └── (4,1) ❌
    │   └── (3,1)
    │       ├── (4,1) ❌ (memo hit)
    │       └── (4,-2) ❌
    └── (2,2)
        ├── (3,2) ❌ (memo hit)
        └── (3,-1) ❌
Memoization prevents redundant evaluations like (3,2) and (4,2), improving efficiency.
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