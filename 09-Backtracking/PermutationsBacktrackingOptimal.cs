public partial class Solution {
    private List<List<int>> PBOres;

    public List<List<int>> PermuteBTOptimal(int[] nums) {
        PBOres = new List<List<int>>();
        PBOBacktrack(nums, 0);
        return PBOres;
    }

    private void PBOBacktrack(int[] nums, int idx) {
        if (idx == nums.Length) {
            PBOres.Add(new List<int>(nums));
            return;
        }
        for (int i = idx; i < nums.Length; i++) {
            PBOSwap(nums, idx, i);
            PBOBacktrack(nums, idx + 1);
            PBOSwap(nums, idx, i);
        }
    }

    private void PBOSwap(int[] nums, int i, int j) {
        int temp = nums[i];
        nums[i] = nums[j];
        nums[j] = temp;
    }
}

/*
Start: nums = [1, 2, 3]

Level 0 (idx = 0)
    [1, 2, 3]  (Initial State)

    ├── Swap(0, 0) → nums = [1, 2, 3]
    │       └── Backtrack(idx = 1)
    │           ├── Swap(1, 1) → nums = [1, 2, 3]
    │           │       └── Backtrack(idx = 2)
    │           │           ├── Swap(2, 2) → nums = [1, 2, 3]
    │           │           │       └── Backtrack(idx = 3) → Add [1, 2, 3] to res

    │           │           └── Undo Swap(2, 2) → nums = [1, 2, 3]
    │           └── Undo Swap(1, 1) → nums = [1, 2, 3]
    │           ├── Swap(1, 2) → nums = [1, 3, 2]
    │           │       └── Backtrack(idx = 2)
    │           │           ├── Swap(2, 2) → nums = [1, 3, 2]
    │           │           │       └── Backtrack(idx = 3) → Add [1, 3, 2] to res
    
    │           │           └── Undo Swap(2, 2) → nums = [1, 3, 2]
    │           └── Undo Swap(1, 2) → nums = [1, 2, 3]
    └── Undo Swap(0, 0) → nums = [1, 2, 3]


    ├── Swap(0, 1) → nums = [2, 1, 3]
    │       └── Backtrack(idx = 1)
    │           ├── Swap(1, 1) → nums = [2, 1, 3]
    │           │       └── Backtrack(idx = 2)
    │           │           ├── Swap(2, 2) → nums = [2, 1, 3]
    │           │           │       └── Backtrack(idx = 3) → Add [2, 1, 3] to res
    │           │           └── Undo Swap(2, 2) → nums = [2, 1, 3]
    │           └── Undo Swap(1, 1) → nums = [2, 1, 3]
    │           ├── Swap(1, 2) → nums = [2, 3, 1]
    │           │       └── Backtrack(idx = 2)
    │           │           ├── Swap(2, 2) → nums = [2, 3, 1]
    │           │           │       └── Backtrack(idx = 3) → Add [2, 3, 1] to res
    │           │           └── Undo Swap(2, 2) → nums = [2, 3, 1]
    │           └── Undo Swap(1, 2) → nums = [2, 1, 3]
    └── Undo Swap(0, 1) → nums = [1, 2, 3]


    ├── Swap(0, 2) → nums = [3, 2, 1]
    │       └── Backtrack(idx = 1)
    │           ├── Swap(1, 1) → nums = [3, 2, 1]
    │           │       └── Backtrack(idx = 2)
    │           │           ├── Swap(2, 2) → nums = [3, 2, 1]
    │           │           │       └── Backtrack(idx = 3) → Add [3, 2, 1] to res
    │           │           └── Undo Swap(2, 2) → nums = [3, 2, 1]
    │           └── Undo Swap(1, 1) → nums = [3, 2, 1]
    │           ├── Swap(1, 2) → nums = [3, 1, 2]
    │           │       └── Backtrack(idx = 2)
    │           │           ├── Swap(2, 2) → nums = [3, 1, 2]
    │           │           │       └── Backtrack(idx = 3) → Add [3, 1, 2] to res
    │           │           └── Undo Swap(2, 2) → nums = [3, 1, 2]
    │           └── Undo Swap(1, 2) → nums = [3, 2, 1]
    └── Undo Swap(0, 2) → nums = [1, 2, 3]
    
*/

/*

First Swap (before recursion):
Swap(nums, idx, i) is called to modify the array so that the element 
at position i is swapped into position idx. This prepares the array 
for the recursive call that follows.

Recursive Call:
The recursive call Backtrack(nums, idx + 1) explores all permutations 
for the remaining elements in the array, assuming the current swap is 
fixed.

Second Swap (undo):
After the recursive call finishes, the second Swap(nums, idx, i) is 
executed. This restores the array to its previous state (before the 
first swap), ensuring the next iteration of the loop starts with the 
array in the correct order.
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