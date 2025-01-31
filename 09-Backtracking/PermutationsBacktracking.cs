public partial class Solution {
    List<List<int>> PermuRes;
    public List<List<int>> PermuteBT(int[] nums) {
        PermuRes = new List<List<int>>();
        PermBBacktrack(new List<int>(), nums, new bool[nums.Length]);
        return PermuRes;
    }

    private void PermBBacktrack(List<int> perm, int[] nums, bool[] pick) {
        if (perm.Count == nums.Length) {
            PermuRes.Add(new List<int>(perm));
            return;
        }
        for (int i = 0; i < nums.Length; i++) {
            if (!pick[i]) {
                perm.Add(nums[i]);
                pick[i] = true;
                PermBBacktrack(perm, nums, pick);
                perm.RemoveAt(perm.Count - 1);
                pick[i] = false;
            }
        }
    }
}

/*

Start: perm = [] (empty)
├── Add 1 → perm = [1]
│   ├── Add 2 → perm = [1, 2]
│   │   ├── Add 3 → perm = [1, 2, 3] (BASE CASE: Add to res)
│   │   └── Backtrack → perm = [1, 2]
│   ├── Add 3 → perm = [1, 3]
│   │   ├── Add 2 → perm = [1, 3, 2] (BASE CASE: Add to res)
│   │   └── Backtrack → perm = [1, 3]
│   └── Backtrack → perm = [1]
├── Add 2 → perm = [2]
│   ├── Add 1 → perm = [2, 1]
│   │   ├── Add 3 → perm = [2, 1, 3] (BASE CASE: Add to res)
│   │   └── Backtrack → perm = [2, 1]
│   ├── Add 3 → perm = [2, 3]
│   │   ├── Add 1 → perm = [2, 3, 1] (BASE CASE: Add to res)
│   │   └── Backtrack → perm = [2, 3]
│   └── Backtrack → perm = [2]
├── Add 3 → perm = [3]
│   ├── Add 1 → perm = [3, 1]
│   │   ├── Add 2 → perm = [3, 1, 2] (BASE CASE: Add to res)
│   │   └── Backtrack → perm = [3, 1]
│   ├── Add 2 → perm = [3, 2]
│   │   ├── Add 1 → perm = [3, 2, 1] (BASE CASE: Add to res)
│   │   └── Backtrack → perm = [3, 2]
│   └── Backtrack → perm = [3]
└── Backtrack → perm = []

-- in more detail, incorporating for loop

Start: perm = [] (empty)
├── for (i = 0): Add nums[0] = 1 → perm = [1]
│   ├── for (i = 0): skip nums[0] (already picked)
│   ├── for (i = 1): Add nums[1] = 2 → perm = [1, 2]
│   │   ├── for (i = 0): skip nums[0] (already picked)
│   │   ├── for (i = 1): skip nums[1] (already picked)
│   │   ├── for (i = 2): Add nums[2] = 3 → perm = [1, 2, 3] (BASE CASE: Add to res)
│   │   └── Backtrack: Remove nums[2] = 3 → perm = [1, 2]
│   └── Backtrack: Remove nums[1] = 2 → perm = [1]
│   ├── for (i = 2): Add nums[2] = 3 → perm = [1, 3]
│   │   ├── for (i = 0): skip nums[0] (already picked)
│   │   ├── for (i = 1): Add nums[1] = 2 → perm = [1, 3, 2] (BASE CASE: Add to res)
│   │   ├── for (i = 2): skip nums[2] (already picked)
│   │   └── Backtrack: Remove nums[1] = 2 → perm = [1, 3]
│   └── Backtrack: Remove nums[2] = 3 → perm = [1]
└── Backtrack: Remove nums[0] = 1 → perm = []

├── for (i = 1): Add nums[1] = 2 → perm = [2]
│   ├── for (i = 0): Add nums[0] = 1 → perm = [2, 1]
│   │   ├── for (i = 0): skip nums[0] (already picked)
│   │   ├── for (i = 1): skip nums[1] (already picked)
│   │   ├── for (i = 2): Add nums[2] = 3 → perm = [2, 1, 3] (BASE CASE: Add to res)
│   │   └── Backtrack: Remove nums[2] = 3 → perm = [2, 1]
│   ├── for (i = 1): skip nums[1] (already picked)
│   ├── for (i = 2): Add nums[2] = 3 → perm = [2, 3]
│   │   ├── for (i = 0): Add nums[0] = 1 → perm = [2, 3, 1] (BASE CASE: Add to res)
│   │   ├── for (i = 1): skip nums[1] (already picked)
│   │   ├── for (i = 2): skip nums[2] (already picked)
│   │   └── Backtrack: Remove nums[0] = 1 → perm = [2, 3]
│   └── Backtrack: Remove nums[2] = 3 → perm = [2]
└── Backtrack: Remove nums[1] = 2 → perm = []

├── for (i = 2): Add nums[2] = 3 → perm = [3]
│   ├── for (i = 0): Add nums[0] = 1 → perm = [3, 1]
│   │   ├── for (i = 0): skip nums[0] (already picked)
│   │   ├── for (i = 1): Add nums[1] = 2 → perm = [3, 1, 2] (BASE CASE: Add to res)
│   │   ├── for (i = 2): skip nums[2] (already picked)
│   │   └── Backtrack: Remove nums[1] = 2 → perm = [3, 1]
│   ├── for (i = 1): Add nums[1] = 2 → perm = [3, 2]
│   │   ├── for (i = 0): Add nums[0] = 1 → perm = [3, 2, 1] (BASE CASE: Add to res)
│   │   ├── for (i = 1): skip nums[1] (already picked)
│   │   ├── for (i = 2): skip nums[2] (already picked)
│   │   └── Backtrack: Remove nums[0] = 1 → perm = [3, 2]
│   └── Backtrack: Remove nums[1] = 2 → perm = [3]
└── Backtrack: Remove nums[2] = 3 → perm = []

*/

/*
Permutations

Given an array nums of unique integers, return all the possible 
permutations. You may return the answer in any order.

Example 1:
Input: nums = [1,2,3]
Output: [[1,2,3],[1,3,2],[2,1,3],[2,3,1],[3,1,2],[3,2,1]]

Example 2:
Input: nums = [7]
Output: [[7]]

Constraints:
1 <= nums.length <= 6
-10 <= nums[i] <= 10

*/