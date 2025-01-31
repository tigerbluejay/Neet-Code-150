public partial class Solution {
    public List<List<int>> PermuteRecursion(int[] nums) {
        if (nums.Length == 0) {
            return new List<List<int>> { new List<int>() };
        }
        
        // In essence, nums[1..] creates a new array that contains 
        // all the elements of the original nums array starting 
        // from the second element to the last.
        var perms = PermuteRecursion(nums[1..]);
        var res = new List<List<int>>();
        foreach (var p in perms) {
            for (int i = 0; i <= p.Count; i++) {
                var p_copy = new List<int>(p);
                // The method inserts nums[0] at the specified index i 
                // in the list p_copy.
                // It shifts all existing elements at and after index i 
                // one position to the right to accommodate the new 
                // element. (see second tree schema)
                p_copy.Insert(i, nums[0]); // nums[0] in the final step is 1
                // The updated p_copy is then added to the result list res.
                res.Add(p_copy);
            }
        }
        return res;
    }
}

/*
Permute([1, 2, 3])
├── Permute([2, 3])
│   ├── Permute([3])
│   │   └── Permute([]) → [[]]
│   │       → Insert 3 into [[]] → [[3]]
│   └── Insert 2 into [[3]] → [[2, 3], [3, 2]]
└── Insert 1 into [[2, 3], [3, 2]]
    → [[1, 2, 3], [2, 1, 3], [2, 3, 1], [1, 3, 2], [3, 1, 2], [3, 2, 1]]

(last branch of the tree above - the one before it works in a similar fashion)
Start: [2, 3], [3, 2]
├── Perm 1: [2, 3]
│   ├── Insert 1 @ 0 → [1, 2, 3]
│   ├── Insert 1 @ 1 → [2, 1, 3]
│   └── Insert 1 @ 2 → [2, 3, 1]
└── Perm 2: [3, 2]
    ├── Insert 1 @ 0 → [1, 3, 2]
    ├── Insert 1 @ 1 → [3, 1, 2]
    └── Insert 1 @ 2 → [3, 2, 1]

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