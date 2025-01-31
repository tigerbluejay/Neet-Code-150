public partial class Solution {
    List<List<int>> PBBMres = new List<List<int>>();

    public List<List<int>> PermuteBitMask(int[] nums) {
        PBBMBacktrack(new List<int>(), nums, 0);
        return PBBMres;
    }

    private void PBBMBacktrack(List<int> perm, int[] nums, int mask) {
        if (perm.Count == nums.Length) {
            PBBMres.Add(new List<int>(perm));
            return;
        }
        for (int i = 0; i < nums.Length; i++) {
            if ((mask & (1 << i)) == 0) {
                perm.Add(nums[i]);
                PBBMBacktrack(perm, nums, mask | (1 << i));
                perm.RemoveAt(perm.Count - 1);
            }
        }
    }
}
/*
Start: perm = [], mask = 000
├── for (i = 0): Add nums[0] = 1 → perm = [1], mask = 001 (Set bit 0)
│   ├── for (i = 0): Skip nums[0] (mask & (1 << 0) != 0)
│   ├── for (i = 1): Add nums[1] = 2 → perm = [1, 2], mask = 011 (Set bit 1)
│   │   ├── for (i = 0): Skip nums[0] (mask & (1 << 0) != 0)
│   │   ├── for (i = 1): Skip nums[1] (mask & (1 << 1) != 0)
│   │   ├── for (i = 2): Add nums[2] = 3 → perm = [1, 2, 3], mask = 111 (Set bit 2)
│   │   │   └── BASE CASE: Add [1, 2, 3] to res
│   │   └── Backtrack: Remove nums[2] = 3 → perm = [1, 2], mask = 011
│   └── Backtrack: Remove nums[1] = 2 → perm = [1], mask = 001
│   ├── for (i = 2): Add nums[2] = 3 → perm = [1, 3], mask = 101 (Set bit 2)
│   │   ├── for (i = 0): Skip nums[0] (mask & (1 << 0) != 0)
│   │   ├── for (i = 1): Add nums[1] = 2 → perm = [1, 3, 2], mask = 111 (Set bit 1)
│   │   │   └── BASE CASE: Add [1, 3, 2] to res
│   │   └── Backtrack: Remove nums[1] = 2 → perm = [1, 3], mask = 101
│   ├── Backtrack: Remove nums[2] = 3 → perm = [1], mask = 001
└── Backtrack: Remove nums[0] = 1 → perm = [], mask = 000

├── for (i = 1): Add nums[1] = 2 → perm = [2], mask = 010 (Set bit 1)
│   ├── for (i = 0): Add nums[0] = 1 → perm = [2, 1], mask = 011 (Set bit 0)
│   │   ├── for (i = 0): Skip nums[0] (mask & (1 << 0) != 0)
│   │   ├── for (i = 1): Skip nums[1] (mask & (1 << 1) != 0)
│   │   ├── for (i = 2): Add nums[2] = 3 → perm = [2, 1, 3], mask = 111 (Set bit 2)
│   │   │   └── BASE CASE: Add [2, 1, 3] to res
│   │   └── Backtrack: Remove nums[2] = 3 → perm = [2, 1], mask = 011
│   ├── Backtrack: Remove nums[0] = 1 → perm = [2], mask = 010
│   ├── for (i = 2): Add nums[2] = 3 → perm = [2, 3], mask = 110 (Set bit 2)
│   │   ├── for (i = 0): Add nums[0] = 1 → perm = [2, 3, 1], mask = 111 (Set bit 0)
│   │   │   └── BASE CASE: Add [2, 3, 1] to res
│   │   └── Backtrack: Remove nums[0] = 1 → perm = [2, 3], mask = 110
│   ├── Backtrack: Remove nums[2] = 3 → perm = [2], mask = 010
└── Backtrack: Remove nums[1] = 2 → perm = [], mask = 000

├── for (i = 2): Add nums[2] = 3 → perm = [3], mask = 100 (Set bit 2)
│   ├── for (i = 0): Add nums[0] = 1 → perm = [3, 1], mask = 101 (Set bit 0)
│   │   ├── for (i = 0): Skip nums[0] (mask & (1 << 0) != 0)
│   │   ├── for (i = 1): Add nums[1] = 2 → perm = [3, 1, 2], mask = 111 (Set bit 1)
│   │   │   └── BASE CASE: Add [3, 1, 2] to res
│   │   └── Backtrack: Remove nums[1] = 2 → perm = [3, 1], mask = 101
│   ├── Backtrack: Remove nums[0] = 1 → perm = [3], mask = 100
│   ├── for (i = 1): Add nums[1] = 2 → perm = [3, 2], mask = 110 (Set bit 1)
│   │   ├── for (i = 0): Add nums[0] = 1 → perm = [3, 2, 1], mask = 111 (Set bit 0)
│   │   │   └── BASE CASE: Add [3, 2, 1] to res
│   │   └── Backtrack: Remove nums[0] = 1 → perm = [3, 2], mask = 110
│   ├── Backtrack: Remove nums[1] = 2 → perm = [3], mask = 100
└── Backtrack: Remove nums[2] = 3 → perm = [], mask = 000
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